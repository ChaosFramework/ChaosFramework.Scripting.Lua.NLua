using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace NLua.Extensions
{
    static class TypeExtensions
    {
        public static bool HasMethod(this Type t, string name)
            => t.GetMethods(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static).Length > 0;

        public static bool HasBitwiseAndOperator(this Type t)
        {
            if (t.IsPrimitive || t.IsEnum)
                return true;

            return t.HasMethod("op_BitwiseAnd");
        }

        public static bool HasBitwiseOrOperator(this Type t)
        {
            if (t.IsPrimitive || t.IsEnum)
                return true;

            return t.HasMethod("op_BitwiseOr");
        }

        public static bool HasBitwiseXOrOperator(this Type t)
        {
            if (t.IsPrimitive || t.IsEnum)
                return true;

            return t.HasMethod("op_ExclusiveOr");
        }

        public static bool HasAdditionOperator(this Type t)
        {
            if (t.IsPrimitive || t.IsEnum)
                return true;

            return t.HasMethod("op_Addition");
        }

        public static bool HasSubtractionOperator(this Type t)
        {
            if (t.IsPrimitive || t.IsEnum)
                return true;

            return t.HasMethod("op_Subtraction");
        }

        public static bool HasMultiplyOperator(this Type t)
        {
            if (t.IsPrimitive)
                return true;

            return t.HasMethod("op_Multiply");
        }

        public static bool HasDivisionOperator(this Type t)
        {
            if (t.IsPrimitive)
                return true;

            return t.HasMethod("op_Division");
        }

        public static bool HasModulusOperator(this Type t)
        {
            if (t.IsPrimitive)
                return true;

            return t.HasMethod("op_Modulus");
        }

        public static bool HasUnaryNegationOperator(this Type t)
        {
            if (t.IsPrimitive || t.IsEnum)
                return true;
            // Unary - will always have only one version.
            var op = t.GetMethod("op_UnaryNegation", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            return op != null;
        }

        public static bool HasEqualityOperator(this Type t)
        {
            if (t.IsPrimitive || t.IsEnum)
                return true;
            return t.HasMethod("op_Equality");
        }

        public static bool HasLessThanOperator(this Type t)
        {
            if (t.IsPrimitive || t.IsEnum)
                return true;

            return t.HasMethod("op_LessThan");
        }

        public static bool HasLessThanOrEqualOperator(this Type t)
        {
            if (t.IsPrimitive || t.IsEnum)
                return true;
            return t.HasMethod("op_LessThanOrEqual");
        }

        public static MethodInfo[] GetMethods(this Type t, string name, BindingFlags flags)
        {
            var methods = t.GetMethods(flags).Where(m => m.Name == name);
            if (t.IsEnum)
                methods = methods.Concat(GetEnumOperators(t, name));
            return methods.ToArray();
        }

        public static MethodInfo[] GetExtensionMethods(this Type type, string name, IEnumerable<Assembly> assemblies = null)
        {
            var types = new List<Type>();

            types.AddRange(type.Assembly.GetTypes().Where(t => t.IsPublic));

            if (assemblies != null)
            {
                foreach (Assembly item in assemblies)
                {
                    if (item == type.Assembly)
                        continue;
                    types.AddRange(item.GetTypes().Where(t => t.IsPublic && t.IsClass && t.IsSealed && t.IsAbstract && !t.IsNested));
                }
            }

            var query = types
                .SelectMany(extensionType => extensionType.GetMethods(name, BindingFlags.Static | BindingFlags.Public),
                    (extensionType, method) => new {extensionType, method})
                .Where(t => t.method.IsDefined(typeof(ExtensionAttribute), false))
                .Where(t =>
                    t.method.GetParameters()[0].ParameterType == type ||
                     t.method.GetParameters()[0].ParameterType.IsAssignableFrom(type) ||
                     type.GetInterfaces().Contains(t.method.GetParameters()[0].ParameterType))
                .Select(t => t.method);

            return query.ToArray();
        }

        /// <summary>
        /// Extends the System.Type-type to search for a given extended MethodeName.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="name"></param>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        public static MethodInfo GetExtensionMethod(this Type t, string name, IEnumerable<Assembly> assemblies = null)
        {
            var mi = t.GetExtensionMethods(name, assemblies).ToArray();
            if (mi.Length == 0)
                return null;
            return mi[0];
        }

        static readonly Dictionary<Type, Dictionary<string, MethodInfo>> operators
            = new Dictionary<Type, Dictionary<string, MethodInfo>>();

        static MethodInfo GetOperator(Type t, string op)
            => typeof(EnumOperators).GetMethod(op, BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(t);

        static MethodInfo[] GetEnumOperators(this Type t, string operation)
        {
            Dictionary<string, MethodInfo> ops;
            if (!operators.TryGetValue(t, out ops))
            {
                operators[t] = ops = new Dictionary<string, MethodInfo>();
                ops["op_Addition"] = GetOperator(t, nameof(EnumOperators.Add));
                ops["op_Subtraction"] = GetOperator(t, nameof(EnumOperators.Subtract));
                ops["op_UnaryNegation"] = GetOperator(t, nameof(EnumOperators.Negate));
                ops["op_Equality"] = GetOperator(t, nameof(EnumOperators.Equal));
                ops["op_LessThan"] = GetOperator(t, nameof(EnumOperators.LessThan));
                ops["op_LessThanOrEqual"] = GetOperator(t, nameof(EnumOperators.LessEqual));
                ops["op_BitwiseAnd"] = GetOperator(t, nameof(EnumOperators.BitAnd));
                ops["op_BitwiseOr"] = GetOperator(t, nameof(EnumOperators.BitOr));
                ops["op_ExclusiveOr"] = GetOperator(t, nameof(EnumOperators.BitXOr));
            }

            MethodInfo op;
            if (ops.TryGetValue(operation, out op))
                return new[] { op };
            else
                return new MethodInfo[0];
        }
    }
}

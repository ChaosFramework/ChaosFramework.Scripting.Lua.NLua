using System.Linq;
using System.Reflection;

namespace NLua
{
    public static class MemberValidation
    {
        public static bool MemberValid(Lua lua, MemberInfo member)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    return FieldValid(lua, member as FieldInfo);

                case MemberTypes.Property:
                    return PropertyValid(lua, member as PropertyInfo);

                case MemberTypes.Method:
                    return MethodValid(lua, member as MethodInfo);

                case MemberTypes.Constructor:
                    return ConstructorValid(lua, member as ConstructorInfo);

                default:
                    return false;
            }
        }

        public static bool FieldValid(Lua lua, FieldInfo field)
            => field != null
            && field.IsPublic
            && !field.IsSpecialName
            && lua.validateReturnType(field.FieldType)
            && lua.validateMember(field)
            ;

        public static bool PropertyValid(Lua lua, PropertyInfo property)
            => property != null
            && property.GetAccessors().Any(IsPublic)
            && !property.IsSpecialName
            && lua.validateReturnType(property.PropertyType)
            && property.GetIndexParameters().Length <= 1
            && lua.validateMember(property)
            ;

        public static bool MethodBaseValid(Lua lua, MethodBase method)
            => method != null
            && method.IsPublic
            && method.GetParameters().All(arg => ParameterValid(lua, arg))
            && lua.validateMember(method)
            ;

        public static bool MethodValid(Lua lua, MethodInfo method)
            => MethodBaseValid(lua, method)
            && !method.IsSpecialName
            && lua.validateReturnType(method.ReturnType)
            ;

        public static bool ConstructorValid(Lua lua, ConstructorInfo ctor)
            => MethodBaseValid(lua, ctor)
            && !ctor.IsStatic
            && lua.validateReturnType(ctor.DeclaringType)
            ;

        public static bool ParameterValid(Lua lua, ParameterInfo arg)
            => arg != null
            && (!arg.IsOut || lua.validateReturnType(arg.ParameterType))
            ;

        static bool IsPublic(MethodInfo m)
            => m.IsPublic;
    }
}

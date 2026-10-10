using System;
using System.Reflection;

namespace NLua
{
    class EnumOperators
    {
        public static T BitAnd<T>(T a, T b)
            where T : struct
        {
            switch (typeof(T).GetEnumUnderlyingType().Name)
            {
                case nameof(SByte): return FromUnderlying<T, sbyte>(ToUnderlying<T, sbyte>(a) & ToUnderlying<T, sbyte>(b));
                case nameof(Int16): return FromUnderlying<T, short>(ToUnderlying<T, short>(a) & ToUnderlying<T, short>(b));
                case nameof(Int32): return FromUnderlying<T, int>(ToUnderlying<T, int>(a) & ToUnderlying<T, int>(b));
                case nameof(Int64): return FromUnderlying<T, long>(ToUnderlying<T, long>(a) & ToUnderlying<T, long>(b));
                case nameof(Byte): return FromUnderlying<T, byte>(ToUnderlying<T, byte>(a) & ToUnderlying<T, byte>(b));
                case nameof(UInt16): return FromUnderlying<T, ushort>(ToUnderlying<T, ushort>(a) & ToUnderlying<T, ushort>(b));
                case nameof(UInt32): return FromUnderlying<T, uint>(ToUnderlying<T, uint>(a) & ToUnderlying<T, uint>(b));
                case nameof(UInt64): return FromUnderlying<T, ulong>(ToUnderlying<T, ulong>(a) & ToUnderlying<T, ulong>(b));
                default: throw UnsupportedEnumType<T>();
            }
        }

        public static T BitOr<T>(T a, T b)
            where T : struct
        {
            switch (typeof(T).GetEnumUnderlyingType().Name)
            {
                case nameof(SByte): return FromUnderlying<T, sbyte>(ToUnderlying<T, sbyte>(a) | ToUnderlying<T, sbyte>(b));
                case nameof(Int16): return FromUnderlying<T, short>(ToUnderlying<T, short>(a) | ToUnderlying<T, short>(b));
                case nameof(Int32): return FromUnderlying<T, int>(ToUnderlying<T, int>(a) | ToUnderlying<T, int>(b));
                case nameof(Int64): return FromUnderlying<T, long>(ToUnderlying<T, long>(a) | ToUnderlying<T, long>(b));
                case nameof(Byte): return FromUnderlying<T, byte>(ToUnderlying<T, byte>(a) | ToUnderlying<T, byte>(b));
                case nameof(UInt16): return FromUnderlying<T, ushort>(ToUnderlying<T, ushort>(a) | ToUnderlying<T, ushort>(b));
                case nameof(UInt32): return FromUnderlying<T, uint>(ToUnderlying<T, uint>(a) | ToUnderlying<T, uint>(b));
                case nameof(UInt64): return FromUnderlying<T, ulong>(ToUnderlying<T, ulong>(a) | ToUnderlying<T, ulong>(b));
                default: throw UnsupportedEnumType<T>();
            }
        }

        public static T BitXOr<T>(T a, T b)
            where T : struct
        {
            switch (typeof(T).GetEnumUnderlyingType().Name)
            {
                case nameof(SByte): return FromUnderlying<T, sbyte>(ToUnderlying<T, sbyte>(a) ^ ToUnderlying<T, sbyte>(b));
                case nameof(Int16): return FromUnderlying<T, short>(ToUnderlying<T, short>(a) ^ ToUnderlying<T, short>(b));
                case nameof(Int32): return FromUnderlying<T, int>(ToUnderlying<T, int>(a) ^ ToUnderlying<T, int>(b));
                case nameof(Int64): return FromUnderlying<T, long>(ToUnderlying<T, long>(a) ^ ToUnderlying<T, long>(b));
                case nameof(Byte): return FromUnderlying<T, byte>(ToUnderlying<T, byte>(a) ^ ToUnderlying<T, byte>(b));
                case nameof(UInt16): return FromUnderlying<T, ushort>(ToUnderlying<T, ushort>(a) ^ ToUnderlying<T, ushort>(b));
                case nameof(UInt32): return FromUnderlying<T, uint>(ToUnderlying<T, uint>(a) ^ ToUnderlying<T, uint>(b));
                case nameof(UInt64): return FromUnderlying<T, ulong>(ToUnderlying<T, ulong>(a) ^ ToUnderlying<T, ulong>(b));
                default: throw UnsupportedEnumType<T>();
            }
        }

        public static T Add<T>(T a, T b)
            where T : struct
        {
            switch (typeof(T).GetEnumUnderlyingType().Name)
            {
                case nameof(SByte): return FromUnderlying<T, sbyte>(ToUnderlying<T, sbyte>(a) + ToUnderlying<T, sbyte>(b));
                case nameof(Int16): return FromUnderlying<T, short>(ToUnderlying<T, short>(a) + ToUnderlying<T, short>(b));
                case nameof(Int32): return FromUnderlying<T, int>(ToUnderlying<T, int>(a) + ToUnderlying<T, int>(b));
                case nameof(Int64): return FromUnderlying<T, long>(ToUnderlying<T, long>(a) + ToUnderlying<T, long>(b));
                case nameof(Byte): return FromUnderlying<T, byte>(ToUnderlying<T, byte>(a) + ToUnderlying<T, byte>(b));
                case nameof(UInt16): return FromUnderlying<T, ushort>(ToUnderlying<T, ushort>(a) + ToUnderlying<T, ushort>(b));
                case nameof(UInt32): return FromUnderlying<T, uint>(ToUnderlying<T, uint>(a) + ToUnderlying<T, uint>(b));
                case nameof(UInt64): return FromUnderlying<T, ulong>(ToUnderlying<T, ulong>(a) + ToUnderlying<T, ulong>(b));
                default: throw UnsupportedEnumType<T>();
            }
        }

        public static T Subtract<T>(T a, T b)
            where T : struct
        {
            switch (typeof(T).GetEnumUnderlyingType().Name)
            {
                case nameof(SByte): return FromUnderlying<T, sbyte>(ToUnderlying<T, sbyte>(a) - ToUnderlying<T, sbyte>(b));
                case nameof(Int16): return FromUnderlying<T, short>(ToUnderlying<T, short>(a) - ToUnderlying<T, short>(b));
                case nameof(Int32): return FromUnderlying<T, int>(ToUnderlying<T, int>(a) - ToUnderlying<T, int>(b));
                case nameof(Int64): return FromUnderlying<T, long>(ToUnderlying<T, long>(a) - ToUnderlying<T, long>(b));
                case nameof(Byte): return FromUnderlying<T, byte>(ToUnderlying<T, byte>(a) - ToUnderlying<T, byte>(b));
                case nameof(UInt16): return FromUnderlying<T, ushort>(ToUnderlying<T, ushort>(a) - ToUnderlying<T, ushort>(b));
                case nameof(UInt32): return FromUnderlying<T, uint>(ToUnderlying<T, uint>(a) - ToUnderlying<T, uint>(b));
                case nameof(UInt64): return FromUnderlying<T, ulong>(ToUnderlying<T, ulong>(a) - ToUnderlying<T, ulong>(b));
                default: throw UnsupportedEnumType<T>();
            }
        }

        public static T Negate<T>(T v)
            where T : struct
        {
            switch (typeof(T).GetEnumUnderlyingType().Name)
            {
                case nameof(SByte): return FromUnderlying<T, sbyte>(-ToUnderlying<T, sbyte>(v));
                case nameof(Int16): return FromUnderlying<T, short>(-ToUnderlying<T, short>(v));
                case nameof(Int32): return FromUnderlying<T, int>(-ToUnderlying<T, int>(v));
                case nameof(Int64): return FromUnderlying<T, long>(-ToUnderlying<T, long>(v));

                case nameof(Byte):
                case nameof(UInt16):
                case nameof(UInt32):
                case nameof(UInt64):
                    throw new InvalidOperationException("Cannot negate unsigned enum values");

                default: throw UnsupportedEnumType<T>();
            }
        }

        public static bool Equal<T>(T a, T b)
            where T : struct
        {
            switch (typeof(T).GetEnumUnderlyingType().Name)
            {
                case nameof(SByte): return ToUnderlying<T, sbyte>(a) == ToUnderlying<T, sbyte>(b);
                case nameof(Int16): return ToUnderlying<T, short>(a) == ToUnderlying<T, short>(b);
                case nameof(Int32): return ToUnderlying<T, int>(a) == ToUnderlying<T, int>(b);
                case nameof(Int64): return ToUnderlying<T, long>(a) == ToUnderlying<T, long>(b);
                case nameof(Byte): return ToUnderlying<T, byte>(a) == ToUnderlying<T, byte>(b);
                case nameof(UInt16): return ToUnderlying<T, ushort>(a) == ToUnderlying<T, ushort>(b);
                case nameof(UInt32): return ToUnderlying<T, uint>(a) == ToUnderlying<T, uint>(b);
                case nameof(UInt64): return ToUnderlying<T, ulong>(a) == ToUnderlying<T, ulong>(b);
                default: throw UnsupportedEnumType<T>();
            }
        }

        public static bool LessThan<T>(T a, T b)
            where T : struct
        {
            switch (typeof(T).GetEnumUnderlyingType().Name)
            {
                case nameof(SByte): return ToUnderlying<T, sbyte>(a) < ToUnderlying<T, sbyte>(b);
                case nameof(Int16): return ToUnderlying<T, short>(a) < ToUnderlying<T, short>(b);
                case nameof(Int32): return ToUnderlying<T, int>(a) < ToUnderlying<T, int>(b);
                case nameof(Int64): return ToUnderlying<T, long>(a) < ToUnderlying<T, long>(b);
                case nameof(Byte): return ToUnderlying<T, byte>(a) < ToUnderlying<T, byte>(b);
                case nameof(UInt16): return ToUnderlying<T, ushort>(a) < ToUnderlying<T, ushort>(b);
                case nameof(UInt32): return ToUnderlying<T, uint>(a) < ToUnderlying<T, uint>(b);
                case nameof(UInt64): return ToUnderlying<T, ulong>(a) < ToUnderlying<T, ulong>(b);
                default: throw UnsupportedEnumType<T>();
            }
        }

        public static bool LessEqual<T>(T a, T b)
            where T : struct
        {
            switch (typeof(T).GetEnumUnderlyingType().Name)
            {
                case nameof(SByte): return ToUnderlying<T, sbyte>(a) <= ToUnderlying<T, sbyte>(b);
                case nameof(Int16): return ToUnderlying<T, short>(a) <= ToUnderlying<T, short>(b);
                case nameof(Int32): return ToUnderlying<T, int>(a) <= ToUnderlying<T, int>(b);
                case nameof(Int64): return ToUnderlying<T, long>(a) <= ToUnderlying<T, long>(b);
                case nameof(Byte): return ToUnderlying<T, byte>(a) <= ToUnderlying<T, byte>(b);
                case nameof(UInt16): return ToUnderlying<T, ushort>(a) <= ToUnderlying<T, ushort>(b);
                case nameof(UInt32): return ToUnderlying<T, uint>(a) <= ToUnderlying<T, uint>(b);
                case nameof(UInt64): return ToUnderlying<T, ulong>(a) <= ToUnderlying<T, ulong>(b);
                default: throw UnsupportedEnumType<T>();
            }
        }

        static T Cast<T>(object value)
        {
            MethodInfo info = value.GetType().GetMethod(
                "System.IConvertible.ToType",
                BindingFlags.NonPublic | BindingFlags.Instance
                );

            return (T)info.Invoke(value, new object[] { typeof(T), System.Globalization.CultureInfo.InvariantCulture });
        }

        static U ToUnderlying<T, U>(T value)
            where T : struct
            where U : struct
            => (U)(object)value;

        static T FromUnderlying<T, U>(object value)
            where T : struct
            where U : struct
            => (T)(object)Cast<U>(value);

        static NotSupportedException UnsupportedEnumType<T>()
            => new NotSupportedException($"Enums can not have the underlying type {typeof(T).FullName}.");
    }
}

using System;

namespace Utilities
{
    public static class EnumUtils<T>
    {
        public static T StringToEnum(string enumString)
        {
            return (T)Enum.Parse(typeof(T), enumString);
        }
    }
}

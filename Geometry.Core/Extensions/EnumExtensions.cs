using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Geometry.Core.Extensions
{
    public static class EnumExtensions
    {
        public static T GetAttributeOfType<T>(this Enum enumValue) where T : Attribute
        {
            var type = enumValue.GetType();
            var memberInfo = type.GetMember(enumValue.ToString()).First();
            var attributes = memberInfo.GetCustomAttributes<T>(false);
            return attributes.FirstOrDefault();
        }

        public static string GetDisplayName(this Enum enumValue)
        {
            var attribute = enumValue.GetAttributeOfType<DisplayAttribute>();
            return attribute == null ? enumValue.ToString() : attribute.Name;
        }
    }
}

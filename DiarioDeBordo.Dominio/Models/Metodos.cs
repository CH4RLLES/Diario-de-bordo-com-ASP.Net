using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace DiarioDeBordo.Dominio
{
    public static class Metodos
    {
        public static IDictionary<int, string> GetEnumToDropDown<TEnum>() where TEnum : struct
        {
            var enumerationType = typeof(TEnum);

            if (!enumerationType.IsEnum)
                throw new ArgumentException("Enumeration type is expected.");

            var dictionary = new Dictionary<int, string>();

            foreach (int value in Enum.GetValues(enumerationType))
            {
                var memInfo = enumerationType.GetMember(enumerationType.GetEnumName(value));
                var descriptionAttribute = memInfo[0]
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .FirstOrDefault() as DescriptionAttribute;

                var name = descriptionAttribute.Description;
                dictionary.Add(value, name.ToString());
            }
            return dictionary;
        }

        public static SelectList GetEnumToSelectList<TEnum>() where TEnum : struct
        {
            var enumerationType = typeof(TEnum);

            if (!enumerationType.IsEnum)
                throw new ArgumentException("Enumeration type is expected.");

            var dictionary = new Dictionary<int, string>();

            foreach (int value in Enum.GetValues(enumerationType))
            {
                var memInfo = enumerationType.GetMember(enumerationType.GetEnumName(value));
                var descriptionAttribute = memInfo[0]
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .FirstOrDefault() as DescriptionAttribute;

                var name = descriptionAttribute.Description;
                dictionary.Add(value, name.ToString());
            }

            var ret = new SelectList(dictionary.ToList(), "Key", "Value");
            return ret;
        }
    }

}

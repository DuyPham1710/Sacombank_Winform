using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SacombankWinform.helper
{
    internal static class FormHelper
    {
        public static FormUrlEncodedContent ToFormData<T>(T dto)
        {
            var dict = dto!.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToDictionary(
                    prop =>
                    {
                        // Lấy theo DisplayName
                        var display = prop.GetCustomAttribute<DisplayNameAttribute>();
                        return display != null ? display.DisplayName : prop.Name;
                    },
                    prop => prop.GetValue(dto)?.ToString() ?? ""
                );

            return new FormUrlEncodedContent(dict);
        }
    }
}

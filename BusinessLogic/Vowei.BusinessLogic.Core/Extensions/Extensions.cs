using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;
using CodeFirstIOCDemo.BusinessLogic.Core.Models;

namespace CodeFirstIOCDemo.BusinessLogic.Core.Extensions
{
    public static class CoreExtensions
    {
        public static string RemoveVariableIndicator(string variable)
        {
            if (string.IsNullOrEmpty(variable))
            {
                return variable;
            }
            else
            {
                // 去掉变量的中括号
                return variable[0] == '[' ? variable.Substring(1, variable.Length - 2) : variable;
            }
        }

        public static string ToJson(this object item)
        {
            return SerializeToJson(item, null);
        }

        public static T FromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        private static List<JsonConverter> _converters = null;
        public static string SerializeToJson(object item)
        {
            return SerializeToJson(item, null);
        }

        public static string SerializeToJson(object item, List<JsonConverter> converters)
        {
            if (converters == null)
            {
                if (_converters == null)
                {
                    _converters = new List<JsonConverter>();
                }

                converters = _converters;
            }

            var settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Converters = converters
            };

            return JsonConvert.SerializeObject(item, Formatting.None, settings);
        }
    }
}

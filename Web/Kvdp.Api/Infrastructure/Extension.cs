using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GMK.OperationSystem.WFProxy.Infrastructure
{
    public static class WebExtensions
    {
        private static JsonSerializerSettings defaultJsonSerializerSettings = new JsonSerializerSettings
        {
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            DateTimeZoneHandling = DateTimeZoneHandling.Local,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        };

        public static string ToJson(this object data, Formatting formatting = Formatting.Indented, JsonSerializerSettings settings = null)
        {
            return JsonConvert.SerializeObject(data, formatting, settings ?? defaultJsonSerializerSettings);
        }

        public static string ToJavaScriptJson(this object data, JsonSerializerSettings settings = null)
        {
            settings = settings ?? new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };
            return JsonConvert.SerializeObject(data, Formatting.None, settings);
        }

        public static Dictionary<string, object> EnumToDictionary(this Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new InvalidOperationException("应为枚举类型");
            }
            return Enum.GetValues(enumType).Cast<object>().ToDictionary(v => v.ToString(), v => v);
        }
    }
}
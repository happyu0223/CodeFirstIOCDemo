using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Linq.Expressions;
using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;

namespace CodeFirstIOCDemo.BusinessLogic.Frameworks.Web
{
    public class AspTranslator : ITranslator
    {
        public CultureInfo Culture
        {
            get;
            private set;
        }

        public AspTranslator(CultureInfo culture)
        {
            Culture = culture;
        }

        public string T(string message)
        {
            if (string.IsNullOrEmpty(message))
                return message;
            else
            {
                var obj = HttpContext.GetGlobalResourceObject("vowei", message, Culture);
                var translated = obj == null ? null : obj.ToString();
                if (string.IsNullOrEmpty(translated))
                    return message;
                else
                    return translated;
            }
        }

        public string T(DateTime value)
        {
            return value.ToString(Culture);
        }

        public string T(double value)
        {
            return value.ToString(Culture);
        }

        public string T<U, TProperty>(Expression<Func<U, TProperty>> expression)
        {
            return Translator.T<U, TProperty>(this, expression);
        }

        public static AspTranslator CreateFrom(HttpRequestBase request)
        {
            var locale = "zh-CN";
            if (request != null && request.UserLanguages != null && request.UserLanguages.Length != 0)
            {
                locale = request.UserLanguages.FirstOrDefault(l => l.IndexOf(';') == -1);
                if (string.IsNullOrEmpty(locale)
                    || "zh-Hans-CN".Equals(locale, StringComparison.CurrentCultureIgnoreCase))
                {
                    locale = "zh-CN";
                }
            }

            CultureInfo culture;
            try
            {
                culture = new CultureInfo(locale);
            }
            catch
            {
                try
                {
                    culture = CultureInfo.CreateSpecificCulture(locale);
                }
                catch
                {
                    culture = new CultureInfo("zh-CN");
                }
            }

            return new AspTranslator(culture);
        }

        internal AspTranslator As<T1>()
        {
            throw new NotImplementedException();
        }
    }
}

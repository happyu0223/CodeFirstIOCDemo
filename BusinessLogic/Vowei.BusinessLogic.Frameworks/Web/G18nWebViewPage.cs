using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;
using CodeFirstIOCDemo.BusinessLogic.Core.Models;

namespace CodeFirstIOCDemo.BusinessLogic.Frameworks.Web
{
    public abstract class G18nWebViewPage : WebViewPage
    {
        protected Employee CurrentEmployee()
        {
            throw new NotImplementedException();
            //if (HttpContext.Current.User.Identity.IsAuthenticated)
            //{
            //    var name = HttpContext.Current.User.Identity.Name;
            //    var users = AclHelper.GetUsers();
            //    return users.SingleOrDefault(e => e.Name == name);
            //}
            //else
            //{
            //    return null;
            //}
        }

        private ITranslator _translator;
        protected ITranslator Translator
        {
            get
            {
                if (_translator == null)
                    _translator = AspTranslator.CreateFrom(Request);

                return _translator;
            }
        }

        public string T(string message)
        {
            return Translator.T(message);
        }

        public string T(DateTime value)
        {
            return Translator.T(value);
        }

        public string T(double value)
        {
            return Translator.T(value);
        }

        protected string GetCulture()
        {
            return Translator.Culture.Name;
        }
    }
    
    public abstract class G18nWebViewPage<U> : WebViewPage<U>
    {
        protected Employee CurrentEmployee()
        {
            throw new NotImplementedException();
            //if (HttpContext.Current.User.Identity.IsAuthenticated)
            //{
            //    var name = HttpContext.Current.User.Identity.Name;
            //    var users = AclHelper.GetUsers();
            //    return users.SingleOrDefault(e => e.Name == name);
            //}
            //else
            //{
            //    return null;
            //}
        }


        private ITranslator _translator;
        // 设置为protected只是为了在单元测试里面用。
        protected ITranslator Translator
        {
            get
            {
                if (_translator == null)
                    _translator = AspTranslator.CreateFrom(Request);

                return _translator;
            }
            set
            {
                _translator = value;
            }
        }

        public string T(string message)
        {
            return Translator.T(message);
        }

        public string T(DateTime value)
        {
            return Translator.T(value);
        }

        public string T(double value)
        {
            return Translator.T(value);
        }

        public string T(DateTime? value)
        {
            if (value.HasValue)
                return T(value.Value);
            else
                return null;
        }

        public string T(double? value)
        {
            if (value.HasValue)
                return T(value.Value);
            else
                return null;
        }

        public string T<TProperty>(Expression<Func<U, TProperty>> expression)
        {
            return Translator.T<U, TProperty>(expression);
        }

        protected string GetCulture()
        {
            return Translator.Culture.Name;
        }
    }
}

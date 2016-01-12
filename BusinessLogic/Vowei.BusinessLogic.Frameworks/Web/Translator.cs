using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;

namespace CodeFirstIOCDemo.BusinessLogic.Frameworks.Web
{
    public class Translator : ITranslator
    {
        public CultureInfo Culture { get; private set; }

        public Translator(CultureInfo culture)
        {
            Culture = culture;
        }

        public string T(string message)
        {
            // TODO: 实现本地化支持！
            return message;
        }

        public string T(DateTime value)
        {
            return value.ToString(Culture);
        }

        public string T(double value)
        {
            return value.ToString(Culture);
        }

        public static string T<U, TProperty>(ITranslator instance, Expression<Func<U, TProperty>> expression)
        {
            Expression memberAccessExpression = expression;
            while (memberAccessExpression.NodeType != ExpressionType.MemberAccess)
            {
                if (memberAccessExpression.NodeType == ExpressionType.Call)
                    throw new InvalidOperationException("只能指定属性，不能使用一个函数调用！");
                if (memberAccessExpression.NodeType == ExpressionType.Convert)
                    throw new InvalidOperationException("只能指定属性，不能使用一个转换语句，例如一个属性是float类型，但是在调用该函数是，采用了Translate.T<ModelType, double>(c => c.FloatProperty)的方式！");

                memberAccessExpression = expression.Body;
            }

            var type = ((MemberExpression)memberAccessExpression).Expression.Type;
            var propertyName = ((MemberExpression)memberAccessExpression).Member.Name;
            var pinfo = type.GetProperty(propertyName);
            var attrs = pinfo.GetCustomAttributes(typeof(DisplayAttribute), false);
            if (attrs.Length == 0)
                return instance.T(pinfo.Name);
            else
                return instance.T(((DisplayAttribute)attrs[0]).Name);
        }

        public string T<U, TProperty>(Expression<Func<U, TProperty>> expression)
        {
            return T(this, expression);
        }
    }
}

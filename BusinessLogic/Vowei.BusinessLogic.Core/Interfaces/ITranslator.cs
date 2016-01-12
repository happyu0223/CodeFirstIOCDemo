using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace CodeFirstIOCDemo.BusinessLogic.Core.Interfaces
{
    public interface ITranslator
    {
        CultureInfo Culture { get; }

        string T(string message);

        string T(DateTime value);

        string T(double value);

        string T<U, TProperty>(Expression<Func<U, TProperty>> expression);
    }
}

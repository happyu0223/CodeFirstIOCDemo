using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstIOCDemo.BusinessLogic.Core
{
    public class PropertyNotFoundException : Exception
    {
        public PropertyNotFoundException(string message)
            : base(message)
        {
        }
    }

    public class InvalidValueException : Exception
    {
        public InvalidValueException(string message)
            : base(message)
        {
        }
    }

    public class FileTypeException : Exception
    {
        public FileTypeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public FileTypeException(string message)
            : base(message)
        {
        }
    }
}

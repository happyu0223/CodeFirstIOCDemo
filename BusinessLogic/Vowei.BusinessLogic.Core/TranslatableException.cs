using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;

namespace CodeFirstIOCDemo.BusinessLogic.Core
{
    /// <summary>
    /// 表示一个消息可以被翻译的异常！
    /// </summary>
    // 虽然.NET基本类库中自己的异常消息是国际化的，但我还没有研究怎么做，所以就设计了这么一个基类！
    public class TranslatableException : Exception
    {
        public TranslatableException(Exception innerException, ITranslator translator, string format, params object[] args)
            : base(null, innerException)
        {
            Format = format;
            Args = args;
            Translator = translator;
        }

        public TranslatableException(ITranslator translator, string format, params object[] args)
            : base()
        {
            Format = format;
            Args = args;
            Translator = translator;
        }

        public override string Message
        {
            get
            {
                return string.Format(Translator != null ? Translator.T(Format) : Format, Args);
            }
        }

        public String Format { get; private set; }

        public object[] Args { get; private set; }

        protected ITranslator Translator { get; private set; }
    }

    /// <summary>
    /// 表明告诉用户不要直接访问，或者组装Url访问网站！
    /// </summary>
    public class DonotComposeUrlException : TranslatableException
    {
        public DonotComposeUrlException(ITranslator translator, string format, params object[] args)
            : base(translator, format, args)
        {
        }
    }

    public class ResourceNotFoundException : TranslatableException
    {
        public ResourceNotFoundException(ITranslator translator, string format, params object[] args)
            : base(translator, format, args)
        {
        }
    }

    /// <summary>
    /// 无访问权限的异常！
    /// </summary>
    public class AccessDeniedException : TranslatableException
    {
        public AccessDeniedException(ITranslator translator, string format, params object[] args)
            : base(translator, format, args)
        {
        }
    }

    /// <summary>
    /// 用户无效操作！
    /// </summary>
    public class InvalidUserOperationException : TranslatableException
    {
        public InvalidUserOperationException(Exception innerException, ITranslator translator, string format, params object[] args)
            : base(innerException, translator, format, args)
        {
        }

        public InvalidUserOperationException(ITranslator translator, string format, params object[] args)
            : base(translator, format, args)
        {
        }
    }

    public class NotAuthenticatedException : TranslatableException
    {
        public NotAuthenticatedException(ITranslator translator, string format, params object[] args)
            : base(translator, format, args)
        {
        }
    }
}

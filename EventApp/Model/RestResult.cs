using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Model
{

    public class RestResult
    {
        public const string TITLE_INFO = "Information";
        public const string TITLE_ERROR = "Erreur";
        public const string TITLE_ATTENTION = "Attention";
        public const string SERVER_ACCESS_ERROR_TITLE = "Erreur";
        public const string SERVER_ACCESS_ERROR_MESS = "Une opération de maintenance est en cours. Veuillez nous excuser pour le dérangement occasionné.";

        public bool IsSuccess { get; set; }
        public string ErrorTitle { get; set; }
        public string ErrorMessage { get; set; }
        public double? MiddlewareExecutionTime { get; set; }
        public double? CallExecutionTime { get; set; }

        public RestResult(bool isSuccess = true)
        {
            IsSuccess = isSuccess;
        }
    }

    public class RestResult<T> : RestResult
    {
        public T Data { get; protected set; }

        public RestResult(T data)
            : this(true, data)
        {
        }

        protected RestResult(bool isSuccess, T data)
            : base(isSuccess)
        {
            Data = data;
        }
    }

    public class RestFailureResult<T> : RestResult<T>
    {
        public RestFailureResult(string errorMessage)
            : base(false, default(T))
        {
            ErrorTitle = TITLE_INFO;
            ErrorMessage = errorMessage;
        }

        public RestFailureResult(string errorTitle, string errorMessage)
            : base(false, default(T))
        {
            ErrorTitle = string.IsNullOrWhiteSpace(errorTitle) ? TITLE_INFO : errorTitle;
            ErrorMessage = errorMessage;
        }

    }

    public class RestFailureResultNotConnected<T> : RestResult<T>
    {
        public RestFailureResultNotConnected()
            : base(false, default(T))
        {
            ErrorTitle = "Information";
            ErrorMessage = "Vous n'êtes pas connecté à Internet";
        }

    }

    public class RestSuccessResult<T> : RestResult<T>
    {
        public RestSuccessResult(T data)
            : base(true, data)
        {
        }

    }

}

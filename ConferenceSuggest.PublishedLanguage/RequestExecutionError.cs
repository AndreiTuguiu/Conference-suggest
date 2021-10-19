using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceSuggest.PublishedLanguage
{
    public class RequestExecutionError<TMessage> : INotification
    {
        public TMessage OriginalRequest { get; set; }
        public Exception Error { get; set; }

        public RequestExecutionError(TMessage originalRequest, Exception ex)
        {
            OriginalRequest = originalRequest;
            Error = ex;
        }
    }
}

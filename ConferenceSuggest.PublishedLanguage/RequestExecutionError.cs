using MediatR;
using System;

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

using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Twilight.Kernel.Logging;

namespace Satistics_API_client
{
    public class Logger<T> : Microsoft.Extensions.Logging.Logger<T>, IEventLogger<T>
    {
        private ILogger<T> _logger;
        public Logger(ILoggerFactory factory) : base(factory)
        {
            this._logger = factory.CreateLogger<T>();
            
        }

        public void Log<TState>(SeverityLevel logLevel, Twilight.Kernel.Logging.EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            
        }

        public async Task Log(SeverityLevel level, Twilight.Kernel.Logging.EventId eventId, Type eventSource, Guid transactionId, string message)
        {
            
        }

        public async Task Log(SeverityLevel level, Twilight.Kernel.Logging.EventId eventId, Type eventSource, string message)
        {
            this._logger.Log(LogLevel.Information, new Microsoft.Extensions.Logging.EventId(eventId.Id), eventSource, null, (s, e) => { return e?.Message; });
#if DEBUG
            //Debug.WriteLine("Source: {0}, Message: {1}, Severity level: {2}", eventSource, message, level);
#endif
        }

        public async Task Log(SeverityLevel level, Twilight.Kernel.Logging.EventId eventId, Type eventSource, Guid transactionId, Exception exception)
        {
            
        }

        public async Task Log(SeverityLevel level, Twilight.Kernel.Logging.EventId eventId, Type eventSource, Exception exception)
        {
            
        }
    }
}

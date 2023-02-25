using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Twilight.Kernel.Logging;

namespace Satistics_API_client
{
    public class Logger<T> : Microsoft.Extensions.Logging.Logger<T>, IEventLogger<T>
    {
        public Logger(ILoggerFactory factory) : base(factory)
        {
        }

        public void Log<TState>(SeverityLevel logLevel, Twilight.Kernel.Logging.EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            
        }

        public async Task Log(SeverityLevel level, Twilight.Kernel.Logging.EventId eventId, Type eventSource, Guid transactionId, string message)
        {
            
        }

        public async Task Log(SeverityLevel level, Twilight.Kernel.Logging.EventId eventId, Type eventSource, string message)
        {
            
        }

        public async Task Log(SeverityLevel level, Twilight.Kernel.Logging.EventId eventId, Type eventSource, Guid transactionId, Exception exception)
        {
            
        }

        public async Task Log(SeverityLevel level, Twilight.Kernel.Logging.EventId eventId, Type eventSource, Exception exception)
        {
            
        }
    }
}

using Microsoft.Extensions.Logging;
using System;
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
            var severityLevel = this.SeverityToLogLevel(logLevel);
            this._logger.Log<TState>(severityLevel, new Microsoft.Extensions.Logging.EventId(eventId), state, exception, (s, e) => e.Message);
        }

        public async Task Log(SeverityLevel logLevel, Twilight.Kernel.Logging.EventId eventId, Type eventSource, Guid transactionId, string message)
        {
            var severityLevel = this.SeverityToLogLevel(logLevel);
        }

        public async Task Log(SeverityLevel level, Twilight.Kernel.Logging.EventId eventId, Type eventSource, string message)
        {
            var severityLevel = this.SeverityToLogLevel(level);
            this._logger.Log(severityLevel, new Microsoft.Extensions.Logging.EventId(eventId.Id), eventSource, null, (s, e) => { return e?.Message; });
        }

        public async Task Log(SeverityLevel level, Twilight.Kernel.Logging.EventId eventId, Type eventSource, Guid transactionId, Exception exception)
        {
            var severityLevel = this.SeverityToLogLevel(level);
            this._logger.Log(severityLevel, new Microsoft.Extensions.Logging.EventId(eventId.Id), eventSource, null, (s, e) => { return e?.Message; });
        }

        public async Task Log(SeverityLevel level, Twilight.Kernel.Logging.EventId eventId, Type eventSource, Exception exception)
        {
            var severityLevel = this.SeverityToLogLevel(level);
            this._logger.Log(severityLevel, new Microsoft.Extensions.Logging.EventId(eventId.Id), eventSource, null, (s, e) => { return e?.Message; });
        }

        private LogLevel SeverityToLogLevel(SeverityLevel severityLevel)
        {
            switch (severityLevel)
            {
                case SeverityLevel.Info:
                    return LogLevel.Information;
                case SeverityLevel.Error: 
                    return LogLevel.Error;
                case SeverityLevel.Warning:
                    return LogLevel.Warning;
                case SeverityLevel.Debug: 
                    return LogLevel.Debug;
                case SeverityLevel.Trace: 
                    return LogLevel.Trace;
                default: throw new ArgumentException(nameof(severityLevel));
                    
            }
        }
    }
}

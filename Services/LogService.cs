using System;

namespace Logging.Services
{
    public class LogService
    {
        private readonly ILogger _logger;
        public LogService(ILogger<string> logger)
        {
            this._logger = logger;
        }
        public void Write(string message)
        {
            this._logger.LogInformation(message);
            //this._logger.LogInformation(2024913905, "Hello {}{}", "Wor", "ld");
            //this._logger.LogWarning("Warning!!!!!!");
            //this._logger.LogError("Error, omg");
        }
    }
}

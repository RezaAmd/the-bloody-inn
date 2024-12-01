using Microsoft.Extensions.Logging;

namespace TheBloodyInn.Framework.Factories
{
    public class InnModelFactory
    {
        #region DI & Ctor

        private readonly ILogger<InnModelFactory> _logger;
        public InnModelFactory(ILogger<InnModelFactory> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Methods



        #endregion
    }
}
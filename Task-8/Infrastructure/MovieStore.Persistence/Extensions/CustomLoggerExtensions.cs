using Microsoft.Extensions.Logging;

namespace MovieStore.Persistence.Extensions
{
    public static class LoggerExtensions<T> where T : class
    {       
        public static void MethodTriggered(ILogger<T> logger,string methodName)
        {
            logger.LogInformation($"{methodName} metodu tetiklendi ");
        }

       
    }
}

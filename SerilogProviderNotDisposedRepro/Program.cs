using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SerilogProviderNotDisposedRepro
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder =>
                {
                    builder.AddFile("test.log");
                })
                .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILogger<Program>>();
            logger.LogError("test");
            
            serviceProvider.Dispose();
            // Thread.Sleep(5000);
        }
    }
}

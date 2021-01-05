using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pericia.ConsoleApp.Starter
{
    public class App
    {
        private readonly ILogger logger;

        public App(ILogger<App> logger)
        {
            this.logger = logger;
        }

        public Task Run()
        {
            logger.LogInformation("Hello World!");
            return Task.CompletedTask;
        }
    }
}

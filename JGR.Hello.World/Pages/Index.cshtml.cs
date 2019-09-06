using System;
using System.Threading;
using System.Threading.Tasks;
using JGR.Hello.World.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace JGR.Hello.World.Pages
{
    public class IndexModel : PageModel, IHostedService, IDisposable
    {
        private readonly ILogger logger;
        private readonly IServiceProvider services;
        private Timer timer;

        public IndexModel(IServiceProvider services, ILogger<IndexModel> logger)
        {
            this.services = services;
            this.logger = logger;
        }

        public void OnGet()
        {
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Time is start");

            this.timer = timer = new Timer(DoWork, "bla", TimeSpan.Zero,
            TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Time is stopping.");
            this.timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            this.timer?.Dispose(); ;
        }

        private void DoWork(object state)
        {
            this.logger.LogInformation("Consume scope message");
            using (var scope = this.services.CreateScope())
            {
                var messageservice =
                    scope.ServiceProvider
                        .GetRequiredService<IMessageService>();
                messageservice.SendMessage();
            }
        }
    }
}
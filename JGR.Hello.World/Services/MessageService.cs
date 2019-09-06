using System.Threading.Tasks;
using JGR.Hello.World.Model;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client.Core.DependencyInjection;
using Microsoft.AspNetCore.Hosting;

namespace JGR.Hello.World.Services
{
    public class MessageService : IMessageService
    {
        private readonly IQueueService queueService;
        private readonly IHostingEnvironment env;
        private readonly ILogger logger;
        public MessageService(ILogger<MessageService> logger, IQueueService queueService, IHostingEnvironment env)
        {
            this.logger = logger;
            this.queueService = queueService;
            this.env = env;
        }

        public async Task SendMessage()
        {
            this.logger.LogInformation("Send message");

            var messageObject = new MessageModel();
            messageObject.ApplicationName = this.env.ApplicationName;

            await this.queueService.SendAsync(
                @object: messageObject,
                exchangeName: "helloworld",
                routingKey: "message.key");
        }
    }
}
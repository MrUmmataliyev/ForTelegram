
using ForTelegram.Infrastructure;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ForTelegram.Services
{
    public class BSTimer : BackgroundService
    {
        private readonly TelegramBotClient _botClient;
        private readonly IServiceScopeFactory _scopeFactory;
        public BSTimer(TelegramBotClient botClient, IServiceScopeFactory scopeFactory)
        {
            _botClient = botClient;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<AppDbContext>();

            while(!stoppingToken.IsCancellationRequested)
            {
                await _botClient.SendTextMessageAsync(
                    chatId: 
                    );
            }
        }
    }
}

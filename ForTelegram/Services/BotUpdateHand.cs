using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot;
using ForTelegram.Infrastructure;
using ForTelegram.Services.UserRepo;
using ForTelegram.Models;

namespace ForTelegram.Services
{
    public class BotUpdateHand : IUpdateHandler
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public BotUpdateHand(IServiceScopeFactory serviceScopeFactory)
        {
           _serviceScopeFactory = serviceScopeFactory;
        }
        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var scope = _serviceScopeFactory.CreateScope();
            var repo = scope.ServiceProvider.GetRequiredService<IUserRepos>();
            // Only process Message updates: https://core.telegram.org/bots/api#message
            if (update.Message is not { } message)
                return;
            // Only process text messages
            if (message.Text is not { } messageText)
                return;

            var chatId = message.Chat.Id;


            var user = new TeleUser
            {
                Id = chatId,
                UserName = message.Chat.Username,

            };
            await repo.AddUser(user);

            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

            // Echo received message text
            Message sentMessage = await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "You said:\n" + messageText,
                cancellationToken: cancellationToken);
        }
    }
}

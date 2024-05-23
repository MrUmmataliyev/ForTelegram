using Telegram.Bot.Polling;
using Telegram.Bot;
using ForTelegram.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<BS>();
builder.Services.AddSingleton<IUpdateHandler, BotUpdateHand>();
builder.Services.AddSingleton(new TelegramBotClient("7152494048:AAE-0j1ChDWE_92vHfvfAVViLoEybh2jSSE"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
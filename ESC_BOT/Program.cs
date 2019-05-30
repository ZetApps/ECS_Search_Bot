using System;
using Telegram.Bot;

namespace ESC_BOT
{
    class Program
    {
        static ITelegramBotClient botClient;

        static void Main(string[] args)
        {
            botClient = new TelegramBotClient("876117037:AAHoCDuy95dlH_EshDt_enlX01_3lr2q1Os");
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
              $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );

            botClient.OnMessage += BotClient_OnMessage;
            botClient.StartReceiving();
            while (Console.ReadKey().Equals(ConsoleKey.Escape)) { }
        }

        private async static void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            Console.WriteLine($"Получено сообщение от пользователя в чате {e.Message.Chat.Id}");

            await botClient.SendTextMessageAsync(
                e.Message.Chat.Id,
                "Ты мне написал: " + e.Message.Text);
        }
    }
}

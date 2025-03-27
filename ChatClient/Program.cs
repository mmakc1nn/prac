using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.Write("Введите ваше имя: ");
        string userName = Console.ReadLine();

        var connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5050/chat")
            .WithAutomaticReconnect()
            .Build();

        connection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            Console.WriteLine($"{user}: {message}");
        });

        await connection.StartAsync();
        Console.WriteLine("Подключено к чату. Введите сообщение:");

        while (true)
        {
            string message = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(message)) continue;

            await connection.InvokeAsync("SendMessage", userName, message);
        }
    }
}

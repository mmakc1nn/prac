using Microsoft.AspNetCore.SignalR;

class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}

class Program
{
    static void Main()
    {

        var builder = WebApplication.CreateBuilder();

        builder.Services.AddSignalR(); // ✅ Добавляем SignalR

        var app = builder.Build();

        app.MapHub<ChatHub>("/chat"); // ✅ Указываем маршрут для хаба

        app.Run();


        Console.WriteLine("Сервер запущен на http://localhost:5000");
        app.Run("http://localhost:5050");
    }
}

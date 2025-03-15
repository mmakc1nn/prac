using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;
using RestSharp;
using System.Text.Json.Serialization;

namespace Liker
{
    class Program
    {
        static async Task Main()
        {
            string token = "Токен суда";

            string channelId = "id канала";

            string userId = "id того, под чьи сообщения ставить эмоции";

            string emoji = "🔥";

            int delay = 5;

            while (true)
            {
                try
                {
                    var messages = await GetMessages(token, channelId);
                    foreach (var msg in messages)
                    {
                        if (msg.Author.Id == userId)
                        {
                            await AddReaction(token, channelId, msg.Id, emoji);
                            Thread.Sleep(delay * 1000); 
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    
                }
                Thread.Sleep(delay * 1000);
            }
        }

        private static async Task<Message[]> GetMessages(string token, string channelId)
        {
            var client = new RestClient($"https://discord.com/api/v9/channels/{channelId}/messages?limit=50");
            var request = new RestRequest();
            request.AddHeader("Authorization", token);
            request.AddHeader("Content-Type", "application/json");

            var response = await client.ExecuteGetAsync(request);
           
            Console.WriteLine(response.Content);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true, 
                AllowTrailingCommas = true,         
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            return JsonSerializer.Deserialize<Message[]>(response.Content, options);
        }

        private static async Task AddReaction(string token, string channelId, string messageId, string emoji)
        {
            string emojiEncoded = Uri.EscapeDataString(emoji);
            var client = new RestClient($"https://discord.com/api/v9/channels/{channelId}/messages/{messageId}/reactions/{emojiEncoded}/@me");
            var request = new RestRequest();
            request.Method = Method.Put;
            request.AddHeader("Authorization", token);
            request.AddHeader("Content-Type", "application/json");
            
            var response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
        }
    }

    // Классы для десериализации JSON-ответов
    public class Message
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("author")]
        public Author Author { get; set; }
    }


        public class Author
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set;}
    }
}
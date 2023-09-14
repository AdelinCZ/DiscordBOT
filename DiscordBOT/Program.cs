using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace DiscordBOT
{
    public class Program
    {
        private static async Task Main()
        {
            List<string> MessagesList = new List<string>()
            {
                "Suiswap is the best project !",
                "Keep building guys !",
                "Waiting for token listing .",
                "What do you think about this bear market ?",
                "Moon is the only destination for this project !",
                "How are you today guys ?",
                "Do you think that sui will go to da moon ?",
                "When BTC to 100k guys ?",
                "Hello fam, how are you ?",
                "Swuiswap will go to da moon",
                "1$ tomorrow SSWP :)",
                "We need a strong SUI community .",
                "Leg's go guys, tomorrow is the best day"
            };

            var random = new Random();
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("XXX");

            while (true)
            {
                Thread.Sleep(125000);

                var count = 0;
                int index = random.Next(MessagesList.Count);
                var message = new DiscordMessage(MessagesList[index]);

                var result = await httpClient.PostAsJsonAsync("https://discord.com/api/v9/channels/1016726800526757931/messages", message);

                if (result.IsSuccessStatusCode)
                {
                    count++;
                    Console.WriteLine($"Mesajul[{count}] trimis : {MessagesList[index]} ");
                }
                else
                    Console.WriteLine("Mesajul nu a putut fi trimis");
            }
        }
    }

    public class DiscordMessage
    {
        public DiscordMessage(string message)
        {
            content = message;
        }

        public string content { get; set; }
        public bool tts = false;
    }
}
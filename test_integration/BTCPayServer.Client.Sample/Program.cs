using System;
using System.Threading.Tasks;

namespace BTCPayServer.Client.Sample
{
    class Program
    {
        private static readonly Uri SERVER_URL = new Uri("https://your_btcpayserver");
        private static readonly string API_KEY = "your_api_key";

        static async Task Main(string[] args)
        {
            Console.WriteLine("BTCPay Server - client");

            var client = new BTCPayServerClient(SERVER_URL, API_KEY);

            var health = await client.GetHealth();
        }
    }
}

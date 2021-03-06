﻿using System;
using System.Threading.Tasks;
using BTCPayServer.Client.Legacy;

namespace BTCPayServer.Client.Sample
{
    class Program
    {
        private static readonly Uri SERVER_URL = new Uri("https://your_btcpayserver");
        private static readonly string API_KEY = "your_api_key";


        static async Task Main(string[] args)
        {
            Console.WriteLine("BTCPay Server - client");

            var client = new BTCPayServerClientLegacy(SERVER_URL, API_KEY);

            var invoice = await client.CreateInvoice(new InvoiceRequestLegacy()
            {
                Currency = "USD",
                Price = 0.99m,
                ItemDesc = "Payment for my_store_order",
                OrderId = "my_store_order::xxxyyy",
                NotificationUrl = new Uri("https://webhook.site/2d2e50dd-0b10-4634-b591-542e1408f4da"),
                RedirectUrl = new Uri("https://webhook.site/2d2e50dd-0b10-4634-b591-542e1408f4da"),
                FullNotifications = true,
                ExtendedNotifications = true
            });

            Console.WriteLine($"Invoice created, id: {invoice.Id}, order: {invoice.OrderId}");
            Console.WriteLine(invoice);
            Console.WriteLine();

            var invoiceId = invoice.Id;
            var invoiceToken = invoice.Token;

            while (true)
            {
                Console.WriteLine("=========================================================");
                Console.WriteLine($"Set invoice id (default on enter: '{invoiceId}'): ");
                var newInvoiceId = Console.ReadLine();
                invoiceId = !string.IsNullOrWhiteSpace(newInvoiceId) ? newInvoiceId : invoiceId;

                Console.WriteLine($"Set invoice token (default on enter: '{invoiceToken}'): ");
                var newInvoiceToken = Console.ReadLine();
                invoiceToken = !string.IsNullOrWhiteSpace(newInvoiceToken) ? newInvoiceToken : invoiceToken;

                var existingInvoice = await client.GetInvoice(invoiceId, invoiceToken);
                Console.WriteLine(existingInvoice);
                Console.WriteLine();
            }
        }
    }
}

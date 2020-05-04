using System;
using System.Diagnostics;

namespace BTCPayServer.Client.Legacy
{
    /// <summary>
    /// Request invoice data model for legacy API
    /// </summary>
    [DebuggerDisplay("Invoice - price: {Price} {Currency}")]
    public class InvoiceRequestLegacy
    {
        /*
            const invoiceCreation = {
              "price": 12345,
              "currency": "USD",
              "orderId": "something",
              "itemDesc": "item description",
              "notificationUrl": "https://webhook.after.checkout.com/goeshere",
              "redirectURL": "https://go.here.after.checkout.com"
            };
         */

        public decimal Price { get; set; }

        public string Currency { get; set; }

        public string OrderId { get; set; }

        public string ItemDesc { get; set; }

        public Uri NotificationUrl { get; set; }

        public Uri RedirectUrl { get; set; }

        public bool FullNotifications { get; set; } = true;

        public bool ExtendedNotifications { get; set; } = true;

        public override string ToString()
        {
            return $"Invoice - price: {Price} {Currency}";
        }
    }
}

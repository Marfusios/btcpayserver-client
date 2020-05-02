using System;
using System.Collections.Generic;
using System.Diagnostics;
using BTCPayServer.Client.Utils;
using Newtonsoft.Json;

namespace BTCPayServer.Client.Legacy
{
    /// <summary>
    /// Response invoice data model for legacy API
    /// </summary>
    [DebuggerDisplay("Invoice - {Id}, price: {Price} {Currency}")]
    public class InvoiceResponseLegacy
    {
        public string Id { get; set; }

        public string Guid { get; set; }

        public decimal Price { get; set; }

        public string Currency { get; set; }

        public string OrderId { get; set; }

        public string ItemDesc { get; set; }

        public string ItemCode { get; set; }

        public string PosData { get; set; }



        public string Url { get; set; }

        public string Status { get; set; }


        public decimal BtcPrice { get; set; }

        public decimal BtcDue { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime InvoiceTime { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime ExpirationTime { get; set; }


        public bool LowFeeDetected { get; set; }

        public decimal BtcPaid { get; set; }

        public decimal Rate { get; set; }

        public string ExceptionStatus { get; set; }

        public Dictionary<string, string> PaymentUrls { get; set; }

        public string BitcoinAddress { get; set; }

        public string Token { get; set; }

        public decimal AmountPaid { get; set; }

        public Dictionary<string, string> Addresses { get; set; }

        public BuyerLegacy Buyer { get; set; }

        public override string ToString()
        {
            return $"Invoice - {Id}, status: {Status}, price: {Price} {Currency} (rate: {Rate}), " +
                   $"created: {InvoiceTime:g}, expiration: {ExpirationTime:g}";
        }
    }
}

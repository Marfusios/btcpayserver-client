![Logo](btcpayserver-logo.png)
# BTCPay Server client [![Build Status](https://travis-ci.com/Marfusios/btcpayserver-client.svg?branch=master)](https://travis-ci.com/Marfusios/btcpayserver-client) [![NuGet version](https://badge.fury.io/nu/BTCPayServer.Client.svg)](https://www.nuget.org/packages/BTCPayServer.Client) [![Nuget downloads](https://img.shields.io/nuget/dt/BTCPayServer.Client)](https://www.nuget.org/packages/BTCPayServer.Client)

This is a C# client for BTCPayServer. Taken from [official repository](https://github.com/btcpayserver/btcpayserver/tree/master/BTCPayServer.Client) and bundled into Nuget package.

*[WIP] Not yet ready!* 

[Releases and breaking changes](https://github.com/Marfusios/btcpayserver-client/releases)

### License: 
    MIT

### Features

* installation via NuGet ([BTCPayServer.Client](https://www.nuget.org/packages/BTCPayServer.Client))
* targeting .NET Standard 2.0 (.NET Core, Linux/MacOS compatible)

### Usage (legacy API)

**Server side: **
```csharp

// create an invoice

var client = new BTCPayServerClientLegacy(new Uri("https://btcpay.yourserver.com"), "legacy_api_key");

var invoice = await client.CreateInvoice(new InvoiceRequestLegacy()
{
    Currency = "USD",
    Price = 100m,
    ItemDesc = "Payment for my_store_order",
    OrderId = "my_store_order::xxxyyy",
    NotificationUrl = new Uri("https://webhook.site/03b96bf0-dbd3-4da0-b3d1-54aa5e7f794c"),
    RedirectUrl = new Uri("https://webhook.site/03b96bf0-dbd3-4da0-b3d1-54aa5e7f794c")
});


// getting an invoice by id
// you have to also specify a token (don't really know why :( )

var invoiceId = invoice.Id;
var invoiceToken = invoice.Token;
var existingInvoice = await client.GetInvoice(invoiceId, invoiceToken);

```


**Client side: **

```html

// display a checkout modal with created invoice id from the previous step

<script src ="https://your.btcpay.url/modal/btcpay.js"></script>
window.btcpay.showInvoice(invoiceId);


// event listeners

window.btcpay.onModalWillEnter(yourCallbackFunction);
window.btcpay.onModalWillLeave(yourCallbackFunction);

```

### Usage (new API)

*Not implemented on BTCPay Server yet*


More usage examples:
* console sample ([link](test_integration/BTCPayServer.Client.Sample/Program.cs))


**Pull Requests are welcome!**


### Available for help
I do consulting, please don't hesitate to contact me if you have a custom solution you would like me to implement ([web](http://mkotas.cz/), 
<m@mkotas.cz>)

Donations gratefully accepted.
* [![Donate with Bitcoin](https://en.cryptobadges.io/badge/small/1HfxKZhvm68qK3gE8bJAdDBWkcZ2AFs9pw)](https://en.cryptobadges.io/donate/1HfxKZhvm68qK3gE8bJAdDBWkcZ2AFs9pw)
* [![Donate with Litecoin](https://en.cryptobadges.io/badge/small/LftdENE8DTbLpV6RZLKLdzYzVU82E6dz4W)](https://en.cryptobadges.io/donate/LftdENE8DTbLpV6RZLKLdzYzVU82E6dz4W)
* [![Donate with Ethereum](https://en.cryptobadges.io/badge/small/0xb9637c56b307f24372cdcebd208c0679d4e48a47)](https://en.cryptobadges.io/donate/0xb9637c56b307f24372cdcebd208c0679d4e48a47)

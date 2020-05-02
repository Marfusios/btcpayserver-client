using System;
using System.Collections.Generic;
using System.Text;

namespace BTCPayServer.Client.Legacy
{
    internal class ResponseLegacy<TData>
    {
        public string Facade { get; set; }

        public TData Data { get; set; }
    }
}

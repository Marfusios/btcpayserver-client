using System;
using System.Collections.Generic;
using System.Text;

namespace BTCPayServer.Client.Exceptions
{
    /// <summary>
    /// Exception to cover bad user input
    /// </summary>
    public class BTCPayServerClientBadInputException : BTCPayServerClientException
    {
        /// <inheritdoc />
        public BTCPayServerClientBadInputException()
        {
        }

        /// <inheritdoc />
        public BTCPayServerClientBadInputException(string message) : base(message)
        {
        }

        /// <inheritdoc />
        public BTCPayServerClientBadInputException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

using System;

namespace BTCPayServer.Client.Exceptions
{
    /// <summary>
    /// Base exception for this client library
    /// </summary>
    public class BTCPayServerClientException : Exception
    {
        /// <inheritdoc />
        public BTCPayServerClientException()
        {
        }

        /// <inheritdoc />
        public BTCPayServerClientException(string message)
            : base(message)
        {
        }

        /// <inheritdoc />
        public BTCPayServerClientException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

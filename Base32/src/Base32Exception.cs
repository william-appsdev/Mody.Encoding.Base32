using System;

namespace Mody.Encoding.Base32NS
{
    /// <summary>
    /// Represents errors that occur during encoding/decoding process.
    /// </summary>
    public class Base32Exception : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Base32Exception"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public Base32Exception(string message)
            : base(message)
        {
        }
    }
}

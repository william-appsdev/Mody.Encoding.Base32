namespace ZiloBase32EncodingNS
{
    public class ZiloBase32Exception : Exception
    {
        public ZiloBase32Exception()
            : base()
        {
        }

        public ZiloBase32Exception(string message)
            : base(message)
        {
        }

        public ZiloBase32Exception(Exception innerException)
            : base(null, innerException)
        {
        }

        public ZiloBase32Exception(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

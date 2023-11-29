using System.Numerics;

namespace Mody.Encoding.Base32NS.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BigInteger input = 1023;
            byte[] bytes = input.ToByteArray();
            string base32Encoded = Base32.GetString(bytes);
            byte[] base32Decoded = Base32.GetBytes(base32Encoded);
            BigInteger output = new BigInteger(base32Decoded);
            bool isSuccess = output == input;

            if (isSuccess)
                Console.WriteLine($"{input} = {base32Encoded}");
            else
                Console.WriteLine("Tested failed");

            base32Decoded = Base32.GetBytes("abc");
            base32Encoded = Base32.GetString(base32Decoded);
            isSuccess = base32Encoded.Equals("abc", StringComparison.OrdinalIgnoreCase);
            if (isSuccess)
                Console.WriteLine($"Tested OK.");
            else
                Console.WriteLine("Tested failed");
        }
    }
}
using System.Numerics;

namespace ZiloBase32EncodingNS.Tester
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BigInteger input = 32;
            byte[] bytes = input.ToByteArray();
            string base32Encoded = ZiloBase32Encoding.GetString(bytes);
            byte[] base32Decoded = ZiloBase32Encoding.GetBytes(base32Encoded);
            BigInteger output = new BigInteger(base32Decoded);
            bool isSuccess = output == input;

            if (isSuccess)
                Console.WriteLine($"{input} = {base32Encoded}");
            else
                Console.WriteLine("Tested failed");

            Console.WriteLine(ZiloBase32Encoding.GetBytes("i"));
        }
    }
}
using System.Numerics;
using System.Text;

namespace ZiloBase32EncodingNS
{
    /// <summary>
    /// Represents the Zilo-base32 encoding.
    /// </summary>
    /// <remarks>
    /// A base32 encoding which ignores case, excluding the character 'I', 'L', 'O', and 'Z'.
    /// </remarks>
    public static class ZiloBase32Encoding
    {
        private const int _Base = 32;
        private const string _CharSet = "0123456789ABCDEFGHJKMNPQRSTUVWXY";

        /// <summary>
        /// Decodes all the bytes into a Zilo-base32 string.
        /// </summary>
        /// <param name="bytes">The byte array containing the sequence of bytes to decode.</param>
        /// <returns>A Zilo-base32 string that contains the results of decoding the specified sequence of bytes.</returns>
        public static string GetString(byte[] bytes)
        {
            StringBuilder stringBuilder = new StringBuilder();

            {
                char ch;
                int remainder;
                BigInteger input = new BigInteger(bytes);
                BigInteger quotient = input;

                do
                {
                    remainder = (int)(quotient % _Base);
                    ch = _CharSet[remainder];

                    stringBuilder.Insert(0, ch);

                    quotient /= _Base;
                } while (quotient > 0);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Encodes all the characters in the specified Zilo-base32 string into a sequence of bytes.
        /// </summary>
        /// <param name="s">The Zilo-base32 string containing the characters to encode.</param>
        /// <returns>A byte array containing the results of encoding the specified set of Zilo-base32 characters.</returns>
        /// <exception cref="ZiloBase32Exception"><c>s</c> containing undefined character in the Zilo-base32 character set.</exception>
        public static byte[] GetBytes(string s)
        {
            BigInteger bigInteger = 0;

            {
                char[] chars = s.ToUpper().ToCharArray();
                int length = chars.Length;

                for (int i = 0; i < length; i++)
                {
                    char ch = chars[i];
                    int index = _CharSet.IndexOf(ch);

                    if (index >= 0)
                    {
                        byte b = (byte)index;
                        bigInteger = bigInteger * _Base + b;
                    }
                    else
                        throw new ZiloBase32Exception($"Unable to decode due to existence of \"{s[i]}\" in the argument.");
                }
            }

            return bigInteger.ToByteArray();
        }

        /// <summary>
        /// Converts the Zilo-base32 string to its byte array equivalent. A return value indicates whether the operation succeeded.
        /// </summary>
        /// <param name="s">The Zilo-base32 string containing the characters to encode.</param>
        /// <param name="bytes">The byte array containing the sequence of bytes to decode.</param>
        /// <returns><c>true</c> if <c>s</c> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryGetBytes(string s, out byte[] bytes)
        {
            BigInteger bigInteger = 0;

            {
                char[] chars = s.ToUpper().ToCharArray();
                int length = chars.Length;

                for (int i = 0; i < length; i++)
                {
                    char ch = chars[i];
                    int index = _CharSet.IndexOf(ch);

                    if (index >= 0)
                    {
                        byte b = (byte)index;
                        bigInteger = bigInteger * _Base + b;
                    }
                    else
                    {
                        bytes = Array.Empty<byte>();

                        return false;
                    }
                }
            }

            bytes = bigInteger.ToByteArray();

            return true;
        }
    }
}

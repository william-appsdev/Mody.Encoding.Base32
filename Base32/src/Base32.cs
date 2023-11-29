using System;
using System.Numerics;
using System.Text;

namespace Mody.Encoding.Base32NS
{
    /// <summary>
    /// Represents the Mody's base32 encoding.
    /// </summary>
    /// <remarks>
    /// A base32 encoding which ignores case, excluding the character 'I', 'L', 'O', and 'Z'.
    /// </remarks>
    public static class Base32
    {
        private const string _CharSet = "0123456789ABCDEFGHJKMNPQRSTUVWXY";
        private static readonly int _Base = _CharSet.Length;

        /// <summary>
        /// Decodes all the bytes into a Mody's base32 string.
        /// </summary>
        /// <param name="bytes">The byte array containing the sequence of bytes to decode.</param>
        /// <returns>A Mody's base32 string that contains the results of decoding the specified sequence of bytes.</returns>
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
        /// Encodes all the characters in the specified Mody's base32 string into a sequence of bytes.
        /// </summary>
        /// <param name="s">The Mody's base32 string containing the characters to encode.</param>
        /// <returns>A byte array containing the results of encoding the specified set of Mody's base32 characters.</returns>
        /// <exception cref="Base32Exception"><c>s</c> containing undefined character in the Mody's base32 character set.</exception>
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
                        throw new Base32Exception($"Unable to decode due to existence of \"{s[i]}\" in the argument.");
                }
            }

            return bigInteger.ToByteArray();
        }

        /// <summary>
        /// Converts the Mody's base32 string to its byte array equivalent. A return value indicates whether the operation succeeded.
        /// </summary>
        /// <param name="s">The Mody's base32 string containing the characters to encode.</param>
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

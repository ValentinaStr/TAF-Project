using System.Text;

namespace Core.Utils
{
    public static class RandomStringGenerator
    {
        private static Random random = new Random();
        private const string charsAlpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private const string charsNumeric = "0123456789";
        private const string charsSpecial = "!@#$%^&*()-_=+[]{}|;:'\",.<>/?";

        public static string GenerateRandomAlphaString(int length)
        {
            return GenerateRandomString(charsAlpha, length);
        }

        public static string GenerateRandomNumericString(int length)
        {
            return GenerateRandomString(charsNumeric, length);
        }

        public static string GenerateRandomSpecialSymbolString(int length)
        {
            return GenerateRandomString(charsSpecial, length);
        }

        public static string GenerateRandomStringAlphaWithNumbers(int length)
        {
            return GenerateRandomString(charsAlpha + charsNumeric, length);
        }

        public static string GenerateRandomAlphaWithSpecialSymbolString(int length)
        {
            return GenerateRandomString(charsAlpha + charsSpecial, length);
        }

        public static string GenerateRandomNumberInRange(int minValue, int maxValue)
        {
            if (minValue > maxValue)
                throw new ArgumentException("minValue must be less than or equal to maxValue");

            return random.Next(minValue, maxValue + 1).ToString();
        }

        private static string GenerateRandomString(string setChars, int length)
        {
            var stringResalt = new StringBuilder();

            while (length > 0)
            {
                var indexrandom = random.Next(setChars.Length);
                stringResalt.Append(setChars[indexrandom]);
                length--;
            }

            return stringResalt.ToString();
        }
    }
}
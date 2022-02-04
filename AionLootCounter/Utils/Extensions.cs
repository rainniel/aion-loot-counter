using System.Globalization;

namespace AionLootCounter.Utils
{
    public static class Extensions
    {
        private static readonly TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

        public static string ToTitleCase(this string str)
        {
            return textInfo.ToTitleCase(str.Trim());
        }

        public static int ToInt(this string str)
        {
            int.TryParse(str, out int output);
            return output;
        }

        public static byte ToByte(this string str)
        {
            byte.TryParse(str, out byte output);
            return output;
        }
    }
}
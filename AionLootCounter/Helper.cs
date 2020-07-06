namespace AionLootCounter
{
    public static class Helper
    {

        public static int GetInt(string str) {
            int.TryParse(str, out int output);
            return output;
        }

    }

}
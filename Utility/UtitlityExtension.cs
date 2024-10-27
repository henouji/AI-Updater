namespace AI_Updater.Utility
{
    public static class UtitlityExtension
    {
        public static string AddTimeStamp(this string fileName)
        {
            return string.Concat(
                Path.GetFileNameWithoutExtension(fileName),
                DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"),
                Path.GetExtension(fileName)
            );

        }
    }
}

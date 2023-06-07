using System.Text.RegularExpressions;

namespace StudentsCoursesManager.Data.Validators
{
    public static class DateValidator
    {
        public static  bool IsValidDateFormat(DateOnly date)
        {
            string stringDate = date.ToString();
            string pattern = @"^\d{2}[./]\d{2}[./]\d{4}$";

            return Regex.IsMatch(stringDate, pattern);
        }

        public static bool IsValidDateFormat(DateTime date)
        {
            string stringDate = date.ToString();
            string pattern = @"^\d{2}[./]\d{2}[./]\d{4}$";

            return Regex.IsMatch(stringDate, pattern);
        }

        public static bool IsValidDateAndTimeFormat(DateTime date)
        {
            string stringDate = date.ToString();
            string pattern = @"^\d{2}[./]\d{2}[./]\d{4} (0?\d|1?\d|2[0-4]):((0?\d|[1-5]\d|60))$";

            return Regex.IsMatch(stringDate, pattern);
        }
    }
}

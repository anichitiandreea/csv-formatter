namespace CSV.Formatter
{
    class Program
    {
        static void Main()
        {
            var redmineCsvFormatter = new RedmineCsvFormatter();
            redmineCsvFormatter.FormatMonthlyReport();
        }
    }
}

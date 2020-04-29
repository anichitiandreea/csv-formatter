using CsvHelper;
using System.Globalization;
using System.IO;

namespace CSV.Formatter
{
    public class RedmineCsvFormatter : IRedmineCsvFormatter
    {
        private readonly CsvTimelogsFormatter timelogsFormatter;
        private readonly CsvTimelogsWriter timelogsWriter;
        private readonly string currentDirectory = Directory.GetCurrentDirectory();
        private readonly string filePath;

        public RedmineCsvFormatter()
        {
            timelogsFormatter = new CsvTimelogsFormatter();
            timelogsWriter = new CsvTimelogsWriter();
            filePath = Path.Combine(currentDirectory, "timelog.csv");
        }

        public void FormatMonthlyReport()
        {
            string previousDate = null;

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HeaderValidated = null;
                csv.Configuration.MissingFieldFound = null;
                var timelogs = csv.GetRecords<Timelog>();

                timelogsFormatter.FormatEachTimelog(timelogs, previousDate);
            }

            timelogsWriter.WriteFormattedTimelogs(Path.Combine(currentDirectory, "result.csv"), timelogsFormatter.TimelogsToBeWritten);
        }
    }
}

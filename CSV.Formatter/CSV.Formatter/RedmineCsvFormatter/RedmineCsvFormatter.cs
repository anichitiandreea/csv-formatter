using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace CSV.Formatter
{
    public class RedmineCsvFormatter : IRedmineCsvFormatter
    {
        private readonly CsvTimelogsFormatter timelogsFormatter;
        private readonly CsvTimelogsWriter timelogsWriter;
        private readonly string currentDirectory = Directory.GetCurrentDirectory();
        private readonly string sourcePath;

        public RedmineCsvFormatter()
        {
            timelogsFormatter = new CsvTimelogsFormatter();
            timelogsWriter = new CsvTimelogsWriter();
            sourcePath = Path.Combine(currentDirectory, "timelog.csv");
        }

        public async Task FormatMonthlyReportAsync()
        {
            string previousDate = null;

            using (var reader = new StreamReader(sourcePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HeaderValidated = null;
                csv.Configuration.MissingFieldFound = null;

                var timelogs = new List<Timelog>();
                await csv.ReadAsync();
                csv.ReadHeader();

                while (await csv.ReadAsync())
                {
                    var timelog = new Timelog
                    {
                        Date = csv.GetField("Date"),
                        Comment = csv.GetField("Comment")
                    };

                    timelogs.Add(timelog);
                }

                timelogsFormatter.FormatEachTimelog(timelogs, previousDate);
            }

            var resultPath = Path.Combine(currentDirectory, "result.csv");

            await timelogsWriter.WriteFormattedTimelogsAsync(resultPath, timelogsFormatter.TimelogsToBeWritten);
        }
    }
}

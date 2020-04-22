using CsvHelper;
using System.Globalization;
using System.IO;

namespace CSV.Formatter
{
    public class ReportFormatter : IReportFormatter
    {
        private readonly CsvRecordsFormatter recordsFormatter;
        private readonly CsvRecordsWriter recordsWriter;
        private readonly string currentDirectory = Directory.GetCurrentDirectory();
        private readonly string filePath;

        public ReportFormatter()
        {
            recordsFormatter = new CsvRecordsFormatter();
            recordsWriter = new CsvRecordsWriter();
            filePath = Path.Combine(currentDirectory, "timelog.csv");
        }

        public void FormatReport()
        {
            string previousDate = null;

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HeaderValidated = null;
                csv.Configuration.MissingFieldFound = null;
                var records = csv.GetRecords<Timelog>();

                recordsFormatter.FormatEachRecord(records, previousDate);
            }

            recordsWriter.WriteFormattedRecords(Path.Combine(currentDirectory, "result.csv"), recordsFormatter.RecordsToBeWritten);
        }
    }
}

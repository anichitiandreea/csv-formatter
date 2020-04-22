using CsvHelper;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CSV.Formatter
{
    public class ReportFormatter : IReportFormatter
    {
        private readonly CsvRecordsFormatter recordsFormatter;
        private readonly CsvRecordsWriter recordsWriter;
        private readonly string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private readonly string filePath;

        public ReportFormatter()
        {
            recordsFormatter = new CsvRecordsFormatter();
            recordsWriter = new CsvRecordsWriter();
            filePath = Path.Combine(assemblyDirectory, "timelog.csv");
        }

        public void FormatReport()
        {
            string previousDate = null;

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();

                if (!csv.Context.HeaderRecord.Contains("Date"))
                {
                    csv.Configuration.HasHeaderRecord = false;
                    reader.BaseStream.Position = 0;
                }

                var records = csv.GetRecords<Timelog>();

                recordsFormatter.FormatEachRecord(records, previousDate);
            }

            recordsWriter.WriteFormattedRecords(filePath, recordsFormatter.RecordsToBeWritten);
        }
    }
}

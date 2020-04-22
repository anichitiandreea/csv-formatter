using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CSV.Formatter
{
    public class CsvRecordsWriter : ICsvRecordsWriter
    {
        public void WriteFormattedRecords(string fileLocation, List<Timelog> recordsToBeWritten)
        {
            using (var writer = new StreamWriter(fileLocation))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                foreach (var record in recordsToBeWritten)
                {
                    csv.WriteRecord(record);
                    csv.NextRecord();
                }

                writer.Flush();
            }
        }
    }
}

using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace CSV.Formatter
{
    public class CsvTimelogsWriter : ICsvTimelogsWriter
    {
        public async Task WriteFormattedTimelogsAsync(string fileLocation, List<Timelog> timelogsToBeWritten)
        {
            using (var writer = new StreamWriter(fileLocation))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                foreach (var timelog in timelogsToBeWritten)
                {
                    csv.WriteRecord(timelog);
                    await csv.NextRecordAsync();
                }

                writer.Flush();
            }

            Console.WriteLine(fileLocation);
            Console.ReadKey();
        }
    }
}

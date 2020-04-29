using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CSV.Formatter
{
    public class CsvTimelogsWriter : ICsvTimelogsWriter
    {
        public void WriteFormattedTimelogs(string fileLocation, List<Timelog> timelogsToBeWritten)
        {
            Console.WriteLine(fileLocation);
            Console.ReadKey();

            using (var writer = new StreamWriter(fileLocation))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                foreach (var timelog in timelogsToBeWritten)
                {
                    csv.WriteRecord(timelog);
                    csv.NextRecord();
                }

                writer.Flush();
            }
        }
    }
}

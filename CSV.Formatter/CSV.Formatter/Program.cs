using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CSV.Formatter
{
    class Program
    {
        static void Main()
        {
            var recordsToBeWritten = new List<dynamic>();
            string fileLocation = "C:\\Users\\Alexandra\\Documents\\Repositories\\Personal\\csv-formatter\\timelog.csv";
            string previousDate = null;

            using (var reader = new StreamReader(fileLocation))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    //csv.Configuration.HasHeaderRecord = false;

                    var records = csv.GetRecords<Timelog>();

                    foreach (var record in records)
                    {
                        string currentDate = record.Date;
                        string[] inlineRecords = record.Comment.Split(';');

                        for (var current = 0; current < inlineRecords.Length; current++)
                        {

                            if (inlineRecords[current] != "")
                            {
                                if (current == 0 && currentDate != previousDate && currentDate != "")
                                {
                                    recordsToBeWritten.Add(new { Date = "", Comment = "" });
                                    recordsToBeWritten.Add(new { Date = currentDate, Comment = inlineRecords[current].Trim(), Time = "08h 00m" });
                                }
                                else
                                {
                                    recordsToBeWritten.Add(new { Date = "", Comment = inlineRecords[current].Trim(), Time = "" });
                                }
                            }
                        }

                        previousDate = currentDate;
                    }
                }
            }

            WriteFormattedRecords(recordsToBeWritten, fileLocation);
        }

        private static void WriteFormattedRecords(List<dynamic> recordsToBeWritten, string fileLocation)
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

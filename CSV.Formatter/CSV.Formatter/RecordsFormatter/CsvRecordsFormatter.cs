using System.Collections.Generic;

namespace CSV.Formatter
{
    public class CsvRecordsFormatter : ICsvRecordsFormatter
    {
        public CsvRecordsFormatter()
        {
            RecordsToBeWritten = new List<Timelog>();
        }

        public List<Timelog> RecordsToBeWritten { get; set; }

        public void FormatEachRecord(IEnumerable<Timelog> records, string previousDate)
        {
            foreach (var record in records)
            {
                string currentDate = record.Date;
                string[] inlineRecords = record.Comment.Split(';');

                BuildRecords(currentDate, previousDate, inlineRecords);

                previousDate = currentDate;
            }
        }

        public void BuildRecords(string currentDate, string previousDate, string[] inlineRecords)
        {
            for (var current = 0; current < inlineRecords.Length; current++)
            {
                if (inlineRecords[current] != "")
                {
                    if (current == 0 && currentDate != previousDate && currentDate != "")
                    {
                        RecordsToBeWritten.Add(new Timelog { Date = "", Comment = "" });
                        RecordsToBeWritten.Add(new Timelog { Date = currentDate, Comment = inlineRecords[current].Trim(), Time = "08h 00m" });
                    }
                    else
                    {
                        RecordsToBeWritten.Add(new Timelog { Date = "", Comment = inlineRecords[current].Trim() });
                    }
                }
            }
        }
    }
}

using System.Collections.Generic;

namespace CSV.Formatter
{
    public class CsvTimelogsFormatter : ICsvTimelogsFormatter
    {
        public CsvTimelogsFormatter()
        {
            TimelogsToBeWritten = new List<Timelog>();
        }

        public List<Timelog> TimelogsToBeWritten { get; set; }

        public void FormatEachTimelog(IEnumerable<Timelog> timelogs, string previousDate)
        {
            foreach (var timelog in timelogs)
            {
                string currentDate = timelog.Date;
                string[] inlineTimelogs = timelog.Comment.Split(';');

                BuildTimelogs(currentDate, previousDate, inlineTimelogs);

                previousDate = currentDate;
            }
        }

        public void BuildTimelogs(string currentDate, string previousDate, string[] inlineTimelogs)
        {
            for (var current = 0; current < inlineTimelogs.Length; current++)
            {
                if (inlineTimelogs[current] != "")
                {
                    if (current == 0 && currentDate != previousDate && currentDate != "")
                    {
                        TimelogsToBeWritten.Add(new Timelog { Date = "", Comment = "" });
                        TimelogsToBeWritten.Add(new Timelog { Date = currentDate, Comment = inlineTimelogs[current].Trim(), Time = "08h 00m" });
                    }
                    else
                    {
                        TimelogsToBeWritten.Add(new Timelog { Date = "", Comment = inlineTimelogs[current].Trim() });
                    }
                }
            }
        }
    }
}

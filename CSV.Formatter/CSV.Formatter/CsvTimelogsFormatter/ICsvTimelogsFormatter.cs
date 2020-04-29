using System.Collections.Generic;

namespace CSV.Formatter
{
    public interface ICsvTimelogsFormatter
    {
        void FormatEachTimelog(IEnumerable<Timelog> timelogs, string previousDate);
        void BuildTimelogs(string currentDate, string previousDate, string[] inlineTimelogs);
    }
}

using System.Collections.Generic;

namespace CSV.Formatter
{
    public interface ICsvRecordsFormatter
    {
        void FormatEachRecord(IEnumerable<Timelog> records, string previousDate);
        void BuildRecords(string currentDate, string previousDate, string[] inlineRecords);
    }
}

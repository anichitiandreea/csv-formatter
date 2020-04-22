using System.Collections.Generic;

namespace CSV.Formatter
{
    public interface ICsvRecordsWriter
    {
        void WriteFormattedRecords(string fileLocation, List<Timelog> recordsToBeWritten);
    }
}

using System.Collections.Generic;

namespace CSV.Formatter
{
    public interface ICsvTimelogsWriter
    {
        void WriteFormattedTimelogs(string fileLocation, List<Timelog> recordsToBeWritten);
    }
}

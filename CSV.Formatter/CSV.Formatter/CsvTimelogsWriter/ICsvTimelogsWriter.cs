using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSV.Formatter
{
    public interface ICsvTimelogsWriter
    {
        Task WriteFormattedTimelogsAsync(string fileLocation, List<Timelog> recordsToBeWritten);
    }
}

using System.Threading.Tasks;

namespace CSV.Formatter
{
    public interface IRedmineCsvFormatter
    {
        Task FormatMonthlyReportAsync();
    }
}

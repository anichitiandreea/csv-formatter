using System.Threading.Tasks;

namespace CSV.Formatter
{
    class Program
    {
        static async Task Main()
        {

            var redmineCsvFormatter = new RedmineCsvFormatter();
            await redmineCsvFormatter.FormatMonthlyReportAsync();
        }
    }
}

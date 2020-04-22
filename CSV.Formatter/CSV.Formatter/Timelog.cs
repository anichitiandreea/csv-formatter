using CsvHelper.Configuration.Attributes;

namespace CSV.Formatter
{
    public class Timelog
    {
        public string Date { get; set; }
        public string Comment { get; set; }

        [Optional]
        public string Time { get; set; }
    }
}

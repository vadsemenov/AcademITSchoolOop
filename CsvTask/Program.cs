namespace CsvTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            var inputCsvFile = "..\\..\\csv.txt";
            var outputHtmlFile = "..\\..\\html.html";

            var csvToHtmlConverter = new CsvToHtmlConverter();

            csvToHtmlConverter.ConvertCsvToHtml(inputCsvFile, outputHtmlFile);
        }
    }
}

namespace CsvTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            var argsLength = args.Length;

            if (argsLength == 1 && args[0] == "-help")
            {
                ShowHelp();

                return;
            }

            if (argsLength != 2)
            {
                Console.WriteLine($"Количество аргументов должно быть равно 2! Сейчас {args.Length}.");

                ShowHelp();

                return;
            }

            var csvToHtmlConverter = new CsvToHtmlConverter();

            try
            {
                csvToHtmlConverter.ConvertCsvToHtml(args[0], args[1]);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ShowHelp()
        {
            Console.WriteLine("Для конвертирования документа нужно указать 2 параметра через пробел коммандной строки:");
            Console.WriteLine("1-Путь к исходному файлу csv.");
            Console.WriteLine("2-Путь к создаваемому файлу html.");
        }
    }
}

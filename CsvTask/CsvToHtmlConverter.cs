using System;
using System.IO;

namespace CsvTask;
public class CsvToHtmlConverter
{
    public void ConvertCsvToHtml(string inputCsvFileName, string outputHtmlFileName)
    {
        if (!File.Exists(inputCsvFileName))
        {
            throw new FileNotFoundException("Исходный файл не найден!", inputCsvFileName);
        }

        using var reader = new StreamReader(inputCsvFileName);
        using var writer = new StreamWriter(outputHtmlFileName);

        WriteHtmlDocumentStartingTags(writer, outputHtmlFileName);

        var isInQuotesToken = false;
        var needToCloseCurrentTrTagAndOpenNewTrTag = false;

        string line;
        while ((line = reader.ReadLine()) != null)
        {
            if (isInQuotesToken && line != "")
            {
                writer.Write("<br>");
            }

            if (needToCloseCurrentTrTagAndOpenNewTrTag && line != "")
            {
                WriteCurrentTrAndOpenNewTr(writer);
                needToCloseCurrentTrTagAndOpenNewTrTag = false;
            }

            var i = 0;

            while (i < line.Length)
            {
                var currentSymbol = line[i];

                if (isInQuotesToken)
                {
                    if (currentSymbol != '"')
                    {
                        WriteCurrentSymbol(writer, currentSymbol);
                    }
                    else
                    {
                        var nextSymbolIndex = i + 1;

                        if (nextSymbolIndex >= line.Length && reader.Peek() < 0)
                        {
                            WriteHtmlDocumentEndingTags(writer);

                            return;
                        }

                        if (nextSymbolIndex >= line.Length && reader.Peek() >= 0)
                        {
                            needToCloseCurrentTrTagAndOpenNewTrTag = true;
                            isInQuotesToken = false;
                        }
                        else if (line[nextSymbolIndex] == ',')
                        {
                            WriteCurrentTdAndOpenNewTd(writer);
                            isInQuotesToken = false;
                            i++;

                            if (i + 1 == line.Length)
                            {
                                WriteCurrentTrAndOpenNewTr(writer);
                            }
                        }
                        else
                        {
                            writer.Write(currentSymbol);
                            i++;
                        }
                    }
                }
                else
                {
                    if (currentSymbol != '"')
                    {
                        if (currentSymbol == ',')
                        {
                            WriteCurrentTdAndOpenNewTd(writer);
                        }
                        else
                        {
                            WriteCurrentSymbol(writer, currentSymbol);
                        }

                        if (i + 1 == line.Length && reader.Peek() >= 0)
                        {
                            needToCloseCurrentTrTagAndOpenNewTrTag = true;
                        }
                    }
                    else
                    {
                        isInQuotesToken = true;
                    }
                }

                i++;
            }
        }

        WriteHtmlDocumentEndingTags(writer);
    }

    private static void WriteCurrentTdAndOpenNewTd(StreamWriter writer)
    {
        writer.WriteLine("</td>");
        writer.Write("\t\t\t\t<td>");
    }

    private static void WriteCurrentTrAndOpenNewTr(StreamWriter writer)
    {
        writer.WriteLine("</td>");
        writer.WriteLine("\t\t\t</tr>");
        writer.WriteLine("\t\t\t<tr>");
        writer.Write("\t\t\t\t<td>");
    }

    private static void WriteHtmlDocumentStartingTags(StreamWriter writer, string title)
    {
        writer.WriteLine("<!DOCTYPE html>");
        writer.WriteLine("<html>");
        writer.WriteLine("\t<head>");
        writer.WriteLine("\t\t<meta charset=\"UTF-8\">");
        writer.WriteLine("\t\t<title>" + title + "</title>");
        writer.WriteLine("\t</head>");
        writer.WriteLine("\t<body>");
        writer.WriteLine("\t\t<table border=\"1\">");
        writer.WriteLine("\t\t\t<tr>");
        writer.Write("\t\t\t\t<td>");
    }

    private static void WriteHtmlDocumentEndingTags(StreamWriter writer)
    {
        writer.WriteLine("</td>");
        writer.WriteLine("\t\t\t</tr>");
        writer.WriteLine("\t\t</table>");
        writer.WriteLine("\t</body>");
        writer.Write("</html>");
    }

    private static void WriteCurrentSymbol(StreamWriter writer, char currentSymbol)
    {
        switch (currentSymbol)
        {
            case '<':
                writer.Write("&lt;");
                break;
            case '>':
                writer.Write("&gt;");
                break;
            case '&':
                writer.Write("&amp;");
                break;
            default:
                writer.Write(currentSymbol);
                break;
        }
    }
}

﻿namespace CsvTask;

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

        var isInQuotes = false;
        var needToCloseCurrentTrTagAndOpenNewTrTag = false;

        string line;

        while ((line = reader.ReadLine()) != null)
        {
            if (isInQuotes && line != "")
            {
                writer.Write("<br>");
            }

            if (needToCloseCurrentTrTagAndOpenNewTrTag && line != "")
            {
                WriteCurrentTrAndOpenNewTr(writer);
                needToCloseCurrentTrTagAndOpenNewTrTag = false;
            }

            for (int i = 0; i < line.Length; i++)
            {
                var currentSymbol = line[i];

                if (isInQuotes)
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

                        if (nextSymbolIndex >= line.Length)
                        {
                            needToCloseCurrentTrTagAndOpenNewTrTag = true;
                            isInQuotes = false;
                        }
                        else if (line[nextSymbolIndex] == ',')
                        {
                            WriteCurrentTdAndOpenNewTd(writer);
                            isInQuotes = false;
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
                    if (currentSymbol == '"')
                    {
                        isInQuotes = true;
                    }
                    else
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
                }
            }
        }

        WriteHtmlDocumentEndingTags(writer);
    }

    private static void WriteCurrentTdAndOpenNewTd(StreamWriter writer)
    {
        writer.WriteLine("</td>");
        writer.Write("\t\t\t<td>");
    }

    private static void WriteCurrentTrAndOpenNewTr(StreamWriter writer)
    {
        writer.WriteLine("</td>");
        writer.WriteLine("\t\t</tr>");
        writer.WriteLine("\t\t<tr>");
        writer.Write("\t\t\t<td>");
    }

    private static void WriteHtmlDocumentStartingTags(StreamWriter writer, string title)
    {
        writer.WriteLine("<!DOCTYPE html>");
        writer.WriteLine("<html>");
        writer.WriteLine("<head>");
        writer.WriteLine("<meta charset=\"UTF-8\">");
        writer.WriteLine("<title>" + title + "</title>");
        writer.WriteLine("</head>");
        writer.WriteLine("<body>");
        writer.WriteLine("\t<table border=\"1\">");
        writer.WriteLine("\t\t<tr>");
        writer.Write("\t\t\t<td>");
    }

    private static void WriteHtmlDocumentEndingTags(StreamWriter writer)
    {
        writer.WriteLine("</td>");
        writer.WriteLine("\t\t</tr>");
        writer.WriteLine("\t</table>");
        writer.WriteLine("</body>");
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

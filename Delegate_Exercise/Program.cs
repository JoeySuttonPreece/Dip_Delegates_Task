using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Security;
using FileParser;

public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise
{
    class Delegate_Exercise
    {
        static void Main(string[] args)
        {
            string readPath = "D:/OneDrive - Swinburne University/Sem3/Programming/week9/data.csv";
            string writePath = "D:/OneDrive - Swinburne University/Sem3/Programming/week9/processed_data.csv";

            DataParser dataParser = new DataParser();

            Func<List<List<string>>, List<List<string>>> parser = new Func<List<List<string>>, List<List<string>>>(dataParser.StripQuotes);
            parser += dataParser.StripWhiteSpace;
            parser += RemoveHashes;

            CsvHandler csvHandler = new CsvHandler();

            csvHandler.ProcessCsv(readPath, writePath, parser);
        }

        public static List<List<string>> RemoveHashes(List<List<string>> data)
        {
            Console.WriteLine(data[10][1]);
            foreach (var row in data)
            {
                for (var index = 0; index < row.Count; index++)
                {
                    if (row[index][0] == '#')
                        row[index] = row[index].Remove(0, 1);
                }
            }
            Console.WriteLine(data[10][1]);

            return data;
        }
    }
}

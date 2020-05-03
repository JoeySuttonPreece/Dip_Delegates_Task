using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileParser
{
    public class FileHandler
    {
        public FileHandler() { }

        /// <summary>
        /// Reads a file returning each line in a list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<string> ReadFile(string filePath)
        {
            List<string> lines = new List<string>(File.ReadAllLines(filePath));

            return lines; //-- return result here
        }

        /// <summary>
        /// Takes a list of a list of data.  Writes to file, using delimeter to seperate data.  Always overwrites.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="rows"></param>
        public void WriteFile(string filePath, char delimeter, List<List<string>> rows)
        {
            List<string> lines = rows.ConvertAll(new Converter<List<string>, string>((r) => string.Join(delimeter.ToString(), r)));

            File.WriteAllLines(filePath, lines);
        }

        /// <summary>
        /// Takes a list of strings and seperates based on delimeter.  Returns list of list of strings seperated by delimeter.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public List<List<string>> ParseData(List<string> data, char delimiter)
        {
            List<List<string>> result = data.ConvertAll(new Converter<string, List<string>>((d) => new List<string>(d.Split(delimiter))));

            return result; //-- return result here
        }

        /// <summary>
        /// Takes a list of strings and seperates on comma.  Returns list of list of strings seperated by comma.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> ParseCsv(List<string> data)
        {
            return ParseData(data, ',');  //-- return result here
        }
    }
}
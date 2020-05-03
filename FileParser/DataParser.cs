using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FileParser
{
    public class DataParser
    {
        /// <summary>
        /// Strips any whitespace before and after a data value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripWhiteSpace(List<List<string>> data)
        {
            foreach (var row in data)
            {
                for (var i = 0; i < row.Count; i++)
                {
                    row[i] = row[i].Trim();
                }
            }

            return data;
        }

        /// <summary>
        /// Strips quotes from beginning and end of each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripQuotes(List<List<string>> data)
        {
            foreach (var row in data)
            {
                for (var i = 0; i < row.Count; i++)
                {
                    if (row[i][0] == '\"')
                    {
                        row[i] = row[i].Remove(0, 1);
                    }

                    if (row[i][row[i].Length - 1] == '\"')
                    {
                        row[i] = row[i].Remove(row[i].Length - 1);
                    }
                }
            }

            return data;
        }
    }
}
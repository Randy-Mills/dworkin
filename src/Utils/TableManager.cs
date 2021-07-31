using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Dworkin.Models;
using Dworkin.Interfaces;
using System.IO;

namespace Dworkin.Utils {
    public class TableManager
    {
        public static string LoadJsonFromFileAsync(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        public static Table BuildTable(string tableFileName)
        {
            var json = TableManager.LoadJsonFromFileAsync(Directory.GetCurrentDirectory() + tableFileName);
            Table table = JsonSerializer.Deserialize<Table>(json);
            return table;
        }

        public static int GetTableSize(Table table)
        {
            var sum = 0;
            foreach (TableEntity te in table.entities)
            {
                sum = sum + te.weight;
            }
            return sum;
        }

        public static string Fetch(ITable table, int position)
        {
            var response = "";
            var pos = 0;
            foreach (TableEntity te in table.Table.entities)
            {
                if (Enumerable.Range(pos,pos+te.weight).Contains(position))
                {
                    response = te.value;
                    break;
                }

                pos = pos+te.weight;
            }
            return response;
        }
    }
}
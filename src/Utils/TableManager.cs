using System.Collections.Generic;
using System.Text.Json;
using Dworkin.Models;
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

        public static Percentile[] BuildTableFromJson(Table table)
        {
            var temp = new List<Percentile>();
            var pos = 0;
            foreach(var entity in table.entities)
            {
                temp.Add(new Percentile(pos, pos+entity.weight, entity.value));
                pos = pos+entity.weight;
            }
            return temp.ToArray();
        }
    }
}
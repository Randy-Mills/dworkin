using System.Collections.Generic;

namespace Dworkin.Models
{
    public class TableEntity
    {
        public int weight { get; set; }
        public string value { get; set; }
        public Dictionary<string, string> tags { get; set; }
    }
}
using System;
using System.Linq;
using Dworkin.Interfaces;
using Dworkin.Models;
using Dworkin.Utils;

namespace Dworkin.Tables.Injury
{
    public class FireInjury : ITable
    {
        private const string _tableJson = "/Tables/TableJson/injury_fire.json";

        public FireInjury()
        {
            Table = TableManager.BuildTable(_tableJson);
            TableSize = TableManager.GetTableSize(Table);
        }

        public Table Table { get; set; }
        public int TableSize { get; set; }
    }
}
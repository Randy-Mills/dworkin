using System;
using System.Linq;
using Dworkin.Interfaces;
using Dworkin.Models;
using Dworkin.Utils;

namespace Dworkin.Tables.AppearanceAdjectives
{
    public class AppearanceAdjectives : ITable
    {
        private const string _tableJson = "/Tables/TableJson/npc_appearances.json";

        public AppearanceAdjectives()
        {
            Table = TableManager.BuildTable(_tableJson);
            TableSize = TableManager.GetTableSize(Table);
        }

        public Table Table { get; set; }
        public int TableSize { get; set; }
    }
}
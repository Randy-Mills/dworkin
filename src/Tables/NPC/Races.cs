using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Dworkin.Interfaces;
using Dworkin.Models;
using Dworkin.Utils;
using System.IO;

namespace Dworkin.Tables.Races
{
    public class Races : ITable
    {
        private const string _tableJson = "/Tables/TableJson/npc_races.json";

        public Races()
        {
            Table = TableManager.BuildTable(_tableJson);
            TableSize = TableManager.GetTableSize(Table);
        }

        public Table Table { get; set; }
        public int TableSize { get; set; }
    } 
}
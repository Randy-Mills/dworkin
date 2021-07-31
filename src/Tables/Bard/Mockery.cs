using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Dworkin.Interfaces;
using Dworkin.Models;
using Dworkin.Utils;
using System.IO;

namespace Dworkin.Tables.Bard
{
    public class MockeryBard : ITable
    {
        private const string _tableJson = "/Tables/TableJson/bard_mockery.json";

        public MockeryBard()
        {
            Table = TableManager.BuildTable(_tableJson);
            TableSize = TableManager.GetTableSize(Table);
        }

        public Table Table { get; set; }
        public int TableSize { get; set; }
    }
}
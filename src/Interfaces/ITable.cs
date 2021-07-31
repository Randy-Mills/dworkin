using Dworkin.Models;

namespace Dworkin.Interfaces
{
    public interface ITable
    {
        Table Table { get; set; }
        int TableSize { get; set; }
    }
}
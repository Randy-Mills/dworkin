using Dworkin.Models;

namespace Dworkin.Interfaces
{
    public interface ITable
    {
        int Max { get; set; }
        int Min { get; set; }
        Percentile[] Table { get; set; }
        Table MainTable { get; set; }
        string Fetch(int position);
    }
}
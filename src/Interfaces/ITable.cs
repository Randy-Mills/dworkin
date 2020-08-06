using Generator.Models;

namespace Toolkit.Generator
{
    public interface ITable
    {
        int Max { get; set; }
        int Min { get; set; }
        Percentile[] Table { get; set; }
        string Fetch(int position);
    }
}
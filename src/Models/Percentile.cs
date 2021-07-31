namespace Dworkin.Models
{
    public class Percentile
    {
        public int min;
        public int max;
        public string value;

        public Percentile(int min, int max, string value)
        {
            this.min = min;
            this.max = max;
            this.value = value;
        }
    }
}
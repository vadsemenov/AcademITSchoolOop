namespace TemperatureTask.Model
{
    public class TemperatureScale
    {
        public string Name { get; set; } = null!;

        public double Offset { get; set; }

        public double Factor { get; set; }
    }
}
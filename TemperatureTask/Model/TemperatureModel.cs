using System.ComponentModel;

namespace TemperatureTask.Model
{
    public class TemperatureModel
    {
        public double SourceTemperature { get; set; }
        public double DestinationTemperature { get; set; }

        public TemperatureScale SelectedSourceScale { get; set; }
        public TemperatureScale SelectedDestinationScale { get; set; }

        public BindingList<TemperatureScale> SourceScales { get; } = new();
        public BindingList<TemperatureScale> DestinationScales { get; } = new();

        public TemperatureModel()
        {
            var celsiusScale = new TemperatureScale { Name = "Цельсия", Offset = 0, Factor = 1 };
            var fahrenheitScale = new TemperatureScale { Name = "Фаренгейта", Offset = 32, Factor = 100 / (212.0 - 32.0) };
            var kelvinScale = new TemperatureScale { Name = "Кельвина", Offset = 273.15, Factor = 100 / (373.15 - 273.15) };

            SourceScales.Add(celsiusScale);
            SourceScales.Add(fahrenheitScale);
            SourceScales.Add(kelvinScale);

            DestinationScales.Add(celsiusScale);
            DestinationScales.Add(fahrenheitScale);
            DestinationScales.Add(kelvinScale);

            SelectedSourceScale = SourceScales[0];
            SelectedDestinationScale = DestinationScales[0];
        }

        public void ConvertTemperature()
        {
            var absoluteTemperature = SelectedSourceScale.Factor * (SourceTemperature - SelectedSourceScale.Offset) + 273.15;

            DestinationTemperature = (absoluteTemperature - 273.15) / SelectedDestinationScale.Factor + SelectedDestinationScale.Offset;
        }
    }
}

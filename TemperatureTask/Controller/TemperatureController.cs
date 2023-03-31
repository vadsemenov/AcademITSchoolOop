using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using TemperatureTask.Model;

namespace TemperatureTask.Controller
{
    public class TemperatureController : INotifyPropertyChanged
    {
        private readonly TemperatureModel _model;

        public TemperatureScale SelectedSourceScale
        {
            get => _model.SelectedSourceScale;
            set => _model.SelectedSourceScale = value;
        }

        public TemperatureScale SelectedDestinationScale
        {
            get => _model.SelectedDestinationScale;
            set => _model.SelectedDestinationScale = value;
        }

        public BindingList<TemperatureScale> SourceScales => _model.SourceScales;
        public BindingList<TemperatureScale> DestinationScales => _model.DestinationScales;

        public string SourceTemperature
        {
            set
            {
                if (Double.TryParse(value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double temperature))
                {
                    _model.SourceTemperature = temperature;
                }
                else
                {
                    throw new ArgumentException("Введеное значение не является числом!");
                }

            }
        }

        public string DestinationTemperature => $"{_model.DestinationTemperature:F2}";

        public TemperatureController()
        {
            _model = new TemperatureModel();
        }

        public void ConvertTemperature(string sourceTemperatureValue)
        {
            try
            {
                SourceTemperature = sourceTemperatureValue;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _model.ConvertTemperature();

                OnPropertyChanged(nameof(DestinationTemperature));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
using System;
using System.Windows.Forms;
using TemperatureTask.Controller;

namespace TemperatureTask
{
    public partial class TemperatureConverterForm : Form
    {
        private readonly TemperatureController _controller = new TemperatureController();

        public TemperatureConverterForm()
        {
            InitializeComponent();

            sourceScaleComboBox.DataSource = _controller.SourceScales;
            sourceScaleComboBox.DisplayMember = "Name";
            sourceScaleComboBox.DataBindings.Add("SelectedItem", _controller, nameof(_controller.SelectedSourceScale), false, DataSourceUpdateMode.OnPropertyChanged);

            destinationScaleComboBox.DataSource = _controller.DestinationScales;
            destinationScaleComboBox.DisplayMember = "Name";
            destinationScaleComboBox.DataBindings.Add("SelectedItem", _controller, nameof(_controller.SelectedDestinationScale), false, DataSourceUpdateMode.OnPropertyChanged);

            temperatureLabel.DataBindings.Add("Text", _controller, nameof(_controller.DestinationTemperature), false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            _controller.ConvertTemperature(valueTextBox.Text);
        }
    }
}

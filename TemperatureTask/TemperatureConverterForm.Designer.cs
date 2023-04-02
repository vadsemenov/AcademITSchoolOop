namespace TemperatureTask
{
    partial class TemperatureConverterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.destinationScaleComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sourceScaleComboBox = new System.Windows.Forms.ComboBox();
            this.convertButton = new System.Windows.Forms.Button();
            this.temperatureLabel = new System.Windows.Forms.Label();
            this.valueGroupBox = new System.Windows.Forms.GroupBox();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.valueGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.convertButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.temperatureLabel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.valueGroupBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(592, 277);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.destinationScaleComboBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(215, 20);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(161, 98);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "В шкалу";
            // 
            // destinationScaleComboBox
            // 
            this.destinationScaleComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.destinationScaleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destinationScaleComboBox.FormattingEnabled = true;
            this.destinationScaleComboBox.Location = new System.Drawing.Point(10, 23);
            this.destinationScaleComboBox.Name = "destinationScaleComboBox";
            this.destinationScaleComboBox.Size = new System.Drawing.Size(141, 21);
            this.destinationScaleComboBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sourceScaleComboBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(20, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(155, 98);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Из шкалы";
            // 
            // sourceScaleComboBox
            // 
            this.sourceScaleComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceScaleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceScaleComboBox.FormattingEnabled = true;
            this.sourceScaleComboBox.Location = new System.Drawing.Point(10, 23);
            this.sourceScaleComboBox.Name = "sourceScaleComboBox";
            this.sourceScaleComboBox.Size = new System.Drawing.Size(135, 21);
            this.sourceScaleComboBox.TabIndex = 0;
            // 
            // convertButton
            // 
            this.convertButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.convertButton.Location = new System.Drawing.Point(416, 50);
            this.convertButton.Margin = new System.Windows.Forms.Padding(20, 50, 20, 0);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(156, 47);
            this.convertButton.TabIndex = 3;
            this.convertButton.Text = "Конвертировать значение";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // temperatureLabel
            // 
            this.temperatureLabel.AutoSize = true;
            this.temperatureLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.temperatureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.temperatureLabel.Location = new System.Drawing.Point(399, 138);
            this.temperatureLabel.Name = "temperatureLabel";
            this.temperatureLabel.Size = new System.Drawing.Size(190, 139);
            this.temperatureLabel.TabIndex = 4;
            this.temperatureLabel.Text = "0";
            this.temperatureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // valueGroupBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.valueGroupBox, 2);
            this.valueGroupBox.Controls.Add(this.valueTextBox);
            this.valueGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.valueGroupBox.Location = new System.Drawing.Point(20, 158);
            this.valueGroupBox.Margin = new System.Windows.Forms.Padding(20);
            this.valueGroupBox.Name = "valueGroupBox";
            this.valueGroupBox.Padding = new System.Windows.Forms.Padding(10);
            this.valueGroupBox.Size = new System.Drawing.Size(356, 99);
            this.valueGroupBox.TabIndex = 5;
            this.valueGroupBox.TabStop = false;
            this.valueGroupBox.Text = "Значение";
            // 
            // valueTextBox
            // 
            this.valueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.valueTextBox.Location = new System.Drawing.Point(26, 43);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(306, 20);
            this.valueTextBox.TabIndex = 0;
            this.valueTextBox.Text = "0";
            // 
            // TemperatureConverterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 277);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TemperatureConverterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Перевод температуры";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.valueGroupBox.ResumeLayout(false);
            this.valueGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox destinationScaleComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox sourceScaleComboBox;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.Label temperatureLabel;
        private System.Windows.Forms.GroupBox valueGroupBox;
        private System.Windows.Forms.TextBox valueTextBox;
    }
}


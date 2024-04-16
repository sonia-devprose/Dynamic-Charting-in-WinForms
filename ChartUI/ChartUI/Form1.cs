using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace ChartUI
{
    public partial class Form1 : Form
    {


        private ChartType currentChartType;
        private List<GapminderData> gapminderDataList;
        // Enum to represent chart types (defined within the Form1 class)
        private enum ChartType
        {
            Line,
            Column,
            Row
        }

        public Form1()
        {
            InitializeComponent();
            // Initialize ComboBox with chart type options
            comboBox1.Items.AddRange(Enum.GetNames(typeof(ChartType)));
            comboBox1.SelectedIndex = 0; // Select the first item by default

            // Set default chart type
            currentChartType = ChartType.Line;

            // Load and bind Gapminder data
            string filePath = "gapminder.json";
            gapminderDataList = ReadAndParseJsonData(filePath);
            if (gapminderDataList != null)
            {
                BindChart(); // Bind chart with default chart type
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update current chart type based on ComboBox selection
            currentChartType = (ChartType)Enum.Parse(typeof(ChartType), comboBox1.SelectedItem.ToString());

            // Re-bind chart with updated chart type
            BindChart();
        }

        private List<GapminderData> ReadAndParseJsonData(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                List<GapminderData> dataList = JsonConvert.DeserializeObject<List<GapminderData>>(json);

                // Ensure dataList is not null before returning
                if (dataList == null)
                {
                    MessageBox.Show("Failed to deserialize JSON data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<GapminderData>(); // Return empty list or handle error appropriately
                }

                return dataList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading JSON data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<GapminderData>(); // Return empty list or handle error appropriately
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void BindChart()
        {
            // Clear existing series from the chart
            chart1.Series.Clear();

            // Check if gapminderDataList is null or empty
            if (gapminderDataList == null || gapminderDataList.Count == 0)
            {
                MessageBox.Show("Gapminder data is not loaded or empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a new series for the selected chart type
            Series series = new Series();
            switch (currentChartType)
            {
                case ChartType.Line:
                    series.ChartType = SeriesChartType.Line;
                    series.Name = "Life Expectancy";
                    foreach (var data in gapminderDataList)
                    {
                        series.Points.AddXY(data.Year, data.LifeExp);
                    }
                    break;
                case ChartType.Column:
                    series.ChartType = SeriesChartType.Column;
                    series.Name = "GDP per Capita";
                    foreach (var data in gapminderDataList)
                    {
                        series.Points.AddXY(data.Year, data.GdpPercap);
                    }
                    break;
                case ChartType.Row:
                    series.ChartType = SeriesChartType.Bar;
                    series.Name = "Population";
                    foreach (var data in gapminderDataList)
                    {
                        series.Points.AddXY(data.Country, data.Pop);
                    }
                    break;
                default:
                    break;
            }

            // Add the series to the chart
            chart1.Series.Add(series);

            // Set axis labels
            chart1.ChartAreas[0].AxisX.Title = "Year/Country";
            chart1.ChartAreas[0].AxisY.Title = GetAxisLabel(currentChartType);
        }

        private string GetAxisLabel(ChartType chartType)
        {
            switch (chartType)
            {
                case ChartType.Line:
                    return "Life Expectancy";
                case ChartType.Column:
                    return "GDP per Capita";
                case ChartType.Row:
                    return "Population";
                default:
                    return string.Empty;
            }
        }

        
    }


    // Class representing Gapminder data structure
    public class GapminderData
    {
        public string Country { get; set; }
        public string Continent { get; set; }
        public int Year { get; set; }
        public double LifeExp { get; set; }
        public long Pop { get; set; }
        public double GdpPercap { get; set; }
    }



}

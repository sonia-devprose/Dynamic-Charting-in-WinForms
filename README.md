# Dynamic-Charting-in-WinForms
**Data Visualization using Chart UI (with Dynamic Charting) - mini sample**
This mini project offers basic data visualization of global development trends. Explore life expectancy, population, and GDP per capita using simple line, column, bar, and area charts. Import JSON or CSV datasets and interact with charts in a straightforward UI. Ideal for learning basic data visualization techniques. Suitable for educational purposes and beginner-friendly exploration of socio-economic data.

![Screenshot 2024-04-17 015954](https://github.com/sonia-devprose/Dynamic-Charting-in-WinForms/assets/161012720/2d88dafb-ba7c-48d7-a49a-5ac3da616405)
![Screenshot 2024-04-17 015941](https://github.com/sonia-devprose/Dynamic-Charting-in-WinForms/assets/161012720/e50bcd05-f2fc-4c47-8ec7-5d24b5c519c0)

This application, ChartUI, is designed to visualize Gapminder data using various chart types within a Windows Forms application. The data is loaded from a JSON file (gapminder.json) and displayed dynamically based on user-selected chart types such as Line, Column, or Row.

**Dependencies**
Newtonsoft.Json: This library is used for deserializing JSON data into C# objects.
Classes and Components
Form1 Class
Description: This class represents the main form of the application where the chart visualization is displayed.
Fields:
private ChartType currentChartType;: Represents the currently selected chart type.
private List<GapminderData> gapminderDataList;: Holds the parsed Gapminder data.
Enums:
private **enum ChartType**: Enumerates the supported chart types: Line, Column, and Row.
Methods:
public Form1(): Constructor initializes the form, loads chart types into ComboBox, and binds the default chart.
private void comboBox1_SelectedIndexChanged(object sender, EventArgs e): Handles ComboBox selection change event to update the chart type.
private void BindChart(): Binds the data to the chart based on the selected chart type.
private List<GapminderData> ReadAndParseJsonData(string filePath): Reads and parses Gapminder JSON data from the specified file path.

**GapminderData Class**
Description: Represents the structure of Gapminder data with properties for Country, Continent, Year, Life Expectancy (LifeExp), Population (Pop), and GDP per Capita (GdpPercap).
Methods Breakdown
Form1() Constructor:

Initializes the form components.
**Loads chart types into the ComboBox (comboBox1).**
Sets default chart type to Line.
Reads and parses Gapminder JSON data into gapminderDataList.
Binds the default chart based on the loaded data.
comboBox1_SelectedIndexChanged(object sender, EventArgs e):

Updates the current chart type based on the selected item in the ComboBox.
**Calls BindChart() to re-bind the chart with the updated chart type.**
BindChart():

Clears existing series from the chart (chart1).
Checks if data is available (gapminderDataList).
Creates a new series based on the selected chart type and adds data points accordingly.
Sets appropriate axis labels based on the selected chart type.
ReadAndParseJsonData(string filePath):

Reads JSON data from the specified file path.
Deserializes the JSON into a list of GapminderData objects.
Handles exceptions and displays error messages via MessageBox if parsing fails.

**Usage**
Launch the application (ChartUI).
The main form displays with a ComboBox to select chart types.
Upon form load, Gapminder data is loaded from gapminder.json and the default chart (Line) is displayed.
Select a different chart type from the ComboBox to visualize the data in the desired format (Line, Column, or Row).
Error Handling
Displays error messages via MessageBox for any exceptions encountered during JSON parsing or if data is not loaded correctly.

**Notes**
Ensure gapminder.json file exists in the application directory with valid Gapminder data.
The application is designed to provide dynamic visualization of Gapminder data using different chart types, facilitating analysis and comparison of key indicators over time or across countries.

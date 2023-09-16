using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WCS_Repository_DemoVersion;

namespace WeatherControlSystem;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly DataBaseEngine _databaseEngine;
    private readonly DataCreator _creator;

    public MainWindow()
    {
        InitializeComponent();
        _databaseEngine = DataBaseEngine.Instance;
        _creator = new DataCreator();
    }

    private void UpdateData_Click(object sender, RoutedEventArgs e)
    {
        if (CheckCorrectEnter())
        {
            if (_databaseEngine.CheckSubjectAndRegion(regionTextBox.Text, cityTextBox.Text))
            {
                MessageBox.Show("Данные уже имеются!");
                StatsForWeather.Content = null;
            }
            else
            {
                GetStats();
            }
        }
    }

    private void GetData_Click(object sender, RoutedEventArgs e)
    {
        if (CheckCorrectEnter())
        {
            if (_databaseEngine.CheckSubjectAndRegion(regionTextBox.Text, cityTextBox.Text))
            {
                GetStats();
            }
            else
            {
                MessageBox.Show("Обновите данные!");
                StatsForWeather.Content = null;
            }
        }
    }

    private void GetStats()
    {
        var countrySide = _databaseEngine.CreateRegion(regionTextBox.Text);
        var city = _databaseEngine.CreateSubjectOfTheRegion(cityTextBox.Text, countrySide.NameOfRegion);
        var weatherServiceGenerator = _databaseEngine.GetWeatherServiceGenerator(city.NameOfSubject);
        city.SetWeatherService(weatherServiceGenerator);
        var statsUserControl = new Stats_ContentControl(city, countrySide.NameOfRegion);
        StatsForWeather.Content = statsUserControl;
    }

    private void cityTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        if (char.IsLetter(Convert.ToChar(e.Text))) return;
        e.Handled = true;
    }

    private void regionTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        if (char.IsLetter(Convert.ToChar(e.Text))) return;
        e.Handled = true;
    }

    private bool CheckCorrectEnter()
    {
        if (cityTextBox.Text == "" || regionTextBox.Text == "") return false;
        return true;
    }


    private async void FillDataBase_Button_Click(object sender, RoutedEventArgs e)
    {
        await Task.Run(() => _creator.FillDB());
        MessageBox.Show("Выполнено");
    }

    private void DeleteSubject_Button_Click(object sender, RoutedEventArgs e)
    {
        _databaseEngine.DeleteSubject(cityTextBox.Text, regionTextBox.Text);
        MessageBox.Show("Готово");
    }
}
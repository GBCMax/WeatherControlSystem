using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WCS_BusinessLogic;

namespace WeatherControlSystem;

/// <summary>
///     Логика взаимодействия для StatsContentControl.xaml
/// </summary>
public partial class Stats_ContentControl : UserControl
{
    private readonly SubjectOfTheRegion _administrativeUnit;
    private readonly string _nameOfRegion;
    private readonly ObservableCollection<WeatherDataItemForRegion> _weatherDataRegion;
    private readonly ObservableCollection<WeatherDataItemForSubject> _weatherDataSubject;

    public Stats_ContentControl(SubjectOfTheRegion subjectOfRegion, string NameOfRegion)
    {
        InitializeComponent();
        _administrativeUnit = subjectOfRegion;
        _nameOfRegion = NameOfRegion;
        _weatherDataSubject = new ObservableCollection<WeatherDataItemForSubject>();
        _weatherDataRegion = new ObservableCollection<WeatherDataItemForRegion>();
    }

    private bool CheckData()
    {
        if (StartDate.SelectedDate.Value == null || EndDate.SelectedDate.Value == null ||
            StartDate.SelectedDate.Value < new DateTime(2023, 6, 1) ||
            EndDate.SelectedDate.Value > new DateTime(2023, 6, 30)) return false;
        return true;
    }

    private void GetStatsFoUnit_Button_Click(object sender, RoutedEventArgs e)
    {
        if (CheckData())
        {
            _weatherDataSubject.Clear();
            for (var i = 0; i < _administrativeUnit.WeatherService.DateTimes.Length; i++)
                if (_administrativeUnit.CheckPeriod(StartDate.SelectedDate.Value, EndDate.SelectedDate.Value, i))
                    _weatherDataSubject.Add(new WeatherDataItemForSubject
                    {
                        Date = _administrativeUnit.GetDate(i),
                        Temperature = _administrativeUnit.GetTemperature(i).ToString() + " C",
                        Pressure = _administrativeUnit.GetAtmosphericPressure(i).ToString() + " мм.рт.ст.",
                        WindSpeed = _administrativeUnit.GetWindSpeed(i).ToString() + " м/с",
                        Precipitation = _administrativeUnit.GetPrecipitation(i).ToString() + " %"
                    });
            TableForSubject.ItemsSource = _weatherDataSubject;
        }
        else
        {
            MessageBox.Show("Жизненный цикл программы с 01.06.2023 по 30.06.2023");
        }
    }

    private void GetStatsForRegion_Button_Click(object sender, RoutedEventArgs e)
    {
        if (CheckData())
        {
            _weatherDataRegion.Clear();
                _weatherDataRegion.Add(new WeatherDataItemForRegion
                {
                    Region = _nameOfRegion,
                    City = _administrativeUnit.NameOfSubject,
                    AverageTemperature = _administrativeUnit.GetAverageValue(_administrativeUnit.WeatherService.Temperatures,
                    StartDate.SelectedDate.Value, EndDate.SelectedDate.Value) + " C"
                    ,AveragePressure = _administrativeUnit.GetAverageValue(_administrativeUnit.WeatherService.AtmosphericPressures,
                    StartDate.SelectedDate.Value, EndDate.SelectedDate.Value) + " мм.рт.ст."
                    ,AverageWindSpeed = _administrativeUnit.GetAverageValue(_administrativeUnit.WeatherService.WindSpeeds,
                    StartDate.SelectedDate.Value, EndDate.SelectedDate.Value) + " м/с"
                    ,AveragePrecipitation = _administrativeUnit.GetAverageValue(_administrativeUnit.WeatherService.Precipitations,
                    StartDate.SelectedDate.Value, EndDate.SelectedDate.Value) + " %"
                });
            TableForRegion.ItemsSource = _weatherDataRegion;
        }
        else
        {
            MessageBox.Show("Введите период!");
        }
    }
}
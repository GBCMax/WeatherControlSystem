namespace WCS_BusinessLogic;

public class SubjectOfTheRegion
{
    public SubjectOfTheRegion(int id, string nameSubject)
    {
        IdSubject = id;
        NameOfSubject = nameSubject;
        WeatherService = new WeatherServiceGenerator();
    }

    public int IdSubject { get; private set; }
    public string NameOfSubject { get; private set; }
    public WeatherServiceGenerator WeatherService { get; private set; }

    public void SetWeatherService(WeatherServiceGenerator weatherService)
    {
        WeatherService = weatherService;
    }
    public bool CheckPeriod(DateTime startDate, DateTime endDate, int selectedDate)
    {
        if (WeatherService.DateTimes[selectedDate] >= startDate && WeatherService.DateTimes[selectedDate] <= endDate)
            return true;
        return false;
    }
    public string GetDate(int selectedDate)
    {
        return WeatherService.DateTimes[selectedDate].ToString().Remove(10);
    }
    public double GetTemperature(int selectedDate)
    {
        return Math.Round(WeatherService.Temperatures[selectedDate], 2);
    }
    public double GetAtmosphericPressure(int selectedDate)
    {
        return Math.Round(WeatherService.AtmosphericPressures[selectedDate], 2);
    }
    public double GetWindSpeed(int selectedDate)
    {
        return Math.Round(WeatherService.WindSpeeds[selectedDate], 2);
    }
    public double GetPrecipitation(int selectedDate)
    {
        return Math.Round(WeatherService.Precipitations[selectedDate], 2);
    }
    public double GetAverageValue(double[] mas, DateTime startDate, DateTime endDate)
    {
        return Math.Round(WeatherService.CalculateAverageUnit(mas, startDate, endDate), 2);
    }
}
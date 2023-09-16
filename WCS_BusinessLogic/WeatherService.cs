namespace WCS_BusinessLogic;

public class
    WeatherService
{
    public WeatherService(int id, DateTime date, double temperature, double pressure, double windSpeed,
        double precipitation)
    {
        IdWeatherService = id;
        Date = date;
        Temperature = temperature;
        Pressure = pressure;
        WindSpeed = windSpeed;
        Precipitation = precipitation;
    }

    public int IdWeatherService { get; private set; }
    public DateTime Date { get; private set; }
    public double Temperature { get; private set; }
    public double Pressure { get; private set; }
    public double WindSpeed { get; private set; }
    public double Precipitation { get; private set; }
}
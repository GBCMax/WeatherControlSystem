namespace WCS_Repository_DemoVersion;

public class WeatherServiceForEFCore
{
    public int IdWeatherService { get; set; }
    public DateTime Date { get; set; }
    public double Temperature { get; set; }
    public double Pressure { get; set; }
    public double WindSpeed { get; set; }

    public double Precipitation { get; set; }

    public virtual SubjectOfTheRegionForEFCore SubjectOfTheRegion { get; set; }
}
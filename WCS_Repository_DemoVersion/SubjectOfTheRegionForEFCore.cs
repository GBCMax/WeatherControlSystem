namespace WCS_Repository_DemoVersion;

public class SubjectOfTheRegionForEFCore
{
    public SubjectOfTheRegionForEFCore()
    {
        Weather = new List<WeatherServiceForEFCore>();
    }

    public int IdSubject { get; set; }
    public string NameOfSubject { get; set; }
    public int RegionId { get; set; }
    public virtual RegionForEFCore Region { get; set; }
    public virtual List<WeatherServiceForEFCore> Weather { get; set; }
}
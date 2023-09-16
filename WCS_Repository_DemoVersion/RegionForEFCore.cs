namespace WCS_Repository_DemoVersion;

public class RegionForEFCore
{
    public RegionForEFCore()
    {
        AdministrativeUnits = new List<SubjectOfTheRegionForEFCore>();
    }

    public int IdRegion { get; set; }
    public string NameOfRegion { get; set; }
    public virtual List<SubjectOfTheRegionForEFCore> AdministrativeUnits { get; set; }

    public void AddUnit(SubjectOfTheRegionForEFCore unit)
    {
        AdministrativeUnits.Add(unit);
    }
}
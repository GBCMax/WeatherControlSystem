namespace WCS_BusinessLogic;

public class CountrySide
{
    public CountrySide(int id, string nameRegion)
    {
        IdRegion = id;
        NameOfRegion = nameRegion;
        AdministrativeUnits = new List<SubjectOfTheRegion>();
    }

    public int IdRegion { get; private set; }
    public string NameOfRegion { get; private set; }
    public List<SubjectOfTheRegion> AdministrativeUnits { get; }

    public void AddUnit(SubjectOfTheRegion subjectOfTheRegion)
    {
        AdministrativeUnits.Add(subjectOfTheRegion);
    }
}
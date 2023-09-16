using WCS_BusinessLogic;

namespace WCS_Repository_DemoVersion;

public class Repository_DemoVersion:IDataBaseEngine
{
    private static readonly Lazy<Repository_DemoVersion> instance = new(() => new Repository_DemoVersion());
    private Repository_DemoVersion()
    {
    }
    public static Repository_DemoVersion Instance => instance.Value;

    public bool CheckRegion(string regionName)
    {
        throw new NotImplementedException();
    }

    public bool CheckSubjectAndRegion(string regionName, string subjectName)
    {
        throw new NotImplementedException();
    }

    public CountrySide CreateRegion(string regionName)
    {
        throw new NotImplementedException();
    }

    public SubjectOfTheRegion CreateSubjectOfTheRegion(string subjectName, string regionName)
    {
        throw new NotImplementedException();
    }

    public void DeleteSubject(string nameOfSubject, string nameOfRegion)
    {
        throw new NotImplementedException();
    }

    public CountrySide GetCountrySide(string nameOfRegion)
    {
        throw new NotImplementedException();
    }

    public SubjectOfTheRegion GetSubject(string nameOfSubject, CountrySide countrySide)
    {
        throw new NotImplementedException();
    }
}
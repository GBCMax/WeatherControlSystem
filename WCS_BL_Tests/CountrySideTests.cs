using WCS_BusinessLogic;

namespace WCS_BL_Tests;

public class CountrySideTests //тесты логики б€л€€€€€€€ когда это кончитс€
{
    [Fact]
    public void AddUnitTest()
    {
        //arrange
        CountrySide countrySide = new CountrySide(1," емеровска€ область");
        SubjectOfTheRegion subjectOfTheRegion = new SubjectOfTheRegion(1," емерово");
        //act
        countrySide.AddUnit(subjectOfTheRegion);
        //assert
        Assert.True(countrySide.AdministrativeUnits.Exists(x => x.IdSubject == subjectOfTheRegion.IdSubject));
    }
}
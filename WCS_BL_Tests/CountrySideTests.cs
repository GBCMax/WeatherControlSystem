using WCS_BusinessLogic;

namespace WCS_BL_Tests;

public class CountrySideTests //����� ������ ���������� ����� ��� ��������
{
    [Fact]
    public void AddUnitTest()
    {
        //arrange
        CountrySide countrySide = new CountrySide(1,"����������� �������");
        SubjectOfTheRegion subjectOfTheRegion = new SubjectOfTheRegion(1,"��������");
        //act
        countrySide.AddUnit(subjectOfTheRegion);
        //assert
        Assert.True(countrySide.AdministrativeUnits.Exists(x => x.IdSubject == subjectOfTheRegion.IdSubject));
    }
}
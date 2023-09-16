namespace WCS_BusinessLogic;

public class DateGenerator
{
    public DateTime[] EnterData(DateTime startDate, int interval)
    {
        var dT = new DateTime[interval];
        var day = startDate.Day;
        var month = startDate.Month;
        var year = startDate.Year;
        for (var i = 0; i < interval; i++)
        {
            if (day == 31)
            {
                day = 1;
                month++;
            }

            if (month == 13)
            {
                month = 1;
                year++;
            }

            if (month == 2 && day == 29)
            {
                month++;
                day = 1;
            }

            dT[i] = new DateTime(year, month, day);
            day++;
        }

        return dT;
    }
}
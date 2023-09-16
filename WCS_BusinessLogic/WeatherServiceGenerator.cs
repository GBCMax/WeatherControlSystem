using WCS_WeatherSensor;

namespace WCS_BusinessLogic;

public class WeatherServiceGenerator
{
    private DateTime _startDate = new DateTime(2023, 6, 1);
    private DateTime _endDate = new DateTime(2023, 6, 30);
    private readonly AtmosphericPressureGenerator _atmosphericPressureGenerator = new();
    private readonly DateGenerator _dateGenerator = new();
    private readonly PrecipitationGenerator _precipitationGenerator = new();
    private readonly TemperatureGenerator _temperatureGenerator = new();
    private readonly WindSpeedGenerator _windSpeedGenerator = new();

    public WeatherServiceGenerator()
    {
        var interval = (_endDate - _startDate).Days + 1;
        DateTimes = _dateGenerator.EnterData(_startDate, interval);
        Temperatures = _temperatureGenerator.GenerateArray(interval);
        AtmosphericPressures = _atmosphericPressureGenerator.GenerateArray(interval);
        WindSpeeds = _windSpeedGenerator.GenerateArray(interval);
        Precipitations = _precipitationGenerator.GenerateArray(interval);
    }

    public DateTime[] DateTimes { get; private set; }
    public double[] Temperatures { get; private set; }
    public double[] AtmosphericPressures { get; private set; }
    public double[] WindSpeeds { get; private set; }
    public double[] Precipitations { get; private set; }

    public double CalculateAverageUnit(double[] mas, DateTime startDate, DateTime endDate)
    {
        double average = 0;
        var k = 0;
        for (var i = 0; i < mas.Length; i++)
            if (DateTimes[i] >= startDate && DateTimes[i] <= endDate)
            {
                average += mas[i];
                k++;
            }

        return Math.Round(average / k, 2);
    }
}
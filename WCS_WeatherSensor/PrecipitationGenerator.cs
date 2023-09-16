namespace WCS_WeatherSensor;

public class PrecipitationGenerator : AbstractGenerator
{
    private Random _random = new Random();
    private int _startInterval = 0;
    private int _endInterval = 101;
    protected override double GenerateRandomValue()
    {
        double precipitationValue = _random.Next(_startInterval, _endInterval);
        return precipitationValue;
    }
}
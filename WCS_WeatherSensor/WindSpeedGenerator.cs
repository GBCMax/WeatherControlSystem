namespace WCS_WeatherSensor;

public class WindSpeedGenerator : AbstractGenerator
{
    private Random _random = new Random();
    private int _startInterval = 0;
    private int _endInterval = 25;
    protected override double GenerateRandomValue()
    {
        var speedValue = _random.Next(_startInterval, _endInterval) + Math.Round(_random.NextDouble(), 2);
        return speedValue;
    }
}
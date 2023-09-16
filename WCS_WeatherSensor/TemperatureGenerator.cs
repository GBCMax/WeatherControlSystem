namespace WCS_WeatherSensor;

public class TemperatureGenerator : AbstractGenerator
{
    private Random _random = new Random();
    private int _startInterval = 5;
    private int _endInterval = 37;
    protected override double GenerateRandomValue()
    {
        var temperature = _random.Next(_startInterval, _endInterval) + Math.Round(_random.NextDouble(), 2);
        return temperature;
    }
}
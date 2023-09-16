namespace WCS_WeatherSensor;

public class AtmosphericPressureGenerator : AbstractGenerator
{
    private Random _random = new Random();
    private int _startInterval = 641;
    private int _endInterval = 817;
    protected override double GenerateRandomValue()
    {
        double atmosphericPressureValue = _random.Next(_startInterval, _endInterval);
        return atmosphericPressureValue;
    }
}
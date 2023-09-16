namespace WCS_WeatherSensor;

public abstract class AbstractGenerator
{
    public double[] GenerateArray(int interval)
    {
        var array = new double[interval];
        for (var i = 0; i < array.Length; i++) array[i] = GenerateRandomValue();

        return array;
    }

    protected abstract double GenerateRandomValue();
}
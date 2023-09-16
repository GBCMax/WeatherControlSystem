using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_BusinessLogic;

namespace WCS_BL_Tests
{
    public class WeatherServiceGeneratorTests
    {
        [Fact]
        public void CalculateAverageUnitTest()
        {
            //arrange
            WeatherServiceGenerator weatherServiceGenerator = new WeatherServiceGenerator();
            double[] mas = new double[30];
            DateTime[] dateTimes = new DateTime[30];
            DateTime startDate = new DateTime(2023,6,5);
            DateTime endDate = new DateTime(2023, 6, 10);
            double expected = 7.5;
            for(int i = 0; i < mas.Length; i++)
            {
                dateTimes[i] = weatherServiceGenerator.DateTimes[0].AddDays(i);
                mas[i] = i + 1;
            }
            //act
            var actual = weatherServiceGenerator.CalculateAverageUnit(mas, startDate, endDate);
            //assert
            Assert.Equal(expected, actual);
        }
    }
}

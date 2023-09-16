using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_BusinessLogic;

namespace WCS_BL_Tests
{
    public class SubjectOfTheRegionTests
    {
        [Fact]
        public void SetWeatherServiceTest()
        {
            //arrange
            SubjectOfTheRegion subjectOfTheRegion = new SubjectOfTheRegion(1, "Междуреченск");
            WeatherServiceGenerator weatherServiceGenerator = new WeatherServiceGenerator();
            //act
            subjectOfTheRegion.SetWeatherService(weatherServiceGenerator);
            //assert
            Assert.Equal(weatherServiceGenerator, subjectOfTheRegion.WeatherService);
        }

        [Fact]
        public void CheckPeriodTestTrue()
        {
            //arrange
            WeatherServiceGenerator weatherServiceGenerator = new WeatherServiceGenerator();
            SubjectOfTheRegion subjectOfTheRegion = new SubjectOfTheRegion(1, "Междуреченск");
            subjectOfTheRegion.SetWeatherService(weatherServiceGenerator);
            //act
            //assert
            Assert.True(subjectOfTheRegion.CheckPeriod(new DateTime(2023, 6, 1), new DateTime(2023, 6, 5), 1));
        }

        [Fact]
        public void CheckPeriodTestFalse()
        {
            //arrange
            WeatherServiceGenerator weatherServiceGenerator = new WeatherServiceGenerator();
            SubjectOfTheRegion subjectOfTheRegion = new SubjectOfTheRegion(1, "Междуреченск");
            subjectOfTheRegion.SetWeatherService(weatherServiceGenerator);
            //act
            //assert
            Assert.False(subjectOfTheRegion.CheckPeriod(new DateTime(2023, 6, 1), new DateTime(2023, 6, 5), 15));
        }

        [Fact]
        public void GetDateTest()
        {
            //arrange
            WeatherServiceGenerator weatherServiceGenerator = new WeatherServiceGenerator();
            SubjectOfTheRegion subjectOfTheRegion = new SubjectOfTheRegion(1, "Междуреченск");
            subjectOfTheRegion.SetWeatherService(weatherServiceGenerator);
            string expected = subjectOfTheRegion.WeatherService.DateTimes[0].ToString().Remove(10);
            //act
            string actual = subjectOfTheRegion.GetDate(0);
            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetTemperature()
        {
            //arrange
            WeatherServiceGenerator weatherServiceGenerator = new WeatherServiceGenerator();
            SubjectOfTheRegion subjectOfTheRegion = new SubjectOfTheRegion(1, "Междуреченск");
            subjectOfTheRegion.SetWeatherService(weatherServiceGenerator);
            double expected = subjectOfTheRegion.WeatherService.Temperatures[0];
            //act
            double actual = subjectOfTheRegion.GetTemperature(0);
            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAtmosphericPressureTest()
        {
            //arrange
            WeatherServiceGenerator weatherServiceGenerator = new WeatherServiceGenerator();
            SubjectOfTheRegion subjectOfTheRegion = new SubjectOfTheRegion(1, "Междуреченск");
            subjectOfTheRegion.SetWeatherService(weatherServiceGenerator);
            double expected = subjectOfTheRegion.WeatherService.AtmosphericPressures[0];
            //act
            double actual = subjectOfTheRegion.GetAtmosphericPressure(0);
            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetWindSpeedTest()
        {
            //arrange
            WeatherServiceGenerator weatherServiceGenerator = new WeatherServiceGenerator();
            SubjectOfTheRegion subjectOfTheRegion = new SubjectOfTheRegion(1, "Междуреченск");
            subjectOfTheRegion.SetWeatherService(weatherServiceGenerator);
            double expected = subjectOfTheRegion.WeatherService.WindSpeeds[0];
            //act
            double actual = subjectOfTheRegion.GetWindSpeed(0);
            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetPrecipitationTest()
        {
            //arrange
            WeatherServiceGenerator weatherServiceGenerator = new WeatherServiceGenerator();
            SubjectOfTheRegion subjectOfTheRegion = new SubjectOfTheRegion(1, "Междуреченск");
            subjectOfTheRegion.SetWeatherService(weatherServiceGenerator);
            double expected = subjectOfTheRegion.WeatherService.Precipitations[0];
            //act
            double actual = subjectOfTheRegion.GetPrecipitation(0);
            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAverageValue()
        {
            //arrange
            WeatherServiceGenerator weatherServiceGenerator = new WeatherServiceGenerator();
            SubjectOfTheRegion subjectOfTheRegion = new SubjectOfTheRegion(1, "Междуреченск");
            subjectOfTheRegion.SetWeatherService(weatherServiceGenerator);
            DateTime startDate = new DateTime(2023,6,1);
            DateTime endDate = new DateTime(2023,6,4);
            double expected = 0;
            int interval = 4;
            for(int i = 0; i < interval; i++)
            {
                expected += subjectOfTheRegion.WeatherService.Temperatures[i];
            }
            expected = Math.Round(expected/interval,2);
            //act
            double actual = subjectOfTheRegion.GetAverageValue(subjectOfTheRegion.WeatherService.Temperatures, startDate, endDate);
            //assert
            Assert.Equal(expected, actual);
        }
    }
}

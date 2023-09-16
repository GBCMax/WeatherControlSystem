using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_BusinessLogic;

namespace WCS_BL_Tests
{
    public class DateGeneratorTests
    {
        [Fact]
        public void EnterDataTest()
        {
            for (int j = 0; j < 100; j++)
            {
                //arrange
                DateGenerator dateGenerator = new DateGenerator();
                DateTime dateTime = new DateTime(2023, 5, 1);
                //act
                DateTime[] dateTime1 = dateGenerator.EnterData(dateTime, 5);
                //assert
                for (int i = 0; i < dateTime1.Length; i++)
                {
                    var expected = dateTime.AddDays(i);
                    Assert.Equal(expected, dateTime1[i]);
                }
            }
        }
    }
}

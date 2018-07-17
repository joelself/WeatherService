using NUnit.Framework;
using Name;
using System;
using System.Collections.Generic;

namespace WeatherService.Test
{
    [TestFixture]
    public class WeatherServiceTest
    {
        [Test]
        public void AggregateOneDatum()
        {
            WeatherData datum = new WeatherData()
            {
                State = "Colorado",
                City = "Denver",
                Date = DateTime.Now,
                HighTemp = 20,
                LowTemp = 10
            };

            Name.WeatherService service = new Name.WeatherService();
            IEnumerable<CityAveragedWeatherData> results = service.AggregateWeatherData(new WeatherData[] { datum });
            CollectionAssert.Contains(results, new CityAveragedWeatherData() {
                State = "Colorado",
                City = "Denver",
                AverageHighTemp = 20,
                AverageLowTemp = 10
            });
        }
    }

    public static class Extensions
    {
        public static bool Equals(this CityAveragedWeatherData d, CityAveragedWeatherData other)
        {
            return d.City == other.City && d.State == other.State &&
                d.AverageHighTemp == other.AverageHighTemp && d.AverageLowTemp == other.AverageLowTemp;
        }
    }
}


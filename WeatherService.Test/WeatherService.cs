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
            CollectionAssert.Contains(results, new CityAveragedWeatherData()
            {
                State = "Colorado",
                City = "Denver",
                AverageHighTemp = 20,
                AverageLowTemp = 10
            });
        }

        [Test]
        public void AggregateData()
        {
            WeatherData data1 = new WeatherData()
            {
                State = "Colorado",
                City = "Denver",
                Date = DateTime.Now,
                HighTemp = 20,
                LowTemp = 0,
            };
            WeatherData data2 = new WeatherData()
            {
                State = "Colorado",
                City = "Denver",
                Date = DateTime.Now,
                HighTemp = 30,
                LowTemp = 10,
            };
            WeatherData data3 = new WeatherData()
            {
                State = "Colorado",
                City = "Denver",
                Date = DateTime.Now,
                HighTemp = 40,
                LowTemp = 20,
            };

            WeatherData data4 = new WeatherData()
            {
                State = "California",
                City = "San Francisco",
                Date = DateTime.Now,
                HighTemp = 15,
                LowTemp = -5,
            };

            WeatherData data5 = new WeatherData()
            {
                State = "California",
                City = "San Francisco",
                Date = DateTime.Now,
                HighTemp = 20,
                LowTemp = 0,
            };

            WeatherData data6 = new WeatherData()
            {
                State = "California",
                City = "San Francisco",
                Date = DateTime.Now,
                HighTemp = 25,
                LowTemp = 5,
            };

            Name.WeatherService service = new Name.WeatherService();
            IEnumerable<CityAveragedWeatherData> results = service.AggregateWeatherData(new WeatherData[] {
                data1, data2, data3, data4, data5, data6
            });
            CollectionAssert.Contains(results, new CityAveragedWeatherData()
            {
                State = "Colorado",
                City = "Denver",
                AverageHighTemp = 30,
                AverageLowTemp = 10
            });
            CollectionAssert.Contains(results, new CityAveragedWeatherData()
            {
                State = "California",
                City = "San Francisco",
                AverageHighTemp = 20,
                AverageLowTemp = 0
            });
        }
    }
}
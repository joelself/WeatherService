using System;
using System.Collections.Generic;

namespace Name
{
    //We are compiling a report on the average temperatures among various cities over each month. 
    //We receive individual daily data points from a weather service. 
    //Given a collection of data points over a given month, average the data into the requested format for easier reporting.

    //Please include tests in the testing framework you are most comfortable with.

    //We prefer your completed work in a Git repo.

    public class WeatherService
    {
        public IEnumerable<CityAveragedWeatherData> AggregateWeatherData(WeatherData[] inputData)
        {
            Dictionary<String, AggregateTemp> temps = new Dictionary<string, AggregateTemp>();
            foreach(WeatherData datum in inputData)
            {
                String name = GetName(datum);
                if(!temps.ContainsKey(name))
                {
                    temps.Add(name, new AggregateTemp() {
                        HighTemp = datum.HighTemp,
                        LowTemp = datum.LowTemp,
                        SampleCount = 1
                    });
                } else
                {
                    temps[name].HighTemp += datum.HighTemp;
                    temps[name].LowTemp += datum.LowTemp;
                    temps[name].SampleCount++;
                }
            }

            List<CityAveragedWeatherData> results = new List<CityAveragedWeatherData>();
            foreach(KeyValuePair<String, AggregateTemp> kvp in temps)
            {
                String[] names = SplitName(kvp.Key);
                CityAveragedWeatherData cityData = new CityAveragedWeatherData()
                {
                    State = names[0],
                    City = names[1],
                    AverageHighTemp = kvp.Value.HighTemp / kvp.Value.SampleCount,
                    AverageLowTemp = kvp.Value.LowTemp / kvp.Value.SampleCount
                };
                results.Add(cityData);
            }
            return results;
        }

        private String GetName(WeatherData datum)
        {
            return datum.State + ";" + datum.City;
        }

        private String[] SplitName(String name)
        {
            return name.Split(';');
        }

        private class AggregateTemp
        {
            public decimal HighTemp { get; set; }
            public decimal LowTemp { get; set; }
            public int SampleCount { get; set; }
        }
    }

    public class WeatherData
    {
        public string State { get; set; }
        public string City { get; set; }
        public DateTime Date { get; set; }
        public decimal HighTemp { get; set; }
        public decimal LowTemp { get; set; }
    }

    public class CityAveragedWeatherData
    {
        public string State { get; set; }
        public string City { get; set; }
        public decimal AverageHighTemp { get; set; }
        public decimal AverageLowTemp { get; set; }
    }
}
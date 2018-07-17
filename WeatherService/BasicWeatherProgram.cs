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
            Dictionary<String, Tuple<decimal, decimal, int>> temps = new Dictionary<string, Tuple<decimal, decimal, int>>();
            foreach(WeatherData datum in inputData)
            {
                String name = GetName(datum);
                if(!temps.ContainsKey(name))
                {
                    temps.Add(name, new Tuple<decimal, decimal, int>(datum.HighTemp, datum.LowTemp, 1));
                } else
                {
                    temps[name].+= datum.HighTemp;
                    temps[name].Item2 += datum.LowTemp;
                    temps[name].Item3++;
                }
            }

        }

        private String GetName(WeatherData datum)
        {
            return datum.State + ";" + datum.City;
        }

        private String[] SplitName(String name)
        {
            return name.Split(';');
        }

        private class TempAggregate
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
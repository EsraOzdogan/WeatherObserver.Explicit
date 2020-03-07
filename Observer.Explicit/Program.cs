using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace WeatherOMatic_Explicit
{
    class Program
    {
        static void Main(string[] args)
        {
			// create the subject and observers
			WeatherData weatherData = new WeatherData();
			weatherData.Humidity = 40.5F;
			weatherData.Pressure = 20F;
			weatherData.Temperature = 72F;
			weatherData.PropertyChanged += degis;
			void degis(object sender, PropertyChangedEventArgs e)
			{
				Console.WriteLine("sıcaklık: "+weatherData.Temperature+"basınç: "+ weatherData.Pressure+"nem: "+ weatherData.Humidity);
			}

			CurrentConditions conditions = new CurrentConditions(weatherData);
            //Statistics statistics = new Statistics(weatherData);
            Forecast forecast = new Forecast(weatherData);

            // create the readings
            WeatherMeasurements readings = new WeatherMeasurements();
            readings.Humidity = 40.5F;
            readings.Pressure = 20F;
            readings.Temperature = 72F;

           // update the readings - everyone should print
           weatherData.UpdateReadings(readings);

            // update
            //readings.Pressure = 10F;
            //weatherData.UpdateReadings(readings);

            // update
            //readings.Humidity = 100;
            //readings.Temperature = 212.75F;
            //readings.Pressure = 950;
            //weatherData.UpdateReadings(readings);*/
			Console.ReadLine();
        }
    }
}

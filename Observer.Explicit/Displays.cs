using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace WeatherOMatic_Explicit
{
    class CurrentConditions : IDisplay, IObserver/*, IDisposable*/
    {
		private INotifyPropertyChanged weatherData = null;
       // private ISubject weatherData = null;
        private WeatherMeasurements readings = new WeatherMeasurements();
        public CurrentConditions(INotifyPropertyChanged newWeatherData)
        {
            this.weatherData = newWeatherData;
			Display();
        }

        /*private void UnRegister()
        {
            if (this.weatherData != null)
                this.weatherData.UnRegister(this);
        }*/

        #region IDisplay Members

        public void Display()
        {
            Console.WriteLine("Current conditions: {0}F degrees and {1}% humidity.",
                this.readings.Temperature, this.readings.Humidity);
        }

        #endregion

        #region IObserver Members

        public void Update(WeatherMeasurements newReadings)
        {
            this.readings = newReadings;
            Display();
        }

        #endregion

      /*  #region IDisposable Members

       public void Dispose()
        {
            this.UnRegister();
        }
        
        #endregion*/
    }

   /* class Statistics : IDisplay, IObserver, IDisposable
    {
        private ISubject weatherData = null;
        private WeatherMeasurements readings = new WeatherMeasurements();

        public Statistics(ISubject newWeatherData)
        {
            this.weatherData = newWeatherData;
            this.weatherData.Register(this);
        }

        private void UnRegister()
        {
            if (this.weatherData != null)
                this.weatherData.UnRegister(this);
        }

        #region IDisplay Members

        public void Display()
        {
            Console.WriteLine("Statistic: Sum of values: {0}.",
                this.readings.Temperature + this.readings.Humidity + this.readings.Pressure);
        }

        #endregion

        #region IObserver Members

        public void Update(WeatherMeasurements newReadings)
        {
            this.readings = newReadings;
            Display();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
	*/
    class Forecast : IDisplay, IObserver, IDisposable
    {
        private INotifyPropertyChanged weatherData = null;
        private WeatherMeasurements readings = new WeatherMeasurements();

        public Forecast(INotifyPropertyChanged newWeatherData)
        {
            this.weatherData = newWeatherData;
			Display();
           // this.weatherData.Register(this);
        }

        /*private void UnRegister()
        {
            if (this.weatherData != null)
                this.weatherData.UnRegister(this);
        }*/

        #region IDisplay Members

        public void Display()
        {
            Console.WriteLine("Forecast: {0}F degress and {1}% humidity.",
                this.readings.Temperature + 13.3,
                this.readings.Humidity - 13.3);
        }

        #endregion

        #region IObserver Members

        public void Update(WeatherMeasurements newReadings)
        {
            this.readings = newReadings;
            Display();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

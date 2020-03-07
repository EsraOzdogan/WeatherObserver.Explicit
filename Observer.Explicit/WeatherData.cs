using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace WeatherOMatic_Explicit
{
	// create readings as struct so new readings don't require many changes
	struct WeatherMeasurements
	 {
		 public float Temperature;
		 public float Humidity;
		 public float Pressure;
	 }

	class WeatherData : INotifyPropertyChanged/*, ISubject*/
	{

		public event PropertyChangedEventHandler PropertyChanged;
		private float temperature;
		public float Temperature
		{
			get => temperature;
			set
			{
				temperature = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(temperature)));
			}
		}
		private float humidity;
		public float Humidity
		{
			get => humidity;
			set
			{
				humidity = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(humidity)));
			}
		}
	
		private float pressure;
		public float Pressure
		{
			get => pressure;
			set
			{
				pressure = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(pressure)));
			}
		}


		private List<IObserver> observers = new List<IObserver>();
		 private WeatherMeasurements readings = new WeatherMeasurements();
				// for refined control over when observers are notified
		/*public void HasChanged()
        {
            Notify();
        }*/

        public void UpdateReadings(WeatherMeasurements newReadings)
        {
            this.readings = newReadings;
           // HasChanged();
        }

        /*#region ISubject Members

        public void Register(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public void UnRegister(IObserver observer)
        {
            this.observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (IObserver observer in this.observers)
                observer.Update(this.readings);
        }

        #endregion*/
    }
}

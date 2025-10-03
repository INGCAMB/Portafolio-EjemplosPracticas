using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloPatronObserver
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();

            CurrentConditionalDisplay currentConditionalDisplay =
                new CurrentConditionalDisplay(weatherData);
            //StatisticsDisplay statisticsDisplay = new StatisticsDisplay(weatherData);
            //ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData);

            weatherData.setMessurements(80, 65, 30.4f);
            weatherData.setMessurements(82, 70, 29.2f);
            weatherData.setMessurements(78, 90, 29.2f);

            Console.ReadKey();
        }

        public class WeatherData: Subject
        {
            private List<Observer> observers;
            private float temperature;
            private float humidity;
            private float pressure;

            public WeatherData()
            {
                observers = new List<Observer>();
            }
            public void registerObserver(Observer o)
            {
                observers.Add(o);
            }

            public void removeObserver(Observer o)
            {
                observers.Remove(o);
            }

            public void notifyObservers()
            {
                foreach (Observer observer in observers)
                {
                    observer.update(temperature, humidity, pressure);
                }
            }

            public void messurementsChanged()
            {
                notifyObservers();
            }

            public void setMessurements(float temperature, float humidity, float pressure)
            {
                this.temperature = temperature;
                this.humidity = humidity;
                this.pressure = pressure;
                messurementsChanged();
            }
        }

        public class CurrentConditionalDisplay: Observer, DisplayElement
        {
            private float temperature;
            private float humidity;
            private WeatherData weatherData;

            public CurrentConditionalDisplay(WeatherData weatherData)
            {
                this.weatherData = weatherData;
                weatherData.registerObserver(this);
            }

            public void update(float temperature, float humidity, float pressure)
            {
                this.temperature = temperature;
                this.humidity = humidity;
                display();
            }

            public void display()
            {
                Console.Write("Current conditions: " + temperature + "F degress and " + humidity + "% humidity" + "\n");
            }
        }

        public interface Subject
        {
            public void registerObserver(Observer o);
            public void removeObserver(Observer o);
            public void notifyObservers();

        }

        public interface Observer
        {
            public void update(float temperature, float humidity, float pressure);
        }

        public interface DisplayElement
        {
            public void display();
        }
    }
}

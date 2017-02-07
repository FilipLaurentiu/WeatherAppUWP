using RemakeWindowsWeather.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemakeWindowsWeather.ViewModels
{
    public class CommandViewModel :INotifyPropertyChanged
    {
        public Command ShowWeather { get; set; }
        private string weatherProp;

        public string WeatherProp
        {
            get { return weatherProp; }
            set { weatherProp = value;
            }
        }
        

        public CommandViewModel()
        {
            ShowWeather = new Command(canExecuteMethod, executeMethod);
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        private bool canExecuteMethod(object parameter)
        {
            return true;
            
        }
        private async void executeMethod(object parameter)
        {
            var pos = await LocationManager.GetLocation();

            var lat = pos.Coordinate.Latitude;
            var lon = pos.Coordinate.Longitude;
            
            var weather = await WeatherProxyMap.GetWeather(lon, lat);
            if (weather != null)
            {
                WeatherProp = weather.main.temp + " " + weather.name;
                this.OnPropertyChanged("WeatherProp");
            }
        }



    }
}

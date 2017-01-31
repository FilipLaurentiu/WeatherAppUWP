using RemakeWindowsWeather.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RemakeWindowsWeather
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
        }



        //private async void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var pos = await LocationManager.GetLocation();

        //    var lat = pos.Coordinate.Latitude;
        //    var lon = pos.Coordinate.Latitude;


        //    var weather = await WeatherProxyMap.GetWeather(lat, lon);

        //    WeatherCondition.Text = ((int)weather.main.temp).ToString() + " " + weather.name;
        //}

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var citySearch = CitySearch.Text;

            var weather = await WeatherProxyMapByCity.GetWeather(citySearch);
            CityNameTxtBlock.Text = ((int)weather.main.temp).ToString() + " " + weather.name;
        }
    }
}

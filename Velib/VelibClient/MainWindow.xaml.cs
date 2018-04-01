using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using VelibClient.ServiceVelib;

namespace VelibClient
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Station> stations;
        private VelibIntermediaryClient velibClient;

        public MainWindow()
        {
            velibClient = new ServiceVelib.VelibIntermediaryClient();
            InitializeComponent();
            GetCities();
            CityName.SelectionChanged += GetSations;
            StationName.TextChanged += (sender, args) =>
            {
                StationView.ItemsSource = stations.FindAll(station =>
                    station.Name.ToLowerInvariant().Contains(StationName.Text.ToLowerInvariant()));
            };
        }

        private async void GetCities()
        {
            CityName.ItemsSource = await velibClient.GetContractsAsync();
        }


        private async void GetSations(object sender, RoutedEventArgs routedEventArgs)
        {
            stations = new List<Station>(await velibClient.GetStationsAsync(((Contract) CityName.SelectedValue).name));
            stations.Sort((station, station1) => station.available_bikes - station1.available_bikes);
            StationView.ItemsSource = stations;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace VelibMonitoringClient
{
    
    public partial class MainWindow : Window
    {
        private VelibMonitoring.MonitoringClient client;

        public MainWindow()
        {
            client = new VelibMonitoring.MonitoringClient();
            InitializeComponent();
            OKnbConnections.Click += OKnbConnectionsOnClick;
            OknbRemoteRequests.Click += OknbRemoteRequestsOnClick;
            Oknames.Click += OknamesOnClick;
        }

        private async void OKnbConnectionsOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            if (int.TryParse(InputnbConnections.Text, out var n))
            {
                var i = await client.GetNbClientCallsAsync(n);
                NbConnections.Content = i;
            }
        }

        private async void OknbRemoteRequestsOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            if (int.TryParse(InputnbRemoteRequests.Text, out var n))
            {
                var i = await client.GetNbDistantRequestAsync(n);
                NbRemoteRequests.Content = i;
            }
        }

        private async void OknamesOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
          
            var names = await client.GetNamesOfCachedItemsAsync();
            Names.ItemsSource = names;
        }
    }
}
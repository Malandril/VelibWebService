using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using MathClient.MathsService;

namespace MathClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string firstEndpointName = "first";
        private string secondEndpointName = "second";
        private MathsServiceClient firstEndpoint;
        private MathsServiceClient secondEndpoint;

        public MainWindow()
        {
            InitializeComponent();
            firstEndpoint = new MathsService.MathsServiceClient(firstEndpointName);
            secondEndpoint = new MathsService.MathsServiceClient(secondEndpointName);
            OperatorBox.ItemsSource = new List<string>() {"+", "/"};
            EndpointBox.ItemsSource = new List<string>() {firstEndpointName, secondEndpointName};
            EqualButton.Click += EqualsOnClick;
        }

        private void EqualsOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            if (int.TryParse(A.Text, out var a) && int.TryParse(B.Text, out var b))
            {
                try
                {
                    if ((string) EndpointBox.SelectedItem == firstEndpointName)
                    {
                        SelectOperation(a, b, firstEndpoint);
                    }
                    else
                    {
                        SelectOperation(a, b, secondEndpoint);
                    }
                }
                catch (FaultException<DivideFault> e)
                {
                    MessageBox.Show(e.Detail.Reason);
                }
            }
        }

        private void SelectOperation(int a, int b, MathsServiceClient mathsService)
        {
            Result.Content = (string) OperatorBox.SelectedItem == "+" ? mathsService.Add(a, b) : mathsService.Div(a, b);
        }
    }
}
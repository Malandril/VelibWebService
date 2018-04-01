using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelibConsoleClient.ServiceVelib;

namespace VelibConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting client");
            var client = new ServiceVelib.VelibIntermediaryClient();
            Console.WriteLine("Client connected");
            Console.WriteLine("Enter a command (type help for help)");
            while (true)
            {
                var command = Console.ReadLine();
                getCommand(command, client);
            }
        }

        private static async void getCommand(string command, VelibIntermediaryClient client)
        {
            switch (command)
            {
                case nameof(client.GetStations):
                    Console.Write("City name: ");
                    var city = Console.ReadLine();
                    var stations = await client.GetStationsAsync(city);
                    foreach (var station in stations)
                    {
                        Console.WriteLine($"{station.Name} available bikes: {station.available_bikes}");
                    }

                    break;
                case nameof(client.GetContracts):
                    var contracts = await client.GetContractsAsync();
                    foreach (var contract in contracts)
                    {
                        Console.WriteLine(contract.name);
                    }

                    Console.WriteLine("KOLOLOLOOO");
                    Console.WriteLine(contracts);
                    break;
                case "exit":
                    System.Environment.Exit(0);
                    break;
                default:
                {
                    Console.WriteLine("The commands are");
                    Console.WriteLine(nameof(client.GetContracts));
                    Console.WriteLine(nameof(client.GetStations));
                    Console.WriteLine("exit");
                    Console.WriteLine("help");
                    break;
                }
            }
        }
    }
}
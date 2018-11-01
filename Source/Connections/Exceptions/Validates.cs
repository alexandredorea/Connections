using Connections.Entities;
using System;
using System.Linq;

namespace Connections.Exceptions
{
    public class Validates
    {
        public static bool ValidateNetwork(string[] connections, NetworkUniverse universo)
        {
            int[] connected = new int[2];

            if (connections == null || connections.Length != 2)
            {
                Console.WriteLine($"Informação inválida");
                Console.ReadKey();
                return false;
            }
            
            if (!int.TryParse(connections[0], out connected[0]) || 
                !int.TryParse(connections[1], out connected[1]))
            {
                Console.WriteLine($"Informação inválida");
                Console.ReadKey();
                return false;
            }

            if (connected[0] < 0 || connected[1] < 0)
            {
                Console.WriteLine($"Informação inválida");
                Console.WriteLine($"Os números informados precisam ser números positivos e inteiros.");
                Console.ReadKey();
                return false;
            }

            if (connected.Length != connected.Distinct().Count())
            {
                Console.WriteLine($"Informação inválida");
                Console.WriteLine($"Os números informados precisam ser diferentes");
                Console.ReadKey();
                return false;
            }

            if (connected[0] > universo.QtNetwork || connected[1] > universo.QtNetwork)
            {
                Console.WriteLine($"Informação inválida");
                Console.WriteLine($"Os números devem ser de 0 à {universo.QtNetwork}.");
                Console.ReadKey();
                return false;
            }

            return true;
        }
    }
}
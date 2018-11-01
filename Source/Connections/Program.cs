using Connections.Entities;
using Connections.Exceptions;
using System;
using System.Collections.Generic;

namespace Connections
{
    internal class Program
    {
        protected static void Main()
        {
            Console.Clear();
            NetworkUniverse networkUniverse = new NetworkUniverse(GetElements());
            Console.Clear();
            SetConnections(networkUniverse);
            Console.Clear();
            GetConnections(networkUniverse);
            Console.ReadKey();
        }

        private static int GetElements()
        {
            bool isPositiveNumber = false;
            int numberElements = 0;

            do
            {
                Console.Clear();
                Console.Write("Informe um número positivo inteiro para determinar o número de elementos: ");
                isPositiveNumber = int.TryParse(Console.ReadLine(), out numberElements);

                if (!isPositiveNumber && numberElements < 1)
                {
                    Console.Clear();
                    Console.WriteLine("Informação inválida.");
                    Console.ReadKey();
                }

            } while (!isPositiveNumber);

            return numberElements;
        }

        private static void GetConnections(NetworkUniverse networkUniverse)
        {
            var element1 = string.Empty;
            var element2 = string.Empty;
            var opcao = string.Empty;

            do
            {
                Console.WriteLine("Deseja realizar consulta das conexões? ");
                Console.Write("Digite [S] se deseja continuar: ");
                opcao = Console.ReadLine().ToUpper();

                if (opcao.Equals("S"))
                {
                    Console.WriteLine("Digite o primeiro elemento: ");
                    element1 = Console.ReadLine();
                    Console.WriteLine("Digite o segundo elemento: ");
                    element2 = Console.ReadLine();

                    if (networkUniverse.Query(Convert.ToInt32(element1), Convert.ToInt32(element2)))
                    {
                        Console.WriteLine($"Os números {element1} e {element2} estão conectados");
                    }
                    else
                    {
                        Console.WriteLine($"Os números {element1} e {element2} não estão conectados");
                    }
                }

            } while (opcao.Equals("S"));
        }
        
        private static NetworkUniverse SetConnections(NetworkUniverse networkUniverse)
        {
            List<string> connections = new List<string>();

            do
            {
                ValidadeConnections(networkUniverse, connections);

                networkUniverse.Connect(Convert.ToInt32(connections[0]),
                                        Convert.ToInt32(connections[1]));

                Console.Clear();
                Console.WriteLine("Deseja inserir mais uma conexão?");
                Console.Write("Digite [S] se deseja continuar: ");

            } while (Console.ReadLine().ToUpper().Equals("S"));

            return networkUniverse;
        }

        private static void ValidadeConnections(NetworkUniverse networkUniverse, List<string> connections)
        {
            do
            {
                for (int index = 0; index < 2; index++)
                {
                    Console.Clear();
                    Console.Write($"Informe o {index + 1}º numero para ligação: ");
                    connections.Add(Console.ReadLine());
                }

            } while (!Validates.ValidateNetwork(connections.ToArray(), networkUniverse));
        }
    }
}
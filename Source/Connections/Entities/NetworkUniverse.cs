using System.Collections.Generic;

namespace Connections.Entities
{
    public class NetworkUniverse
    {
        private IDictionary<Network, int> Networks = new Dictionary<Network, int>();
        public int QtNetwork { get;  set; }

        public NetworkUniverse(int qtNetwork)
        {
            QtNetwork = qtNetwork;
            GenerateNetwork(QtNetwork);
        }

        public void GenerateNetwork(int qtNetwork)
        {
            for (int item = 1; item < qtNetwork; item++)
            {
                var connection = new Network(item);
                Networks.Add(connection, item);
            }
        }

        public bool Connect(int element1, int element2)
        {
            foreach (var items in Networks.Keys)
            {
                items.Connect(element1, element2);
            }

            return true;
        }

        public bool Query(int element1, int element2)
        {
            foreach (var items in Networks.Keys)
            {
                if (items.Query(element1, element2))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
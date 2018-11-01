using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Connections.Entities
{
    public class Network
    {
        private ArrayList elementsList = new ArrayList();
        public Network(int networkId)
        {
            NetworkId = networkId;
            elementsList.Add(NetworkId);
        }

        public int NetworkId { get; set; }

        public void Connect(int elementNumber1, int elementNumber2)
        {
            bool element1Exists = false;
            bool element2Exists = false;

            foreach (int item in elementsList)
            {
                if (item == elementNumber1)
                    element1Exists = true;

                if (item == elementNumber2)
                    element2Exists = true;
            }

            if (element1Exists && !element2Exists)
                elementsList.Add(elementNumber2);

            if (!element1Exists && element2Exists)
                elementsList.Add(elementNumber1);

            if (!element1Exists && !element2Exists) { }//Exceção 
        }

        public bool Query(int elementNumber1, int elementNumber2)
        {
            var element1Exists = false;
            var element2Exists = false;

            foreach (int item in elementsList)
            {
                if (item == elementNumber1)
                    element1Exists = true;

                if (item == elementNumber2)
                    element2Exists = true;
            }

            return (element1Exists && element2Exists);
        }
    }
}

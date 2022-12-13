using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirézia.Model
{
    public class Room
    {
        public bool isEmpty = true;
        public bool isHeated = false;
        public int temperature = 20;
        public int HeatingCost
        {
            get
            {
                if (isHeated)
                {
                    return 100;
                }
                else
                {
                    return 0;
                }
            }
        }
        public Room(bool isEmpty)
        {
            this.isEmpty = isEmpty;
            if (!isEmpty)
            {
                temperature = 20 + (Random.Shared.Next() % 3);
                isHeated = true;
            }
        }
        public void TemperatureChange()
        {
            if (isEmpty)
            {
                return;
            }
            if (isHeated)
            {
                temperature += 2;
            }
            else
            {
                int rand = Random.Shared.Next() % 10;
                if (rand < 3)
                {
                    temperature -= 1;
                }
                else if(rand < 6)
                {
                    temperature -= 2;
                }
            }
        }
        public void SwitchHeating()
        {
            if (isEmpty)
            {
                return;
            }
            isHeated = !isHeated;
        }
    }
}

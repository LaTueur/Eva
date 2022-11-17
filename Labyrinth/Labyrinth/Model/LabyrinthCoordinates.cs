using System;
using System.Collections.Generic;
using System.Text;

namespace Labyrinth.Model
{
    internal struct LabyrinthCoordinates
    {
        public int x;
        public int y;

        public LabyrinthCoordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public LabyrinthCoordinates(LabyrinthCoordinates origin, LabyrinthDirection direction)
        {
            x = origin.x;
            y = origin.y;
            switch (direction)
            {
                case LabyrinthDirection.Up:
                    y -= 1;
                    break;
                case LabyrinthDirection.Right:
                    x += 1;
                    break;
                case LabyrinthDirection.Down:
                    y += 1;
                    break;
                case LabyrinthDirection.Left:
                    x -= 1;
                    break;
            }
        }
    }
}

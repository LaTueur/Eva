using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeOut.Model
{
    public struct Coords
    {
        public int x;
        public int y;

        public Coords(int x, int y)
        {
            this.x = x; this.y = y;
        }
        public Coords(Direction d)
        {
            x = 0;
            y = 0;
            switch (d)
            {
                case Direction.Up:
                    y = -1;
                    break;
                case Direction.Down:
                    y = 1;
                    break;
                case Direction.Left:
                    x = -1;
                    break;
                case Direction.Right:
                    x = 1;
                    break;
            }
        }

        public T At<T>(T[,] t)
        {
            return t[y, x];
        }
        public bool Valid<T>(T[,] t)
        {
            try
            {
                At(t);
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }
        public void Put<T>(T[,] t, T v)
        {
            t[y, x] = v;
        }
        public Coords Difference(Coords c)
        {
            return new Coords { x = this.x - c.x, y = this.y - c.y };
        }
        public Coords Move(Coords c)
        {
            return new Coords { x = this.x + c.x, y = this.y + c.y };
        }
        public Coords Move(Direction d)
        {
            return Move(new Coords(d));
        }
        public int XDistance(Coords c)
        {
            return Math.Abs(this.x - c.x);
        }
        public int YDistance(Coords c)
        {
            return Math.Abs(this.y - c.y);
        }
        public int Distance(Coords c)
        {
            return XDistance(c) + YDistance(c);
        }
    }
}

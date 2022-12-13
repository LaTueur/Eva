using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirézia.View
{
    internal class BoardButton : Button
    {
        public readonly int x;
        public readonly int y;
        public BoardButton(int x, int y): base()
        {
            this.x = x;
            this.y = y;
        }
    }
}

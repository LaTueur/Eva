using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeOut.Model;

namespace TakeOut.View
{
    internal class BoardButton : Button
    {
        public readonly Coords coords;
        public BoardButton(Coords coords) : base()
        {
            this.coords = coords;
        }
    }
}

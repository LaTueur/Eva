using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeOut.Persistence
{
    public interface ITakeOutDataAccess
    {
        public void Load(string path, out int round, out TakeOutField[,] board);
        public void Save(string path, int round, TakeOutField[,] board);
    }
}

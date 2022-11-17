using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockDocu.Persistance
{
    public interface IDataAccess
    {
        public void Load(string path, out Field[,] board, out Field[,] nextBlock, out int points);
        public void Save(string path, Field[,] board, Field[,] nextBlock, int points);
    }
}

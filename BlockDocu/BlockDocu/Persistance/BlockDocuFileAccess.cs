using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockDocu.Persistance
{
    public class BlockDocuFileAccess : IDataAccess
    {
        public void Load(string path, out Field[,] board, out Field[,] nextBlock, out int points)
        {
            try
            {
                string[] data = File.ReadAllText(path).Split("\r\n");
                Field[,]  _board = new Field[4, 4];
                Field[,]  _nextBlock = new Field[2, 2];
                for (int i = 0; i < 4; ++i)
                {
                    for (int j = 0; j < 4; ++j)
                    {
                        switch (data[i][j])
                        {
                            case '0':
                                _board[i, j] = new Field();
                                break;
                            case '1':
                                _board[i, j] = new Field() { isFilled=true };
                                break;
                        }
                    }
                }
                for (int i = 0; i < 2; ++i)
                {
                    for (int j = 0; j < 2; ++j)
                    {
                        switch (data[i+4][j])
                        {
                            case '0':
                                _nextBlock[i, j] = new Field();
                                break;
                            case '1':
                                _nextBlock[i, j] = new Field() { isFilled = true };
                                break;
                        }
                    }
                }
                int _points = int.Parse(data[6]);

                board = _board;
                nextBlock = _nextBlock;
                points = _points;
            }
            catch
            {
                throw new DataException();
            }
        }
        public void Save(string path, Field[,] board, Field[,] nextBlock, int points)
        {
            try
            {
                string[] contents = new string[7];
                for (int i = 0; i < 4; ++i)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < 4; ++j)
                    {
                        if(board[i, j].isFilled)
                        {
                            sb.Append('1');
                        }
                        else
                        {
                            sb.Append('0');
                        }
                    }
                    contents[i] = sb.ToString();
                }
                for (int i = 0; i < 2; ++i)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < 2; ++j)
                    {
                        if (nextBlock[i, j].isFilled)
                        {
                            sb.Append('1');
                        }
                        else
                        {
                            sb.Append('0');
                        }
                    }
                    contents[i+4] = sb.ToString();
                }
                contents[6] = points.ToString();
                File.WriteAllLines(path, contents);
            }
            catch
            {
                throw new DataException();
            }
        }
    }
}

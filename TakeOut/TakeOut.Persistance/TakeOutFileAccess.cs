using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeOut.Persistence
{
    public class TakeOutFileAccess : ITakeOutDataAccess
    {
        public void Load(string path, out int round, out TakeOutField[,] board)
        {
            try
            {
                string[] data = File.ReadAllLines(path);
                int n = data.Length - 1;
                int _round = int.Parse(data[0]);
                TakeOutField[,] _board = new TakeOutField[n, n];
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        switch (data[i+1][j])
                        {
                            case 'e':
                                _board[i, j] = TakeOutField.Empty;
                                break;
                            case 'b':
                                _board[i, j] = TakeOutField.White;
                                break;
                            case 'w':
                                _board[i, j] = TakeOutField.Black;
                                break;
                        }
                    }
                }

                board = _board;
                round = _round;
            }
            catch
            {
                throw new DataException();
            }
        }
        public void Save(string path, int round, TakeOutField[,] board)
        {
            try
            {
                List<string> contents = new List<string>();
                contents.Add(round.ToString());
                for (int i = 0; i < board.GetLength(0); ++i)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < board.GetLength(1); ++j)
                    {
                        switch (board[i, j])
                        {
                            case TakeOutField.Empty:
                                sb.Append('e');
                                break;
                            case TakeOutField.Black:
                                sb.Append('b');
                                break;
                            case TakeOutField.White:
                                sb.Append('w');
                                break;
                        }
                    }
                    contents.Add(sb.ToString());
                }
                File.WriteAllLines(path, contents);
            }
            catch
            {
                throw new DataException();
            }
        }
    }
}

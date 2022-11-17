using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TakeOut.Persistence;

namespace TakeOut.Model
{
    public class GameModel
    {
        private readonly ITakeOutDataAccess _persistance;
        private TakeOutField[,] _board;
        private int _round;
        public TakeOutField NextPlayer { get { return _round % 2 == 0 ? TakeOutField.Black : TakeOutField.White; } }
        public int N { get { return _board?.GetLength(0) ?? 0; } }
        public TakeOutField Winner
        {
            get
            {
                int b = 0;
                int w = 0;
                for (int i = 0; i < N; ++i)
                {
                    for (int j = 0; j < N; ++j)
                    {
                        switch (_board[i, j])
                        {
                            case TakeOutField.Black:
                                b += 1;
                                break;
                            case TakeOutField.White:
                                w += 1;
                                break;
                        }
                    }
                }
                if (b == w)
                {
                    return TakeOutField.Empty;
                }
                else if (b > w)
                {
                    return TakeOutField.Black;
                }
                else
                {
                    return TakeOutField.White;
                }
            }
        }
        public bool HasGameEnded
        {
            get
            {
                return _round >= 5 * N;
            }
        }
        public TakeOutField[,] Board { get { return _board; } }
        public int Round { get { return _round; } }

        public EventHandler<EventArgs>? GameStarted;
        public EventHandler<EventArgs>? PlayerMoved;
        public EventHandler<EventArgs>? GameEnded;

        public GameModel(ITakeOutDataAccess persistance)
        {
            _persistance = persistance;
        }

        public void NewGame(int n)
        {
            _board = new TakeOutField[n, n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    _board[i, j] = TakeOutField.Empty;
                }
            }
            for (int i = 0; i < n; ++i)
            {
                int jb = RandomNumberGenerator.GetInt32(0, n);
                _board[i, jb] = TakeOutField.Black;

                int jw = RandomNumberGenerator.GetInt32(0, n);
                if (jb == jw) jw = (jw + 1) % n;
                _board[i, jw] = TakeOutField.White;
            }
            _round = 1;

            TriggerEvent(GameStarted);
        }

        public bool CanSelect(Coords coords)
        {
            return coords.Valid(_board) && coords.At(_board) == NextPlayer && !HasGameEnded;
        }

        public void Move(Coords from, Coords to)
        {
            if(CanSelect(from) && to.Valid(_board) && from.Distance(to) == 1 && !HasGameEnded)
            {
                Coords vector = to.Difference(from);
                Coords prev = from;
                Coords next = to;
                TakeOutField prevField = TakeOutField.Empty;
                do{
                    TakeOutField nextField = prev.At(_board);
                    prev.Put(_board, prevField);
                    prev = next;
                    prevField = nextField;
                    next = prev.Move(vector);
                }while (prev.Valid(_board) && prevField != TakeOutField.Empty);

                _round += 1;

                TriggerEvent(PlayerMoved);

                if (HasGameEnded)
                {
                    TriggerEvent(GameEnded);
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void Load(string path)
        {
            _persistance.Load(path, out _round, out _board);
            TriggerEvent(GameStarted);
        }

        public void Save(string path)
        {
            _persistance.Save(path, _round, _board);
        }

        private void TriggerEvent(EventHandler<EventArgs>? e)
        {
            e?.Invoke(this, EventArgs.Empty);
        }
    }
}

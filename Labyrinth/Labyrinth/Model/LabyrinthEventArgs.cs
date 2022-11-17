using System;
using System.Collections.Generic;
using System.Text;
using Labyrinth.Persistence;

namespace Labyrinth.Model
{
    public class LabyrinthEventArgs : EventArgs
    {
        private LabyrinthField[,] _labyrinth;
        public LabyrinthField[,] Labyrinth { get { return _labyrinth; } }
        private int _time;
        public int Time { get { return _time; } }
        private bool _gameOver;
        public bool GameOver { get { return _gameOver; } }

        public LabyrinthEventArgs(LabyrinthGameModel labyrinth)
        {
            _labyrinth = labyrinth.Labyrinth;
            _time = labyrinth.Time;
            _gameOver = labyrinth.GameOver;
        }
    }
}

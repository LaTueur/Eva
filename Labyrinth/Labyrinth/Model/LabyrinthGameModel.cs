using Labyrinth.Persistence;
using System;

namespace Labyrinth.Model
{
    public class LabyrinthGameModel
    {
        #region Fields

        private readonly ILabyrinthDataAccess _dataAccess;
        private LabyrinthCoordinates _player;
        private LabyrinthField[,] _labyrinth;
        private bool _gameOver;
        private int _time;

        #endregion

        #region Properties

        public LabyrinthField[,] Labyrinth { get { return _labyrinth; } }
        public bool Paused { set; get; }
        public bool GameOver { get { return _gameOver; } }
        public int Time { get { return _time; } }

        #endregion

        #region Events

        public event EventHandler<LabyrinthEventArgs>? GameStarted;
        public event EventHandler<LabyrinthEventArgs>? PlayerMoved;
        public event EventHandler<LabyrinthEventArgs>? GameEnded;
        public event EventHandler<LabyrinthEventArgs>? TimeAdvanced;

        #endregion

        #region Constructors

        public LabyrinthGameModel(ILabyrinthDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _gameOver = true;
        }

        #endregion

        #region Public methods
		
        public void Move(LabyrinthDirection direction)
        {
            if(!GameRuns())
            {
                return;
            }
            LabyrinthCoordinates newPlayerPosition = new LabyrinthCoordinates(_player, direction);
            LabyrinthField? targetField = FieldAtCoordinates(newPlayerPosition);
            if(targetField == null || targetField.type == LabyrinthFieldType.Wall)
            {
                throw new ArgumentException("Invalid direction.");
            }
            targetField.type = LabyrinthFieldType.Player;
            FieldAtCoordinates(_player).type = LabyrinthFieldType.Empty;
            _player = newPlayerPosition;
            HideAll();
            SpreadLight(_player);
            PlayerMoved?.Invoke(this, new LabyrinthEventArgs(this));
            if(_player.x == _labyrinth.GetLength(1) - 1 && _player.y == 0)
            {
                _gameOver = true;
                GameEnded?.Invoke(this, new LabyrinthEventArgs(this));
            }
        }
        public void Load(string path)
        {
            _labyrinth = _dataAccess.Load(path);
            _player = new LabyrinthCoordinates(0, _labyrinth.GetLength(0)-1);
            FieldAtCoordinates(_player).type = LabyrinthFieldType.Player;
            SpreadLight(_player);
            _gameOver = false;
            Paused = false;
            _time = 0;
            GameStarted?.Invoke(this, new LabyrinthEventArgs(this));
        }
        public void AdvanceTime()
        {
            if (GameRuns())
            {
                _time += 1;
                TimeAdvanced?.Invoke(this, new LabyrinthEventArgs(this));
            }
        }

        #endregion

        #region Private methods

        private LabyrinthField? FieldAtCoordinates(LabyrinthCoordinates coordinates)
        {
            try
            {
                return _labyrinth[coordinates.y, coordinates.x];
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }
        private void HideAll()
        {
            foreach (var row in _labyrinth)
            {
                foreach (var field in _labyrinth)
                {
                    field.isVisible = false;
                }
            }
        }
        private void SpreadLight(LabyrinthCoordinates coordinates)
        {
            if (Math.Abs(coordinates.x - _player.x) > 2 ||
                Math.Abs(coordinates.y - _player.y) > 2)
            {
                return;
            }
            LabyrinthField? field = FieldAtCoordinates(coordinates);
            if (field != null && !field.isVisible)
            {
                field.isVisible = true;
                if (field.type != LabyrinthFieldType.Wall)
                {
                    foreach (var direction in Enum.GetValues(typeof(LabyrinthDirection)))
                    {
                        SpreadLight(new LabyrinthCoordinates(coordinates, (LabyrinthDirection)direction));
                    }
                }
            }
        }
        private bool GameRuns()
        {
            return !(_gameOver || Paused);
        }

        #endregion
    }
}

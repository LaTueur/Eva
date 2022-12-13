using System;
using System.Collections.ObjectModel;
using Labyrinth.Model;
using Labyrinth.Persistence;

namespace Labyrinth.ViewModel
{
    public class LabyrinthViewModel : ViewModelBase
    {
        #region Fields

        private readonly LabyrinthGameModel _model;

        #endregion

        #region Properties

        public DelegateCommand LoadCommand { get; private set; }
        public DelegateCommand ExitCommand { get; private set; }
        public DelegateCommand PauseCommand { get; private set; }
        public DelegateCommand MoveCommand { get; private set; }

        public ObservableCollection<LabyrinthViewField> Fields { get; set; }

        public int RowCount {
            get {
                if (_model.Labyrinth != null)
                {
                    return _model.Labyrinth.GetLength(0);
                }
                else
                {
                    return 0;
                }
            }
        }
        public int ColumnCount
        {
            get
            {
                if (_model.Labyrinth != null)
                {
                    return _model.Labyrinth.GetLength(1);
                }
                else
                {
                    return 0;
                }
            }
        }
        public RowDefinitionCollection RowCountDefinitions
        {
            get => new RowDefinitionCollection(Enumerable.Repeat(new RowDefinition(GridLength.Star), RowCount).ToArray());
        }
        public ColumnDefinitionCollection ColumnCountDefinitions
        {
            get => new ColumnDefinitionCollection(Enumerable.Repeat(new ColumnDefinition(GridLength.Star), ColumnCount).ToArray());
        }

        public String GameTime { get { return TimeSpan.FromSeconds(_model.Time).ToString("g"); } }

        #endregion

        #region Events

        public event EventHandler? LoadGame;

        public event EventHandler? ExitGame;

        public event EventHandler? PauseGame;

        public event EventHandler? RefreshBoard;


        #endregion

        #region Constructors

        public LabyrinthViewModel(LabyrinthGameModel model)
        {
            // játék csatlakoztatása
            _model = model;
            _model.GameStarted += new EventHandler<LabyrinthEventArgs>(Model_GameStarted);
            _model.PlayerMoved += new EventHandler<LabyrinthEventArgs>(Model_PlayerMoved);
            _model.TimeAdvanced += new EventHandler<LabyrinthEventArgs>(Model_TimeAdvanced);

            // parancsok kezelése
            LoadCommand = new DelegateCommand(param => OnLoadGame());
            ExitCommand = new DelegateCommand(param => OnExitGame());
            PauseCommand = new DelegateCommand(param => OnPauseGame());
            MoveCommand = new DelegateCommand(param =>
                                                  TryToMove( (LabyrinthDirection)Enum.Parse(
                                                                typeof(LabyrinthDirection),
                                                                param.ToString())));

            Fields = new ObservableCollection<LabyrinthViewField>();
        }

		#endregion

		#region Private methods

        private void TryToMove(LabyrinthDirection direction)
        {
            try
            {
                _model.Move(direction);
            }
            catch { }
        }

        #endregion

        #region Model event handlers

        private void Model_GameStarted(Object? sender, LabyrinthEventArgs e)
        {
            Fields.Clear();

            if(RefreshBoard?.GetInvocationList() != null)
            {
                foreach (Delegate d in RefreshBoard.GetInvocationList())
                {
                    RefreshBoard -= (EventHandler)d;
                }
            }

            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    Fields.Add(new LabyrinthViewField(e.Labyrinth[i, j], this, j, i));
                }
            }

            OnPropertyChanged(nameof(RowCount));
            OnPropertyChanged(nameof(ColumnCount));
            OnPropertyChanged(nameof(RowCountDefinitions));
            OnPropertyChanged(nameof(ColumnCountDefinitions));
            OnPropertyChanged(nameof(GameTime));
            RefreshBoard?.Invoke(this, new EventArgs());
        }
        private void Model_PlayerMoved(Object? sender, LabyrinthEventArgs e)
        {
            RefreshBoard?.Invoke(this, new EventArgs());
        }
        private void Model_TimeAdvanced(Object? sender, LabyrinthEventArgs e)
        {
            OnPropertyChanged(nameof(GameTime));
        }
        #endregion

        #region Event methods

        private void OnLoadGame()
        {
            LoadGame?.Invoke(this, EventArgs.Empty);
        }

        private void OnExitGame()
        {
            ExitGame?.Invoke(this, EventArgs.Empty);
        }
        private void OnPauseGame()
        {
            PauseGame?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}

using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;
using TakeOut.Model;
using TakeOut.Persistence;
using Microsoft.Win32;

namespace TakeOut.ViewModel
{
    public class TakeOutViewModel : ViewModelBase
    {
        #region Fields

        private readonly GameModel _model;

        private Coords _selected;

        private bool _hasSelected;

        #endregion

        #region Properties

        public DelegateCommand LoadCommand { get; private set; }
        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand ExitCommand { get; private set; }
        public DelegateCommand NewCommand { get; private set; }

        public ObservableCollection<TakeOutViewField> Board { get; set; }

        public int RowCount {
            get {
                return _model.N;
            }
        }
        public int ColumnCount
        {
            get
            {
                return _model.N;
            }
        }

        public int Round { get { return _model.Round; } }
        public int MaxRound { get { return 5 * _model.N; } }

        #endregion

        #region Events

        public event EventHandler? LoadGame;

        public event EventHandler? SaveGame;

        public event EventHandler? ExitGame;

        public event EventHandler? RefreshBoard;

        #endregion

        #region Constructors

        public TakeOutViewModel(GameModel model)
        {
            // játék csatlakoztatása
            _model = model;
            _model.GameStarted += new EventHandler<EventArgs>(Model_GameStarted);
            _model.PlayerMoved += new EventHandler<EventArgs>(Model_PlayerMoved);

            // parancsok kezelése
            LoadCommand = new DelegateCommand(param => OnLoadGame());
            SaveCommand = new DelegateCommand(param => OnSaveGame());
            ExitCommand = new DelegateCommand(param => OnExitGame());
            NewCommand = new DelegateCommand(param => StartNewGame(int.Parse((string)param)));

            Board = new ObservableCollection<TakeOutViewField>();
        }

		#endregion

		#region Private methods

        private void StartNewGame(int n)
        {
            _model.NewGame(n);
        }

        #endregion

        #region Model event handlers

        private void Model_GameStarted(Object? sender, EventArgs e)
        {
            Board.Clear();

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
                    TakeOutViewField field = new TakeOutViewField(new Coords(i, j), _model.Board, this);
                    Board.Add(field);
                    field.Selected += ViewField_Selected;
                }
            }

            _hasSelected = false;

            OnPropertyChanged(nameof(RowCount));
            OnPropertyChanged(nameof(ColumnCount));
            OnPropertyChanged(nameof(Round));
            OnPropertyChanged(nameof(MaxRound));
            RefreshBoard?.Invoke(this, new EventArgs());
        }
        private void Model_PlayerMoved(Object? sender, EventArgs e)
        {
            _hasSelected = false;
            RefreshBoard?.Invoke(this, new EventArgs());
            OnPropertyChanged(nameof(Round));
        }
        #endregion

        #region ViewField event handlers

        private void ViewField_Selected(Object? sender, EventArgs e)
        {
            TakeOutViewField? field = sender as TakeOutViewField;
            if (field != null)
            {
                Coords c = field.Coords;
                if (_hasSelected)
                {
                    try
                    {
                        _model.Move(_selected, c);
                    }
                    catch { }
                }
                else if (_model.CanSelect(c))
                {
                    _selected = c;
                    _hasSelected = true;
                }
            }
        }
        #endregion

        #region Event methods

        private void OnLoadGame()
        {
            LoadGame?.Invoke(this, EventArgs.Empty);
        }
        private void OnSaveGame()
        {
            SaveGame?.Invoke(this, EventArgs.Empty);
        }
        private void OnExitGame()
        {
            ExitGame?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}

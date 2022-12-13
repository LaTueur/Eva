using Labyrinth.Model;
using Labyrinth.Persistence;
using Labyrinth.ViewModel;

namespace Labyrinth
{
    public partial class AppShell : Shell
    {
        #region Fields

        private readonly ILabyrinthDataAccess _dataAccess;
        private readonly LabyrinthGameModel _gameModel;
        private readonly LabyrinthViewModel _viewModel;

        private readonly IDispatcherTimer _timer;

        #endregion

        #region Application methods

        public AppShell(ILabyrinthDataAccess dataAccess,
            LabyrinthGameModel gameModel,
            LabyrinthViewModel viewModel)
        {
            InitializeComponent();

            _dataAccess = dataAccess;
            _gameModel = gameModel;
            _viewModel = viewModel;

            _timer = Dispatcher.CreateTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (_, _) => _gameModel.AdvanceTime();
            /*
            _gameModel.GameOver += GameModel_GameOver;

            _viewModel.NewGame += SudokuViewModel_NewGame;
            _viewModel.LoadGame += SudokuViewModel_LoadGame;
            _viewModel.SaveGame += SudokuViewModel_SaveGame;
            _viewModel.ExitGame += SudokuViewModel_ExitGame;*/
        }

        #endregion

        #region Internal methods

        /// <summary>
        ///     Elindtja a játék léptetéséhez használt időzítőt.
        /// </summary>
        internal void StartTimer() => _timer.Start();

        /// <summary>
        ///     Megállítja a játék léptetéséhez használt időzítőt.
        /// </summary>
        internal void StopTimer() => _timer.Stop();

        #endregion
    }
}
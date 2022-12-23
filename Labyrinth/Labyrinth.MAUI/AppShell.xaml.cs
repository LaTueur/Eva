using Labyrinth.Model;
using Labyrinth.Persistence;
using Labyrinth.View;
using Labyrinth.ViewModel;

namespace Labyrinth
{
    public partial class AppShell : Shell
    {
        #region Fields

        private readonly ILabyrinthDataAccess _dataAccess;
        private readonly LabyrinthGameModel _gameModel;
        private readonly LabyrinthViewModel _viewModel;
        private readonly LabyrinthBrowserViewModel _browserModel;

        private readonly IDispatcherTimer _timer;

        #endregion

        #region Application methods

        public AppShell(ILabyrinthDataAccess dataAccess,
            LabyrinthGameModel gameModel,
            LabyrinthViewModel viewModel,
            LabyrinthBrowserViewModel browserModel)
        {
            InitializeComponent();

            _dataAccess = dataAccess;
            _gameModel = gameModel;
            _viewModel = viewModel;
            _browserModel = browserModel;

            _timer = Dispatcher.CreateTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (_, _) => _gameModel.AdvanceTime();

            _gameModel.GameEnded += GameModel_GameEnded;
            _viewModel.LoadGame += ViewModel_LoadGame;
            _viewModel.PauseGame += ViewModel_PauseGame;
            _browserModel.LoadGame += BrowserModel_LoadGame;
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

        #region Model event handlers
        private async void GameModel_GameEnded(object? sender, EventArgs e)
        {
            StopTimer();

            await DisplayAlert("Labirintus",
                "Gratulálok, győztél!" + Environment.NewLine +
                "Összesen " + _viewModel.GameTime + " ideig játszottál.",
                "OK");
        }
        #endregion

        #region ViewModel event handlers

        private async void ViewModel_LoadGame(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoadPage
            {
                BindingContext = _browserModel
            });
        }
        private void ViewModel_PauseGame(object? sender, EventArgs e)
        {
            _gameModel.Paused = !_gameModel.Paused;
            if (_gameModel.Paused)
            {
                StopTimer();
            }
            else
            {
                StartTimer();
            }
        }

        private async void BrowserModel_LoadGame(object? sender, EventArgs e)
        {
            await Navigation.PopAsync();

            try
            {
                _gameModel.Load(((LabyrinthEntry)sender).FilePath);

                await Navigation.PopAsync();
                await DisplayAlert("Labirintus", "Sikeres betöltés.", "OK");

                StartTimer();
            }
            catch
            {
                await DisplayAlert("Labirintus", "Sikertelen betöltés.", "OK");
            }
        }
        #endregion
    }
}
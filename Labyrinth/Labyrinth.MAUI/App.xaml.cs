using Labyrinth.Model;
using Labyrinth.Persistence;
using Labyrinth.ViewModel;

namespace Labyrinth
{
    public partial class App : Application
    {
        private readonly AppShell _appShell;
        private readonly ILabyrinthDataAccess _dataAccess;
        private readonly LabyrinthGameModel _gameModel;
        private readonly LabyrinthViewModel _viewModel;

        public App()
        {
            InitializeComponent();

            _dataAccess = new LabyrinthFileAccess();

            _gameModel = new LabyrinthGameModel(_dataAccess);
            _viewModel = new LabyrinthViewModel(_gameModel);

            _appShell = new AppShell(_dataAccess, _gameModel, _viewModel)
            {
                BindingContext = _viewModel
            };
            MainPage = _appShell;
        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window window = base.CreateWindow(activationState);

            window.Created += (s, e) =>
            {
                // új játékot indítunk
                _gameModel.Load(Path.Combine("Resources", "Raw", "Labyrinths", "easy.lab"));
                _appShell.StartTimer();
            };

            return window;
        }
    }
}
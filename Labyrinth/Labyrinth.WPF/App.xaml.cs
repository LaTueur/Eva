using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using System.IO;
using Labyrinth.Model;
using Labyrinth.Persistence;
using Labyrinth.View;
using Labyrinth.ViewModel;
using Microsoft.Win32;

namespace Labyrinth
{
    public partial class App : Application
    {
        #region Fields

        private LabyrinthGameModel _model = null!;
        private LabyrinthViewModel _viewModel = null!;
        private MainWindow _view = null!;
        private DispatcherTimer _timer = null!;

        #endregion

        #region Constructors

        public App()
        {
            Startup += new StartupEventHandler(App_Startup);
        }

        #endregion

        #region Application event handlers

        private void App_Startup(object? sender, StartupEventArgs e)
        {
            _model = new LabyrinthGameModel(new LabyrinthFileAccess());
            _model.GameEnded += new EventHandler<LabyrinthEventArgs>(Model_GameEnded);

            _viewModel = new LabyrinthViewModel(_model);
            _viewModel.LoadGame += new EventHandler(ViewModel_LoadGame);
            _viewModel.ExitGame += new EventHandler(ViewModel_ExitGame);
            _viewModel.PauseGame += new EventHandler(ViewModel_PauseGame);

            _view = new MainWindow();
            _view.DataContext = _viewModel;
            _view.Closing += new CancelEventHandler(View_Closing);
            _view.Show();

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += new EventHandler(Timer_Tick);

            _model.Load(Path.Combine("Labyrinths", "easy.lab"));
            _timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            _model.AdvanceTime();
        }

        #endregion

        #region View event handlers

        private void View_Closing(object? sender, CancelEventArgs e)
        {
            bool restartTimer = _timer.IsEnabled;

            _timer.Stop();

            if (MessageBox.Show("Biztos, hogy ki akarsz lépni?", "Labirintus", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                e.Cancel = true;

                if (restartTimer)
                {
                    _timer.Start();
                }
            }
        }

        #endregion

        #region ViewModel event handlers

        private void ViewModel_LoadGame(object? sender, EventArgs e)
        {
            bool restartTimer = _timer.IsEnabled;

            _timer.Stop();

            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "Labirintus betöltése",
                    FileName = "easy.lab",
                    Filter = "Labirintus fájl|*.lab",
                    InitialDirectory = Path.Join(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Labyrinths")
                };
                if (openFileDialog.ShowDialog() == true)
                {
                    _model.Load(openFileDialog.FileName);

                    _timer.Start();
                }
            }
            catch (LabyrinthDataException)
            {
                MessageBox.Show("A fájl betöltése sikertelen!", "Labirintus", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (restartTimer)
            {
                _timer.Start();
            }
        }
        private void ViewModel_ExitGame(object? sender, EventArgs e)
        {
            _view.Close();
        }
        private void ViewModel_PauseGame(object? sender, EventArgs e)
        {
            _model.Paused = !_model.Paused;
            _timer.IsEnabled = !_model.Paused;
        }

        #endregion

        #region Model event handlers

        private void Model_GameEnded(object? sender, LabyrinthEventArgs e)
        {
            _timer.Stop();
            MessageBox.Show("Gratulálok, győztél!" + Environment.NewLine +
                "Összesen " + _viewModel.GameTime + " ideig játszottál.",
                "Labirintus",
                MessageBoxButton.OK,
                MessageBoxImage.Asterisk);
        }

        #endregion
    }
}

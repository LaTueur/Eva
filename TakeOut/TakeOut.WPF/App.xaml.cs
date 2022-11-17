using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using System.IO;
using TakeOut.Model;
using TakeOut.Persistence;
using TakeOut.View;
using TakeOut.ViewModel;
using Microsoft.Win32;
using System.Data;

namespace Labyrinth
{
    public partial class App : Application
    {
        #region Fields

        private GameModel _model = null!;
        private TakeOutViewModel _viewModel = null!;
        private MainWindow _view = null!;

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
            _model = new GameModel(new TakeOutFileAccess());
            _model.GameEnded += new EventHandler<EventArgs>(Model_GameEnded);

            _viewModel = new TakeOutViewModel(_model);
            _viewModel.LoadGame += new EventHandler(ViewModel_LoadGame);
            _viewModel.SaveGame += new EventHandler(ViewModel_SaveGame);
            _viewModel.ExitGame += new EventHandler(ViewModel_ExitGame);

            _view = new MainWindow();
            _view.DataContext = _viewModel;
            _view.Closing += new CancelEventHandler(View_Closing);
            _view.Show();

            _model.NewGame(3);
        }

        #endregion

        #region View event handlers

        private void View_Closing(object? sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Biztos, hogy ki akarsz lépni?", "Kitolás", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region ViewModel event handlers

        private void ViewModel_LoadGame(object? sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "Kitolás betöltése",
                    FileName = "save.kit",
                    Filter = "Kitolás fájl|*.kit",
                };
                if (openFileDialog.ShowDialog() == true)
                {
                    _model.Load(openFileDialog.FileName);
                }
            }
            catch (DataException)
            {
                MessageBox.Show("A fájl betöltése sikertelen!", "Kitolás", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ViewModel_SaveGame(object? sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Title = "Kitolás mentése",
                    FileName = "save.kit",
                    Filter = "Kitolás fájl|*.kit",
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    _model.Save(saveFileDialog.FileName);
                }
            }
            catch (DataException)
            {
                MessageBox.Show("A fájl mentése sikertelen!", "Kitolás", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ViewModel_ExitGame(object? sender, EventArgs e)
        {
            _view.Close();
        }

        #endregion

        #region Model event handlers

        private void Model_GameEnded(object? sender, EventArgs e)
        {
            string text = "";
            switch (_model.Winner)
            {
                case TakeOutField.Empty:
                    text = "Döntetelen!";
                    break;
                case TakeOutField.Black:
                    text = "A fekete győzött!";
                    break;
                case TakeOutField.White:
                    text = "A fehér győzött!";
                    break;
            }
            MessageBox.Show(text,
                "Kitolás",
                MessageBoxButton.OK,
                MessageBoxImage.Asterisk);
        }

        #endregion
    }
}

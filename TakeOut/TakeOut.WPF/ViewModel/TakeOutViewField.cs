using TakeOut.Model;
using TakeOut.Persistence;
using System;
using System.Data;
using System.Linq;
using System.Windows.Controls;

namespace TakeOut.ViewModel
{
    public class TakeOutViewField : ViewModelBase
    {
        #region Fields

        private readonly Coords _coords;
        private readonly TakeOutField[,] _board;

        #endregion

        #region Properties

        public Coords Coords
        {
            get { return _coords; }
        }
        public TakeOutField Value
        {
            get { return _coords.At(_board); }
        }
        public DelegateCommand SelectCommand { get; private set; }

        #endregion

        #region Events

        public event EventHandler? Selected;

        #endregion

        #region Constructors

        public TakeOutViewField(Coords coords, TakeOutField[,] board, TakeOutViewModel viewModel)
        {
            _coords = coords;
            _board = board;
            viewModel.RefreshBoard += ViewModel_RefreshBoard;
            SelectCommand = new DelegateCommand(param => OnSelect());
        }

        #endregion

        #region Event methods

        public void OnSelect()
        {
            Selected?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region ViewModel event handlers

        private void ViewModel_RefreshBoard(Object? sender, EventArgs e)
        {
            OnPropertyChanged(nameof(Value));
        }

        #endregion
    }
}
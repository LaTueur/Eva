using Labyrinth.Model;
using Labyrinth.Persistence;
using System;
using System.Data;
using System.Linq;

namespace Labyrinth.ViewModel
{
    public class LabyrinthViewField : ViewModelBase
    {
        #region Fields

        private readonly LabyrinthField _field;
        private readonly int _x;
        private readonly int _y;

        #endregion

        #region Properties

        public LabyrinthFieldType Type
        {
            get { return _field.type; }
        }
        public bool IsVisible
        {
            get { return _field.isVisible; }
        }
        public int X
        {
            get { return _x; }
        }
        public int Y
        {
            get { return _y; }
        }
        #endregion

        #region Constructors

        public LabyrinthViewField(LabyrinthField field, LabyrinthViewModel viewModel, int x, int y)
        {
            _field = field;
            _x = x;
            _y = y;
            viewModel.RefreshBoard += ViewModel_RefreshBoard;
        }

        #endregion

        #region ViewModel event handlers

        private void ViewModel_RefreshBoard(Object? sender, EventArgs e)
        {
            OnPropertyChanged(nameof(Type));
            OnPropertyChanged(nameof(IsVisible));
        }

        #endregion
    }
}
using Labyrinth.Model;
using Labyrinth.Persistence;
using System;
using System.Data;
using System.Linq;
using System.Windows.Controls;

namespace Labyrinth.ViewModel
{
    public class LabyrinthViewField : ViewModelBase
    {
        #region Fields

        private readonly LabyrinthField _field;

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

        #endregion

        #region Constructors

        public LabyrinthViewField(LabyrinthField field, LabyrinthViewModel viewModel)
        {
            _field = field;
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
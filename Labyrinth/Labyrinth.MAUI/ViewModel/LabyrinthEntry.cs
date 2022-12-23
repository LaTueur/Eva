using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.ViewModel
{
    public class LabyrinthEntry : ViewModelBase
    {
        public string DisplayName { get; private set; }
        public string FileName { get; private set; }
        public string FilePath { get { return Path.Combine("Labyrinths", FileName); } }
        public DelegateCommand LoadCommand { get; private set; }
        public event EventHandler? LoadGame;
        public LabyrinthEntry(string displayName, string fileName, LabyrinthBrowserViewModel viewModel)
        {
            DisplayName = displayName;
            FileName = fileName;
            LoadCommand = new DelegateCommand(param => LoadGame?.Invoke(this, EventArgs.Empty));
            LoadGame += new EventHandler(viewModel.LabyrinthEntry_LoadGame);
        }
    }
}

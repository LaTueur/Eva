using System;
using System.Collections.ObjectModel;
using Labyrinth.Model;

namespace Labyrinth.ViewModel
{
    /// <summary>
    /// Tárolt játékkezelő nézetmodellje.
    /// </summary>
    public class LabyrinthBrowserViewModel : ViewModelBase
    {

        /// <summary>
        /// Betöltés eseménye.
        /// </summary>
        public event EventHandler<EventArgs>? LoadGame;

        public ObservableCollection<LabyrinthEntry> Labyrinths { get; private set; }

        public LabyrinthBrowserViewModel()
        {
            Labyrinths = new ObservableCollection<LabyrinthEntry>();
            Labyrinths.Add(new LabyrinthEntry("Könnyű", "easy.lab", this));
            Labyrinths.Add(new LabyrinthEntry("Közepes", "medium.lab", this));
            Labyrinths.Add(new LabyrinthEntry("Nehéz", "hard.lab", this));
        }

        public void LabyrinthEntry_LoadGame(Object? sender, EventArgs e)
        {
            LoadGame?.Invoke(sender, e);
        }
    }
}
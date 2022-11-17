using System;

namespace Labyrinth.Persistence
{
    public class LabyrinthField
    {
        public LabyrinthFieldType type;
        public bool isVisible;

        public LabyrinthField(LabyrinthFieldType type, bool isVisible)
        {
            this.type = type;
            this.isVisible = isVisible;
        }
        public LabyrinthField(LabyrinthFieldType type): this(type, false) {}
    }
}

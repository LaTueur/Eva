namespace Labyrinth.Persistence
{
    public interface ILabyrinthDataAccess
    {
        public LabyrinthField[,] Load(string path);
    }
}

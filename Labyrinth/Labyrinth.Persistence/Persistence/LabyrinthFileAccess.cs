using System.IO;

namespace Labyrinth.Persistence
{
    public class LabyrinthFileAccess : ILabyrinthDataAccess
    {
        public LabyrinthField[,] Load(string path)
        {
            try
            {
                string[] data = File.ReadAllText(path).Split("\r\n");
                LabyrinthField[,] labyrinth = new LabyrinthField[data.Length, data[0].Length];
                for(int i = 0; i < labyrinth.GetLength(0); ++i)
                {
                    for (int j = 0; j < labyrinth.GetLength(1); ++j)
                    {

                        switch (data[i][j])
                        {
                            case '0':
                                labyrinth[i, j] = new LabyrinthField(LabyrinthFieldType.Empty);
                                break;
                            case '1':
                                labyrinth[i, j] = new LabyrinthField(LabyrinthFieldType.Wall);
                                break;
                        }
                    }
                }
                return labyrinth;
            }
            catch
            {
                throw new LabyrinthDataException();
            }
        }
    }
}

using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Persistence
{
    public class LabyrinthAssetAccess : ILabyrinthDataAccess
    {
        public LabyrinthField[,] Load(string path)
        {
            try
            {
                string[] data = Task.Run<string[]>(async () => await LoadMauiAsset(path)).Result;
                LabyrinthField[,] labyrinth = new LabyrinthField[data.Length, data[0].Length];
                for (int i = 0; i < labyrinth.GetLength(0); ++i)
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
        private async Task<string[]> LoadMauiAsset(string path)
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync(path);
            using var reader = new StreamReader(stream);

            return reader.ReadToEnd().Split("\r\n");
        }
    }
}

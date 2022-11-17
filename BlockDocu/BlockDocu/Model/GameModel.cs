using System.Globalization;
using BlockDocu.Persistance;

namespace BlockDocu.Model
{
    public class GameModel
    {
        public Field[,] board;
        public Field[,] nextBlock;
        static readonly Field[][,] randomBlocks =
        {
            new Field[,] {
                { new Field {isFilled = true}, new Field {isFilled = true} },
                { new Field {isFilled = false}, new Field {isFilled = false} }
            },
            new Field[,] {
                { new Field {isFilled = true}, new Field {isFilled = false} },
                { new Field {isFilled = true}, new Field {isFilled = false} }
            },
            new Field[,] {
                { new Field {isFilled = true}, new Field {isFilled = false} },
                { new Field {isFilled = true}, new Field {isFilled = true} }
            },
            new Field[,] {
                { new Field {isFilled = true}, new Field {isFilled = true} },
                { new Field {isFilled = false}, new Field {isFilled = true} }
            }
        };
        public int points;
        public EventHandler<EventArgs>? GameStarted;
        public EventHandler<EventArgs>? BlockPlaced;
        public EventHandler<EventArgs>? GameEnded;

        private readonly IDataAccess _persistance;

        public GameModel(IDataAccess persistance)
        {
            this._persistance = persistance;
            StartNewGame();
        }
        private void ChooseNextBlock()
        {
            nextBlock = randomBlocks[Random.Shared.Next() % randomBlocks.Length];
        }
        private bool CanBePlaced(int x, int y)
        {
            try
            {
                for (int i = 0; i < nextBlock.GetLength(0); i++)
                {
                    for (int j = 0; j < nextBlock.GetLength(1); j++)
                    {
                        if (nextBlock[i, j].isFilled && board[x + i, y + j].isFilled)
                        {
                            return false;
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            return true;
        }
        private void CheckFullRows()
        {
            for (int i = 0; i < 4; i++)
            {
                int j = 0;
                while (j < 4 && board[i, j].isFilled)
                {
                    j++;
                }
                if (j >= 4)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        board[i, k].isFilled = false;
                    }
                }
            }
        }
        private void CheckFullColoumns()
        {
            for (int i = 0; i < 4; i++)
            {
                int j = 0;
                while (j < 4 && board[j, i].isFilled)
                {
                    j++;
                }
                if (j >= 4)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        board[k, i].isFilled = false;
                    }
                }
            }
        }
        private bool GameShouldEnd()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (CanBePlaced(i, j))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void Place(int x, int y)
        {
            if (!CanBePlaced(x, y)) throw new ArgumentException();

            for (int i = 0; i < nextBlock.GetLength(0); i++)
            {
                for (int j = 0; j < nextBlock.GetLength(1); j++)
                {
                    if (nextBlock[i, j].isFilled)
                    {
                        board[x + i, y + j].isFilled = true;
                    }
                }
            }

            CheckFullRows();
            CheckFullColoumns();

            points += 1;

            ChooseNextBlock();

            BlockPlaced?.Invoke(this, new EventArgs());

            if (GameShouldEnd()) GameEnded?.Invoke(this, new EventArgs());
        }
        public void StartNewGame()
        {
            board = new Field[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    board[i, j] = new Field();
                }
            }
            points = 0;
            ChooseNextBlock();
            GameStarted?.Invoke(this, new EventArgs());
        }
        public void Load(string path)
        {
            _persistance.Load(path, out board, out nextBlock, out points);
            GameStarted?.Invoke(this, new EventArgs());
        }
        public void Save(string path)
        {
            _persistance.Save(path, board, nextBlock, points);
        }
    }
}
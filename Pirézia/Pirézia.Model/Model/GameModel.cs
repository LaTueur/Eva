namespace Pirézia.Model
{
    public class GameModel
    {
        public Room[,] board;
        public int money;
        public bool gameEnded;
        public EventHandler<EventArgs>? GameStarted;
        public EventHandler<EventArgs>? TimeAdvanced;
        public EventHandler<EventArgs>? HeatingSwitched;
        public EventHandler<EventArgs>? GameEndedLowTemp;
        public EventHandler<EventArgs>? GameEndedLowMoney;

        public GameModel()
        {
            StartNewGame();
        }
        public void SwitchHeating(int x, int y)
        {
            if (gameEnded)
            {
                return;
            }
            try
            {
                board[x, y].SwitchHeating();
                HeatingSwitched?.Invoke(this, EventArgs.Empty);
            }
            catch (IndexOutOfRangeException)
            {

            }
        }
        public void AdvanceTime()
        {
            if (gameEnded)
            {
                return;
            }
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j].TemperatureChange();
                    money -= board[i, j].HeatingCost;
                }
            }
            TimeAdvanced?.Invoke(this, EventArgs.Empty);
            CheckGameEnd();
        }
        private void CheckGameEnd()
        {
            int lowTempRooms = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (!board[i, j].isEmpty && board[i,j].temperature < 18)
                    {
                        lowTempRooms++;
                    }
                }
            }
            if (lowTempRooms >= 5)
            {
                gameEnded = true;
                GameEndedLowTemp?.Invoke(this, EventArgs.Empty);
            }
            if (money <= 0)
            {
                gameEnded = true;
                GameEndedLowMoney?.Invoke(this, EventArgs.Empty);
            }
        }
        public void StartNewGame()
        {
            int n = 6;
            int m = 7;
            board = new Room[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    bool secondRow = i == 1 || i == n - 2;
                    bool outerRow = i == 0 || i == n - 1;
                    bool secondColoumn = j == 1 || j == m - 2;
                    bool outerColoumn = j == 0 || j == m - 1;
                    if ((secondRow || secondColoumn) && !(outerRow || outerColoumn))
                    {
                        board[i, j] = new Room(true);
                    }
                    else
                    {
                        board[i, j] = new Room(false);
                    }
                }
            }
            money = 200000;
            gameEnded = false;
            GameStarted?.Invoke(this, EventArgs.Empty);
        }
    }
}
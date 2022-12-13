using Pirézia.Model;
using Timer = System.Windows.Forms.Timer;

namespace Pirézia.View
{
    public partial class PiréziaForm : Form
    {
        #region Fields

        private readonly GameModel _model;
        private BoardButton[,]? _buttons;
        private Timer _timer;

        #endregion

        #region Constructors

        public PiréziaForm()
        {
            InitializeComponent();

            _model = new GameModel();
            _model.GameStarted += new EventHandler<EventArgs>(Model_GameStarted);
            _model.HeatingSwitched += new EventHandler<EventArgs>(Model_HeatingSwitched);
            _model.TimeAdvanced += new EventHandler<EventArgs>(Model_TimeAdvanced);
            _model.GameEndedLowTemp += new EventHandler<EventArgs>(Model_GameEndedLowTemp);
            _model.GameEndedLowMoney += new EventHandler<EventArgs>(Model_GameEndedLowMoney);

            _timer = new Timer();
            _timer.Interval = 2000;
            _timer.Tick += new EventHandler(Timer_Tick);

            _model.StartNewGame();
        }

        #endregion

        #region Model event handlers

        private void Model_GameStarted(Object? sender, EventArgs e)
        {
            if (_buttons == null)
            {
                BoardSetup();
            }
            ChangeBoard();
            _timer.Start();
        }
        private void Model_HeatingSwitched(Object? sender, EventArgs e)
        {
            ChangeBoard();
        }
        private void Model_TimeAdvanced(Object? sender, EventArgs e)
        {
            ChangeBoard();
        }
        private void Model_GameEndedLowTemp(Object? sender, EventArgs e)
        {
            GameEnded("Túl sok termet hagytál hidegen!");
        }
        private void Model_GameEndedLowMoney(Object? sender, EventArgs e)
        {
            GameEnded("Elfogyott a pénzed!");
        }

        #endregion

        #region Button event handlers

        private void BoardButton_Click(Object? sender, EventArgs e)
        {
            BoardButton bb = sender as BoardButton;
            if (bb != null)
            {
                try
                {
                    _model.SwitchHeating(bb.x, bb.y);
                }
                catch { }
            }
        }
        private void ButtonNewGame_Click(object sender, EventArgs e)
        {
            _model.StartNewGame();
        }

        #endregion

        #region Timer event handlers

        private void Timer_Tick(Object? sender, EventArgs e)
        {
            _model.AdvanceTime();
        }

        #endregion

        #region Private methods

        private void ChangeBoard()
        {
            for (int i = 0; i < _tableLayoutGrid.RowCount; i++)
            {
                for (int j = 0; j < _tableLayoutGrid.ColumnCount; j++)
                {
                    Button button = _buttons[i, j];
                    Room room = _model.board[i,j];
                    if (room.isEmpty)
                    {
                        button.BackColor = Color.White;
                    }
                    else
                    {
                        button.Text = room.temperature.ToString();
                        if (room.isHeated)
                        {
                            button.BackColor = Color.Red;
                        }
                        else
                        {
                            button.BackColor = Color.Blue;
                        }
                    }
                    
                }
            }
            _labelMoney.Text = $"Pénz: {_model.money} pengő";
        }

        private void BoardSetup()
        {
            _tableLayoutGrid.RowCount = _model.board.GetLength(0);
            _tableLayoutGrid.ColumnCount = _model.board.GetLength(1);

            _buttons = new BoardButton[_tableLayoutGrid.RowCount, _tableLayoutGrid.ColumnCount];


            for (int i = 0; i < _model.board.GetLength(0); i++)
            {
                for (int j = 0; j < _model.board.GetLength(1); j++)
                {
                    _buttons[i, j] = new BoardButton(i, j);
                    _buttons[i, j].Dock = DockStyle.Fill;
                    _buttons[i, j].Click += BoardButton_Click;
                    _tableLayoutGrid.Controls.Add(_buttons[i, j], j, i);
                }
            }

            _tableLayoutGrid.RowStyles.Clear();
            _tableLayoutGrid.ColumnStyles.Clear();

            for (int i = 0; i < _tableLayoutGrid.RowCount; i++)
            {
                _tableLayoutGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 1 / Convert.ToSingle(_tableLayoutGrid.RowCount)));
            }
            for (int j = 0; j < _tableLayoutGrid.ColumnCount; j++)
            {
                _tableLayoutGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1 / Convert.ToSingle(_tableLayoutGrid.ColumnCount)));
            }
        }

        private void GameEnded(string desc)
        {
            _timer.Stop();
            if (MessageBox.Show(desc + Environment.NewLine +
                            "Veszítettél." + Environment.NewLine +
                            "Szeretnél új játékot kezdeni?",
                            "Játék vége", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                _model.StartNewGame();
            }
            else
            {
                Close();
            }
        }
        #endregion
    }
}

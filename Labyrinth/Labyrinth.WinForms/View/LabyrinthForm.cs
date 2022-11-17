using Labyrinth.Model;
using Labyrinth.Persistence;
using Timer = System.Windows.Forms.Timer;

namespace Labyrinth.View
{
    public partial class LabyrinthForm : Form
    {
        #region Fields

        private readonly LabyrinthGameModel _model;
        private Button[,]? _buttons;
        private Timer _timer;

        #endregion

        #region Constructors

        public LabyrinthForm()
        {
            InitializeComponent();

            _model = new LabyrinthGameModel(new LabyrinthFileAccess());
            _model.GameStarted += new EventHandler<LabyrinthEventArgs>(Model_GameStarted);
            _model.PlayerMoved += new EventHandler<LabyrinthEventArgs>(Model_PlayerMoved);
            _model.GameEnded += new EventHandler<LabyrinthEventArgs>(Model_GameEnded);
            _model.TimeAdvanced += new EventHandler<LabyrinthEventArgs>(Model_TimeAdvanced);

            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(Timer_Tick);

            _model.Load(Path.Combine("Labyrinths", "easy.lab"));
        }

        #endregion

        #region _model event handlers

        private void Model_GameStarted(Object? sender, LabyrinthEventArgs e)
        {
            if (_buttons != null)
            {
                foreach (Button button in _buttons)
                    _tableLayoutGrid.Controls.Remove(button);
            }
            _buttons = new Button[e.Labyrinth.GetLength(0), e.Labyrinth.GetLength(1)];

            _tableLayoutGrid.RowCount = e.Labyrinth.GetLength(0);
            _tableLayoutGrid.ColumnCount = e.Labyrinth.GetLength(1);

            for (int i = 0; i < _tableLayoutGrid.RowCount; i++)
            {
                for (int j = 0; j < _tableLayoutGrid.ColumnCount; j++)
                {
                    _buttons[i, j] = new Button();
                    _buttons[i, j].Dock = DockStyle.Fill;
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

            ChangeBoard(e.Labyrinth);

            _timer.Start();

            _labelTime.Text = "Idő: " + TimeSpan.FromSeconds(e.Time).ToString("g");
        }
        private void Model_PlayerMoved(Object? sender, LabyrinthEventArgs e)
        {
            ChangeBoard(e.Labyrinth);
        }
        private void Model_GameEnded(Object? sender, LabyrinthEventArgs e)
        {
            MessageBox.Show("Kijutottál a labirintusból!" + Environment.NewLine + "Gratulálok, megnyerted a játékot!", "Kijutottál", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _timer.Stop();
        }
        private void Model_TimeAdvanced(Object? sender, LabyrinthEventArgs e)
        {
            _labelTime.Text = "Idő: " + TimeSpan.FromSeconds(e.Time).ToString("g");
        }

        #endregion

        #region Control buttons event handlers

        private void Up_Click(object sender, EventArgs e)
        {
            TryToMove(LabyrinthDirection.Up);
        }
        private void Right_Click(object sender, EventArgs e)
        {
            TryToMove(LabyrinthDirection.Right);
        }
        private void Down_Click(object sender, EventArgs e)
        {
            TryToMove(LabyrinthDirection.Down);

        }
        private void Left_Click(object sender, EventArgs e)
        {
            TryToMove(LabyrinthDirection.Left);
        }

        #endregion

        #region Other buttons event handlers

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK) // ha kiválasztottunk egy fájlt
            {
                try
                {
                    _model.Load(_openFileDialog.FileName);
                }
                catch (LabyrinthDataException)
                {
                    MessageBox.Show("Játék betöltése sikertelen!" + Environment.NewLine + "Hibás az elérési út, vagy a fájlformátum.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ButtonPause_Click(object sender, EventArgs e)
        {
            _model.Paused = !_model.Paused;
            _timer.Enabled = !_model.Paused;
        }

        #endregion

        #region Timer event handlers

        private void Timer_Tick(Object? sender, EventArgs e)
        {
            _model.AdvanceTime();
        }

        #endregion

        #region Private methods

        private void ChangeBoard(LabyrinthField[,] labyrinth)
        {
            for (int i = 0; i < _tableLayoutGrid.RowCount; i++)
            {
                for (int j = 0; j < _tableLayoutGrid.ColumnCount; j++)
                {
                    Button button = _buttons[i, j];
                    LabyrinthField field = labyrinth[i, j];
                    if (field.isVisible)
                    {
                        switch (field.type)
                        {
                            case LabyrinthFieldType.Player:
                                button.BackColor = Color.Red;
                                break;
                            case LabyrinthFieldType.Empty:
                                button.BackColor = Color.White;
                                break;
                            case LabyrinthFieldType.Wall:
                                button.BackColor = Color.DarkBlue;
                                break;
                        }
                    }
                    else
                    {
                        button.BackColor = Color.Black;
                    }
                }
            }
        }
        private void TryToMove(LabyrinthDirection direction)
        {
            try
            {
                _model.Move(direction);
            }
            catch { }
        }

        #endregion
    }
}

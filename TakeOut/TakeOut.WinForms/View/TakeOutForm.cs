using TakeOut.Model;
using TakeOut.Persistence;
using System.Data;

namespace TakeOut.View
{
    public partial class TakeOutForm : Form
    {
        #region Fields

        private readonly GameModel _model;
        private BoardButton[,]? _buttons;
        private Coords _selected;
        private bool _hasSelected;

        #endregion

        #region Constructors

        public TakeOutForm()
        {
            InitializeComponent();

            _model = new GameModel(new TakeOutFileAccess());
            _model.GameStarted += new EventHandler<EventArgs>(Model_GameStarted);
            _model.PlayerMoved += new EventHandler<EventArgs>(Model_PlayerMoved);
            _model.GameEnded += new EventHandler<EventArgs>(Model_GameEnded);

            _model.NewGame(4);
        }

        #endregion

        #region Model event handlers

        private void Model_GameStarted(Object? sender, EventArgs e)
        {
            
            if (_buttons != null)
            {
                foreach (Button button in _buttons)
                    _tableLayoutGrid.Controls.Remove(button);
            }

            _tableLayoutGrid.RowCount = _model.Board.GetLength(0);
            _tableLayoutGrid.ColumnCount = _model.Board.GetLength(1);

            _buttons = new BoardButton[_tableLayoutGrid.RowCount, _tableLayoutGrid.ColumnCount];


            for (int i = 0; i < _tableLayoutGrid.RowCount; i++)
            {
                for (int j = 0; j < _tableLayoutGrid.ColumnCount; j++)
                {
                    _buttons[i, j] = new BoardButton(new Coords(j,i));
                    _buttons[i, j].Dock = DockStyle.Fill;
                    _buttons[i, j].Click += BoardButton_Click;
                    _tableLayoutGrid.Controls.Add(_buttons[i,j], j, i);
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

            _hasSelected = false;

            ChangeBoard();
        }
        private void Model_PlayerMoved(Object? sender, EventArgs e)
        {
            ChangeBoard();
        }
        private void Model_GameEnded(Object? sender, EventArgs e)
        {
            string text = "";
            switch (_model.Winner)
            {
                case TakeOutField.Empty:
                    text = "Döntetelen!";
                    break;
                case TakeOutField.Black:
                    text = "A fekete győzött!";
                    break;
                case TakeOutField.White:
                    text = "A fehér győzött!";
                    break;
            }
            MessageBox.Show(text,
                "Kitolás",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk);
        }

        #endregion

        #region Button event handlers

        private void BoardButton_Click(Object? sender, EventArgs e)
        {
            BoardButton bb = sender as BoardButton;
            if (bb != null)
            {
                Coords c = bb.coords;
                if (_hasSelected)
                {
                    try
                    {
                        _model.Move(_selected, c);
                    }
                    catch { }
                }
                else if (_model.CanSelect(c))
                {
                    _selected = c;
                    _hasSelected = true;
                }
            }
        }

        private void ButtonLoad_Click(Object? sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _model.Load(_openFileDialog.FileName);
                }
                catch (DataException)
                {
                    MessageBox.Show("Játék betöltése sikertelen!" + Environment.NewLine + "Hibás az elérési út, vagy a fájlformátum.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _model.Save(_saveFileDialog.FileName);
                }
                catch (DataException)
                {
                    MessageBox.Show("Játék mentése sikertelen!" + Environment.NewLine + "Hibás az elérési út, vagy a fájlformátum.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonNew3x3_Click(object sender, EventArgs e)
        {
            _model.NewGame(3);
        }

        private void ButtonNew5x5_Click(object sender, EventArgs e)
        {
            _model.NewGame(5);
        }

        private void ButtonNew6x6_Click(object sender, EventArgs e)
        {
            _model.NewGame(6);
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
                    TakeOutField field = _model.Board[i, j];
                    switch (field)
                    {
                        case TakeOutField.Empty:
                            button.BackColor = Color.Brown;
                            break;
                        case TakeOutField.Black:
                            button.BackColor = Color.Black;
                            break;
                        case TakeOutField.White:
                            button.BackColor = Color.White;
                            break;
                    }
                }
            }
            _labelRounds.Text = $"Kör: {_model.Round} / {5 * _model.N}";
            _hasSelected = false;
        }
        #endregion
    }
}

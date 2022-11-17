using BlockDocu.Model;
using BlockDocu.Persistance;
using System.Data;

namespace BlockDocu.View
{
    public partial class BlockDocuForm : Form
    {
        #region Fields

        private readonly GameModel _model;
        private BoardButton[,]? _buttons;

        #endregion

        #region Constructors

        public BlockDocuForm()
        {
            InitializeComponent();

            _model = new GameModel(new BlockDocuFileAccess());
            _model.GameStarted += new EventHandler<EventArgs>(Model_GameStarted);
            _model.BlockPlaced += new EventHandler<EventArgs>(Model_BlockPlaced);
            _model.GameEnded += new EventHandler<EventArgs>(Model_GameEnded);

            _model.StartNewGame();
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

            _tableLayoutGrid.RowCount = _model.board.GetLength(0);
            _tableLayoutGrid.ColumnCount = _model.board.GetLength(1) + _model.nextBlock.GetLength(1) + 1;

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
            for (int i = 0; i < _model.nextBlock.GetLength(0); i++)
            {
                for (int j = 0; j < _model.nextBlock.GetLength(1); j++)
                {
                    int jr = j + _model.board.GetLength(1) + 1;
                    _buttons[i, jr] = new BoardButton(i, jr);
                    _buttons[i, jr].Dock = DockStyle.Fill;
                    _buttons[i, jr].Enabled = false;
                    _tableLayoutGrid.Controls.Add(_buttons[i, jr], jr, i);
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

            ChangeBoard();
        }
        private void Model_BlockPlaced(Object? sender, EventArgs e)
        {
            ChangeBoard();
        }
        private void Model_GameEnded(Object? sender, EventArgs e)
        {
            if (MessageBox.Show("Nem tudod a következő blokkot lehelyezni." + Environment.NewLine +
                            $"Összesen {_model.points} pontot szereztél." + Environment.NewLine +
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

        #region Button event handlers

        private void BoardButton_Click(Object? sender, EventArgs e)
        {
            BoardButton bb = sender as BoardButton;
            if (bb != null)
            {
                try
                {
                    _model.Place(bb.x, bb.y);
                }
                catch { }
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

        #endregion

        #region Private methods

        private void ChangeBoard()
        {
            for (int i = 0; i < _tableLayoutGrid.RowCount; i++)
            {
                for (int j = 0; j < _tableLayoutGrid.ColumnCount; j++)
                {
                    Button button = _buttons[i, j];
                    Field field;
                    if (j < _model.board.GetLength(1))
                    {
                        field = _model.board[i, j];
                    }
                    else if(i < _model.nextBlock.GetLength(0) && j != _model.board.GetLength(1))
                    {
                        field = _model.nextBlock[i, j - _model.board.GetLength(1) -1];
                    }
                    else
                    {
                        continue;
                    }
                    if (field.isFilled)
                    {
                        button.BackColor = Color.Blue;
                    }
                    else
                    {
                        button.BackColor = Color.White;
                    }
                }
            }
            _labelPoints.Text = $"Pontok: {_model.points}";
        }
        #endregion
    }
}

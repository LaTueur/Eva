namespace Pirézia.View
{
    partial class PiréziaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this._tableLayoutGrid = new System.Windows.Forms.TableLayoutPanel();
            this._tableLayoutUpper = new System.Windows.Forms.TableLayoutPanel();
            this._groupBoxMoney = new System.Windows.Forms.GroupBox();
            this._labelMoney = new System.Windows.Forms.Label();
            this._groupBoxNewGame = new System.Windows.Forms.GroupBox();
            this._buttonNewGame = new System.Windows.Forms.Button();
            this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this._tableLayoutMain.SuspendLayout();
            this._tableLayoutUpper.SuspendLayout();
            this._groupBoxMoney.SuspendLayout();
            this._groupBoxNewGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tableLayoutMain
            // 
            this._tableLayoutMain.ColumnCount = 1;
            this._tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tableLayoutMain.Controls.Add(this._tableLayoutGrid, 0, 1);
            this._tableLayoutMain.Controls.Add(this._tableLayoutUpper, 0, 0);
            this._tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this._tableLayoutMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._tableLayoutMain.Name = "_tableLayoutMain";
            this._tableLayoutMain.RowCount = 2;
            this._tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this._tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tableLayoutMain.Size = new System.Drawing.Size(877, 599);
            this._tableLayoutMain.TabIndex = 3;
            // 
            // _tableLayoutGrid
            // 
            this._tableLayoutGrid.AutoSize = true;
            this._tableLayoutGrid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._tableLayoutGrid.ColumnCount = 2;
            this._tableLayoutGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutGrid.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this._tableLayoutGrid.Location = new System.Drawing.Point(4, 61);
            this._tableLayoutGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._tableLayoutGrid.Name = "_tableLayoutGrid";
            this._tableLayoutGrid.RowCount = 2;
            this._tableLayoutGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutGrid.Size = new System.Drawing.Size(869, 535);
            this._tableLayoutGrid.TabIndex = 3;
            // 
            // _tableLayoutUpper
            // 
            this._tableLayoutUpper.AutoSize = true;
            this._tableLayoutUpper.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._tableLayoutUpper.ColumnCount = 2;
            this._tableLayoutUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.60345F));
            this._tableLayoutUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.39655F));
            this._tableLayoutUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this._tableLayoutUpper.Controls.Add(this._groupBoxMoney, 0, 0);
            this._tableLayoutUpper.Controls.Add(this._groupBoxNewGame, 0, 0);
            this._tableLayoutUpper.Location = new System.Drawing.Point(3, 3);
            this._tableLayoutUpper.Name = "_tableLayoutUpper";
            this._tableLayoutUpper.RowCount = 1;
            this._tableLayoutUpper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutUpper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutUpper.Size = new System.Drawing.Size(201, 52);
            this._tableLayoutUpper.TabIndex = 4;
            // 
            // _groupBoxMoney
            // 
            this._groupBoxMoney.AutoSize = true;
            this._groupBoxMoney.Controls.Add(this._labelMoney);
            this._groupBoxMoney.Location = new System.Drawing.Point(115, 3);
            this._groupBoxMoney.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._groupBoxMoney.Name = "_groupBoxMoney";
            this._groupBoxMoney.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._groupBoxMoney.Size = new System.Drawing.Size(58, 46);
            this._groupBoxMoney.TabIndex = 5;
            this._groupBoxMoney.TabStop = false;
            this._groupBoxMoney.Text = "Pénz";
            // 
            // _labelMoney
            // 
            this._labelMoney.AutoSize = true;
            this._labelMoney.Location = new System.Drawing.Point(7, 19);
            this._labelMoney.Name = "_labelMoney";
            this._labelMoney.Size = new System.Drawing.Size(44, 15);
            this._labelMoney.TabIndex = 1;
            this._labelMoney.Text = "Pénz: 0";
            // 
            // _groupBoxNewGame
            // 
            this._groupBoxNewGame.AutoSize = true;
            this._groupBoxNewGame.Controls.Add(this._buttonNewGame);
            this._groupBoxNewGame.Location = new System.Drawing.Point(4, 3);
            this._groupBoxNewGame.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._groupBoxNewGame.Name = "_groupBoxNewGame";
            this._groupBoxNewGame.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._groupBoxNewGame.Size = new System.Drawing.Size(103, 46);
            this._groupBoxNewGame.TabIndex = 3;
            this._groupBoxNewGame.TabStop = false;
            this._groupBoxNewGame.Text = "Új Játék";
            // 
            // _buttonNewGame
            // 
            this._buttonNewGame.Location = new System.Drawing.Point(8, 13);
            this._buttonNewGame.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._buttonNewGame.Name = "_buttonNewGame";
            this._buttonNewGame.Size = new System.Drawing.Size(88, 27);
            this._buttonNewGame.TabIndex = 0;
            this._buttonNewGame.Text = "Új Játék";
            this._buttonNewGame.UseVisualStyleBackColor = true;
            this._buttonNewGame.Click += new System.EventHandler(this.ButtonNewGame_Click);
            // 
            // _openFileDialog
            // 
            this._openFileDialog.Filter = "BlockDocu fájl|*.bld";
            this._openFileDialog.Title = "Állás  betöltése";
            // 
            // _saveFileDialog
            // 
            this._saveFileDialog.FileName = "save.bld";
            this._saveFileDialog.Filter = "BlockDocu fájl|*.bld";
            this._saveFileDialog.Title = "Állás  betöltése";
            // 
            // PiréziaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 599);
            this.Controls.Add(this._tableLayoutMain);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(698, 472);
            this.Name = "PiréziaForm";
            this.Text = "Pirézia";
            this._tableLayoutMain.ResumeLayout(false);
            this._tableLayoutMain.PerformLayout();
            this._tableLayoutUpper.ResumeLayout(false);
            this._tableLayoutUpper.PerformLayout();
            this._groupBoxMoney.ResumeLayout(false);
            this._groupBoxMoney.PerformLayout();
            this._groupBoxNewGame.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel _tableLayoutMain;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutGrid;
        private OpenFileDialog _openFileDialog;
        private TableLayoutPanel _tableLayoutUpper;
        private GroupBox _groupBoxNewGame;
        private Button _buttonNewGame;
        private GroupBox _groupBoxMoney;
        private Label _labelMoney;
        private SaveFileDialog _saveFileDialog;
    }
}
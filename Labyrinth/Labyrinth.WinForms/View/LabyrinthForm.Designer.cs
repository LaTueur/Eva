namespace Labyrinth.View
{
    partial class LabyrinthForm
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
            this._groupBoxTime = new System.Windows.Forms.GroupBox();
            this._labelTime = new System.Windows.Forms.Label();
            this._buttonPause = new System.Windows.Forms.Button();
            this._groupBoxControl = new System.Windows.Forms.GroupBox();
            this._left = new System.Windows.Forms.Button();
            this._down = new System.Windows.Forms.Button();
            this._right = new System.Windows.Forms.Button();
            this._up = new System.Windows.Forms.Button();
            this._groupBoxLoad = new System.Windows.Forms.GroupBox();
            this._buttonLoad = new System.Windows.Forms.Button();
            this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._tableLayoutMain.SuspendLayout();
            this._tableLayoutUpper.SuspendLayout();
            this._groupBoxTime.SuspendLayout();
            this._groupBoxControl.SuspendLayout();
            this._groupBoxLoad.SuspendLayout();
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
            this._tableLayoutGrid.Enabled = false;
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
            this._tableLayoutUpper.ColumnCount = 3;
            this._tableLayoutUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.60345F));
            this._tableLayoutUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.39655F));
            this._tableLayoutUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this._tableLayoutUpper.Controls.Add(this._groupBoxTime, 0, 0);
            this._tableLayoutUpper.Controls.Add(this._groupBoxControl, 0, 0);
            this._tableLayoutUpper.Controls.Add(this._groupBoxLoad, 0, 0);
            this._tableLayoutUpper.Location = new System.Drawing.Point(3, 3);
            this._tableLayoutUpper.Name = "_tableLayoutUpper";
            this._tableLayoutUpper.RowCount = 1;
            this._tableLayoutUpper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutUpper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutUpper.Size = new System.Drawing.Size(574, 52);
            this._tableLayoutUpper.TabIndex = 4;
            // 
            // _groupBoxTime
            // 
            this._groupBoxTime.AutoSize = true;
            this._groupBoxTime.Controls.Add(this._labelTime);
            this._groupBoxTime.Controls.Add(this._buttonPause);
            this._groupBoxTime.Location = new System.Drawing.Point(352, 3);
            this._groupBoxTime.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._groupBoxTime.Name = "_groupBoxTime";
            this._groupBoxTime.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._groupBoxTime.Size = new System.Drawing.Size(146, 46);
            this._groupBoxTime.TabIndex = 5;
            this._groupBoxTime.TabStop = false;
            this._groupBoxTime.Text = "Idő";
            // 
            // _labelTime
            // 
            this._labelTime.AutoSize = true;
            this._labelTime.Location = new System.Drawing.Point(103, 19);
            this._labelTime.Name = "_labelTime";
            this._labelTime.Size = new System.Drawing.Size(36, 15);
            this._labelTime.TabIndex = 1;
            this._labelTime.Text = "Idő: 0";
            // 
            // _buttonPause
            // 
            this._buttonPause.Location = new System.Drawing.Point(8, 13);
            this._buttonPause.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._buttonPause.Name = "_buttonPause";
            this._buttonPause.Size = new System.Drawing.Size(88, 27);
            this._buttonPause.TabIndex = 0;
            this._buttonPause.Text = "Szünet";
            this._buttonPause.UseVisualStyleBackColor = true;
            this._buttonPause.Click += new System.EventHandler(this.ButtonPause_Click);
            // 
            // _groupBoxControl
            // 
            this._groupBoxControl.AutoSize = true;
            this._groupBoxControl.Controls.Add(this._left);
            this._groupBoxControl.Controls.Add(this._down);
            this._groupBoxControl.Controls.Add(this._right);
            this._groupBoxControl.Controls.Add(this._up);
            this._groupBoxControl.Location = new System.Drawing.Point(198, 3);
            this._groupBoxControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._groupBoxControl.Name = "_groupBoxControl";
            this._groupBoxControl.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._groupBoxControl.Size = new System.Drawing.Size(146, 46);
            this._groupBoxControl.TabIndex = 4;
            this._groupBoxControl.TabStop = false;
            this._groupBoxControl.Text = "Irányítás";
            // 
            // _left
            // 
            this._left.Location = new System.Drawing.Point(112, 13);
            this._left.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._left.Name = "_left";
            this._left.Size = new System.Drawing.Size(27, 27);
            this._left.TabIndex = 3;
            this._left.Text = "←";
            this._left.UseVisualStyleBackColor = true;
            this._left.Click += new System.EventHandler(this.Left_Click);
            // 
            // _down
            // 
            this._down.Location = new System.Drawing.Point(77, 13);
            this._down.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._down.Name = "_down";
            this._down.Size = new System.Drawing.Size(27, 27);
            this._down.TabIndex = 2;
            this._down.Text = "↓";
            this._down.UseVisualStyleBackColor = true;
            this._down.Click += new System.EventHandler(this.Down_Click);
            // 
            // _right
            // 
            this._right.Location = new System.Drawing.Point(42, 13);
            this._right.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._right.Name = "_right";
            this._right.Size = new System.Drawing.Size(27, 27);
            this._right.TabIndex = 1;
            this._right.Text = "→";
            this._right.UseVisualStyleBackColor = true;
            this._right.Click += new System.EventHandler(this.Right_Click);
            // 
            // _up
            // 
            this._up.Location = new System.Drawing.Point(8, 13);
            this._up.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._up.Name = "_up";
            this._up.Size = new System.Drawing.Size(27, 27);
            this._up.TabIndex = 0;
            this._up.Text = "↑";
            this._up.UseVisualStyleBackColor = true;
            this._up.Click += new System.EventHandler(this.Up_Click);
            // 
            // _groupBoxLoad
            // 
            this._groupBoxLoad.AutoSize = true;
            this._groupBoxLoad.Controls.Add(this._buttonLoad);
            this._groupBoxLoad.Location = new System.Drawing.Point(4, 3);
            this._groupBoxLoad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._groupBoxLoad.Name = "_groupBoxLoad";
            this._groupBoxLoad.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._groupBoxLoad.Size = new System.Drawing.Size(104, 46);
            this._groupBoxLoad.TabIndex = 3;
            this._groupBoxLoad.TabStop = false;
            this._groupBoxLoad.Text = "Betöltés";
            // 
            // _buttonLoad
            // 
            this._buttonLoad.Location = new System.Drawing.Point(8, 13);
            this._buttonLoad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._buttonLoad.Name = "_buttonLoad";
            this._buttonLoad.Size = new System.Drawing.Size(88, 27);
            this._buttonLoad.TabIndex = 0;
            this._buttonLoad.Text = "Betöltés";
            this._buttonLoad.UseVisualStyleBackColor = true;
            this._buttonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // _openFileDialog
            // 
            this._openFileDialog.FileName = "easy.lab";
            this._openFileDialog.Filter = "Labirintus fájl|*.lab";
            this._openFileDialog.InitialDirectory = "\\\\?\\C:\\Users\\geonc\\AppData\\Local\\Microsoft\\VisualStudio\\17.0_88a915a4\\WinFormsDes" +
    "igner\\ejiaq3qv.eda\\Labyrinths";
            this._openFileDialog.Title = "Labirintus betöltése";
            // 
            // LabyrinthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 599);
            this.Controls.Add(this._tableLayoutMain);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(698, 472);
            this.Name = "LabyrinthForm";
            this.Text = "Labirintus";
            this._tableLayoutMain.ResumeLayout(false);
            this._tableLayoutMain.PerformLayout();
            this._tableLayoutUpper.ResumeLayout(false);
            this._tableLayoutUpper.PerformLayout();
            this._groupBoxTime.ResumeLayout(false);
            this._groupBoxTime.PerformLayout();
            this._groupBoxControl.ResumeLayout(false);
            this._groupBoxLoad.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel _tableLayoutMain;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutGrid;
        private OpenFileDialog _openFileDialog;
        private TableLayoutPanel _tableLayoutUpper;
        private GroupBox _groupBoxControl;
        private Button _right;
        private Button _up;
        private GroupBox _groupBoxLoad;
        private Button _buttonLoad;
        private Button _left;
        private Button _down;
        private GroupBox _groupBoxTime;
        private Label _labelTime;
        private Button _buttonPause;
    }
}


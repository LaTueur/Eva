namespace BlockDocu.View
{
    partial class BlockDocuForm
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
            this._groupBoxPoints = new System.Windows.Forms.GroupBox();
            this._labelPoints = new System.Windows.Forms.Label();
            this._groupBoxData = new System.Windows.Forms.GroupBox();
            this._buttonSave = new System.Windows.Forms.Button();
            this._buttonLoad = new System.Windows.Forms.Button();
            this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this._tableLayoutMain.SuspendLayout();
            this._tableLayoutUpper.SuspendLayout();
            this._groupBoxPoints.SuspendLayout();
            this._groupBoxData.SuspendLayout();
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
            this._tableLayoutUpper.ColumnCount = 3;
            this._tableLayoutUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.60345F));
            this._tableLayoutUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.39655F));
            this._tableLayoutUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this._tableLayoutUpper.Controls.Add(this._groupBoxPoints, 0, 0);
            this._tableLayoutUpper.Controls.Add(this._groupBoxData, 0, 0);
            this._tableLayoutUpper.Location = new System.Drawing.Point(3, 3);
            this._tableLayoutUpper.Name = "_tableLayoutUpper";
            this._tableLayoutUpper.RowCount = 1;
            this._tableLayoutUpper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutUpper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutUpper.Size = new System.Drawing.Size(585, 52);
            this._tableLayoutUpper.TabIndex = 4;
            // 
            // _groupBoxPoints
            // 
            this._groupBoxPoints.AutoSize = true;
            this._groupBoxPoints.Controls.Add(this._labelPoints);
            this._groupBoxPoints.Location = new System.Drawing.Point(204, 3);
            this._groupBoxPoints.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._groupBoxPoints.Name = "_groupBoxPoints";
            this._groupBoxPoints.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._groupBoxPoints.Size = new System.Drawing.Size(71, 46);
            this._groupBoxPoints.TabIndex = 5;
            this._groupBoxPoints.TabStop = false;
            this._groupBoxPoints.Text = "Pontok";
            // 
            // _labelPoints
            // 
            this._labelPoints.AutoSize = true;
            this._labelPoints.Location = new System.Drawing.Point(7, 19);
            this._labelPoints.Name = "_labelPoints";
            this._labelPoints.Size = new System.Drawing.Size(57, 15);
            this._labelPoints.TabIndex = 1;
            this._labelPoints.Text = "Pontok: 0";
            // 
            // _groupBoxData
            // 
            this._groupBoxData.AutoSize = true;
            this._groupBoxData.Controls.Add(this._buttonSave);
            this._groupBoxData.Controls.Add(this._buttonLoad);
            this._groupBoxData.Location = new System.Drawing.Point(4, 3);
            this._groupBoxData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._groupBoxData.Name = "_groupBoxData";
            this._groupBoxData.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._groupBoxData.Size = new System.Drawing.Size(192, 46);
            this._groupBoxData.TabIndex = 3;
            this._groupBoxData.TabStop = false;
            this._groupBoxData.Text = "Adat Kezelés";
            // 
            // _buttonSave
            // 
            this._buttonSave.Location = new System.Drawing.Point(96, 13);
            this._buttonSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._buttonSave.Name = "_buttonSave";
            this._buttonSave.Size = new System.Drawing.Size(88, 27);
            this._buttonSave.TabIndex = 1;
            this._buttonSave.Text = "Mentés";
            this._buttonSave.UseVisualStyleBackColor = true;
            this._buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
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
            this._openFileDialog.Filter = "BlockDocu fájl|*.bld";
            this._openFileDialog.Title = "Állás  betöltése";
            // 
            // _saveFileDialog
            // 
            this._saveFileDialog.FileName = "save.bld";
            this._saveFileDialog.Filter = "BlockDocu fájl|*.bld";
            this._saveFileDialog.Title = "Állás  betöltése";
            // 
            // BlockDocuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 599);
            this.Controls.Add(this._tableLayoutMain);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(698, 472);
            this.Name = "BlockDocuForm";
            this.Text = "Labirintus";
            this._tableLayoutMain.ResumeLayout(false);
            this._tableLayoutMain.PerformLayout();
            this._tableLayoutUpper.ResumeLayout(false);
            this._tableLayoutUpper.PerformLayout();
            this._groupBoxPoints.ResumeLayout(false);
            this._groupBoxPoints.PerformLayout();
            this._groupBoxData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel _tableLayoutMain;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutGrid;
        private OpenFileDialog _openFileDialog;
        private TableLayoutPanel _tableLayoutUpper;
        private GroupBox _groupBoxData;
        private Button _buttonLoad;
        private GroupBox _groupBoxPoints;
        private Label _labelPoints;
        private Button _buttonSave;
        private SaveFileDialog _saveFileDialog;
    }
}
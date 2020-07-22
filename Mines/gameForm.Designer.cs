namespace Mines
{
    partial class gameForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblBombsCount = new System.Windows.Forms.Label();
            this.lblCB = new System.Windows.Forms.Label();
            this.pnlGameField = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblBombsCount);
            this.splitContainer1.Panel1.Controls.Add(this.lblCB);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlGameField);
            this.splitContainer1.Size = new System.Drawing.Size(510, 472);
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.TabIndex = 1;
            // 
            // lblBombsCount
            // 
            this.lblBombsCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblBombsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBombsCount.Location = new System.Drawing.Point(176, 0);
            this.lblBombsCount.Name = "lblBombsCount";
            this.lblBombsCount.Size = new System.Drawing.Size(100, 40);
            this.lblBombsCount.TabIndex = 1;
            this.lblBombsCount.Text = "1";
            this.lblBombsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCB
            // 
            this.lblCB.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCB.Location = new System.Drawing.Point(0, 0);
            this.lblCB.Name = "lblCB";
            this.lblCB.Size = new System.Drawing.Size(176, 40);
            this.lblCB.TabIndex = 0;
            this.lblCB.Text = "Осталось бомб: ";
            this.lblCB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlGameField
            // 
            this.pnlGameField.AutoScroll = true;
            this.pnlGameField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGameField.Location = new System.Drawing.Point(0, 0);
            this.pnlGameField.Name = "pnlGameField";
            this.pnlGameField.Size = new System.Drawing.Size(510, 428);
            this.pnlGameField.TabIndex = 0;
            // 
            // gameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(510, 472);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Name = "gameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Минное поле";
            this.Load += new System.EventHandler(this.gameForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblCB;
        private System.Windows.Forms.Label lblBombsCount;
        private System.Windows.Forms.Panel pnlGameField;
    }
}
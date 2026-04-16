namespace FileCompare
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel2 = new Panel();
            txtLeftDir = new TextBox();
            btnLeftDir = new Button();
            splitContainer1 = new SplitContainer();
            panel3 = new Panel();
            lvwLeftDir = new ListView();
            LeftName = new ColumnHeader();
            LeftSize = new ColumnHeader();
            LeftDate = new ColumnHeader();
            panel1 = new Panel();
            btnCopyFromLeft = new Button();
            lblAppName = new Label();
            panel6 = new Panel();
            lvwRightDir = new ListView();
            RightName = new ColumnHeader();
            RightSize = new ColumnHeader();
            RightDate = new ColumnHeader();
            panel5 = new Panel();
            txtRightDir = new TextBox();
            btnRightDir = new Button();
            panel4 = new Panel();
            btnCopyFromRight = new Button();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ScrollBar;
            panel2.Controls.Add(txtLeftDir);
            panel2.Controls.Add(btnLeftDir);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 100);
            panel2.Name = "panel2";
            panel2.Size = new Size(399, 60);
            panel2.TabIndex = 0;
            // 
            // txtLeftDir
            // 
            txtLeftDir.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtLeftDir.Location = new Point(9, 16);
            txtLeftDir.Name = "txtLeftDir";
            txtLeftDir.Size = new Size(306, 23);
            txtLeftDir.TabIndex = 3;
            // 
            // btnLeftDir
            // 
            btnLeftDir.Anchor = AnchorStyles.Right;
            btnLeftDir.Location = new Point(321, 17);
            btnLeftDir.Name = "btnLeftDir";
            btnLeftDir.Size = new Size(75, 23);
            btnLeftDir.TabIndex = 2;
            btnLeftDir.Text = "폴더선택";
            btnLeftDir.UseVisualStyleBackColor = true;
            btnLeftDir.Click += btnLeftDir_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(5, 5);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel3);
            splitContainer1.Panel1.Controls.Add(panel2);
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel6);
            splitContainer1.Panel2.Controls.Add(panel5);
            splitContainer1.Panel2.Controls.Add(panel4);
            splitContainer1.Size = new Size(790, 440);
            splitContainer1.SplitterDistance = 399;
            splitContainer1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlDarkDark;
            panel3.Controls.Add(lvwLeftDir);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 160);
            panel3.Name = "panel3";
            panel3.Size = new Size(399, 280);
            panel3.TabIndex = 2;
            // 
            // lvwLeftDir
            // 
            lvwLeftDir.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvwLeftDir.Columns.AddRange(new ColumnHeader[] { LeftName, LeftSize, LeftDate });
            lvwLeftDir.FullRowSelect = true;
            lvwLeftDir.GridLines = true;
            lvwLeftDir.Location = new Point(8, 9);
            lvwLeftDir.Name = "lvwLeftDir";
            lvwLeftDir.Size = new Size(385, 262);
            lvwLeftDir.TabIndex = 0;
            lvwLeftDir.UseCompatibleStateImageBehavior = false;
            lvwLeftDir.View = View.Details;
            // 
            // LeftName
            // 
            LeftName.Text = "이름";
            LeftName.Width = 100;
            // 
            // LeftSize
            // 
            LeftSize.Text = "크기";
            LeftSize.Width = 100;
            // 
            // LeftDate
            // 
            LeftDate.Text = "수정한 날짜";
            LeftDate.Width = 160;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCopyFromLeft);
            panel1.Controls.Add(lblAppName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(399, 100);
            panel1.TabIndex = 1;
            // 
            // btnCopyFromLeft
            // 
            btnCopyFromLeft.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCopyFromLeft.Location = new Point(319, 62);
            btnCopyFromLeft.Name = "btnCopyFromLeft";
            btnCopyFromLeft.Size = new Size(75, 32);
            btnCopyFromLeft.TabIndex = 1;
            btnCopyFromLeft.Text = ">>>";
            btnCopyFromLeft.UseVisualStyleBackColor = true;
            btnCopyFromLeft.Click += btnCopyFromLeft_Click;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.BackColor = SystemColors.Control;
            lblAppName.Font = new Font("맑은 고딕", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblAppName.ForeColor = SystemColors.HotTrack;
            lblAppName.Location = new Point(9, 8);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(230, 47);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "File Compare";
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.ControlText;
            panel6.Controls.Add(lvwRightDir);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 160);
            panel6.Name = "panel6";
            panel6.Size = new Size(387, 280);
            panel6.TabIndex = 2;
            // 
            // lvwRightDir
            // 
            lvwRightDir.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvwRightDir.Columns.AddRange(new ColumnHeader[] { RightName, RightSize, RightDate });
            lvwRightDir.FullRowSelect = true;
            lvwRightDir.GridLines = true;
            lvwRightDir.Location = new Point(3, 9);
            lvwRightDir.Name = "lvwRightDir";
            lvwRightDir.Size = new Size(381, 262);
            lvwRightDir.TabIndex = 1;
            lvwRightDir.UseCompatibleStateImageBehavior = false;
            lvwRightDir.View = View.Details;
            // 
            // RightName
            // 
            RightName.Text = "이름";
            RightName.Width = 100;
            // 
            // RightSize
            // 
            RightSize.Text = "크기";
            RightSize.Width = 100;
            // 
            // RightDate
            // 
            RightDate.Text = "수정한 날짜";
            RightDate.Width = 160;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ControlDarkDark;
            panel5.Controls.Add(txtRightDir);
            panel5.Controls.Add(btnRightDir);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 100);
            panel5.Name = "panel5";
            panel5.Size = new Size(387, 60);
            panel5.TabIndex = 1;
            // 
            // txtRightDir
            // 
            txtRightDir.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtRightDir.Location = new Point(3, 18);
            txtRightDir.Name = "txtRightDir";
            txtRightDir.Size = new Size(300, 23);
            txtRightDir.TabIndex = 5;
            // 
            // btnRightDir
            // 
            btnRightDir.Anchor = AnchorStyles.Right;
            btnRightDir.Location = new Point(309, 17);
            btnRightDir.Name = "btnRightDir";
            btnRightDir.Size = new Size(75, 23);
            btnRightDir.TabIndex = 4;
            btnRightDir.Text = "폴더선택";
            btnRightDir.UseVisualStyleBackColor = true;
            btnRightDir.Click += btnRightDir_Click;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ScrollBar;
            panel4.Controls.Add(btnCopyFromRight);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(387, 100);
            panel4.TabIndex = 0;
            // 
            // btnCopyFromRight
            // 
            btnCopyFromRight.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCopyFromRight.Location = new Point(3, 62);
            btnCopyFromRight.Name = "btnCopyFromRight";
            btnCopyFromRight.Size = new Size(75, 32);
            btnCopyFromRight.TabIndex = 2;
            btnCopyFromRight.Text = "<<<";
            btnCopyFromRight.UseVisualStyleBackColor = true;
            btnCopyFromRight.Click += btnCopyFromRight_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Padding = new Padding(5);
            Text = "File Compare v1.0";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private TextBox txtLeftDir;
        private Button btnLeftDir;
        private ListView lvwLeftDir;
        private Button btnCopyFromLeft;
        private Label lblAppName;
        private ListView lvwRightDir;
        private TextBox txtRightDir;
        private Button btnRightDir;
        private Button btnCopyFromRight;
        private ColumnHeader LeftName;
        private ColumnHeader LeftSize;
        private ColumnHeader LeftDate;
        private ColumnHeader RightName;
        private ColumnHeader RightSize;
        private ColumnHeader RightDate;
    }
}

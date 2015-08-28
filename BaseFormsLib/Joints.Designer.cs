namespace BaseFormsLib
{
    partial class Joints
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCaption = new System.Windows.Forms.Label();
            this.cmbMain = new System.Windows.Forms.ComboBox();
            this.gbSecond = new System.Windows.Forms.GroupBox();
            this.btnToLeft = new System.Windows.Forms.Button();
            this.btnToRight = new System.Windows.Forms.Button();
            this.lblSelected = new System.Windows.Forms.Label();
            this.lblNotSelected = new System.Windows.Forms.Label();
            this.lbYes = new System.Windows.Forms.ListBox();
            this.lbNot = new System.Windows.Forms.ListBox();
            this.gbSecond.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Location = new System.Drawing.Point(-3, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(57, 13);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "Название";
            // 
            // cmbMain
            // 
            this.cmbMain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMain.FormattingEnabled = true;
            this.cmbMain.Location = new System.Drawing.Point(0, 16);
            this.cmbMain.Name = "cmbMain";
            this.cmbMain.Size = new System.Drawing.Size(263, 21);
            this.cmbMain.TabIndex = 1;
            this.cmbMain.SelectedIndexChanged += new System.EventHandler(this.cmbMain_SelectedIndexChanged);
            // 
            // gbSecond
            // 
            this.gbSecond.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSecond.Controls.Add(this.btnToLeft);
            this.gbSecond.Controls.Add(this.btnToRight);
            this.gbSecond.Controls.Add(this.lblSelected);
            this.gbSecond.Controls.Add(this.lblNotSelected);
            this.gbSecond.Controls.Add(this.lbYes);
            this.gbSecond.Controls.Add(this.lbNot);
            this.gbSecond.Location = new System.Drawing.Point(0, 56);
            this.gbSecond.Name = "gbSecond";
            this.gbSecond.Size = new System.Drawing.Size(370, 315);
            this.gbSecond.TabIndex = 2;
            this.gbSecond.TabStop = false;
            this.gbSecond.Text = "Название 2";
            // 
            // btnToLeft
            // 
            this.btnToLeft.Location = new System.Drawing.Point(166, 133);
            this.btnToLeft.Name = "btnToLeft";
            this.btnToLeft.Size = new System.Drawing.Size(39, 23);
            this.btnToLeft.TabIndex = 2;
            this.btnToLeft.Text = "<---";
            this.btnToLeft.UseVisualStyleBackColor = true;
            this.btnToLeft.Click += new System.EventHandler(this.btnToLeft_Click);
            // 
            // btnToRight
            // 
            this.btnToRight.Location = new System.Drawing.Point(166, 86);
            this.btnToRight.Name = "btnToRight";
            this.btnToRight.Size = new System.Drawing.Size(39, 23);
            this.btnToRight.TabIndex = 2;
            this.btnToRight.Text = "--->";
            this.btnToRight.UseVisualStyleBackColor = true;
            this.btnToRight.Click += new System.EventHandler(this.btnToRight_Click);
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Location = new System.Drawing.Point(218, 22);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(57, 13);
            this.lblSelected.TabIndex = 1;
            this.lblSelected.Text = "Выбраны:";
            // 
            // lblNotSelected
            // 
            this.lblNotSelected.AutoSize = true;
            this.lblNotSelected.Location = new System.Drawing.Point(3, 22);
            this.lblNotSelected.Name = "lblNotSelected";
            this.lblNotSelected.Size = new System.Drawing.Size(73, 13);
            this.lblNotSelected.TabIndex = 1;
            this.lblNotSelected.Text = "Не выбраны:";
            // 
            // lbYes
            // 
            this.lbYes.AllowDrop = true;
            this.lbYes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbYes.FormattingEnabled = true;
            this.lbYes.Location = new System.Drawing.Point(222, 38);
            this.lbYes.Name = "lbYes";
            this.lbYes.Size = new System.Drawing.Size(142, 264);
            this.lbYes.TabIndex = 0;
            this.lbYes.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbYes_DragDrop);
            this.lbYes.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbYes_DragEnter);
            this.lbYes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbYes_MouseDown);
            // 
            // lbNot
            // 
            this.lbNot.AllowDrop = true;
            this.lbNot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbNot.FormattingEnabled = true;
            this.lbNot.Location = new System.Drawing.Point(6, 38);
            this.lbNot.Name = "lbNot";
            this.lbNot.Size = new System.Drawing.Size(142, 264);
            this.lbNot.TabIndex = 0;
            this.lbNot.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbNot_DragDrop);
            this.lbNot.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbNot_DragEnter);
            this.lbNot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbNot_MouseDown);
            // 
            // Joints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbSecond);
            this.Controls.Add(this.cmbMain);
            this.Controls.Add(this.lblCaption);
            this.Name = "Joints";
            this.Size = new System.Drawing.Size(373, 374);
            this.Resize += new System.EventHandler(this.Joints_Resize);
            this.gbSecond.ResumeLayout(false);
            this.gbSecond.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.ComboBox cmbMain;
        private System.Windows.Forms.GroupBox gbSecond;
        private System.Windows.Forms.Button btnToLeft;
        private System.Windows.Forms.Button btnToRight;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Label lblNotSelected;
        private System.Windows.Forms.ListBox lbYes;
        private System.Windows.Forms.ListBox lbNot;
    }
}

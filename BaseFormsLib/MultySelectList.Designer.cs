namespace BaseFormsLib
{
    partial class MultySelectList
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
            this.btnSelectValue = new System.Windows.Forms.Button();
            this.lbSelectedValues = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnSelectValue
            // 
            this.btnSelectValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectValue.Location = new System.Drawing.Point(315, 3);
            this.btnSelectValue.Name = "btnSelectValue";
            this.btnSelectValue.Size = new System.Drawing.Size(41, 25);
            this.btnSelectValue.TabIndex = 102;
            this.btnSelectValue.Text = "...";
            this.btnSelectValue.UseVisualStyleBackColor = true;
            this.btnSelectValue.Click += new System.EventHandler(this.btnSelectValue_Click);
            // 
            // lbSelectedValues
            // 
            this.lbSelectedValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSelectedValues.FormattingEnabled = true;
            this.lbSelectedValues.Location = new System.Drawing.Point(3, 3);
            this.lbSelectedValues.Name = "lbSelectedValues";
            this.lbSelectedValues.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbSelectedValues.Size = new System.Drawing.Size(306, 95);
            this.lbSelectedValues.TabIndex = 101;
            // 
            // MultySelectList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSelectValue);
            this.Controls.Add(this.lbSelectedValues);
            this.Name = "MultySelectList";
            this.Size = new System.Drawing.Size(359, 109);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button btnSelectValue;
        private System.Windows.Forms.ListBox lbSelectedValues;
    }
}

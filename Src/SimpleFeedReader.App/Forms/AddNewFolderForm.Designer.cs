namespace SimpleFeedReader.App.Forms
{
    partial class AddNewFolderForm
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
            this.lbFolderName = new System.Windows.Forms.Label();
            this.tbxFolderName = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbFolderName
            // 
            this.lbFolderName.AccessibleName = "folder name";
            this.lbFolderName.AutoSize = true;
            this.lbFolderName.Location = new System.Drawing.Point(0, 0);
            this.lbFolderName.Name = "lbFolderName";
            this.lbFolderName.Size = new System.Drawing.Size(62, 13);
            this.lbFolderName.TabIndex = 0;
            this.lbFolderName.Text = "folder name";
            // 
            // tbxFolderName
            // 
            this.tbxFolderName.AccessibleName = "folder name";
            this.tbxFolderName.Location = new System.Drawing.Point(8, 7);
            this.tbxFolderName.Name = "tbxFolderName";
            this.tbxFolderName.Size = new System.Drawing.Size(100, 20);
            this.tbxFolderName.TabIndex = 1;
            this.tbxFolderName.TextChanged += new System.EventHandler(this.tbxFolderName_TextChanged);
            // 
            // btnOk
            // 
            this.btnOk.AccessibleName = "ok";
            this.btnOk.BackColor = System.Drawing.Color.Cyan;
            this.btnOk.Location = new System.Drawing.Point(16, 15);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "cancel";
            this.btnCancel.BackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(363, 214);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "cancle";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // AddNewFolderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tbxFolderName);
            this.Controls.Add(this.lbFolderName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddNewFolderForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "AddNewFolder";
            this.Load += new System.EventHandler(this.AddNewFolderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFolderName;
        private System.Windows.Forms.TextBox tbxFolderName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
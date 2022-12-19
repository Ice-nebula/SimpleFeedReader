namespace SimpleFeedReader.App.Forms
{
    partial class MainForm
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
            this.lbFeedFolder = new System.Windows.Forms.Label();
            this.tvwFeedFolder = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // lbFeedFolder
            // 
            this.lbFeedFolder.AccessibleName = "feed folder";
            this.lbFeedFolder.AutoSize = true;
            this.lbFeedFolder.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbFeedFolder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbFeedFolder.Location = new System.Drawing.Point(0, 100);
            this.lbFeedFolder.Name = "lbFeedFolder";
            this.lbFeedFolder.Size = new System.Drawing.Size(57, 13);
            this.lbFeedFolder.TabIndex = 0;
            this.lbFeedFolder.Text = "feed folder";
            // 
            // tvwFeedFolder
            // 
            this.tvwFeedFolder.AccessibleName = "feed folder";
            this.tvwFeedFolder.Location = new System.Drawing.Point(8, 108);
            this.tvwFeedFolder.Name = "tvwFeedFolder";
            this.tvwFeedFolder.Size = new System.Drawing.Size(121, 97);
            this.tvwFeedFolder.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AccessibleName = "simple feed reader";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tvwFeedFolder);
            this.Controls.Add(this.lbFeedFolder);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "simple feed reader";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFeedFolder;
        private System.Windows.Forms.TreeView tvwFeedFolder;
    }
}
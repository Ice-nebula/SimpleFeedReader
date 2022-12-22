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
            this.lbFeeds = new System.Windows.Forms.Label();
            this.lvFeeds = new System.Windows.Forms.ListView();
            this.lbFeedEntries = new System.Windows.Forms.Label();
            this.lvFeedEntries = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lbFeedFolder
            // 
            this.lbFeedFolder.AccessibleName = "feed folder";
            this.lbFeedFolder.AutoSize = true;
            this.lbFeedFolder.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbFeedFolder.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbFeedFolder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbFeedFolder.Location = new System.Drawing.Point(0, 0);
            this.lbFeedFolder.Name = "lbFeedFolder";
            this.lbFeedFolder.Size = new System.Drawing.Size(57, 13);
            this.lbFeedFolder.TabIndex = 0;
            this.lbFeedFolder.Text = "feed folder";
            // 
            // tvwFeedFolder
            // 
            this.tvwFeedFolder.AccessibleName = "feed folder";
            this.tvwFeedFolder.BackColor = System.Drawing.Color.Turquoise;
            this.tvwFeedFolder.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvwFeedFolder.Location = new System.Drawing.Point(57, 0);
            this.tvwFeedFolder.Name = "tvwFeedFolder";
            this.tvwFeedFolder.Size = new System.Drawing.Size(121, 450);
            this.tvwFeedFolder.TabIndex = 1;
            this.tvwFeedFolder.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwFeedFolder_AfterSelect);
            this.tvwFeedFolder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvwFeedFolder_KeyDown);
            // 
            // lbFeeds
            // 
            this.lbFeeds.AccessibleName = "feeds";
            this.lbFeeds.AutoSize = true;
            this.lbFeeds.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbFeeds.Location = new System.Drawing.Point(178, 0);
            this.lbFeeds.Name = "lbFeeds";
            this.lbFeeds.Size = new System.Drawing.Size(33, 13);
            this.lbFeeds.TabIndex = 2;
            this.lbFeeds.Text = "feeds";
            // 
            // lvFeeds
            // 
            this.lvFeeds.AccessibleName = "feeds";
            this.lvFeeds.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvFeeds.HideSelection = false;
            this.lvFeeds.Location = new System.Drawing.Point(211, 0);
            this.lvFeeds.MultiSelect = false;
            this.lvFeeds.Name = "lvFeeds";
            this.lvFeeds.Size = new System.Drawing.Size(121, 450);
            this.lvFeeds.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvFeeds.TabIndex = 3;
            this.lvFeeds.UseCompatibleStateImageBehavior = false;
            this.lvFeeds.View = System.Windows.Forms.View.List;
            this.lvFeeds.SelectedIndexChanged += new System.EventHandler(this.lvFeeds_SelectedIndexChanged);
            // 
            // lbFeedEntries
            // 
            this.lbFeedEntries.AccessibleName = "feed entries";
            this.lbFeedEntries.AutoSize = true;
            this.lbFeedEntries.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbFeedEntries.Location = new System.Drawing.Point(738, 0);
            this.lbFeedEntries.Name = "lbFeedEntries";
            this.lbFeedEntries.Size = new System.Drawing.Size(62, 13);
            this.lbFeedEntries.TabIndex = 4;
            this.lbFeedEntries.Text = "feed entries";
            // 
            // lvFeedEntries
            // 
            this.lvFeedEntries.AccessibleName = "feed entries";
            this.lvFeedEntries.BackColor = System.Drawing.Color.Violet;
            this.lvFeedEntries.Dock = System.Windows.Forms.DockStyle.Right;
            this.lvFeedEntries.FullRowSelect = true;
            this.lvFeedEntries.GridLines = true;
            this.lvFeedEntries.HideSelection = false;
            this.lvFeedEntries.Location = new System.Drawing.Point(617, 0);
            this.lvFeedEntries.MultiSelect = false;
            this.lvFeedEntries.Name = "lvFeedEntries";
            this.lvFeedEntries.Size = new System.Drawing.Size(121, 450);
            this.lvFeedEntries.TabIndex = 5;
            this.lvFeedEntries.UseCompatibleStateImageBehavior = false;
            this.lvFeedEntries.View = System.Windows.Forms.View.SmallIcon;
            this.lvFeedEntries.SelectedIndexChanged += new System.EventHandler(this.lvFeedEntries_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AccessibleName = "simple feed reader";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvFeedEntries);
            this.Controls.Add(this.lbFeedEntries);
            this.Controls.Add(this.lvFeeds);
            this.Controls.Add(this.lbFeeds);
            this.Controls.Add(this.tvwFeedFolder);
            this.Controls.Add(this.lbFeedFolder);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "simple feed reader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFeedFolder;
        private System.Windows.Forms.TreeView tvwFeedFolder;
        private System.Windows.Forms.Label lbFeeds;
        private System.Windows.Forms.ListView lvFeeds;
        private System.Windows.Forms.Label lbFeedEntries;
        private System.Windows.Forms.ListView lvFeedEntries;
    }
}
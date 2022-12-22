using SimpleFeedReader.App.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFeedReader.App.Forms
{
    public partial class MainForm : Form
    {
private FeedDataController _feedDataController { get; set; }
        private ContextMenu _tvwContextMenu;
        private ContextMenu _lvFeedsContextMenu;
        private MenuItem _addNewFolderMenuItem;
        private MenuItem _deleteFolderMenuItem;
        private MenuItem _addNewFeedMenuItem;
        public MainForm()
        {
            InitializeComponent();
            _lvFeedsContextMenu = new ContextMenu();
            _feedDataController = new FeedDataController(tvwFeedFolder, lvFeeds,lvFeedEntries);
            _tvwContextMenu = new ContextMenu();
            PopulateContextMenu();
            _tvwContextMenu.Popup += _tvwContextMenu_Popup;
        }

        private void _tvwContextMenu_Popup(object sender, EventArgs e)
        {
            if (tvwFeedFolder.SelectedNode.Level == 0)
            {
                _deleteFolderMenuItem.Enabled = false;
            } //end if
            else if (tvwFeedFolder.SelectedNode.Level > 0 && _deleteFolderMenuItem.Enabled == false)
            {
                _deleteFolderMenuItem.Enabled = true;
            } //end else if
            if (tvwFeedFolder.SelectedNode == null)
            {
                _addNewFeedMenuItem.Enabled = false;
                _addNewFolderMenuItem.Enabled = false;
                _deleteFolderMenuItem.Enabled = false;
            } //endif
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            _feedDataController.Load();
        }

        private void PopulateContextMenu()
        {
            lvFeeds.ContextMenu = _lvFeedsContextMenu;
            tvwFeedFolder.ContextMenu = _tvwContextMenu;
            _addNewFolderMenuItem = new MenuItem("add new folder");
            _addNewFeedMenuItem= new MenuItem("add new feed");
            _deleteFolderMenuItem = new MenuItem("delete folder");
            var addNewFeedMenuItemClone = _addNewFeedMenuItem.CloneMenu();
addNewFeedMenuItemClone.Click +=new EventHandler(_addNewFeedMenuItem_Click);
            _tvwContextMenu.MenuItems.Add(_addNewFeedMenuItem);
            _lvFeedsContextMenu.MenuItems.Add(addNewFeedMenuItemClone);
            _tvwContextMenu.MenuItems.Add(_addNewFolderMenuItem);
            _tvwContextMenu.MenuItems.Add(_deleteFolderMenuItem);
            _addNewFolderMenuItem.Click += _addNewFolderMenuItem_Click;
            _deleteFolderMenuItem.Click += _deleteFolderMenuItem_Click;
            _addNewFeedMenuItem.Click += _addNewFeedMenuItem_Click;
        }//end method

        private void _addNewFeedMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new AddNewFeedForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (form.FeedItem == null) return;
                    _feedDataController.AddNewFeed(form.FeedItem);
                } //end if
            }//end using
        }

        private void _deleteFolderMenuItem_Click(object sender, EventArgs e)
        {
            deleteFolder();
        }

        private void _addNewFolderMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AddNewFolderForm();
           var result =  form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                _feedDataController.AddNewFolder(form._feedFolder);
            } //end if
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_feedDataController.Modified == true)
            {
                var result = MessageBox.Show("do you want to save changes?", "save", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _feedDataController.Save();

                } //end if
            } //end if
        }

        private void tvwFeedFolder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                deleteFolder();
            } //end if
        }

        private void deleteFolder()
        {
            var result = MessageBox.Show("do you want to delete this folder?,", "delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                _feedDataController.DeleteFolderAndSubFolders();
            } //end if. check result dialog is yes
        } //end method.delete folder

        private void tvwFeedFolder_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _feedDataController.LoadFeedsToListView();
        }

        private void lvFeedEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private async void lvFeeds_SelectedIndexChanged(object sender, EventArgs e)
        {
           await _feedDataController.fetchNewFeedAsync();
        }
    } //end class
}//end namespace

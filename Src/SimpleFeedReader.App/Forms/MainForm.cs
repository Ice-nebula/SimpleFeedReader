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
        private MenuItem _addNewFolderMenuItem;
        private MenuItem _addNewFeedMenuItem;
        public MainForm()
        {
            InitializeComponent();
            _feedDataController = new FeedDataController(tvwFeedFolder);
            _tvwContextMenu = new ContextMenu();
            PopulateContextMenu();
            _tvwContextMenu.Popup += _tvwContextMenu_Popup;
        }

        private void _tvwContextMenu_Popup(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _feedDataController.Load();
        }

        private void PopulateContextMenu()
        {
            tvwFeedFolder.ContextMenu = _tvwContextMenu;
            _addNewFolderMenuItem = new MenuItem("add new folder");
            _addNewFeedMenuItem= new MenuItem("add new feed");
            _tvwContextMenu.MenuItems.Add(_addNewFeedMenuItem);
            _tvwContextMenu.MenuItems.Add(_addNewFolderMenuItem);
            _addNewFolderMenuItem.Click += _addNewFolderMenuItem_Click;
    
        }//end method

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
    } //end class
}//end namespace

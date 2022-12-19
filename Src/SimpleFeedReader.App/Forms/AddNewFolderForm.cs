using SimpleFeedReader.App.Entities;
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
    public partial class AddNewFolderForm : Form
    {
public  FeedFolder _feedFolder { get; private set; }
        public AddNewFolderForm()
        {
            InitializeComponent();
            _feedFolder = new FeedFolder("feed folder");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_feedFolder.Name))
            {
                return;
            } //end if.check empty string
            this.DialogResult = DialogResult.OK;
        }

        private void tbxFolderName_TextChanged(object sender, EventArgs e)
        {
            _feedFolder.Name = tbxFolderName.Text;
        }

        private void AddNewFolderForm_Load(object sender, EventArgs e)
        {
            tbxFolderName.Text = _feedFolder.Name;
        }
    }
}

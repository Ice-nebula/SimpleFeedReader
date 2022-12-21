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
    public partial class AddNewFeedForm : Form
    {
        public FeedDataItem FeedItem { get; set; }
        public AddNewFeedForm()
        {
            InitializeComponent();
            FeedItem = new FeedDataItem();
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            FeedItem.Name = tbxName.Text;
        }

        private void tbxUrl_TextChanged(object sender, EventArgs e)
        {
            FeedItem.Url = tbxUrl.Text;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FeedItem.Name) || string.IsNullOrEmpty(FeedItem.Url))
            {
                this.DialogResult = DialogResult.Cancel;
            } //end if
        }
    }
}

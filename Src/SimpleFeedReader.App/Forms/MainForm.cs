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
        public MainForm()
        {
            InitializeComponent();
            _feedDataController = new FeedDataController(tvwFeedFolder);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _feedDataController.LoadFeedFolder();
        }
    }
}

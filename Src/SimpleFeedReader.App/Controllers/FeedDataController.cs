using SimpleFeedReader.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SimpleFeedReader.App.Controllers
{
    public class FeedDataController
    {
private FeedFolder _FeedFolder { get; set; }
private System.Windows.Forms.TreeView _treeView { get; set; }
        public FeedDataController(System.Windows.Forms.TreeView treeView)
        {
            _FeedFolder = new FeedFolder("news");
            _treeView = treeView;
        } //end con

        public void LoadFeedFolder()
        {
            _treeView.Nodes.Clear();
                        var route = new TreeNode(_FeedFolder.Name);
            route.Tag = _FeedFolder;
            _treeView.Nodes.Add(route);
        } //end method

        private void PopulateTreeView(TreeNode routeNode, FeedFolder feedFolder)
        {
            if (feedFolder.SubFolders.Count > 0)
            {
                foreach (var f in feedFolder.SubFolders)
                {
                    var treeNode = new TreeNode(f.Name);
                    treeNode.Tag = f;
                    routeNode.Nodes.Add(treeNode);
                    PopulateTreeView(treeNode, f);
                } //end foreach
            } //end if
        } //end method
    }
}

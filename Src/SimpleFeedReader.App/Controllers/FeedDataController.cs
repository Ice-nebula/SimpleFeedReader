using SimpleFeedReader.App.Entities;
using SimpleFeedReader.App.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SimpleFeedReader.App.Controllers
{
    public class FeedDataController
    {
        FeedFolder _feedCollection { get; set; }
public bool Modified { get; private set; }
private System.Windows.Forms.TreeView _treeView { get; set; }
        public FeedDataController(System.Windows.Forms.TreeView treeView)
        {
            _feedCollection = new FeedFolder("database");
            _treeView = treeView;
        } //end con
        public void DeleteFolderAndSubFolder()
        {
            var node = _treeView.SelectedNode;
            if (node == null || node.Parent == null) return;
            FeedFolder parentFolder = (FeedFolder)_treeView.SelectedNode.Parent.Tag;
            FeedFolder folder = (FeedFolder)node.Tag;
            folder.DeleteAll();
            parentFolder.SubFolders.Remove(folder);
            _treeView.Nodes.Remove(node);
            Modified = true;
        } //end method

        public void AddNewFolder(FeedFolder item)
        {
            if (_treeView.SelectedNode == null) return;
            FeedFolder folder = (FeedFolder)_treeView.SelectedNode.Tag;
            var treeNode = new TreeNode(item.Name);
            treeNode.Tag = item;
            _treeView.SelectedNode.Nodes.Add(treeNode);
            folder.AddSubFolder(item);
            Modified = true;
        } //end method

        public void Load()
        {
            Modified = false;
            if (File.Exists(@"database.xml") == true)
            {
                var rawXml = File.ReadAllText(@"database.xml");
                _feedCollection = XmlDataManager.Deserialize<FeedFolder>(rawXml);
            } //end if
                        var route = new TreeNode(_feedCollection.Name);
            route.Tag = _feedCollection;
            _treeView.Nodes.Add(route);
            foreach (var f in _feedCollection.SubFolders)
            {
                PopulateTreeView(route, f);
            } //end for.each
        } //end method

        private void PopulateTreeView(TreeNode routeNode, FeedFolder feedFolder)
        {
            var treeNode = new TreeNode(feedFolder.Name);
            treeNode.Tag = feedFolder;
            routeNode.Nodes.Add(treeNode);
            foreach (var f in feedFolder.SubFolders)
                {
                    PopulateTreeView(treeNode, f);
                } //end foreach
        } //end method
        public void Save()
        {
            var data = XmlDataManager.Serialize(_feedCollection);
            File.WriteAllText("database.xml", data);
        } //end method.save
    }//end class
}//end namespace

using SimpleFeedReader.App.Entities;
using SimpleFeedReader.App.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
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
private System.Windows.Forms.ListView _feedsListView { get; set; }
        public FeedDataController(System.Windows.Forms.TreeView treeView, System.Windows.Forms.ListView feedsListView)
        {
            _feedCollection = new FeedFolder("database");
            _treeView = treeView;
            _feedsListView = feedsListView;
        } //end con
        public void AddNewFeed(FeedDataItem item)
        {
            if (_treeView.SelectedNode == null) return;
            var folder = (FeedFolder)_treeView.SelectedNode.Tag;
            if (ValidateUrl(item.Url) == false) return;
            _feedsListView.BeginUpdate();
            folder.AddFeedData(item);
            var listViewItem = new ListViewItem(item.Name);
            _feedsListView.Items.Add(listViewItem);
            _feedsListView.EndUpdate();
            Modified = true;
        } //end method

        public void LoadFeedsToListView()
        {
            if (_treeView.SelectedNode == null) return;
            _feedsListView.Items.Clear();
            var feedsFolder = (FeedFolder)_treeView.SelectedNode.Tag;
            var temp = new List<ListViewItem>();
            foreach (var item in feedsFolder.FeedDataItems)
            {
                var listViewItem = new ListViewItem(item.Name);
                listViewItem.Tag = item;
                temp.Add(listViewItem);
            } //end for.each
            _feedsListView.BeginUpdate();
            _feedsListView.Items.AddRange(temp.ToArray());
            _feedsListView.EndUpdate();
        } //end method

        public void DeleteFolderAndSubFolders()
        {
            var node = _treeView.SelectedNode;
            if (node == null || node.Parent == null) return;
            FeedFolder parentFolder = (FeedFolder)_treeView.SelectedNode.Parent.Tag;
            FeedFolder folder = (FeedFolder)node.Tag;
            folder.DeleteAll();
            parentFolder.SubFolders.Remove(folder);
            _treeView.Nodes.Remove(node);
            Modified = true;
            _treeView.SelectedNode = node.Parent;
            this.LoadFeedsToListView();
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

        private bool ValidateUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("url can not be blank");
            } //end if
            var regex = new Regex(@"^(?:https?:\/\/)(?:\S+(?::\S*)?@)?(?:(?!(?:10|127)(?:\.\d{1,3}){3})(?!(?:169\.254|192\.168)(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)(?:\.(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)*(?:\.(?:[a-z\u00a1-\uffff]{2,})))(?::\d{2,5})?(?:[/?#]\S*)?$", RegexOptions.Compiled);
           return regex.IsMatch(url);
        } //end method.validate url
    }//end class
}//end namespace

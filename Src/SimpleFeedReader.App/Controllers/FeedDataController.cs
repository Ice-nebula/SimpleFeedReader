using SimpleFeedReader.App.Entities;
using SimpleFeedReader.App.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.ServiceModel.Syndication;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SimpleFeedReader.App.Controllers
{
    public class FeedDataController
    {
        FeedFolder _feedCollection { get; set; }
public bool Modified { get; private set; }
private System.Windows.Forms.TreeView _treeView { get; set; }
private System.Windows.Forms.ListView _feedsListView { get; set; }
        private System.Windows.Forms.ListView _lvFeedEntries;
        public FeedDataController(System.Windows.Forms.TreeView treeView, System.Windows.Forms.ListView feedsListView, System.Windows.Forms.ListView lvFeedEntries)
        {
            _feedCollection = new FeedFolder("database");
            _treeView = treeView;
            _feedsListView = feedsListView;
            _lvFeedEntries = lvFeedEntries;
        } //end con

        public async Task fetchNewFeedAsync()
        {
            ListViewItem selectedItem = _feedsListView.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
            if (selectedItem == null) return;
            FeedDataItem feedData = (FeedDataItem)selectedItem.Tag;
            var result = await this.DownloadFeedAsync(feedData.Url);
            var items = new List<ListViewItem>();
            foreach (var item in result.Items)
            {
                ListViewItem listViewItem = new ListViewItem();
                var date_created = item.PublishDate.LocalDateTime;
                listViewItem.Text = $"{item.Title.Text}; date_created:{date_created}";
                items.Add(listViewItem);
            } //end for.each
            _lvFeedEntries.BeginUpdate();
            _lvFeedEntries.Items.AddRange(items.ToArray());
        } //end method.fetch

        private async Task<SyndicationFeed> DownloadFeedAsync(string url)
        {
            using (var req = new HttpClient())
            {
                string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.66 Safari/537.36";
                req.DefaultRequestHeaders.UserAgent.TryParseAdd(UserAgent);
                var result = await req.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    using (StringReader reader = new StringReader(await result.Content.ReadAsStringAsync()))
                    {
                        using (var xml = XmlReader.Create(reader))
                        {
                            SyndicationFeed feed = SyndicationFeed.Load(xml);
                            return feed;
                        } //end xml
                    } //end string reader
                } //end if check request is success
                return null;
            } //end req
        } //end method
        public void AddNewFeed(FeedDataItem item)
        {
            if (_treeView.SelectedNode == null) return;
            var folder = (FeedFolder)_treeView.SelectedNode.Tag;
            if (FeedUtils.ValidateUrl(item.Url) == false) return;
            _feedsListView.BeginUpdate();
            folder.AddFeedData(item);
            var listViewItem = new ListViewItem(item.Name);
            listViewItem.Tag = item;
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

        
    }//end class
}//end namespace

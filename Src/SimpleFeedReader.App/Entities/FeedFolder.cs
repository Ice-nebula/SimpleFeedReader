using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFeedReader.App.Entities
{
    public class FeedFolder
    {
//name of folder
public string Name { get; set; }
//sub folders
public List<FeedFolder> SubFolders { get; set; }
public List<FeedDataItem> FeedDataItems { get; set; }
        public FeedFolder(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("name can not be blank");
            } //end if.check name
            Name = name;
            FeedDataItems = new List<FeedDataItem>();
            SubFolders = new List<FeedFolder>();
        } //end con
/// <summary>
/// add new folder to sub folder.
/// </summary>
/// <param name="item"></param>
        public void AddSubFolder(FeedFolder item)
        {
            SubFolders.Add(item);
        } //end method.add sub folder
/// <summary>
/// add new feed data to this folder.
/// </summary>
/// <param name="item"></param>
        public void AddFeedData(FeedDataItem item)
        {
            FeedDataItems.Add(item);
        } //end method.add feed data
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SimpleFeedReader.App.Entities
{
[XmlRoot("folder")]
    public class FeedFolder
    {
        public FeedFolder() { }
//name of folder
[XmlElement("name")]
public string Name { get; set; }
//sub folders
[XmlArray("subFolders")]
public List<FeedFolder> SubFolders { get; set; }
[XmlArray("FeedItems")]
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

        public void DeleteAll()
        {
            SubFolders.Clear();
            FeedDataItems.Clear();
        } //end method.delete all
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

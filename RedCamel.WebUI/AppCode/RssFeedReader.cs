using RedCamel.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace RedCamel.WebUI.AppCode
{
    public enum FeedSource { CBR, CVINE };

    public class FeedRequest

    {

        public FeedSource Source { get; set; }

        public string Url { get; set; }

    }

    public class RssFeedReader

    {
       

        public IEnumerable<Post> ReadFeed(string url, FeedSource source)

        {

            var rssFeed = XDocument.Load(url);



            var posts = from item in rssFeed.Descendants("item")

                        select new Post

                        {

                            Title = item.Element("title").Value,

                            Description = item.Element("description").Value,

                            PublishedDate = item.Element("pubDate").Value,

                            Image = source == FeedSource.CBR ? item.Element("enclosure").Attribute("url").Value : item.Elements().Last().Attribute("url").Value,

                            Link = item.Element("link").Value



                        };



            return posts;

        }

    }

}

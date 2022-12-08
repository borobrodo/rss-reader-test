using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.Xml;

namespace RSS_test // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string feedUrl = "https://habr.com/ru/rss/interesting/";
            XmlReader reader = XmlReader.Create(feedUrl);
            var formatter = new Rss20FeedFormatter();
            formatter.ReadFrom(reader);
            //SyndicationFeed feed = SyndicationFeed.Load(reader);
            var feed = formatter.Feed;
            var feedContent = formatter.Feed.Items;
            reader.Close();

            Console.WriteLine(feed.Title.Text);
            //Console.WriteLine(feed.Items);
            foreach (SyndicationItem item in feed.Items)
            {
                Console.WriteLine(item.Title);
                Console.WriteLine(item.Summary.Text);
                Console.WriteLine("===================");
            }
        }
    }
}
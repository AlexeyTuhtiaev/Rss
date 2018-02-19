using Rss.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Rss.Bll
{
    public class RssSourseReader
    {
        public RssSoure InitialazeSourse(RssSoure sourse)
        {
            WebRequest request = WebRequest.Create(sourse.UrlSourse);

            WebResponse response = request.GetResponse();
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(response.GetResponseStream());

                XmlElement rssElem = doc["rss"];
                if (rssElem == null) return null;
                XmlElement chanElem = rssElem["channel"];

                if (chanElem != null)
                {
                    sourse.Title = chanElem["title"].InnerText;
                    sourse.UrlSourse = chanElem["link"].InnerText;
                    sourse.NewsItems = new List<NewsItem>();
                    XmlNodeList itemElems = chanElem.GetElementsByTagName("item");
                    foreach (XmlElement itemElem in itemElems)
                    {
                        NewsItem item = new NewsItem();
                        item.Title = itemElem["title"].InnerText;
                        item.UrlNews = itemElem["link"].InnerText;
                        item.Description = itemElem["description"].InnerText;
                        item.PublicationDate = itemElem["pubDate"].InnerText;
                        sourse.NewsItems.Add(item);
                    }
                }
                return sourse;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}

using Rss.Dal.Interfaces;
using System.Collections.Generic;
using Rss.Dal.EF;
using Rss.Dal.Entities;
using System.Linq;
using System;

namespace Rss.Dal.Repositories
{
    public class RssRepository : IRepository<RssSoure>
    {

        readonly RssContext context;

        public RssRepository()
        {
            context = RssContext.Create();
        }

        public IEnumerable<NewsItem> GetAllNews()
        {
            var items = context.NewsItem;
            return items;
        }

        public bool IsNewsItemInDb(NewsItem newsItem)
        {
            var newsItemInDbQuery = from n in context.NewsItem
                       where n.Title == newsItem.Title 
                            && n.PublicationDate==newsItem.PublicationDate
                       select n;

            if (newsItemInDbQuery.Any())
            {
                return true;
            }
            return false;
        }

        public void AddNewsItem(NewsItem newsItem)
        {
            context.NewsItem.Add(newsItem);
            context.SaveChanges();
        }
    }
}

using Rss.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rss.Dal.Interfaces
{
    public interface IRepository<out T> where T : class
    {
        bool IsNewsItemInDb(NewsItem newsItem);
        void AddNewsItem(NewsItem newsItem);
        IEnumerable<NewsItem> GetAllNews();
    }
}

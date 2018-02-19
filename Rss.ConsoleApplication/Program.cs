using Rss.Bll;
using Rss.Dal.Entities;
using Rss.Dal.Interfaces;
using Rss.Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rss.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            RssSoure habr = new RssSoure { UrlSourse = @"http://habrahabr.ru/rss/", Title = "Хабрахабр" };

            IRepository<RssSoure> repository = new RssRepository();
            
            RssSourseReader reader = new RssSourseReader();

            RssSoure filledHabr = reader.InitialazeSourse(habr);

            if (filledHabr.NewsItems == null)
            {
                Console.WriteLine("Something wrong happend, try again . . .");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("RSS reading ...");

            int readCount = 0;
            int saveNewsCount = 0;
            foreach (NewsItem item in filledHabr.NewsItems)
            {
                readCount++;
                if (!repository.IsNewsItemInDb(item))
                {
                    saveNewsCount++;
                    repository.AddNewsItem(item);
                }
                Console.Write(".");               
            }
            Console.WriteLine();
            Console.WriteLine("Read news: {0}", readCount);
            Console.WriteLine("Saved news: {0}", saveNewsCount);
            Console.ReadKey();
        }
    }
}


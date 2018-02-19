using Rss.Dal.Entities;
using System.Collections.Generic;
using System.Data.Entity;


namespace Rss.Dal.EF
{
    public class RssContext : DbContext
    {
        public RssContext() : base("RssDbConnection")
        {
            Database.SetInitializer(new RoutesContextInitializer());
        }
        public DbSet<RssSoure> Sourse { get; set; }
        public DbSet<NewsItem> NewsItem { get; set; }

        public static RssContext Create()
        {
            return new RssContext();
        }
    }

    class RoutesContextInitializer : CreateDatabaseIfNotExists<RssContext>
    {
        protected override void Seed(RssContext context)
        {
            List<NewsItem> newsItems = new List<NewsItem> {
                                                            new NewsItem { Description = "news 1 Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", PublicationDate = "01.01.2010", Title = "Title1", UrlNews="ya.ru" },
                                                            new NewsItem { Description = "news 2 It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here'", PublicationDate = "01.01.2011", Title = "Title2", UrlNews="ya.ru" },
                                                            new NewsItem { Description = "news 3 Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia", PublicationDate = "01.01.2012", Title = "Title3", UrlNews="ya.ru" },
                                                            new NewsItem { Description = "news 4 There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.", PublicationDate = "01.01.2013", Title = "Title4", UrlNews="ya.ru" },
                                                            new NewsItem { Description = "news 5 The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham", PublicationDate = "01.01.2014", Title = "Title5", UrlNews="ya.ru" }
                                                            };
            RssSoure sourse = new RssSoure { Title = "Хабрахабр", UrlSourse = @"http://habrahabr.ru/rss/", NewsItems =newsItems };

            context.Sourse.Add(sourse);
            context.SaveChanges();
        }
    }
}

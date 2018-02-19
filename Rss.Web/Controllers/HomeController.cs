using Rss.Dal.Entities;
using Rss.Dal.Repositories;
using Rss.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rss.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly int tableSize = 10;

        public ActionResult Index(int page = 1)
        {
            RssRepository repository = new RssRepository();

            List<NewsItem> newsItems = repository.GetAllNews().ToList();

            var model = PageListViewModel<NewsItem>.CreatePage(newsItems, page, tableSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("ListViewPatial", model);
            }
            return View(model);
        }        
    }
}
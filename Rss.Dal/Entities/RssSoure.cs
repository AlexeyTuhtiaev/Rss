using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rss.Dal.Entities
{
    public class RssSoure
    {
        public int RssSoureId { get; set; }
        public string Title { get; set; }
        public string UrlSourse { get; set; }

        public List<NewsItem> NewsItems { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rss.Dal.Entities
{
    public class NewsItem
    {
        [Key]
        [Column(Order = 1)]
        public string Title { get; set; }
        [Key]
        [Column(Order = 2)]
        public string PublicationDate { get; set; }
        public string Description { get; set; }
        public string UrlNews { get; set; }
    }
}

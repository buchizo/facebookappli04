using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenGraphWeb.Models
{
    public class Gift
    {
        public int GiftId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
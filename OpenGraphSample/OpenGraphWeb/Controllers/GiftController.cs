using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenGraphWeb.Models;

namespace OpenGraphWeb.Controllers
{
    public class GiftController : Controller
    {
        private readonly List<Gift> gifts;

        public GiftController()
        {
            string sampleImageUrl = "https://s-static.ak.fbcdn.net/images/devsite/attachment_blank.png";
            gifts = new List<Gift>();
            gifts.Add(new Gift { GiftId = 1, Title = "Water", ImageUrl = sampleImageUrl, Description = "1 liter PET bottle" });
            gifts.Add(new Gift { GiftId = 2, Title = "Blood", ImageUrl = sampleImageUrl, Description = "A/B/AB/O" });
            gifts.Add(new Gift { GiftId = 3, Title = "Drug", ImageUrl = sampleImageUrl, Description = "Drug medicine" });
            gifts.Add(new Gift { GiftId = 4, Title = "Blanket", ImageUrl = sampleImageUrl, Description = "Blanket cloth" });
            gifts.Add(new Gift { GiftId = 5, Title = "Money", ImageUrl = sampleImageUrl, Description = "" });
        }

        public ActionResult Index()
        {
            return View(gifts);
        }

        public ActionResult Details(int id)
        {
            return View(gifts.Find(i=>i.GiftId == id));
        }
    }
}

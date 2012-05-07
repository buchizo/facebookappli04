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
		public GiftController()
			: this(new GiftRepository())
		{
		}

		public GiftController(IGiftRepository giftRepository)
		{
			_giftRepository = giftRepository;
		}

		private readonly IGiftRepository _giftRepository;

		public ActionResult Index()
		{
			return View(_giftRepository.GetAll());
		}

		public ActionResult Details(int id)
		{
			return View(_giftRepository.Find(id));
		}

	}
}

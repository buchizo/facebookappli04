using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Net;
using System;
using Facebook;

namespace OpenGraphWeb.Controllers
{
	public class AccountController : Controller
	{

		public ActionResult LogOn()
		{
			return View();
		}

		[HttpGet]
		public ActionResult FacebookLogin(string token)
		{
			var fb = new FacebookClient(token);
			var me = fb.Get("me") as IDictionary<string, object>;
			var username = (string)me["name"];

			FormsAuthentication.SetAuthCookie(username, true);

			return RedirectToAction("Index", "Home");
		}
		
		public ActionResult LogOff()
		{
			FormsAuthentication.SignOut();

			return RedirectToAction("Index", "Home");
		}
	}
}

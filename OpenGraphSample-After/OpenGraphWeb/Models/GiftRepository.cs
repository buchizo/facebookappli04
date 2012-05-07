using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenGraphWeb.Models
{
	public class GiftRepository : IGiftRepository
	{
		private readonly List<Gift> _gifts;

		public GiftRepository()
		{
			string sampleImageUrl = "https://s-static.ak.fbcdn.net/images/devsite/attachment_blank.png";
			string type = System.Configuration.ConfigurationManager.AppSettings["FacebookAppNamespace"] + ":gift";

			_gifts = new List<Gift>();
			_gifts.Add(new Gift { GiftId = 1, Title = "Water", ImageUrl = sampleImageUrl, Description = "1 liter PET bottle", Type = type });
			_gifts.Add(new Gift { GiftId = 2, Title = "Blood", ImageUrl = sampleImageUrl, Description = "A/B/AB/O", Type = type });
			_gifts.Add(new Gift { GiftId = 3, Title = "Drug", ImageUrl = sampleImageUrl, Description = "Drug medicine", Type = type });
			_gifts.Add(new Gift { GiftId = 4, Title = "Blanket", ImageUrl = sampleImageUrl, Description = "Blanket cloth", Type = type });
			_gifts.Add(new Gift { GiftId = 5, Title = "Money", ImageUrl = sampleImageUrl, Description = "", Type = type });
		}

		Gift IGiftRepository.Find(int id)
		{
			return _gifts.Find(x => x.GiftId == id);
		}

		IList<Gift> IGiftRepository.GetAll()
		{
			return _gifts;
		}

		public IList<Gift> GetPagedList(int page, int count)
		{
			throw new NotImplementedException();
		}

		public void Add(Gift gift)
		{
			throw new NotImplementedException();
		}

		public void Remove(Gift gift)
		{
			throw new NotImplementedException();
		}

		public void Save()
		{
			throw new NotImplementedException();
		}
	}
}
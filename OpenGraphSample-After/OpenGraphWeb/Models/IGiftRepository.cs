using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenGraphWeb.Models
{
	public interface IGiftRepository
	{
		Gift Find(int id);
		IList<Gift> GetAll();
		IList<Gift> GetPagedList(int page, int count);
		void Add(Gift gift);
		void Remove(Gift gift);
		void Save();
	}
}
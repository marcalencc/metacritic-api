using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MetacriticAPI.Services;
using MetacriticScraper.Interfaces;

namespace MetacriticAPI.Controllers
{
    public class AlbumController : ApiController
    {
        private readonly IMetacriticService m_metacriticService;

        public AlbumController(IMetacriticService metacriticService)
        {
            m_metacriticService = metacriticService;
        }

        public IHttpActionResult GetAlbum(string title)
        {
            string id = m_metacriticService.GetId();
            IMetacriticData[] result = m_metacriticService.GetResult(id, string.Format("/album/{0}", title));
            return Json(result);
        }
    }
}

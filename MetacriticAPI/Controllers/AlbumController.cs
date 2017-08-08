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

        [HttpGet]
        public IHttpActionResult Get(string title)
        {
            string id = m_metacriticService.GetId();
            IMetacriticData[] result = m_metacriticService.GetResult(id, string.Format("/album/{0}", title));
            return Json(result);
        }

        [HttpGet]
        public IHttpActionResult GetAlbumDetails(string title, string details)
        {
            string id = m_metacriticService.GetId();
            IMetacriticData[] result = m_metacriticService.GetResult(id, string.Format("/album/{0}/details", title));
            return Json(result);
        }

        [HttpGet]
        public IHttpActionResult GetAlbumWithYear(string title, int? year)
        {
            string id = m_metacriticService.GetId();
            IMetacriticData[] result = m_metacriticService.GetResult(id, string.Format("/album/{0}/{1}",
                title, year));
            return Json(result);
        }

        [HttpGet]
        public IHttpActionResult Get(string title, int? year, string details)
        {
            string id = m_metacriticService.GetId();
            IMetacriticData[] result = m_metacriticService.GetResult(id, string.Format("/album/{0}/{1}/details",
                title, year));
            return Json(result);
        }
    }
}

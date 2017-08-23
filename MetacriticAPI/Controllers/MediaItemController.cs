using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Http;
using MetacriticAPI.Services;
using MetacriticScraper.Interfaces;
using MetacriticAPI.Helpers;

namespace MetacriticAPI.Controllers
{
    public class MediaItemController : ApiController
    {
        protected readonly IMetacriticService m_metacriticService;
        protected string m_keyword;

        public MediaItemController(IMetacriticService metacriticService)
        {
            m_metacriticService = metacriticService;
        }

        [HttpGet]
        public IHttpActionResult Get(string title)
        {
            HttpStatusCode statusCode;
            string id = m_metacriticService.GetId();
            string ip = HttpExtensions.GetClientIP(Request);
            IMetacriticData[] result = m_metacriticService.GetResult(id, string.Format("/{0}/{1}", m_keyword,
                title), ip, out statusCode);

            return Content(statusCode, result);
        }

        [HttpGet]
        public IHttpActionResult GetDetails(string title, string details)
        {
            HttpStatusCode statusCode;
            string id = m_metacriticService.GetId();
            string ip = HttpExtensions.GetClientIP(Request);
            IMetacriticData[] result = m_metacriticService.GetResult(id, string.Format("/{0}/{1}/{2}",
                m_keyword, title, details), ip, out statusCode);

            return Content(statusCode, result);
        }

        [HttpGet]
        public IHttpActionResult GetItemWithYear(string title, int? year)
        {
            HttpStatusCode statusCode;
            string id = m_metacriticService.GetId();
            string ip = HttpExtensions.GetClientIP(Request);
            IMetacriticData[] result = m_metacriticService.GetResult(id, string.Format("/{0}/{1}/{2}",
                m_keyword, title, year), ip, out statusCode);

            return Content(statusCode, result);
        }

        [HttpGet]
        public IHttpActionResult Get(string title, int? year, string details)
        {
            HttpStatusCode statusCode;
            string id = m_metacriticService.GetId();
            string ip = HttpExtensions.GetClientIP(Request);
            IMetacriticData[] result = m_metacriticService.GetResult(id, string.Format("/{0}/{1}/{2}/{3}",
                m_keyword, title, year, details), ip, out statusCode);

            return Content(statusCode, result);
        }
    }
}

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
    public class TvShowController : ApiController
    {
        private readonly IMetacriticService m_metacriticService;

        public TvShowController(IMetacriticService metacriticService)
        {
            m_metacriticService = metacriticService;
        }

        [HttpGet]
        public IHttpActionResult Get(string title)
        {
            HttpStatusCode statusCode;
            string id = m_metacriticService.GetId();
            IMetacriticData[] result = m_metacriticService.GetResult(id, string.Format("/tvshow/{0}", title),
                out statusCode);

            if (statusCode == HttpStatusCode.OK)
            {
                return Json(result);
            }
            else
            {
                return Content(statusCode, result);
            }
        }

        [HttpGet]
        public IHttpActionResult GetDetails(string title, string details)
        {
            HttpStatusCode statusCode;
            string id = m_metacriticService.GetId();
            IMetacriticData[] result = m_metacriticService.GetResult(id, string.Format("/tvshow/{0}/{1}",
                title, details), out statusCode);

            if (statusCode == HttpStatusCode.OK)
            {
                return Json(result);
            }
            else
            {
                return Content(statusCode, result);
            }
        }

        [HttpGet]
        public IHttpActionResult GetItemWithYear(string title, int? year)
        {
            HttpStatusCode statusCode;
            string id = m_metacriticService.GetId();
            IMetacriticData[] result = m_metacriticService.GetResult(id, string.Format("/tvshow/{0}/{1}",
                title, year), out statusCode);

            if (statusCode == HttpStatusCode.OK)
            {
                return Json(result);
            }
            else
            {
                return Content(statusCode, result);
            }
        }

        [HttpGet]
        public IHttpActionResult Get(string title, int? year, string details)
        {
            HttpStatusCode statusCode;
            string id = m_metacriticService.GetId();
            IMetacriticData[] result = m_metacriticService.GetResult(id, string.Format("/tvshow/{0}/{1}/{2}",
                title, year, details), out statusCode);

            if (statusCode == HttpStatusCode.OK)
            {
                return Json(result);
            }
            else
            {
                return Content(statusCode, result);
            }
        }
    }
}

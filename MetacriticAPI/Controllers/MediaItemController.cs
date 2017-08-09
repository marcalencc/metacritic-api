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
    public class MediaItemController : ApiController
    {
        protected readonly IMetacriticService m_metacriticService;
        protected string m_keyword;

        public MediaItemController(IMetacriticService metacriticService)
        {
            m_metacriticService = metacriticService;
        }

        private IHttpActionResult GetReturn(HttpStatusCode statusCode, IMetacriticData[] result)
        {
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
        public IHttpActionResult Get(string title)
        {
            HttpStatusCode statusCode;
            string id = m_metacriticService.GetId();
            IMetacriticData[] result = m_metacriticService.GetResult(id, string.Format("/{0}/{1}", m_keyword,
                title), out statusCode);

            return GetReturn(statusCode, result);
        }

        [HttpGet]
        public IHttpActionResult GetDetails(string title, string details)
        {
            HttpStatusCode statusCode;
            string id = m_metacriticService.GetId();
            IMetacriticData[] result = m_metacriticService.GetResult(id, string.Format("/{0}/{1}/{2}",
                m_keyword, title, details), out statusCode);

            return GetReturn(statusCode, result);
        }

        [HttpGet]
        public IHttpActionResult GetItemWithYear(string title, int? year)
        {
            HttpStatusCode statusCode;
            string id = m_metacriticService.GetId();
            IMetacriticData[] result = m_metacriticService.GetResult(id, string.Format("/{0}/{1}/{2}",
                m_keyword, title, year), out statusCode);

            return GetReturn(statusCode, result);
        }

        [HttpGet]
        public IHttpActionResult Get(string title, int? year, string details)
        {
            HttpStatusCode statusCode;
            string id = m_metacriticService.GetId();
            IMetacriticData[] result = m_metacriticService.GetResult(id, string.Format("/{0}/{1}/{2}/{3}",
                m_keyword, title, year, details), out statusCode);

            return GetReturn(statusCode, result);
        }
    }
}

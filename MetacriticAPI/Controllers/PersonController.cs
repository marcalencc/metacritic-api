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
    public class PersonController : ApiController
    {
        protected readonly IMetacriticService m_metacriticService;

        public PersonController(IMetacriticService metacriticService)
        {
            m_metacriticService = metacriticService;
        }

        [HttpGet]
        public IHttpActionResult GetDetails(string title, string details)
        {
            HttpStatusCode statusCode;
            string id = m_metacriticService.GetId();
            IMetacriticData[] result = m_metacriticService.GetResult(id, string.Format("/person/{0}/{1}",
                title, details), out statusCode);

            return Content(statusCode, result);
        }
    }
}

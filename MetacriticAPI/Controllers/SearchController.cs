﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MetacriticAPI.Services;
using MetacriticScraper.Interfaces;
using MetacriticAPI.Helpers;

namespace MetacriticAPI.Controllers
{
    public class SearchController : ApiController
    {
        protected readonly IMetacriticService m_metacriticService;

        public SearchController(IMetacriticService metacriticService)
        {
            m_metacriticService = metacriticService;
        }

        [HttpGet]
        public IHttpActionResult GetDetails(string title, string details, string offset = "",
            string limit = "")
        {
            HttpStatusCode statusCode;
            string id = m_metacriticService.GetId();

            string ip = HttpExtensions.GetClientIP(Request);
            IMetacriticData[] result = m_metacriticService.GetResult(id,
                string.Format("/search/{0}/{1}?offset={2}&limit={3}", title, details, offset, limit),
                ip, out statusCode);

            return Content(statusCode, result);
        }
    }
}
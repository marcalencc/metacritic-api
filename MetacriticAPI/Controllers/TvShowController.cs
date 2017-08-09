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
    public class TvShowController : MediaItemController
    {
        public TvShowController(IMetacriticService metacriticService) : base (metacriticService)
        {
            m_keyword = "tvshow";
        }
    }
}

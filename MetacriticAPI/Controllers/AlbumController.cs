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
    public class AlbumController : MediaItemController
    {
        public AlbumController(IMetacriticService metacriticService) : base(metacriticService)
        {
            m_keyword = "album";
        }
    }
}

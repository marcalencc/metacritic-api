using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetacriticAPI.Models
{
    public class MediaDetail
    {
        public List<DetailItem> Details { get; set; }
    }

    public class DetailItem
    {
        public string Description { get; set; }
        public string Value { get; set; }
    }
}

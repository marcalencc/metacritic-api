using System;

namespace MetacriticAPI.Models
{
    public class TVShow : MediaItem
    {
        public int Season { get; set; }
        public string Studio { get; set; }
    }
}

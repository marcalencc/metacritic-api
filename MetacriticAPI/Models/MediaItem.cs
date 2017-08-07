using System;

namespace MetacriticAPI.Models
{
    public abstract class MediaItem
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Rating Rating { get; set; }
        public string ImageUrl { get; set; }
    }
}

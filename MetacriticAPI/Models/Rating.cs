using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetacriticAPI.Models
{
    public class Rating
    {
        public short CriticRating { get; set; }
        public short CriticReviewCount { get; set; }
        public float UserRating { get; set; }
        public short UserReviewCount { get; set; }
    }
}

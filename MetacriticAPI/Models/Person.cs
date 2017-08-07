using System;
using System.Collections.Generic;

namespace MetacriticAPI.Models
{
    public class Person
    {
        public string Name { get; set; }
        public List<CreditMediaItemPair> CreditMediaPairItems { get; set; }
        public PersonRatingSummary RatingsSummary { get; set; }

        public struct PersonRatingSummary
        {
            public double HighestRating;
            public double AverageRating;
            public double LowestRating;
            public int ReviewCount;

        }

        public struct CreditMediaItemPair
        {
            public string Credit;
            public MediaItem Item;

            public CreditMediaItemPair(string credit, MediaItem item)
            {
                Credit = credit;
                Item = item;
            }
        }
    }
}

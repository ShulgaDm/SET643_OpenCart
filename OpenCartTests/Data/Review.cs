using System;
using System.Collections.Generic;
using System.Linq;
namespace OpenCartTests.Data
{
    public class Review
    {
        public string YourName { get; set; }
        public string YourReview { get; set; }
        public string RatingValue { get; set; }

        public Review() { }
        public static ReviewBuilder CreateBuilder()
        {
            return new ReviewBuilder();
        }
    }
}

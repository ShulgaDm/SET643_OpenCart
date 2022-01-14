namespace OpenCartTests.Data
{
    public class ReviewBuilder
    {
        private Review review;
        public ReviewBuilder()
        {
            review = new Review();
        }
        public ReviewBuilder SetYourName(string yourName)
        {
            review.YourName = yourName;
            return this;
        }
        public ReviewBuilder SetYourReview(string yourReview)
        {
            review.YourReview = yourReview;
            return this;
        }
        public ReviewBuilder SetRatingValue(string ratingValue)
        {
            review.RatingValue = ratingValue;
            return this;
        }
        public Review Build()
        {
            return review;
        }
    }
}

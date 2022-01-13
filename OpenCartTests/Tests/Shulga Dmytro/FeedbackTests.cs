using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;
using OpenCartTests.Tools;

namespace OpenCartTests.Tests.Shulga_Dmytro
{
    [TestFixture]
    public class FeedbackTests : TestRunner
    {
        protected override string OpenCartURL { get => "http://cart"; }
        public readonly string EXPECTED_NO_REVIEWS_MESSAGE = "There are no reviews for this product.";
        public readonly string EXPECTED_SUCCESSFULL_ADD_REVIEW_MESSAGE =
                    "Thank you for your review. It has been submitted to the webmaster for approval.";

        Review review;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            review = Review.CreateBuilder()
                        .SetYourName("Ivan")
                        .SetYourReview("It is the best product in the world")
                        .SetRatingValue("3").Build();
        }

        [Test]
        public void CheckProductWithEmptyReview()
        {
            string expected = EXPECTED_NO_REVIEWS_MESSAGE;

            string actual = new HomePage(driver)
                                .GetFirstProductDetails()
                                .OpenReviews()
                                .GetReviewText();

            Assert.IsTrue(actual.Contains(expected));
        }

        [Test]
        public void SuccessfullAddReviewTest()
        {
            string expected = EXPECTED_SUCCESSFULL_ADD_REVIEW_MESSAGE;

            string actual = new HomePage(driver)
                                .GetFirstProductDetails()
                                .OpenReviews()
                                .SuccessfullAddReview(review)
                                .GetAlertMessageText();

            Assert.AreEqual(expected, actual);
        }
    }
}
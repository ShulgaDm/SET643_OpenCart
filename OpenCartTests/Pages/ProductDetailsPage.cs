using OpenCartTests.Data;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace OpenCartTests.Pages
{
    public class ProductDetailsPage : AStatusBarComponent
    {
        private readonly string VALUE_NOT_FOUND_MESSAGE = "Cannot found the option";

        public IWebElement ReviewTab { get; private set; }
        public IWebElement Review { get; private set; }
        public IWebElement YourNameField { get; private set; }
        public IWebElement YourReviewField { get; private set; }
        public IList<IWebElement> RatingValues { get; private set; }
        public IWebElement ContinueButton { get; private set; }
        public IWebElement AddToWishListButton { get; private set; }
        public IWebElement Price { get; private set; }
        public IWebElement Alertmessage { get { return driver.FindElement(By.CssSelector(".alert-success:not( .fa-check-circle)")); } }

        
        public ProductDetailsPage(IWebDriver driver) : base(driver)
        {
            ReviewTab = driver.FindElement(By.XPath("//a[contains(@href, '#tab-review')]"));
            Review = driver.FindElement(By.Id("review"));
            YourNameField = driver.FindElement(By.Id("input-name"));
            YourReviewField = driver.FindElement(By.Id("input-review"));
            RatingValues = driver.FindElements(By.XPath("//input[contains(@type, 'radio')]"));
            ContinueButton = driver.FindElement(By.Id("button-review"));
            AddToWishListButton = driver.FindElement(By.XPath("//button[@data-original-title='Add to Wish List']//i[@class='fa fa-heart']"));
            Price = driver.FindElement(By.CssSelector(".list-unstyled h2"));
          
        }

        public void ClickReviewTab() => ReviewTab.Click();

        public string GetReviewText() => Review.Text;

        // YourNameField
        public void ClickYourNameFieldButton() => YourNameField.Click();
        public void ClearYourNameField() => YourNameField.Clear();
        public void SetYourNameField(string yourName) => YourNameField.SendKeys(yourName);

        // YourReviewField
        public void ClickYourReviewFieldButton() => YourReviewField.Click();
        public void ClearYourReviewField() => YourReviewField.Clear();
        public void SetYourReviewField(string yourName) => YourReviewField.SendKeys(yourName);

        // ContinueButton
        public void ClickContinueButton() => ContinueButton.Click();
        public string GetPriceText() => Price.Text;
        //public ProductDetailsPage 

        public void ClickAddToWishListButton() => AddToWishListButton.Click();
        public string GetAlertMessageText()
        {
            return Alertmessage.Text;
        }
        public ProductDetailsPage AddToWishList()
        {
            ClickAddToWishListButton();
            return new ProductDetailsPage(driver);
        }

        // RatingValues
        public IWebElement GetRatingByValue(string value)
        {
            IWebElement result = null;
            foreach (var item in RatingValues)
            {
                if (item.GetAttribute(TAG_ATTRIBUTE_VALUE).Equals(value))
                {
                    result = item;
                    break;
                }
            }
            return result;
        }
        private bool FindRatingByValue(string value)
        {
            bool isFound = false;
            foreach (var item in RatingValues)
            {
                if (item.GetAttribute(TAG_ATTRIBUTE_VALUE).Equals(value))
                {
                    isFound = true;
                }
            }
            return isFound;
        }
        public void ClickRatingByValue(string value)
        {
            if (!FindRatingByValue(value))
            {
                throw new FormatException(VALUE_NOT_FOUND_MESSAGE);
            }
            GetRatingByValue(value).Click();
        }


        // Functional

        public void ClearAll()
        {
            ClearYourNameField();
            ClearYourReviewField();
        }

        public void FillForm(Review review)
        {
            SetYourNameField(review.YourName);
            SetYourReviewField(review.YourReview);
            ClickRatingByValue(review.RatingValue);
        }


        // Business Logic

        public ProductDetailsPage OpenReviews()
        {
            ClickReviewTab();
            return this;
        }
        public ProductDetailsMessagePage SuccessfullAddReview(Review correctReview)
        {
            ClearAll();
            FillForm(correctReview);
            ClickContinueButton();
            return new ProductDetailsMessagePage(driver);
        }
    }
}

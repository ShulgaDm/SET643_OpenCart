using OpenQA.Selenium;
using System.Collections.Generic;

namespace OpenCartTests.Pages
{
    public class HomePage : AHeadComponent
    {
        public IList<IWebElement> Products { get; private set; }
        public HomePage(IWebDriver driver) : base(driver) 
        {
            Products = driver.FindElements(By.CssSelector(".product-layout"));
        }

        public void ClickOnFirstProduct() => Products[0].Click();

        public ProductDetailsPage GetFirstProductDetails()
        {
            ClickOnFirstProduct();
            return new ProductDetailsPage(driver);
        }

        public HomePage GetFirstProductInfo()
        {
            ClickOnFirstProduct();
            return new HomePage(driver);
        }

        public ASearchCriteriaComponent FindProduct(string searchText)
        {
            ClearSearchProductField();
            SetSearchProductField(searchText);
            SetSearchProductField(Keys.Enter);
            return new SearchResultPage(driver);
        }
    }
}

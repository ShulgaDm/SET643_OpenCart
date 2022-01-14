using OpenQA.Selenium;

namespace OpenCartTests.Pages
{
    public class ProductDetailsMessagePage : ProductDetailsPage
    {
        public IWebElement AlertMessage { get; private set; }
        public ProductDetailsMessagePage(IWebDriver driver) : base(driver)
        {
            AlertMessage = driver.FindElement(By.CssSelector(".alert"));
        }
        public string GetAlertMessageText() => AlertMessage.Text;
    }
}

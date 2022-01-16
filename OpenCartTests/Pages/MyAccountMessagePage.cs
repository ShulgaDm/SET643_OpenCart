using OpenQA.Selenium;

namespace OpenCartTests.Pages
{

    public class MyAccountMessagePage : MyAccountPage
    {
        private IWebElement AlertMessage;
        
        public MyAccountMessagePage(IWebDriver driver) : base(driver)
        {
            AlertMessage = driver.FindElement(By.CssSelector(".alert.alert-success"));
        }
        
        public string GetAlertMessageText() => AlertMessage.Text;

    }
}
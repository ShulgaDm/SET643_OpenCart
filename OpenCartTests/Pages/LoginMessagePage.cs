using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public class LoginMessagePage : LoginPage
    {
        private IWebElement AlertMessage;
        public LoginMessagePage(IWebDriver driver) : base(driver)
        {
            AlertMessage = driver.FindElement(By.CssSelector(".alert.alert-danger"));
        }
        public string GetAlertMessageText() => AlertMessage.Text;
    }
}

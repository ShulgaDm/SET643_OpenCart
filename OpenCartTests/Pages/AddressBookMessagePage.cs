using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public class AddressBookMessagePage : AddressBookPage
    {
        public IWebElement AlertMessage { get; private set; }
        public AddressBookMessagePage(IWebDriver driver) : base(driver)
        {
            AlertMessage = driver.FindElement(By.CssSelector(".alert-success"));
        }
        public string GetAlertMessageText() => AlertMessage.Text;
    }
}

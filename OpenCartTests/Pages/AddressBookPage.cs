using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public class AddressBookPage : ARightMenuComponent
    {
        public IWebElement NewAddressButton { get; private set; }

        public AddressBookPage(IWebDriver driver) : base(driver)
        {
            NewAddressButton = driver.FindElement(By.CssSelector("a.btn.btn-primary"));
        }

        // NewAddressButton
        public void ClickNewAddressButton() => NewAddressButton.Click();
        public string GetNewAddressButtonText() => NewAddressButton.Text;

        // Functional
        public void VerifyAddressBookPage()
        {
            GetNewAddressButtonText();
        }
    }
}

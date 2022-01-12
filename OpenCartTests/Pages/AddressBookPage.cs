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
        public string URL { get; private set; }
        public IWebElement NewAddressButton { get; private set; }

        public AddressBookPage(IWebDriver driver) : base(driver)
        {
            URL = driver.Url;
            NewAddressButton = driver.FindElement(By.CssSelector("a.btn.btn-primary"));
        }

        // NewAddressButton
        public void ClickNewAddressButton() => NewAddressButton.Click();
        public string GetNewAddressButtonText() => NewAddressButton.Text;

        // Functional
        public string GetURLAddressBookPage() => URL;

        public AddAddressPage GoToAddAddressPage()
        {
            ClickNewAddressButton();
            return new AddAddressPage(driver);
        }
    }
}

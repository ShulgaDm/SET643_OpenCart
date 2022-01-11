using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public abstract class AUnloggedRightMenuComponent : AStatusBarComponent
    {
        public IWebElement AddressBookButton { get; private set; }
        public IWebElement LoginPageButton { get; private set; }
       
        
        public AUnloggedRightMenuComponent(IWebDriver driver) : base(driver)
        {
            AddressBookButton = driver.FindElement(By.XPath("//a[contains(@href, 'address')]"));
            LoginPageButton = driver.FindElement(By.XPath("//a[contains(@href, 'login')]"));
      
        }

        // Atomic Methods

        // AddressBookButton

        public void ClickAddressBookButton() => AddressBookButton.Click();
    

        // Business Logic

        public LoginPage unloggedClickAddressBookButton()
        {
            return new LoginPage(driver);
        }
    }
}
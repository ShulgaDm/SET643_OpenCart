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
       
        public IWebElement WishListButton { get; private set; }

        public AUnloggedRightMenuComponent(IWebDriver driver) : base(driver)
        {
            AddressBookButton = driver.FindElement(By.XPath("//a[contains(@href, 'address')]"));
            WishListButton = driver.FindElement(By.XPath("//a[contains(@href, 'wishlist')]"));
            LoginPageButton = driver.FindElement(By.XPath("//a[contains(@href, 'login')]"));

        }

        // Atomic Methods

        // AddressBookButton

        public void ClickAddressBookButton() => AddressBookButton.Click();
        public void ClickWishListButton() => WishListButton.Click();

        // Business Logic

        public LoginPage unloggedClickAddressBookButton()
        {
            return new LoginPage(driver);
        }

        public LoginPage unloggedClickWishListButton()
        {
            return new LoginPage(driver);
        }
    }
}
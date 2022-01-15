using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public abstract class ARightMenuComponent : AStatusBarComponent
    {
        public IWebElement AddressBook { get; private set; }
        public IWebElement WishListButton { get; private set; }       
        public IWebElement EditAccountInformation { get; private set; }
        
       
        public ARightMenuComponent(IWebDriver driver) : base(driver)
        {
            AddressBook = driver.FindElement(By.XPath("//*[text()='Address Book']"));
            WishListButton = driver.FindElement(By.XPath("//a[contains(@href, 'wishlist')]"));
        }
        
        public string GetEditAccountInformationText() => EditAccountInformation.Text;
        public void ClickEditAccountInformation() => EditAccountInformation.Click();


        // AddressBook
        public void ClickAddressBook() => AddressBook.Click();
        //WishList
        public void ClickWishList() => WishListButton.Click();

        // Business Logic

        public AddressBookPage GoToAddressBookPage()
        {
            ClickAddressBook();
            return new AddressBookPage(driver);
        }

        public WishListPage GoToWishListPage()
        {
            ClickWishList();
            return new WishListPage(driver);
        }
    }
}

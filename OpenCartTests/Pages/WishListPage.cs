using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public class WishListPage : ARightMenuComponent
    {
        public IWebElement VerifyWishList { get; private set; }
        public WishListPage(IWebDriver driver) : base(driver)
        {
            VerifyWishList = driver.FindElement(By.CssSelector (".container .row .col-sm-9 p"));
        }

        public string GetVerifyWishListText() => VerifyWishList.Text;
        /*public void ClickNewWishListButton() => NewWishList.Click();
        public string GetNewWishListButtonText() => NewWishList.Text;*/

        public void VerifyWishListPage()
        {
            GetVerifyWishListText();
        }
    }
}

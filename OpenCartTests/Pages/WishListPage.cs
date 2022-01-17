using OpenQA.Selenium;
using OpenCartTests.Data;
using OpenCartTests.Pages;
using OpenCartTests.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public class WishListPage : AStatusBarComponent 
    {        
        public IWebElement DeleteButton { get {return driver.FindElement(By.CssSelector("#content tr:first-child .btn-danger")); } }
        
        public IWebElement Alertmessage { get { return driver.FindElement(By.CssSelector(".alert-success:not( .fa-check-circle)")); } }
        public IWebElement EmptyWishListMessage { get { return driver.FindElement(By.CssSelector("#content > p")); } }
        public WishListPage(IWebDriver driver) : base(driver)
        {           
            
            
        }



        public void DeleteProduct()
        {
            DeleteButton.Click();
        }
        public string GetAlertMessageText()
        {
            return Alertmessage.Text;
        }
        public string GetEmptyWishListMessageText()
        {
            return EmptyWishListMessage.Text;
        }
    }
}

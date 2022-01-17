using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public class WishListPage : AHeadComponent
    {
        public IWebElement Wishproduct { get; private set; }

        public WishListPage(IWebDriver driver) : base(driver)
        {
            Wishproduct = driver.FindElement(By.Id("content"));

        }
    }
}

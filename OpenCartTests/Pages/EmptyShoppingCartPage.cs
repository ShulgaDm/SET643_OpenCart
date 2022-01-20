using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public class EmptyShoppingCartPage : AHeadComponent
    {
        public IWebElement EmptyShoppingCartContent { get; private set; }
       
        public EmptyShoppingCartPage(IWebDriver driver) : base(driver)
        {
            EmptyShoppingCartContent = driver.FindElement(By.XPath("//*[@id='content']/p"));
            
        }

        public string GetEmptyShoppingCartText() => EmptyShoppingCartContent.Text;
      
    }
}

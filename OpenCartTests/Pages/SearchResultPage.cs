using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public class SearchResultPage : ASearchCriteriaComponent
    {
        public IWebElement ResultPageHeader { get; private set; }
        public SearchResultPage(IWebDriver driver) : base(driver) 
        { 
            ResultPageHeader = driver.FindElement(By.XPath("//*[@id='content']/h1")); 
        }
    }
}

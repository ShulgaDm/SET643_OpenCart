using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public class HomePage : AHeadComponent
    {
        public HomePage(IWebDriver driver) : base(driver) { }
        public ASearchCriteriaComponent FindProduct(string searchText)
        {
            ClearSearchProductField();
            SetSearchProductField(searchText);
            SetSearchProductField(Keys.Enter);
            return new SearchResultPage(driver);
        }
    }
}

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
        public IWebElement ButtonListView { get; private set; }
        public IWebElement ButtonGridView { get; private set; }
        public IWebElement SortBy { get; private set; }
        public SearchResultPage(IWebDriver driver) : base(driver) 
        { 
            ResultPageHeader = driver.FindElement(By.XPath("//*[@id='content']/h1"));
            ButtonListView = driver.FindElement(By.Id("list-view"));
            ButtonGridView = driver.FindElement(By.Id("grid-view"));
            SortBy = driver.FindElement(By.Id("input-sort"));
        }
        public void ClickButtonListView() => ButtonListView.Click();
        public void ClickButtonGridView() => ButtonGridView.Click();
        public void ClickSortBy() => SortBy.Click();
        public SearchResultPage SelectSortByType(string category)
        {
            foreach (IWebElement type in SortBy.FindElements(By.TagName("option")))
            {
                if (type.Text.Equals(category))
                    type.Click();
            }
            return new SearchResultPage(driver);
        }
    } 
}

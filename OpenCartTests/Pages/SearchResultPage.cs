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
        public IWebElement ProductCompare { get; }
        public IWebElement ProductTable { get; }
        public IWebElement FirstProductTitle { get; }
        public IWebElement SortBy { get; private set; }
        public IWebElement Show { get; private set; }
        public SearchResultPage(IWebDriver driver) : base(driver)
        {
            ResultPageHeader = driver.FindElement(By.XPath("//*[@id='content']/h1"));
            ButtonListView = driver.FindElement(By.Id("list-view"));
            ButtonGridView = driver.FindElement(By.Id("grid-view"));
            ProductCompare = driver.FindElement(By.Id("compare-total"));
            ProductTable = driver.FindElement(By.CssSelector("#content > div:nth-child(8)"));
            FirstProductTitle = driver.FindElement(By.XPath("//*[@id='content']/div[3]/div[1]/div/div[2]/div[1]/h4/a"));
            SortBy = driver.FindElement(By.Id("input-sort"));
            Show = driver.FindElement(By.Id("input-limit"));
        }
        public void ClickButtonListView() => ButtonListView.Click();
        public void ClickButtonGridView() => ButtonGridView.Click();
        public void ClickProductCompare() => ProductCompare.Click();
        public void ClickSortBy() => SortBy.Click();
        public void ClickShow() => Show.Click();
        public SearchResultPage SelectSortByType(string category)
        {
            foreach (IWebElement type in SortBy.FindElements(By.TagName("option")))
            {
                if (type.Text.Equals(category))
                    type.Click();
            }
            return new SearchResultPage(driver);
        }
        public SearchResultPage SelectShowType(string category)
        {
            foreach (IWebElement type in Show.FindElements(By.TagName("option")))
            {
                if (type.Text.Equals(category))
                    type.Click();
            }
            return new SearchResultPage(driver);
        }
    }
}
using OpenCartTests.Tests.Cristina_Budzinska;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public abstract class ASearchCriteriaComponent : AStatusBarComponent
    {
        public IWebElement SearchCriteria { get; private set; }
        public IWebElement Description { get; private set; }
        public IWebElement SubCategory { get; private set; }
        public IWebElement SearchCriteriaButton { get; private set; }
        public IWebElement Categories { get; private set; }
        public ASearchCriteriaComponent(IWebDriver driver) : base(driver)
        {
            SearchCriteria = driver.FindElement(By.Name("search"));
            Description = driver.FindElement(By.Name("description"));
            SubCategory = driver.FindElement(By.Name("sub_category"));
            SearchCriteriaButton = driver.FindElement(By.Id("button-search"));
            Categories = driver.FindElement(By.Name("category_id"));
        }
        public void ClickSearchCriteria() => SearchCriteria.Click();
        public void ClickDescription() => Description.Click();
        public void ClickSubCategory() => SubCategory.Click();
        public SearchResultPage ClickSearchCriteriaButton()
        {
            SearchCriteriaButton.Click();
            return new SearchResultPage(driver);
        }
        public void SetSearchCriteria(string text)
        {
            ClickSearchCriteria();
            SearchCriteria.SendKeys(text);
        }
        public void ClickCategory() => Categories.Click();
        public void SelectCategory(string category)
        {
            foreach (IWebElement option in Categories.FindElements(By.TagName("option")))
            {
                if (option.Text.Equals(category))
                    option.Click();
            }
        }
    }
}

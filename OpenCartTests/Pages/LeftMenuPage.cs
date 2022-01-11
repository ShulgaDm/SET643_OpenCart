using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace OpenCartTests.Pages
{
    public class LeftMenuPage : ALeftMenuComponent
    {
        public IWebElement CategoryNameText { get; private set; }
        public LeftMenuPage(IWebDriver driver) : base(driver)
        {
            CategoryNameText = driver.FindElement(By.CssSelector("#content > h2"));
        }
        public string GetCategoryNameFromContent() => CategoryNameText.Text;
    }
}


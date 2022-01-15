using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using static OpenCartTests.Pages.AHeadComponent;

namespace OpenCartTests.Pages
{
    public class AdminCategoriesPage : AAdminNavigationComponent
    {


        public IWebElement AddNewCategoryButton { get; private set; }
        public IWebElement MyAdminAccountButton { get; private set; }
        public IWebElement RebuildButton { get; private set; }

        public AdminCategoriesPage(IWebDriver driver) : base(driver)
        {
            AddNewCategoryButton = driver.FindElement(By.CssSelector("a.btn.btn-primary"));
            MyAdminAccountButton = driver.FindElement(By.CssSelector("#header > div > ul > li.dropdown"));
            RebuildButton = driver.FindElement(By.XPath("//*[@id='content']/div[1]/div/div/a[2]"));
        }
        public void ClickMyAdminAccountButton() => MyAdminAccountButton.Click();
        public void ClickRebuild() => RebuildButton.Click();

        public AdminCategoriesMessagePage Rebuild() 
        {
            ClickRebuild();
            return new AdminCategoriesMessagePage(driver);
        }

    }
}

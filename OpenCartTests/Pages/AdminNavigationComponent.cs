using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using static OpenCartTests.Pages.AHeadComponent;

namespace OpenCartTests.Pages
{
    public abstract class AAdminNavigationComponent
    {

        protected IWebDriver driver;
        public IWebElement AdminDashBoard { get; private set; }
        public IWebElement AdminCatalog { get; private set; }
        public IWebElement Categories { get; private set; }

        public IWebElement CategoryProduct { get; private set; }
        public AAdminNavigationComponent(IWebDriver driver)
        {
            this.driver = driver;
            AdminDashBoard = driver.FindElement(By.CssSelector("li#menu-dashboard"));
            AdminCatalog = driver.FindElement(By.CssSelector("li#menu-catalog"));
            Categories = driver.FindElement(By.XPath("//*[@id='collapse1']/li[1]"));

            CategoryProduct= driver.FindElement(By.XPath("//*[@id='content']/div[1]/div/ul/li[2]/a"));

        }
        public void ClickOnAdminDashBoard() => AdminDashBoard.Click();
        public void ClickAdminCatalog() => AdminCatalog.Click();
        public void ClickCategories() => Categories.Click();

       
    }
}
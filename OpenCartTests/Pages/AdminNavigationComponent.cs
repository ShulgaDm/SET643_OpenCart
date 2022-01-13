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
        private readonly string OPTION_NOT_FOUND_MESSAGE = "Cannot foud the option";

        private DropdownOptions dropdownOptions;
        public IWebElement AdminDashBoard { get; private set; }
        public IWebElement AdminCatalog { get; private set; }
        public AAdminNavigationComponent(IWebDriver driver)
        {
            this.driver = driver;
            AdminDashBoard = driver.FindElement(By.CssSelector("li#menu-dashboard"));
            AdminCatalog = driver.FindElement(By.CssSelector("li#menu-catalog"));
      
        }
        public void ClickOnAdminDashBoard() => AdminDashBoard.Click();
        public void ClickAdminCatalog() => AdminCatalog.Click();

    }
}
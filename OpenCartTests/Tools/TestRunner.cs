using NUnit.Framework;
using OpenCartTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Tools
{
    public abstract class TestRunner
    {
        protected IWebDriver driver;
        private readonly string OpenCartURL = "http://cart/";

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {

            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            // driver.Quit();
        }

        protected HomePage LoadApplication()
        {
            return new HomePage(driver);
        }
    }
}

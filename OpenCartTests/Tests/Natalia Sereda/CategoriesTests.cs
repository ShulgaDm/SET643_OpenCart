using System;
using NUnit.Framework;
using OpenCartTests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenCartTests.Pages;

namespace OpenCartTests.Tests.Sereda_Natalia
{

    [TestFixture]
    class CategoriesTests
    {
        private readonly string URL = "http://localhost";
        private readonly string AdminURL = "http://localhost/admin/";
        private IWebDriver driver;

        [OneTimeSetUp]
        public void StartChrome()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
        }

        public void CategoryPreTest(string CategoryExpected)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(URL);
            Thread.Sleep(1000);
            HomePage homePage = new HomePage(driver);
            Thread.Sleep(1000);
            LeftMenuPage productPage = homePage.ClickShowAllFromCategoryByPartialCategoryName(CategoryExpected);

            string actualInLeftMenu = productPage.GetCurrentItemFromLeftMenuText();
            string actualInContent = productPage.GetCategoryNameFromContent();
            StringAssert.Contains(CategoryExpected, actualInLeftMenu);
            Console.WriteLine("Expected: " + CategoryExpected + " Actual in Left: " + actualInLeftMenu + " Actual in Content: " + actualInContent);
            Assert.AreEqual(CategoryExpected, actualInContent);
        }
        [Test]
        public void DesktopCategoryTest()
        {
            string CategoryExpected = "Desktops";
            CategoryPreTest(CategoryExpected);
        }
        [Test]
        public void ComponentsCategoryTest()
        {
            string CategoryExpected = "Components";
            CategoryPreTest(CategoryExpected);
        }
        //[Test]
        //public void TabletsCategoryTest()
        //{
        //    string CategoryExpected = "Tablets";
        //    CategoryPreTest(CategoryExpected);
        //}

        //[Test]
        //public void CamerasCategoryTest()
        //{
        //    string CategoryExpected = "Cameras";
        //    CategoryPreTest(CategoryExpected);
        //}
        //[Test]
        //public void SoftwareCategoryTest()
        //{
        //    string CategoryExpected = "Software";
        //    CategoryPreTest(CategoryExpected);
        //}


        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }
    }
}
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }

        public void CategoryIsVisibleTest(string CategoryExpected)
        {
       
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(URL);
            HomePage homePage = new HomePage(driver);
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
            CategoryIsVisibleTest(CategoryExpected);
        }
        [Test]
        public void ComponentsCategoryTest()
        {
            string CategoryExpected = "Components";
            CategoryIsVisibleTest(CategoryExpected);
        }

        [Test]
        public void LaptopsAndNotebooksCategoryTest()
        {
            string CategoryExpected = "Laptops & Notebooks";
            CategoryIsVisibleTest(CategoryExpected);
        }
        [Test]
        public void MP3PlayersCategoryTest()
        {
            string CategoryExpected = "MP3 Players";
            CategoryIsVisibleTest(CategoryExpected);
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
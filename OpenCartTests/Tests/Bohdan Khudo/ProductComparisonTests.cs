using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenCartTests.Data;
using OpenCartTests.Pages;
using OpenCartTests.Tools;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace OpenCartTests.Tests.Bohdan_Khudo
{

    [TestFixture]
    public class ProductComparisonTests : TestRunner
    {
        protected override string OpenCartURL { get => "http://localhost/opencart3/upload"; }
        private const string EXPECTED_CATEGORY = "Phones & PDAs";
        private const int EXPECTED_COUNT_OF_PRODUCTS = 3;
        private readonly double[] EXPECTED_PRICES = new double[] {122, 123.2, 337.99};
        
        
        [Test]
        public void CategoryCheckTest()
        {
            new HomePage(driver).ClickPhonesAndPdasCategory();

            CategoryPage categoryPage = new CategoryPage(driver);

            Assert.AreEqual(EXPECTED_CATEGORY, categoryPage.GetLastBreadcrumbText());
        }
        
        [Test]
        public void CountOfSelectedProductTest()
        {
            new HomePage(driver).ClickPhonesAndPdasCategory();
            CategoryPage categoryPage = new CategoryPage(driver);
            ProductsListComponent productsList = new ProductsListComponent(driver);
            
            foreach (var item in productsList.ProductComponents)
            {
                item.ClickAddToCompareButton();
                Thread.Sleep(1000);
            }
            
            Assert.AreEqual($"Product Compare ({EXPECTED_COUNT_OF_PRODUCTS})", categoryPage.ProductCompareText);
        }
        [Test]
        
        public void ProductCompareTest()
        {
            
            new HomePage(driver).ClickPhonesAndPdasCategory();
            CategoryPage page = new CategoryPage(driver);
            ProductsListComponent productsList = new ProductsListComponent(driver);

            foreach (var item in productsList.ProductComponents)
            {
                item.ClickAddToCompareButton();
                Thread.Sleep(1000);
            }
            page.ClickOnProductCompare();

            ProductComparison productComparison = new ProductComparison(driver);
            
            Assert.AreEqual(EXPECTED_PRICES, productComparison.Prices);

        }

    }
}
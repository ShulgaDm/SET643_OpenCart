using NUnit.Framework;
using OpenCartTests.Pages;
using OpenCartTests.Tools;
using System.Threading;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;


namespace OpenCartTests.Tests.Bohdan_Khudo
{

    [AllureNUnit]
    [Category("ProductComparison")]
    [TestFixture]
    public class ProductComparisonTests : TestRunner
    {
        protected override string OpenCartURL { get => "http://34.136.246.110"; }
        private const string EXPECTED_CATEGORY = "Phones & PDAs";
        private const int EXPECTED_COUNT_OF_PRODUCTS = 3;
        private readonly double[] EXPECTED_PRICES = new double[] {122, 123.2, 337.99};


        [AllureTag("ProductComparison")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("KhB")]
        [Test]
        public void CategoryCheckTest()
        {
            new HomePage(driver).ClickPhonesAndPdasCategory();

            CategoryPage categoryPage = new CategoryPage(driver);

            Assert.AreEqual(EXPECTED_CATEGORY, categoryPage.GetLastBreadcrumbText());
        }

        [AllureTag("ProductComparison")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("KhB")]
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

        [AllureTag("ProductComparison")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("KhB")]
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
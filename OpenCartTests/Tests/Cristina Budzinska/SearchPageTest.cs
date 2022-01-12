using NUnit.Framework;
using OpenCartTests.Pages;
using OpenCartTests.Tools;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Tests.Cristina_Budzinska
{
    [TestFixture]
    public class SearchPageTest: TestRunner 
    {
        protected override string OpenCartURL { get => "http://opencart"; }
        private readonly string TAG_ATTRIBUTE_CLASS = "class";
        private readonly string OPTION_ACTIVE = "active";

        [Test]
        public void SearchResultPageTest()
        {
            string expectedResult = "Search - iPhone";

            HomePage homePage = new HomePage(driver);
            SearchResultPage resultPage = (SearchResultPage)homePage.FindProduct("iPhone");

            string actualResult = resultPage.ResultPageHeader.Text;
            Assert.AreEqual(expectedResult, actualResult);   //check if page header equals expected result
        }
        [Test]
        public void SearchResultPageListGridViewTests()
        {
            HomePage homePage = new HomePage(driver);

            SearchResultPage resultPage = (SearchResultPage)homePage.FindProduct("iPhone");
            resultPage.ClickButtonListView();
            Assert.IsTrue(resultPage.ButtonListView.GetAttribute(TAG_ATTRIBUTE_CLASS).Contains(OPTION_ACTIVE));   //check if list view active

            resultPage.ClickButtonGridView();
            Assert.IsTrue(resultPage.ButtonGridView.GetAttribute(TAG_ATTRIBUTE_CLASS).Contains(OPTION_ACTIVE));  //check if grid view active
        }
        [Test]
        public void SortByTest()
        {
            string expectedResult = "Model (Z - A)";
            HomePage homePage = new HomePage(driver);

            SearchResultPage resultPage = (SearchResultPage)homePage.FindProduct("iPod");
            resultPage.ClickSortBy();

            SearchResultPage newResultPage = resultPage.SelectSortByType("Model (Z - A)");
            SelectElement actualResult = new SelectElement(newResultPage.SortBy);
            Assert.AreEqual(expectedResult, actualResult.SelectedOption.Text);
        }
    }
}

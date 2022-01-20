using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
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
    [AllureNUnit]
    [Category("SearchPage")]
    public class SearchPageTest : TestRunner
    {
        protected override string OpenCartURL { get => "http://opencart"; }
        private readonly string TAG_ATTRIBUTE_CLASS = "class";
        private readonly string OPTION_ACTIVE = "active";

        [Test]
        [AllureTag("SearchPage")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("BudCr")]
        public void SearchResultPageTest()
        {
            string expectedResult = "Search - iPhone";

            HomePage homePage = new HomePage(driver);
            SearchResultPage resultPage = (SearchResultPage)homePage.FindProduct("iPhone");

            string actualResult = resultPage.ResultPageHeader.Text;
            Assert.AreEqual(expectedResult, actualResult);   //check if page header equals expected result
        }
        [Test]
        [AllureTag("SearchPage")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("BudCr")]
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
        [AllureTag("SearchPage")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("BudCr")]
        public void CategoriesTest()
        {
            string expectedTitle = "Nikon D300";
            string expectedCategory = "Cameras";

            HomePage homePage = new HomePage(driver);

            SearchResultPage searchResult = (SearchResultPage)homePage.FindProduct("Nikon");
            searchResult.SelectCategory("Cameras");

            SearchResultPage resultPage = searchResult.ClickSearchCriteriaButton();
            SelectElement actualCategory = new SelectElement(resultPage.Categories);
            string actualTitle = resultPage.FirstProductTitle.Text;

            Assert.AreEqual(actualCategory.SelectedOption.Text, expectedCategory);         //check if selected option as same as expected
            Assert.AreEqual(expectedTitle, actualTitle);        //check if title of first product in the list as same as expected
        }
        [Test]
        [AllureTag("SearchPage")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("BudCr")]
        public void SubCategoryTest()
        {
            string expectedTitle = "iPod Nano";

            HomePage homePage = new HomePage(driver);

            SearchResultPage searchResult = (SearchResultPage)homePage.FindProduct("Nano");
            searchResult.SelectCategory("MP3 Players");
            searchResult.ClickSubCategory();
            Assert.IsTrue(searchResult.SubCategory.Selected);        //assert a check box is checked

            SearchResultPage resultPage = searchResult.ClickSearchCriteriaButton();
            string actualTitle = resultPage.FirstProductTitle.Text;

            Assert.AreEqual(expectedTitle, actualTitle);   //check if title of first product in the list as same as expected
        }

        [Test]
        [AllureTag("SearchPage")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("BudCr")]
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
        [Test]
        [AllureTag("SearchPage")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("BudCr")]
        public void ShowTest()
        {
            string expectedResult = "100";
            HomePage homePage = new HomePage(driver);

            SearchResultPage resultPage = (SearchResultPage)homePage.FindProduct("Mac");

            SearchResultPage newResultPage = resultPage.SelectShowType("100");
            SelectElement actualResult = new SelectElement(newResultPage.Show);
            Assert.AreEqual(expectedResult, actualResult.SelectedOption.Text);
        }
    }
}









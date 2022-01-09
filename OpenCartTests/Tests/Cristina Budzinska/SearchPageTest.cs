using NUnit.Framework;
using OpenCartTests.Pages;
using OpenCartTests.Tools;
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
        [Test]
        public void SearchResultPageTest()
        {
            string expectedResult = "Search - iPhone";

            HomePage homePage = new HomePage(driver);
            SearchResultPage resultPage = (SearchResultPage)homePage.FindProduct("iPhone");

            string actualResult = resultPage.ResultPageHeader.Text;
            Assert.AreEqual(expectedResult, actualResult);   //check if page header equals expected result
        }
    }
}

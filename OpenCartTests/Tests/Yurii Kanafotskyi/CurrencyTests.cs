using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;
using OpenCartTests.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCartTests.Tests.Yurii_Kanafotskyi
{
    public class CurrencyTests : TestRunner
    {
        
        protected override string OpenCartURL { get => "http://localhost"; }

        [Test]
        public void PriceChangingDependingOnCurrency()
        {
            string expected = "472";

            string homePage = new HomePage(driver).ChangeCurrency().GetFirstProductInfo().GetURL();
            Thread.Sleep(6000);
            
            string actual = new ProductDetailsPage(driver).GetPriceText();

            Assert.LessOrEqual(expected, actual);
        }
    }
}

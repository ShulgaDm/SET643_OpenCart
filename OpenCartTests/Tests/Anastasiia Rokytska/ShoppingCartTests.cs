using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;
using OpenCartTests.Tools;

namespace OpenCartTests.Tests.Anastasiia_Rokytska
{
    [TestFixture]
    public class ShoppingCartTests : TestRunner
    {
        //private emtyCartText = By.XPath("//*[@id='content']/p");
        //protected override string OpenCartURL { get => "http://localhost/index.php?route=checkout/cart"; }
        protected override string OpenCartURL { get => "http://localhost"; }
        [Test]
        public void EmptyShoppingCartWithoutLogging()
        {
            ShoppingCartPage shoppingCartPage = new HomePage(driver).GoToShoppingCartPage();
            string actualResult = shoppingCartPage.GetEmptyShoppingCartText();
            string expectedResult = "Your shopping cart is empty!";
            Assert.AreEqual(expectedResult, actualResult);

        }

    }
}

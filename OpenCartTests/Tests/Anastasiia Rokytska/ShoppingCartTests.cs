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
        //protected override string OpenCartURL { get => "http://localhost/index.php?route=checkout/cart"; }
        private readonly string EMPTY_SHOPPING_CART_TEXT = "Your shopping cart is empty!";
        protected override string OpenCartURL { get => "http://localhost"; }
        [Test]
        public void EmptyShoppingCartWithoutLogging()
        {
            ShoppingCartPage shoppingCartPage = new HomePage(driver).GoToShoppingCartPage();
            string actualResult = shoppingCartPage.GetEmptyShoppingCartText();
            Assert.AreEqual(EMPTY_SHOPPING_CART_TEXT, actualResult);
        }

    }
}

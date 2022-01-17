using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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

        User user;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            user = User.CreateBuilder()
              .SetFirstName("Nastya")
              .SetLastName("Rokytska")
              .SetEMail("nastya@gmail.com")
              .SetTelephone("0673256485")
              .SetPassword("qwerty123")
              .Build();
        }
        [Test]
        public void EmptyShoppingCartWithoutLogging()
        {
            ShoppingCartPage shoppingCartPage = new HomePage(driver).GoToShoppingCartPage();
            string actualResult = shoppingCartPage.GetEmptyShoppingCartText();
            Assert.AreEqual(EMPTY_SHOPPING_CART_TEXT, actualResult);
        }

        [Test]
        public void EmptyShoppingCartWithLogging()
        {
            RegisterPage registerPage = new HomePage(driver).GoToRegisterPage();
            registerPage.FillRegisterForm(user);
            registerPage.ClickAgreeCheckBox();


            AccountSuccessPage successPage = registerPage.ClickContinueButtonSuccess();
            Thread.Sleep(1000);
            string actualResult = new HomePage(driver).GoToShoppingCartPage().GetEmptyShoppingCartText();
            Assert.AreEqual(EMPTY_SHOPPING_CART_TEXT, actualResult);
        }

    }
}

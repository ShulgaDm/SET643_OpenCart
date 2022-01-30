using System;
using System.Threading;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;
using OpenCartTests.Tools;

namespace OpenCartTests.Tests.Anastasiia_Rokytska
{
    [TestFixture]
    [AllureNUnit]
    [Category("ShoppingCart")]
    public class ShoppingCartTests : TestRunner
    {
        private readonly string EMPTY_SHOPPING_CART_TEXT = "Your shopping cart is empty!";
        protected override string OpenCartURL { get => "http://34.136.246.110"; }

        User user1, user2, user3, user4;

        public User CreateUser()
        {
            var rand = new Random();
            string id = (rand.Next(1000)).ToString();
            return User.CreateBuilder()
              .SetFirstName("test" + id)
              .SetLastName("test" + id)
              .SetEMail("test" + id +"@gmail.com")
              .SetTelephone("0671234567")
              .SetPassword("qwerty")
              .Build();
        }


        public void RegisterUser(User data)
        {
            RegisterPage registerPage = new HomePage(driver).GoToRegisterPage();
            registerPage.FillRegisterForm(data);
            registerPage.ClickAgreeCheckBox();
            AccountSuccessPage successPage = registerPage.ClickContinueButtonSuccess();
        }


        public void VerifyOneProductAdding()
        {
            HomePage homepage = new HomePage(driver).GoToHomePage().GetProductDetails(0); 
            string price = new ProductDetailsPage(driver).GetPriceText();
            ProductDetailsPage pd = new ProductDetailsPage(driver).AddToShoppingCart();
            string totalPrice = homepage.GoToShoppingCartPage().GetTotalPriceText();
            Assert.AreEqual(totalPrice, price);
        }


        public void DeleteProductFromShoppingCart()
        {
            new HomePage(driver).GoToShoppingCartPage().DeleteProduct();
        }


        public void VerifyEmptyShoppingCart()
        {
            string actualResult = new HomePage(driver).GoToEmptyShoppingCartPage().GetEmptyShoppingCartText();
            Assert.AreEqual(EMPTY_SHOPPING_CART_TEXT, actualResult);
        }

        public void CheckInputFieldNotEmptyShoppingCart(string data, string expected)
        {
            VerifyOneProductAdding();
            HomePage homePage = new HomePage(driver).GoToShoppingCartPage().EnterInputFieldForFirstProduct(data);
            string actual = new ShoppingCartPage(driver).GetInputFieldForFirstProductText();
            DeleteProductFromShoppingCart();
            Assert.AreEqual(expected, actual);
        }

        public void CheckInputFieldEmptyShoppingCart(string data)
        {
            VerifyOneProductAdding();
            HomePage homePage = new HomePage(driver).GoToShoppingCartPage().EnterInputFieldForFirstProduct(data);
            VerifyEmptyShoppingCart();
        }


        public void VerifyInputFieldsForProduct()
        {
            CheckInputFieldNotEmptyShoppingCart("10.2", "10");
            CheckInputFieldNotEmptyShoppingCart("3,9", "3");
            CheckInputFieldNotEmptyShoppingCart("10000000000", "2147483647");
            CheckInputFieldEmptyShoppingCart("-7");
            CheckInputFieldEmptyShoppingCart("abc");
            CheckInputFieldEmptyShoppingCart("");
            CheckInputFieldEmptyShoppingCart("0");
            CheckInputFieldEmptyShoppingCart("0.6");
            CheckInputFieldEmptyShoppingCart("0,2");
        }


        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            user1 = CreateUser();
            user2 = CreateUser();
            user3 = CreateUser();
            user4 = CreateUser();
        }


        [Test]
        [Category("ShoppingCart")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("AR")]
        public void EmptyShoppingCartWithoutLogging()
        {
            VerifyEmptyShoppingCart();
        }


        [Test]
        [Category("ShoppingCart")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("AR")]
        public void EmptyShoppingCartWithLogging()
        {
            RegisterUser(user1);
            VerifyEmptyShoppingCart();
        }


        [Test]
        [Category("ShoppingCart")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("AR")]
        public void AddItemToShoppingCartWithoutLogging()
        {
            VerifyOneProductAdding();
        }


        [Test]
        [Category("ShoppingCart")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("AR")]
        public void AddItemToShoppingCartWithLogging()
        {
            RegisterUser(user2);
            VerifyOneProductAdding();
        }


        [Test]
        [Category("ShoppingCart")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("AR")]
        public void DeletePoductFromShoppingCartWithoutLogging()
        {
            VerifyOneProductAdding();
            DeleteProductFromShoppingCart();
            VerifyEmptyShoppingCart();
        }


        [Test]
        [Category("ShoppingCart")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("AR")]
        public void DeletePoductFromShoppingCartWithLogging()
        {
            RegisterUser(user3);
            VerifyOneProductAdding();
            DeleteProductFromShoppingCart();
            VerifyEmptyShoppingCart();
        }


        [Test]
        [Category("ShoppingCart")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("AR")]
        public void ValidatePoductFieldWithoutLoginning()
        {
            VerifyInputFieldsForProduct();
        }


        [Test]
        [Category("ShoppingCart")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("AR")]
        public void ValidatePoductFieldWithLoginning()
        {
            RegisterUser(user4);
            VerifyInputFieldsForProduct();
        }


        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }
    }
}

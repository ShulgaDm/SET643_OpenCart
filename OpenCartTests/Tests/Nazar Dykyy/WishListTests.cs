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

namespace OpenCartTests.Tests.Nazar_Dykyy
{
    public class WishListTests : TestRunner
    {
        protected override string OpenCartURL { get => "http://localhost"; }
        public readonly string Wishlist_URL = "index.php?route=account/wishlist";
        public readonly string LOGIN_URL = "index.php?route=account/login";
        
        User user;
        User user1;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
          user = User.CreateBuilder()
              .SetFirstName("Nazar")
              .SetLastName("Dykyy")
              .SetEMail("n.dykyy@gmail.com")
              .SetTelephone("0980201806")
              .SetPassword("qwerty")
              .Build();
            user1 = User.CreateBuilder()
             .SetFirstName("Ihor")
             .SetLastName("Dykyy")
             .SetEMail("addproduct@towishlict.com")
             .SetTelephone("0980201807")
             .SetPassword("qwerty")
             .Build();

        }
        [Test]
        public void EmptyWishListAfterFirstLogin()
        {
            string expected = Wishlist_URL;
            RegisterPage registerPage = new HomePage(driver).GoToRegisterPage();

            registerPage.FillRegisterForm(user);
            registerPage.ClickAgreeCheckBox();


            AccountSuccessPage successPage = registerPage.ClickContinueButtonSuccess();

            string actual = new WishListPage(driver).GoToWishPage()//
                                                    .GetURL();
            Assert.IsTrue(actual.Contains(expected));

        }
        [Test]
        public void InaccessibleWishListWithoutLogging()
        {
            string expected = LOGIN_URL;
            string actual = new HomePage(driver)
                                    .GoToLoginPage()
                                    .unloggedClickWishListButton()
                                    .GetURL();

            Assert.IsTrue(actual.Contains(expected));

        }
        [Test]
        public void AddProductToWishList()
        {
            string expected = Wishlist_URL;
            string homepage = new HomePage(driver)
                                    .GoToLoginPage()
                                    .SuccessfullLogin(user1)
                                    .GoToHomePage()
                                    .GetFirstProductInfo()                                    
                                    .GetURL();
            ProductDetailsPage pd = new ProductDetailsPage(driver).AddToWishList();
            string actual = new WishListPage(driver).GoToWishPage()
                                                     .GetURL();
            Assert.IsTrue(actual.Contains(expected));

        }
    }
}

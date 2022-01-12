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
        protected override string OpenCartURL { get => "http://localhost/index.php?route=account/register"; }
        [Test]
        public void EmptyWishListAfterFirstLogin()
        {
            RegisterPage registerPage = new RegisterPage(driver);
            User user = User.CreateBuilder().SetFirstName("Nazar").SetLastName("Dykyy").SetEMail("n.dykyy@gmail.com").SetTelephone("0980201806").SetPassword("qwerty").Build();

            registerPage.FillRegisterForm(user);
            registerPage.ClickAgreeCheckBox();


            AccountSuccessPage successPage = registerPage.ClickContinueButtonSuccess();

            WishListPage wishlistpage = new WishListPage(driver).GoToWishListPage();
           

        }
        [Test]
        public void InaccessibleWishListWithoutLogging()
        {
            LoginPage loginPage = new HomePage(driver)
                                    .GoToLoginPage()
                                    .unloggedClickWishListButton();
            
            Assert.DoesNotThrow(() => loginPage.VerifyLoginPage());

        }
    }
}

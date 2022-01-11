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

namespace OpenCartTests.Tests.Shulga_Dmytro
{
    [TestFixture]
    public class AddressBookTests : TestRunner
    {
        
        protected override string OpenCartURL { get => "http://cart"; }
        [Test]
        public void UnloggedClickAddressBookButton()
        {
            LoginPage loginPage = new HomePage(driver)
                                    .GoToLoginPage()
                                    .unloggedClickAddressBookButton();

            Assert.DoesNotThrow(() => loginPage.VerifyLoginPage());
        }

        [Test]
        public void LoggedClickAddressBookButton()
        {
            User user = User.CreateBuilder().SetEMail("email@email.com").SetPassword("123456").Build();

            AddressBookPage addressBookPage = new HomePage(driver)
                                    .GoToLoginPage()
                                    .SuccessfullLogin(user)
                                    .GoToAddressBookPage();

            Assert.DoesNotThrow(() => addressBookPage.VerifyAddressBookPage());
        }
    }
}

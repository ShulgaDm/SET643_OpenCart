using NUnit.Framework;
using OpenCartTests.Pages;
using OpenCartTests.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Tests.Shulga_Dmytro
{
    [TestFixture]
    public class AddressBookTests : TestRunner
    {
        [Test]
        public void UnloggedClickAddressBookButton()
        {
            LoginPage loginPage = new HomePage(driver)
                                    .ClickMyAccountOptionLogin("Login")
                                    .unloggedClickAddressBookButton();

            Assert.True(loginPage.IsLoginPage);
        }
    }
}

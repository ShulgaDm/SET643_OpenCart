using System;
using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;
using OpenCartTests.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCartTests.Tests.Bohdan_Khudo
{
    [TestFixture]
    public class LoginTest : TestRunner
    {

        protected override string OpenCartURL { get => "http://localhost/opencart3/upload"; }

        [Test]
        [TestCase(arg: new string[] { "bahdan510@gmail.com", "school22" })]
        public void LoginWithValidData(string[] userData)
        {
            User user = new UserBuilder().SetEMail(userData[0]).SetPassword(userData[1]).Build();

            MyAccountPage myAccountPage = new HomePage(driver).GoToLoginPage().SuccessfullLogin(user);
            //
            myAccountPage.Logout();

        }

        [Test]
        [TestCase(arg: new string[] { "invalid@gmail.com", "invalid" })]
        public void LoginWithInvalidData(string[] userData)
        {
            User user = new UserBuilder().SetEMail(userData[0]).SetPassword(userData[1]).Build();

            new HomePage(driver).GoToLoginPage().UnSuccessfullLogin(user);
        }
    }
}
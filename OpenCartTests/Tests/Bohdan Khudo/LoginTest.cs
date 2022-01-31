using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;
using OpenCartTests.Tools;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace OpenCartTests.Tests.Bohdan_Khudo
{
    [AllureNUnit]
    [Category("Login")]
    [TestFixture]
    public class LoginTest : TestRunner
    {

        protected override string OpenCartURL { get => "http://34.136.246.110"; }

        private const string EXPECTED_CHANGE_YOUR_PASSWORD = "Change your password";
        private const string EXPECTED_WARNING_LOGIN = "Warning: No match for E-Mail Address and/or Password.";

        [AllureTag("Login")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("KhB")]
        [Test]
        [TestCase(arg: new string[] { "bahdan510@gmail.com", "school22" })]
        public void LoginWithValidData(string[] userData)
        {
            User user = new UserBuilder().SetEMail(userData[0]).SetPassword(userData[1]).Build();

            MyAccountPage myAccountPage = new HomePage(driver).GoToLoginPage().SuccessfullLogin(user);
            
            Assert.AreEqual(EXPECTED_CHANGE_YOUR_PASSWORD, myAccountPage.GetChangeYourPasswordText());
            
            myAccountPage.Logout();

        }

        [AllureTag("Login")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("KhB")]
        [Test]
        [TestCase(arg: new string[] { "invalid@gmail.com", "invalid" })]
        public void LoginWithInvalidData(string[] userData)
        {
            User user = new UserBuilder().SetEMail(userData[0]).SetPassword(userData[1]).Build();

            new HomePage(driver).GoToLoginPage().UnSuccessfullLogin(user);
            LoginMessagePage loginMessagePage = new LoginMessagePage(driver);
            
            Assert.AreEqual(EXPECTED_WARNING_LOGIN, loginMessagePage.GetAlertMessageText());

        }
    }
}
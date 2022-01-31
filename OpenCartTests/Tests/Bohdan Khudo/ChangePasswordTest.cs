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
    [Category("ChangePassword")]
    [TestFixture]
    public class ChangePasswordTest : TestRunner
    {
        protected override string OpenCartURL
        {
            get => "http://34.136.246.110";
        }
        

        private const string E_MAIL = "bahdan510@gmail.com";
        private const string OLD_PASSWORD = "school22";
        private const string NEW_PASSWORD = "school33";
        private const string EXPECTED_AlERT_MESSAGE = "Success: Your password has been successfully updated.";

        [AllureTag("ChangePassword")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("KhB")]
        [Test]
        public void ChangePassword()
        {
            User user = User.CreateBuilder().SetEMail(E_MAIL).SetPassword(OLD_PASSWORD).Build();

            new HomePage(driver)
                .GoToLoginPage()
                .SuccessfullLogin(user);
                
            new MyAccountPage(driver).ClickhangeYourPassword();

            ChangePasswordPage changePasswordPage = new ChangePasswordPage(driver);
            changePasswordPage.PasswordField.SendKeys(NEW_PASSWORD);
            changePasswordPage.PasswordConfirm.SendKeys(NEW_PASSWORD);
            changePasswordPage.ClickContinueButton();
            MyAccountMessagePage myAccountMessagePage = new MyAccountMessagePage(driver);
            
            Assert.AreEqual(EXPECTED_AlERT_MESSAGE, myAccountMessagePage.GetAlertMessageText());

            myAccountMessagePage.Logout();
            user = User.CreateBuilder().SetEMail(E_MAIL).SetPassword(NEW_PASSWORD).Build();
            new HomePage(driver)
                .GoToLoginPage()
                .SuccessfullLogin(user);

        }
    }
}
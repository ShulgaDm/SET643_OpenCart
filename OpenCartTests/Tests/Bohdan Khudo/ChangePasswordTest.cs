using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;
using OpenCartTests.Tools;

namespace OpenCartTests.Tests.Bohdan_Khudo
{

    [TestFixture]
    public class ChangePasswordTest : TestRunner
    {
        protected override string OpenCartURL
        {
            get => "http://localhost/opencart3/upload";
        }

        [Test]
        public void ChangePassword()
        {
            User user = User.CreateBuilder().SetEMail("bahdan510@gmail.com").SetPassword("school22").Build();

            new HomePage(driver)
                .GoToLoginPage()
                .SuccessfullLogin(user)
                .GoToMyAccountPage()
                .ClickhangeYourPassword();


            ChangePasswordPage changePasswordPage = new ChangePasswordPage(driver);
            changePasswordPage.PasswordField.SendKeys("school33");
            changePasswordPage.PasswordConfirm.SendKeys("school33");
            changePasswordPage.ClickContinueButton();

        }
    }
}
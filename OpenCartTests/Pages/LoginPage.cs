using OpenCartTests.Data;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public class LoginPage : AUnloggedRightMenuComponent
    {
        public IWebElement EmailField { get; private set; }
        public IWebElement PasswordField { get; private set; }
        public IWebElement LoginButton { get; private set; }
        public LoginPage(IWebDriver driver) : base(driver)
        {
            EmailField = driver.FindElement(By.Id("input-email"));
            PasswordField = driver.FindElement(By.Id("input-password"));
            LoginButton = driver.FindElement(By.CssSelector("input.btn.btn-primary"));
        }

        // Atomic Methods

        // EmailField
        public void ClickEmailField() => EmailField.Click();
        public void ClearEmailField() => EmailField.Clear();
        public void SetEmailField(string text) => EmailField.SendKeys(text);

        // PasswordField
        public void ClickPasswordField() => PasswordField.Click();
        public void ClearPasswordField() => PasswordField.Clear();
        public void SetPasswordField(string text) => PasswordField.SendKeys(text);

        // LoginButton
        public void ClickLoginButton() => LoginButton.Click();
        public string GetLoginButtonText() => LoginButton.GetAttribute(TAG_ATTRIBUTE_VALUE);

        // Functional

        public void VerifyLoginPage() // TO DELETE
        {
            GetLoginButtonText();
        }

        // Business Logic
        private void FillLoginForm(User user)
        {
            ClickEmailField();
            ClearEmailField();
            SetEmailField(user.EMail);
            ClickPasswordField();
            ClearPasswordField();
            SetPasswordField(user.Password);
            ClickLoginButton();
        }

        public MyAccountPage SuccessfullLogin(User user)
        {
            FillLoginForm(user);
            LoggedUser = true;
            return new MyAccountPage(driver);
        }
        
        public LoginMessagePage UnSuccessfullLogin(User invalidUser)
        {
            FillLoginForm(invalidUser);
            return new LoginMessagePage(driver);
        }
    }
}

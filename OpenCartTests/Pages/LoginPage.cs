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
        public bool IsLoginPage
        {
            get => EmailField != null && PasswordField != null && LoginButton != null;
        }
        public LoginPage(IWebDriver driver) : base(driver)
        {
            EmailField = driver.FindElement(By.Id("input-email"));
            PasswordField = driver.FindElement(By.Id("input-password"));
            LoginButton = driver.FindElement(By.CssSelector("input.btn.btn-primary"));
        }

    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public abstract class AHeadComponent
    {
        public class DropdownOptions
        {
            private readonly string OPTION_NOT_FOUND_MESSAGE = "Cannot found the option";
            private readonly IWebDriver driver;
            public IList<IWebElement> ListOptions { get; private set; }
            public DropdownOptions(IWebDriver driver, By searchLocator)
            {
                this.driver = driver;
                InitListOptions(searchLocator);
            }
            private void InitListOptions(By searchLocator)
            {
                ListOptions = driver.FindElements(searchLocator);
            }
            public IWebElement GetDropdownOptionByPartialName(string optionName)
            {
                IWebElement result = null;
                foreach (var item in ListOptions)
                {
                    if (item.Text.ToLower().Contains(optionName.ToLower()))
                    {
                        result = item;
                        break;
                    }
                }
                return result;
            }
            public void ClickDropdownOptionByPartialName(string optionName)
            {
                if (!FindDropdownOptionByPartialName(optionName))
                {
                    throw new FormatException(OPTION_NOT_FOUND_MESSAGE);
                }
                GetDropdownOptionByPartialName(optionName).Click();
            }

            private bool FindDropdownOptionByPartialName(string optionName)
            {
                bool isFound = false;
                foreach (var item in ListOptions)
                {
                    if (item.Text.ToLower().Contains(optionName.ToLower()))
                    {
                        isFound = true;
                    }
                }
                return isFound;
            }
        }

        protected readonly string TAG_ATTRIBUTE_VALUE = "value";

        protected IWebDriver driver;
        private DropdownOptions dropdownOptions;

        public static bool LoggedUser { get; set; } = false;
        public IWebElement MyAccount { get; private set; }
        public IWebElement SearchProductField { get; private set; }
        public IWebElement SearchProductButton { get; private set; }


        public IList<IWebElement> MenuTop { get; private set; }
        public IWebElement DesktopCategory { get; private set; }
        public IWebElement LaptopsAndNotebooksCategory { get; private set; }
        public IWebElement ComponentsCategory { get; private set; }
        public IWebElement TabletsCategory { get; private set; }
        public IWebElement SoftwareCategory { get; private set; }
        public IWebElement PhonesAndPdasCategory { get; private set; }
        public IWebElement CamerasCategory { get; private set; }
        public IWebElement MP3PlayersCategory { get; private set; }
        protected AHeadComponent(IWebDriver driver)
        {
            this.driver = driver;
            MyAccount = driver.FindElement(By.CssSelector("a[title='My Account']"));
            SearchProductField = driver.FindElement(By.Name("search"));
            SearchProductButton = driver.FindElement(By.CssSelector("button.btn.btn-default.btn-lg"));
            MenuTop = driver.FindElements(By.CssSelector("ul.nav.navbar-nav > li"));
            DesktopCategory = driver.FindElement(By.LinkText("Desktops"));
            LaptopsAndNotebooksCategory = driver.FindElement(By.LinkText("Laptops & Notebooks"));
            ComponentsCategory = driver.FindElement(By.LinkText("Components"));
            TabletsCategory = driver.FindElement(By.LinkText("Tablets"));
            SoftwareCategory = driver.FindElement(By.LinkText("Software"));
            PhonesAndPdasCategory = driver.FindElement(By.LinkText("Phones & PDAs"));
            CamerasCategory = driver.FindElement(By.LinkText("Cameras"));
            MP3PlayersCategory = driver.FindElement(By.LinkText("MP3 Players"));
        }

        // Atomic Methods

        // MyAccount

        public void ClickMyAccount() => MyAccount.Click();
        public void ClickMyAccountOptionByPartialName(string optionName)
        {
            ClickSearchProductField();
            ClickMyAccount();
            CreateDropdownOptions(By.CssSelector("ul.dropdown-menu.dropdown-menu-right li"));
            dropdownOptions.ClickDropdownOptionByPartialName(optionName);
            dropdownOptions = null;
        }

        // SearchProductField
        private void ClickOnShowAll()
        {
            driver.FindElement(By.PartialLinkText("Show All")).Click();
        }
        public void ClickCategoryByPartialLinkText(string Category)
        {
            ClickSearchProductField();
            driver.FindElement(By.PartialLinkText(Category)).Click();
        }
        public LeftMenuPage ClickShowAllFromCategoryByPartialCategoryName(string Category)
        {
            ClickCategoryByPartialLinkText(Category);
            ClickOnShowAll();
            return new LeftMenuPage(driver);

        }

        public void ClickSearchProductField() => SearchProductField.Click();
        public void SetSearchProductField(string text)
        {
            SearchProductField.SendKeys(text);
        }
        public void ClearSearchProductField()
        {
            SearchProductField.Clear();
        }

        // Dropdown Methods

        private void CreateDropdownOptions(By searchLocator)
        {
            dropdownOptions = new DropdownOptions(driver, searchLocator);
        }

        // Business Logic

        public LoginPage GoToLoginPage()
        {
            if (LoggedUser)
            {
                throw new Exception("LOGIN_ERROR");
            }
            ClickMyAccountOptionByPartialName("Login");
            return new LoginPage(driver);
        }
        

        public MyAccountPage GoToMyAccountPage()
        {
            if (!LoggedUser)
            {
                throw new Exception("LOGIN_ERROR");
            }
            ClickMyAccountOptionByPartialName("My");
            return new MyAccountPage(driver);
        }
        public AccountLogoutPage Logout()
        {
            if (!LoggedUser)
            {
                throw new Exception("LOGOUT_ERROR");
            }
            ClickMyAccountOptionByPartialName("Logout");
            LoggedUser = false;
            return new AccountLogoutPage(driver);

        }

    }
}

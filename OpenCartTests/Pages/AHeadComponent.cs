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

        protected IWebDriver driver;
        private DropdownOptions dropdownOptions;
        public IWebElement MyAccount { get; private set; }
        public IWebElement SearchProductField { get; private set; }

        protected AHeadComponent(IWebDriver driver)
        {
            this.driver = driver;
            MyAccount = driver.FindElement(By.CssSelector("a[title='My Account']"));
            SearchProductField = driver.FindElement(By.Name("search"));
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

        public void ClickSearchProductField() => SearchProductField.Click();

        // Dropdown Methods

        private void CreateDropdownOptions(By searchLocator)
        {
            dropdownOptions = new DropdownOptions(driver, searchLocator);
        }

        // Business Logic

        public LoginPage ClickMyAccountOptionLogin(string optionName)
        {
            ClickMyAccountOptionByPartialName(optionName);
            return new LoginPage(driver);
        }
    }
}

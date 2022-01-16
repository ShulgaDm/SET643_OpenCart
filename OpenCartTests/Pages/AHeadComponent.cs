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


        public IWebElement Currency { get; private set; }

        public static bool LoggedUser { get; set; } = false;
        public string URL { get; private set; }

        public IWebElement MyAccount { get; private set; }
        public IWebElement ShoppingCartButton { get; private set; }
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

            Currency = driver.FindElement(By.CssSelector(".btn.btn-link.dropdown-toggle"));
            URL = driver.Url;
            MyAccount = driver.FindElement(By.CssSelector("a[title='My Account']"));
            ShoppingCartButton = driver.FindElement(By.CssSelector("a[title='Shopping Cart']"));
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
        public char GetCurrencyText() => Convert.ToChar(Currency.Text.Substring(0, 1));
       
        public void ClickDesktopCategory() => DesktopCategory.Click();
        public void ClickLaptopsAndNotebooksCategory() => LaptopsAndNotebooksCategory.Click();
        public void ClickComponentsCategory() => ComponentsCategory.Click();
        public void ClickTabletsCategory() => TabletsCategory.Click();
        public void ClickSoftwareCategory() => SoftwareCategory.Click();
        public void ClickPhonesAndPdasCategory() => PhonesAndPdasCategory.Click();
        public void ClickCamerasCategory() => CamerasCategory.Click();
        public void ClickMP3PlayersCategory() => MP3PlayersCategory.Click();

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

        // ShoppingCart

        private void ClickShoppingCart() => ShoppingCartButton.Click();

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

        public void ClickCurrency() => Currency.Click();
        public void ClickCurrencyOptionByPartialName(string optionName)
        {
            ClickCurrency();
            CreateDropdownOptions(By.CssSelector(".currency-select.btn.btn-link.btn-block"));

            dropdownOptions.ClickDropdownOptionByPartialName(optionName);
            dropdownOptions = null;
        }

        // Dropdown Methods

        private void CreateDropdownOptions(By searchLocator)
        {
            dropdownOptions = new DropdownOptions(driver, searchLocator);
        }

        // URL
        public string GetURL() => URL;

        // Business Logic
        public ShoppingCartPage GoToShoppingCartPage()
        {
            ClickShoppingCart();
            return new ShoppingCartPage(driver);
        }

        public LoginPage GoToLoginPage()
        {
            if (LoggedUser)
            {
                throw new Exception("LOGIN_ERROR");
            }
            ClickMyAccountOptionByPartialName("Login");
            return new LoginPage(driver);
        }
        public RegisterPage GoToRegisterPage()
        {      
            ClickMyAccountOptionByPartialName("Register");
            return new RegisterPage(driver);
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

        public HomePage ChangeCurrency()
        {
            ClickCurrencyOptionByPartialName("Euro");

            return new HomePage(driver);
        }
    }
}

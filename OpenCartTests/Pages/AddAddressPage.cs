using OpenCartTests.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public class AddAddressPage : ARightMenuComponent
    {
        public IWebElement FirstNameField { get; private set; }
        public IWebElement LastNameField { get; private set; }
        public IWebElement Address1Field { get; private set; }
        public IWebElement CityField{ get; private set; }
        public IWebElement PostCodeField { get; private set; }
        public SelectElement CountrySelect { get; private set; }
        public SelectElement RegionStateSelect { get; private set; }
        public IWebElement ContinueButton { get; private set; }

        public AddAddressPage(IWebDriver driver) : base(driver)
        {
            FirstNameField = driver.FindElement(By.Id("input-firstname"));
            LastNameField = driver.FindElement(By.Id("input-lastname"));
            Address1Field = driver.FindElement(By.Id("input-address-1"));
            CityField = driver.FindElement(By.Id("input-city"));
            PostCodeField = driver.FindElement(By.Id("input-postcode"));
            CountrySelect = new SelectElement(driver.FindElement(By.Id("input-country")));
            RegionStateSelect = new SelectElement(driver.FindElement(By.Id("input-zone")));
            ContinueButton = driver.FindElement(By.CssSelector(".btn-primary"));
        }

        // FirstNameField
        public void ClickFirstNameFieldButton() => FirstNameField.Click();
        public void ClearFirstNameField() => FirstNameField.Clear();
        public void SetFirstNameField(string firstName) => FirstNameField.SendKeys(firstName);

        // LastNameField
        public void ClickLastNameField() => LastNameField.Click();
        public void ClearLastNameField() => LastNameField.Clear();
        public void SetLastNameField(string lastName) => LastNameField.SendKeys(lastName);

        // Address1Field
        public void ClickAddress1Field() => Address1Field.Click();
        public void ClearAddress1Field() => Address1Field.Clear();
        public void SetAddress1Field(string address1) => Address1Field.SendKeys(address1);

        // CityField
        public void ClickCityField() => CityField.Click();
        public void ClearCityField() => CityField.Clear();
        public void SetCityField(string city) => CityField.SendKeys(city);

        // PostCodeField
        public void ClickPostCodeField() => PostCodeField.Click();
        public void ClearPostCodeField() => PostCodeField.Clear();
        public void SetPostCodeField(string postCode) => PostCodeField.SendKeys(postCode);

        // CountrySelect
        public void SelectCountry(string country) => CountrySelect.SelectByText(country);

        // RegionStateSelect
        public void SelectRegionState(string country) => RegionStateSelect.SelectByText(country);

        // ContinueButton
        public void ClickContinueButton() => ContinueButton.Click();


        // Functional

        public void ClearAll()
        {
            ClearFirstNameField();
            ClearLastNameField();
            ClearAddress1Field();
            ClearCityField();
            ClearPostCodeField();
        }

        public void FillForm(Address address)
        {
            SetFirstNameField(address.FirstName);
            SetLastNameField(address.LastName);
            SetAddress1Field(address.Adress1);
            SetCityField(address.City);
            SetPostCodeField(address.PostCode);
            SelectCountry(address.Country);
            SelectRegionState(address.RegionState);
        }


        // Business Logic

        public AddressBookMessagePage SuccessfullAddNewAddress(Address address)
        {
            ClearAll();
            FillForm(address);
            ClickContinueButton();
            return new AddressBookMessagePage(driver);
        }
    }
}

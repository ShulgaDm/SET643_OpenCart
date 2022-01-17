using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public abstract class ARightMenuComponent : AStatusBarComponent
    {
        public IWebElement AddressBook { get; private set; }
            
        public IWebElement EditAccountInformation { get; private set; }


        public ARightMenuComponent(IWebDriver driver) : base(driver)
        {
            AddressBook = driver.FindElement(By.XPath("//*[text()='Address Book']"));
         
        }

        public string GetEditAccountInformationText() => EditAccountInformation.Text;
        public void ClickEditAccountInformation() => EditAccountInformation.Click();


        // AddressBook
        public void ClickAddressBook() => AddressBook.Click();
        

        // Business Logic

        public AddressBookPage GoToAddressBookPage()
        {
            ClickAddressBook();
            return new AddressBookPage(driver);
        }

      
    }
}

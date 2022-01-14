using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
   
       public class AdminCategoriesMessagePage : AdminCategoriesPage
        {
        
            public IWebElement AlertMessage { get; private set; }
            public AdminCategoriesMessagePage(IWebDriver driver) : base(driver)
            {
                InitAlertMessage();
            }
            public void InitAlertMessage()
            {
                AlertMessage = driver.FindElement(By.CssSelector(".alert"));
            }

            public string GetAlertMessageText() => AlertMessage.Text;
        }
    }


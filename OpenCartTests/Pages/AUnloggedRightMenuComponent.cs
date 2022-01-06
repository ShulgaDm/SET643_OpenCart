using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public abstract class AUnloggedRightMenuComponent : AStatusBarComponent
    {
        // fields
        public AUnloggedRightMenuComponent(IWebDriver driver) : base(driver)
        {
            // constructor
        }
    }
}
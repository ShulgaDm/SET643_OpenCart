using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public class ProductsListComponent
    {   // TODO
        private IWebDriver driver;
        private List<ProductComponent> productComponents;
        public ProductsListComponent(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}

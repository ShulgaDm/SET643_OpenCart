using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    class ProductComponent
    {   // TODO
        public IWebElement productLayout;
        public IWebElement Name { get; private set; }
        public IWebElement Price { get; private set; }
        public IWebElement AddToCartButton { get; private set; }
        public IWebElement AddToWishButton { get; private set; }
        public IWebElement AddToCompareButton { get; private set; }
        public ProductComponent(IWebElement productLayout)
        {
            // constructor
        }

    }
}

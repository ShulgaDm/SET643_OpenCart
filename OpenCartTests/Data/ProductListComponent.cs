using System;
using System.Linq;
using OpenQA.Selenium;
using System.Collections.Generic;
using NUnit.Framework;

namespace OpenCartTests.Data
{

    public class ProductListComponent
    {
        private IWebDriver _driver;
        private List<ProductComponent> _productComponents;

        public ProductListComponent(IWebDriver driver)
        {
            _driver = driver;
            initProductsListComponents();
        }

        public List<ProductComponent> ProductComponents => _productComponents;

        private void initProductsListComponents()
        {
            _productComponents = new List<ProductComponent>();
            foreach (var item in _driver.FindElements(By.CssSelector(".product-layout")))
                _productComponents.Add(new ProductComponent(item));
        }

        public IEnumerable<string> GetProductsNameList()
            => _productComponents.Select(x => x.GetNameText()); 

    }
}
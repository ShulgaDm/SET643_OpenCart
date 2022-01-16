using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public class ProductsListComponent
    { 
        private IWebDriver _driver;
        private List<ProductComponent> _productComponents;

        public ProductsListComponent(IWebDriver driver)
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

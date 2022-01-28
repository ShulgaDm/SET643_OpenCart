using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Pages
{
    public class ShoppingCartPage : AHeadComponent
    {
        public IWebElement InputFieldForFirstProduct { get; private set; }
        public IWebElement TotalPrice { get; private set; }
        public IWebElement DeleteProductButton { get; private set; }

        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
            TotalPrice = driver.FindElement(By.XPath("//strong[text()='Total:']/../following-sibling::td"));
            DeleteProductButton = driver.FindElement(By.CssSelector(".fa.fa-times-circle"));
            InputFieldForFirstProduct = driver.FindElement(By.XPath("//input[@class='form-control' and @size='1' and @type='text']"));
        }

        public string GetInputFieldForFirstProductText() => InputFieldForFirstProduct.GetAttribute("value");
        public void ClickInputFieldForFirstProduct() => InputFieldForFirstProduct.Click();
        public void SetInputFieldForFirstProduct(string value) => InputFieldForFirstProduct.SendKeys(value);
        public string GetTotalPriceText() => TotalPrice.Text;
        public void ClickDeleteProductButton() => DeleteProductButton.Click();


        public HomePage DeleteProduct()
        {
            ClickDeleteProductButton();
            return new HomePage(driver);
        }


        public HomePage EnterInputFieldForFirstProduct(string value)
        {
            ClickInputFieldForFirstProduct();
            InputFieldForFirstProduct.Clear();
            SetInputFieldForFirstProduct(value);
            InputFieldForFirstProduct.SendKeys(Keys.Enter);
            return new HomePage(driver);
        }

    }
}

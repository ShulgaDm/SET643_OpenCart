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
            TotalPrice = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/table/tbody/tr[4]/td[2]"));
            //DeleteProductButton = driver.FindElement(By.CssSelector(".fa fa-times-circle"));
            DeleteProductButton = driver.FindElement(By.XPath("//*[@id='content']/form/div/table/tbody/tr/td[4]/div/span/button[2]"));
            InputFieldForFirstProduct = driver.FindElement(By.XPath("//*[@id='content']/form/div/table/tbody/tr/td[4]/div/input"));

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

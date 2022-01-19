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
        //public IWebElement EmptyShoppingCartContent { get; private set; }
        public IWebElement InputFieldForFirstProduct { get; private set; }
        public IWebElement TotalPrice { get; private set; }
        public IWebElement DeleteProductButton { get; private set; }
        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
            //EmptyShoppingCartContent = driver.FindElement(By.XPath("//*[@id='content']/p"));
            TotalPrice = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div/table/tbody/tr[4]/td[2]"));
            //DeleteProductButton = driver.FindElement(By.CssSelector(".fa fa-times-circle"));
            DeleteProductButton = driver.FindElement(By.XPath("//*[@id='content']/form/div/table/tbody/tr/td[4]/div/span/button[2]"));
            //ProductList = driver.FindElements(By.XPath("/html/body/div[2]/div/div/form/div/table/tbody"));
            InputFieldForFirstProduct = driver.FindElement(By.XPath("//*[@id='content']/form/div/table/tbody/tr/td[4]/div/input"));

        }
        //public string GetEmptyShoppingCartText() => EmptyShoppingCartContent.Text;
        public string GetInputFieldForFirstProductText() => InputFieldForFirstProduct.GetAttribute("value");
            //getAttribute("value");
        public void ClickInputFieldForFirstProduct() => InputFieldForFirstProduct.Click();
        public void SetInputFieldForFirstProduct(string value) => InputFieldForFirstProduct.SendKeys(value);
        public string GetTotalPriceText() => TotalPrice.Text;
        public void ClickDeleteProductButton() => DeleteProductButton.Click();
        public HomePage DeleteProduct()
        {

            ClickDeleteProductButton();
            //if(driver.FindElements(By.XPath("//*[@id='content']/form/div/table/tbody/tr/td[4]/div/span/button[2]")).Count() == 0)
            //{
            //    System.Console.WriteLine("empty shop");
            //    return new EmptyShoppingCartPage(driver);
            //}
            //System.Console.WriteLine("shop");
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

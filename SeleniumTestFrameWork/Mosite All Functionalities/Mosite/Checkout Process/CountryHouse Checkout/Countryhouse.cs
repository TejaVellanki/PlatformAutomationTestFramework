using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium;
//using System.Drawing;

namespace MoBankUI
{
    internal class Countryhouse
    {
        public void checkoutprocess(IWebDriver driver, ISelenium selenium)
        {
            //country house checkout process
            driver.FindElement(By.Id("Pagecontent_TextBoxUserName")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextBoxUserName")).SendKeys("mopoweredtest@mobankgroup.com");
            driver.FindElement(By.Id("Pagecontent_TextBoxPassword")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextBoxPassword")).SendKeys("M0Test08");
            driver.FindElement(By.Id("Pagecontent_ButtonLogin")).Click();
            selenium.WaitForPageToLoad("30000");
            driver.FindElement(By.XPath("//span[@id='Pagecontent_RadioButtonListDeliveryMethods']/div/label/span"))
                  .Click();
            selenium.WaitForPageToLoad("30000");
            driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[2]/input")).Clear();
            driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[2]/input")).SendKeys("test");
            driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[3]/input")).Clear();
            driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[3]/input")).SendKeys("99999");
            new SelectElement(
                driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[4]/fieldset/div[2]/div/div/select")))
                .SelectByText("12 - Dec");
            new SelectElement(
                driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[4]/fieldset/div[2]/div[2]/div/select")))
                .SelectByText("22");
            driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[5]/input")).Clear();
            driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[5]/input")).SendKeys("123");
            new SelectElement(
                driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[6]/fieldset/div[2]/div/div/select")))
                .SelectByText("12 - Dec");
            driver.FindElement(By.XPath("//select[@id='Pagecontent_ddlStartMonth']/option[13]")).Click();
            new SelectElement(
                driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[6]/fieldset/div[2]/div[2]/div/select")))
                .SelectByText("4");
            driver.FindElement(By.Id("Pagecontent_ButtonCheckoutStep3")).Click();
            driver.FindElement(By.Id("Pagecontent_ButtonConfirmCheckout")).Click();
        }
    }
}
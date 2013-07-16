using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium;
using OpenQA.Selenium;

namespace MoBankUI
{
    class GlobalSetting
    {
        public void globalsetting(IWebDriver driver, ISelenium selenium)
        {
            driver.Navigate().GoToUrl("https://qaadmin.mobankdev.com/");
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30000));
            driver.FindElement(By.LinkText("MoShop")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30000));
            driver.FindElement(By.CssSelector("#IndexMenuLeaf6 > a")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30000));
            driver.FindElement(By.Id("ExternalLinkConfigs_5__Name")).Clear();
            driver.FindElement(By.Id("ExternalLinkConfigs_5__Name")).SendKeys("pinterest");
            driver.FindElement(By.CssSelector("input.button")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30000));
            driver.FindElement(By.XPath("(//a[contains(text(),'…')])[6]")).Click();
            driver.FindElement(By.Id("UrlFormat")).Clear();
            driver.FindElement(By.Id("UrlFormat")).SendKeys("http://facebook.com/{0}");
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30000));
            driver.FindElement(By.CssSelector("input.button")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30000));
            driver.FindElement(By.Id("Image")).Clear();
            driver.FindElement(By.Id("Image")).SendKeys("C:\\Users\\teja\\Desktop\\fb.png");
            driver.FindElement(By.CssSelector("input.button")).Click();
        }
    }
}

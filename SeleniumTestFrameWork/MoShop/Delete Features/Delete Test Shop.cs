using System;
using OpenQA.Selenium;
    
namespace MoBankUI
{
    class DeleteTestShop
    {
        public void Deleteshop(IWebDriver driver)
        {
            driver.FindElement(By.LinkText("MoShop")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30000));
            driver.FindElement(By.CssSelector("#IndexMenuLeaf3 > a")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30000));
            driver.FindElement(By.LinkText("testshop")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30000));
            driver.FindElement(By.LinkText("Delete")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30000));
            driver.FindElement(By.CssSelector("p.submit.submitInline > input.button")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30000));

        }
        public void Deletedscrape(IWebDriver driver)
        {
            driver.FindElement(By.LinkText("MoShop")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30000));
            driver.FindElement(By.CssSelector("#IndexMenuLeaf2 > a")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30000));
            driver.FindElement(By.LinkText("2")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30000));
            driver.FindElement(By.LinkText("TestShop-Scrape")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30000));
            driver.FindElement(By.LinkText("Delete")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30000));
            driver.FindElement(By.CssSelector("p.submit.submitInline > input.button")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30000));
        }
    }
}

using OpenQA.Selenium;

namespace MoBankUI
{
    internal class CategoryImages
    {
        public void images(IWebDriver driver, datarow datarow)
        {
            driver.FindElement(By.LinkText("Shop")).Click();
            driver.FindElement(By.LinkText("…")).Click();
            driver.FindElement(By.LinkText("Home (0)")).Click();
            driver.FindElement(By.Id("Image"))
                  .SendKeys(
                      @"C:\Users\teja\Documents\GitHub\PlatformAutomationTestFramework\SeleniumTestFrameWork\ObjectRepository\Homepage and CategoryImages\wolford_home.jpeg");
            driver.FindElement(By.CssSelector("input.button")).Click();
            driver.FindElement(By.Id("ImageAnchorUrl")).SendKeys("http://qamodrophenia.mobankdev.com/");
            driver.FindElement(By.CssSelector("input.button")).Click();
            string imageanchrolurl1 = driver.FindElement(By.Id("ImageAnchorUrl")).GetAttribute("Value");
            driver.Navigate().Back();
            driver.FindElement(By.LinkText("Gift Wrap (0)")).Click();
            driver.FindElement(By.Id("Image"))
                  .SendKeys(
                      @"C:\Users\teja\Documents\GitHub\PlatformAutomationTestFramework\SeleniumTestFrameWork\ObjectRepository\Homepage and CategoryImages\Teja Home Image.jpg");
            driver.FindElement(By.CssSelector("input.button")).Click();
            driver.FindElement(By.Id("ImageAnchorUrl")).SendKeys("http://qamodrophenia.mobankdev.com/");
            driver.FindElement(By.CssSelector("input.button")).Click();
            string imageanchorurl2 = driver.FindElement(By.Id("ImageAnchorUrl")).GetAttribute("Value");
            driver.Navigate().Back();
            driver.FindElement(By.LinkText("Greeting Cards (0)")).Click();
            driver.FindElement(By.Id("Image"))
                  .SendKeys(
                      @"C:\Users\teja\Documents\GitHub\PlatformAutomationTestFramework\SeleniumTestFrameWork\ObjectRepository\Homepage and CategoryImages\dw_new_in_15_10_13.jpg");
            driver.FindElement(By.CssSelector("input.button")).Click();
            driver.FindElement(By.Id("ImageAnchorUrl")).SendKeys("http://qamodrophenia.mobankdev.com/");
            driver.FindElement(By.CssSelector("input.button")).Click();
            string imageanchorurl3 = driver.FindElement(By.Id("ImageAnchorUrl")).GetAttribute("Value");

            #region Validations

            #endregion
        }
    }
}
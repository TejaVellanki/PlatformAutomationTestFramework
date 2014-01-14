using System;
using OpenQA.Selenium;

namespace MoBankUI.Mosite.Product
{
    public class SocialMediaSharing
    {
        public void Socialmediashare(IWebDriver driver, Datarow datarow)
        {
            driver.FindElement(By.XPath("//div[@id='social-media-sharing']/a[1]/img")).Click();
            driver.FindElement(By.XPath("//div[@id='social-media-sharing']/a[2]/img")).Click();
            driver.FindElement(By.XPath("//div[@id='social-media-sharing']/a[3]/img")).Click();
            var str = driver.WindowHandles.GetEnumerator();
            var parentwindow = driver.CurrentWindowHandle;
            while (str.MoveNext())
            {
                var window = Convert.ToString(str.Current);
                driver.SwitchTo().Window(window);
                var url = driver.Url;
                datarow.Newrow("Social Share URL", "", url, "PASS");
            }
            driver.SwitchTo().Window(parentwindow);
        }
    }
}
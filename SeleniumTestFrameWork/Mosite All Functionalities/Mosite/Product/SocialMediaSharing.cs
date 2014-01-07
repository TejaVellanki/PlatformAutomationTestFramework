using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace MoBankUI
{
    public class SocialMediaSharing
    {
        public void Socialmediashare(IWebDriver driver, Datarow datarow)
        {
            driver.FindElement(By.XPath("//div[@id='social-media-sharing']/a[1]/img")).Click();
            driver.FindElement(By.XPath("//div[@id='social-media-sharing']/a[2]/img")).Click();
            driver.FindElement(By.XPath("//div[@id='social-media-sharing']/a[3]/img")).Click();
            IEnumerator<string> str = driver.WindowHandles.GetEnumerator();
            string parentwindow = driver.CurrentWindowHandle;
            while (str.MoveNext())
            {
                string window = Convert.ToString(str.Current);
                driver.SwitchTo().Window(window);
                string url = driver.Url;
                datarow.newrow("Social Share URL", "", url, "PASS");
            }
            driver.SwitchTo().Window(parentwindow);
        }
    }
}
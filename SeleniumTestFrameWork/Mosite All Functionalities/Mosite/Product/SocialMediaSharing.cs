using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace MoBankUI
{
    public class SocialMediaSharing
    {
        public void socialmediashare(IWebDriver driver,datarow datarow)
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
                 string url= driver.Url;
                 datarow.newrow("Social Share URL","",url,"PASS");
            }
            driver.SwitchTo().Window(parentwindow);
        

        }
    }

}

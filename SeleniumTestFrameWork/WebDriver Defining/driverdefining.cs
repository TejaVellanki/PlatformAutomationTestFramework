﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MoBankUI
{
    public class Driverdefining
    {
        public void Waitforpagetoload(IWebDriver driver, int time)
        {
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(time));
        }


        public bool IsElementPresent(IWebDriver driver, By by, int timeoutSeconds = 05)
        {
            for (var second = 0; second < timeoutSeconds;)
            {
                try
                {
                    driver.FindElement(by);
                }
                catch (NoSuchElementException)
                {
                    break;
                }
                return true;
            }

            return false;
        }

        public string GetValue(IWebDriver driver, By by, int timeoutSeconds = 10)
        {
            try
            {
                var value = driver.FindElement(by).GetAttribute("Value");
                return value;
            }
            catch (NoSuchElementException e)
            {
                var ex = e.ToString();
                return ex;
            }
        }

        public string Option(IWebDriver driver, By by, int timeoutseconds = 10)
        {
            var data = driver.FindElement(by);
            //IList<IWebElement> dataoptions = data.FindElements(By.TagName("option"));
            new SelectElement(data);
            var option = driver.FindElement(By.TagName("option")).GetAttribute("Value");
            var optio = driver.FindElement(By.TagName("option")).Text;
            return option;
        }

        public decimal GetXpathCount(IWebDriver driver, string xpath)
        {
            return driver.FindElements(By.XPath(xpath)).Count;
        }

        public void Selectanoption(IWebDriver driver, By by, string optiontoselect)
        {
            var data = driver.FindElement(@by);
            //IList<IWebElement> dataoptions = data.FindElements(By.TagName("option"));
            var select = new SelectElement(data);
            @select.SelectByText(optiontoselect);
        }
    }
}
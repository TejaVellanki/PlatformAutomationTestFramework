using System;
using System.Threading;
using MoBankUI;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebDriver_Refining
{
    public class driverdefining
    {
      
       public void waitforpagetoload(IWebDriver driver, int time)
        {
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(time));
        }


       public bool IsElementPresent(IWebDriver driver, By by,int timeoutSeconds=05)
        {
        for (int second = 0; second< timeoutSeconds ; second++)
        {
            try
            {
                 driver.FindElement(by);
            }
            catch (NoSuchElementException e)
            {
                break;
            }
            return true;
        }

        return false;

    }

        public string GetValue(IWebDriver driver,By by, int timeoutSeconds = 10)
        {
            try
            {
                string value = driver.FindElement(by).GetAttribute("Value");
                return value;
            }
            catch (NoSuchElementException e)
            {
                string ex = e.ToString();
                return ex;
            }
        }

        public string Option(IWebDriver driver, By by, int timeoutseconds = 10)
        {
            IWebElement data = driver.FindElement(by);
            //IList<IWebElement> dataoptions = data.FindElements(By.TagName("option"));
            SelectElement select = new SelectElement(data);
            string option=  driver.FindElement(By.TagName("option")).GetAttribute("Value");
            string optio = driver.FindElement(By.TagName("option")).Text;
            return option;
        }

        public decimal GetXpathCount(IWebDriver driver,string xpath)
        {
           return driver.FindElements(By.XPath(xpath)).Count;
        }

        public void Selectanoption(IWebDriver driver, By by, string optiontoselect)
        {
            try
            {
                 IWebElement data = driver.FindElement(by);
                 //IList<IWebElement> dataoptions = data.FindElements(By.TagName("option"));
                 SelectElement select = new SelectElement(data);
                 select.SelectByText(optiontoselect);                            
                             
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                throw;
            }

        }
    }
}

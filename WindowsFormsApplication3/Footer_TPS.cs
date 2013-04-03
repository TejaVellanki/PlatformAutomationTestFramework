// Generated by .NET Reflector from C:\Program Files\Default Company Name\Selenium Test Tool\MoBankUI.exe
namespace MoBankUI
{
    using OpenQA.Selenium;
    using Selenium;
    using System;
    
    internal class Footer_TPS
    {
        private MoBankUI.Screenshot screenshot = new MoBankUI.Screenshot();
        
        public void Footer(IWebDriver driver, ISelenium selenium, datarow_TPS datarow)
        {
            string str2;
            try
            {
                int num2;
                string str3;
                try
                {
                    decimal xpathCount = selenium.GetXpathCount("//html/body/div/div[3]/ul/li");
                    for (num2 = 1; num2 <= xpathCount; num2++)
                    {
                        driver.FindElement(By.XPath("//html/body/div/div[3]/ul/li[" + num2 + "]/div/div/a")).Click();
                        selenium.WaitForPageToLoad("30000");
                        string actual = driver.Title.ToString();
                        datarow.newrowTPS("Footer Title", "", actual, "PASS", driver, selenium);
                        driver.Navigate().Back();
                        selenium.WaitForPageToLoad("30000");
                    }
                }
                catch (Exception exception1)
                {
                    str2 = exception1.ToString();
                    datarow.newrowTPS("Exception", "Exception Not Expected", str2, "FAIL", driver, selenium);
                    this.screenshot.screenshotfailed(driver, selenium);
                }
                try
                {
                    decimal num3 = selenium.GetXpathCount("//html/body/div/div[3]/div/a");
                    for (num2 = 1; num2 <= num3; num2++)
                    {
                        driver.FindElement(By.XPath("//html/body/div/div[3]/div/a[" + num2 + "]/img")).Click();
                        selenium.WaitForPageToLoad("30000");
                        str3 = driver.Title.ToString();
                        datarow.newrowTPS("Footer Image Title", "", str3, "PASS", driver, selenium);
                        driver.Navigate().Back();
                        selenium.WaitForPageToLoad("30000");
                    }
                }
                catch (Exception exception2)
                {
                    str2 = exception2.ToString();
                    datarow.newrowTPS("Exception", "Exception Not Expected", str2, "FAIL", driver, selenium);
                    this.screenshot.screenshotfailed(driver, selenium);
                }
                try
                {
                    if (selenium.IsElementPresent("//html/body/div/div[3]/p/a"))
                    {
                        driver.FindElement(By.XPath("//html/body/div/div[3]/p/a")).Click();
                        selenium.WaitForPageToLoad("30000");
                        str3 = driver.Title.ToString();
                        datarow.newrowTPS("Footer Title", "", str3, "PASS", driver, selenium);
                        driver.Navigate().Back();
                        selenium.WaitForPageToLoad("30000");
                    }
                    else
                    {
                        datarow.newrowTPS("Fotter Element", "", "Footer Element Not Present//html/body/div/div[3]/p/a", "FAIL", driver, selenium);
                        this.screenshot.screenshotfailed(driver, selenium);
                    }
                }
                catch (Exception exception3)
                {
                    str2 = exception3.ToString();
                    datarow.newrowTPS("Exception", "Exception Not Expected", str2, "FAIL", driver, selenium);
                    this.screenshot.screenshotfailed(driver, selenium);
                }
                try
                {
                    decimal num4 = selenium.GetXpathCount("//html/body/div/div[3]/p[2]/a");
                    for (num2 = 1; num2 <= num4; num2++)
                    {
                        driver.FindElement(By.XPath("//html/body/div/div[3]/p[2]/a[" + num2 + "]")).Click();
                        selenium.WaitForPageToLoad("30000");
                        str3 = driver.Title.ToString();
                        datarow.newrowTPS("Lower Footer Title", "", str3, "PASS", driver, selenium);
                        driver.Navigate().Back();
                        selenium.WaitForPageToLoad("30000");
                    }
                }
                catch (Exception exception4)
                {
                    str2 = exception4.ToString();
                    datarow.newrowTPS("Exception", "Exception Not Expected", str2, "FAIL", driver, selenium);
                    this.screenshot.screenshotfailed(driver, selenium);
                }
            }
            catch (Exception exception5)
            {
                str2 = exception5.ToString();
                datarow.newrowTPS("Exception", "", "Exception Not Expected", "FAIL", driver, selenium);
                this.screenshot.screenshotfailed(driver, selenium);
            }
        }
        
        public void Footerhome(IWebDriver driver, ISelenium selenium, string url, datarow_TPS datarow)
        {
            try
            {
                driver.Navigate().GoToUrl(url);
                selenium.WaitForPageToLoad("30000");
                this.Footer(driver, selenium, datarow);
                new Imagevalidation().homepageimage(driver, selenium, datarow);
            }
            catch (Exception exception)
            {
                string actual = exception.ToString();
                datarow.newrowTPS("Exception", "Exception Not Expected", actual, "FAIL", driver, selenium);
                this.screenshot.screenshotfailed(driver, selenium);
            }
        }
    }
}

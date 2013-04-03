// Generated by .NET Reflector from C:\Program Files\Default Company Name\Selenium Test Tool\MoBankUI.exe
namespace MoBankUI
{
    using OpenQA.Selenium;
    using Selenium;
    using System;
    using System.Threading;
    
    public class mopayconsoleacctab
    {
        private MoBankUI.Screenshot screenshot = new MoBankUI.Screenshot();
        
        public void acctabs(IWebDriver driver, ISelenium selenium, datarow datarow)
        {
            driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management");
            try
            {
                string str;
                driver.FindElement(By.CssSelector("#IndexMenu > ul > li.selected > ul > li > a")).Click();
                selenium.WaitForPageToLoad("30000");
                if (selenium.IsTextPresent("Test Client Account"))
                {
                    driver.FindElement(By.LinkText("Test Client Account")).Click();
                    datarow.newrow("Test Client Tab", "Test Client Tab", "Test Client Account", "PASS", driver, selenium);
                }
                if (selenium.IsTextPresent("Test Client Account"))
                {
                    driver.FindElement(By.LinkText("Test Client Account")).Click();
                    datarow.newrow("Test Client Tab", "Test Client Tab", "Test Client Account", "PASS", driver, selenium);
                }
                else
                {
                    str = "Test Client Account TabNot Present";
                    datarow.newrow("Test Client Account Link", str, "Test Client Account Link", "FAIL", driver, selenium);
                    this.screenshot.screenshotfailed(driver, selenium);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }
                string actual = driver.Title.ToString();
                if (actual == "Details : mopowered.co.uk")
                {
                    datarow.newrow("Details Tab", "Details : mopowered.co.uk", actual, "PASS", driver, selenium);
                }
                else
                {
                    datarow.newrow("Details Tab", "Details : mopowered.co.uk", actual, "FAIL", driver, selenium);
                    this.screenshot.screenshotfailed(driver, selenium);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }
                if (selenium.IsTextPresent("Payment Provider"))
                {
                    driver.FindElement(By.LinkText("Payment Provider")).Click();
                    datarow.newrow("Payment Provider Tab", "Payment Provider Tab", "Payment Provider", "PASS", driver, selenium);
                }
                else
                {
                    str = "Payment Provider TabNot Present";
                    datarow.newrow("Payment Provider Link", str, "Payment Provider Link", "FAIL", driver, selenium);
                    this.screenshot.screenshotfailed(driver, selenium);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }
                selenium.WaitForPageToLoad("30000");
                string str3 = driver.Title.ToString();
                if (str3 == "Payment Provider : mopowered.co.uk")
                {
                    datarow.newrow("Payment Provider Tab", "Payment Provider : mopowered.co.uk", str3, "PASS", driver, selenium);
                    new Paymentprovider().provider(driver, selenium, datarow);
                }
                else
                {
                    datarow.newrow("Payment Provider Tab", "Payment Provider : mopowered.co.uk", str3, "FAIL", driver, selenium);
                    this.screenshot.screenshotfailed(driver, selenium);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }
                if (selenium.IsTextPresent("Notifications"))
                {
                    driver.FindElement(By.LinkText("Notifications")).Click();
                    datarow.newrow("Notifications Tab", "Notifications Tab", "Notifications", "PASS", driver, selenium);
                    new Notificationtab().Notifications(driver, selenium, datarow);
                }
                else
                {
                    datarow.newrow("Notifications Link", "Notifications TabNot Present", "Notifications Link", "FAIL", driver, selenium);
                    this.screenshot.screenshotfailed(driver, selenium);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }
                selenium.WaitForPageToLoad("30000");
                string str4 = driver.Title.ToString();
                if (str4 == "Notifications : mopowered.co.uk")
                {
                    datarow.newrow("Notifications Tab", "Notifications : mopowered.co.uk", str4, "PASS", driver, selenium);
                }
                else
                {
                    datarow.newrow("Notifications Tab", "Notifications : mopowered.co.uk", str4, "FAIL", driver, selenium);
                    this.screenshot.screenshotfailed(driver, selenium);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }
                Thread.Sleep(0x1388);
                if (selenium.IsTextPresent("Transactions"))
                {
                    driver.FindElement(By.LinkText("Transactions")).Click();
                    datarow.newrow("Transactions Tab", "Transactions Tab", "Transactions", "PASS", driver, selenium);
                }
                else
                {
                    str = "Transactions TabNot Present";
                    datarow.newrow("Transactions Link", str, "Transactions Link", "FAIL", driver, selenium);
                    this.screenshot.screenshotfailed(driver, selenium);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }
                selenium.WaitForPageToLoad("30000");
                string str5 = driver.Title.ToString();
                if (str5 == "Transactions : mopowered.co.uk")
                {
                    datarow.newrow("Transactions Tab", "Transactions : mopowered.co.uk", str5, "PASS", driver, selenium);
                }
                else
                {
                    datarow.newrow("Transactions Tab", "Transactions : mopowered.co.uk", str5, "FAIL", driver, selenium);
                    this.screenshot.screenshotfailed(driver, selenium);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }
                if (selenium.IsTextPresent("History"))
                {
                    driver.FindElement(By.LinkText("History")).Click();
                    datarow.newrow("History Tab", "History Tab", "History", "PASS", driver, selenium);
                }
                else
                {
                    str = "History TabNot Present";
                    datarow.newrow("History Link", str, "History Link", "FAIL", driver, selenium);
                    this.screenshot.screenshotfailed(driver, selenium);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }
                selenium.WaitForPageToLoad("30000");
                string str6 = driver.Title.ToString();
                if (str6 == "History : mopowered.co.uk")
                {
                    datarow.newrow("History Tab", "History : mopowered.co.uk", str6, "PASS", driver, selenium);
                }
                else
                {
                    datarow.newrow("History Tab", "History : mopowered.co.uk", str6, "FAIL", driver, selenium);
                    this.screenshot.screenshotfailed(driver, selenium);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10.0));
                IWebElement element = driver.FindElement(By.LinkText("Payment Provider"));
                driver.FindElement(By.LinkText("Payment Provider")).Click();
                selenium.WaitForPageToLoad("30000");
                string str7 = driver.Title.ToString();
                if (str7 == "Payment Provider : mopowered.co.uk")
                {
                    datarow.newrow("Payment Provider Tab", "Payment Provider : mopowered.co.uk", str7, "PASS", driver, selenium);
                }
                else
                {
                    datarow.newrow("Payment Provider Tab", "Payment Provider : mopowered.co.uk", str7, "FAIL", driver, selenium);
                    this.screenshot.screenshotfailed(driver, selenium);
                }
                if (selenium.IsTextPresent("…"))
                {
                    driver.FindElement(By.LinkText("…")).Click();
                    selenium.WaitForPageToLoad("30000");
                    datarow.newrow("Update Tab", "Update Tab", "Update", "PASS", driver, selenium);
                }
                else
                {
                    str = "Update TabNot Present";
                    datarow.newrow("Update Link", str, "Update Link", "FAIL", driver, selenium);
                    this.screenshot.screenshotfailed(driver, selenium);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }
                string str8 = driver.Title.ToString();
                if (str8 == "Update : mopowered.co.uk")
                {
                    datarow.newrow("Update Tab", "Update : mopowered.co.uk", str8, "PASS", driver, selenium);
                }
                else
                {
                    datarow.newrow("Update Tab", "Update : mopowered.co.uk", str8, "FAIL", driver, selenium);
                    this.screenshot.screenshotfailed(driver, selenium);
                }
                selenium.WaitForPageToLoad("30000");
                string str9 = driver.Title.ToString();
                if (str9 == "Update : mopowered.co.uk")
                {
                    datarow.newrow("Update Tab", "Update : mopowered.co.uk", str9, "PASS", driver, selenium);
                }
                else
                {
                    datarow.newrow("Update Tab", "Update : mopowered.co.uk", str9, "FAIL", driver, selenium);
                    this.screenshot.screenshotfailed(driver, selenium);
                }
                driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management");
                selenium.WaitForPageToLoad("30000");
                if (selenium.IsTextPresent("Users"))
                {
                    driver.FindElement(By.LinkText("Users")).Click();
                    datarow.newrow("Users Tab", "Users Tab", "Users", "PASS", driver, selenium);
                }
                else
                {
                    str = "Users TabNot Present";
                    datarow.newrow("Users Link", str, "Users Link", "FAIL", driver, selenium);
                    this.screenshot.screenshotfailed(driver, selenium);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }
                selenium.WaitForPageToLoad("30000");
                string str10 = driver.Title.ToString();
                if (str10 == "Users : mopowered.co.uk")
                {
                    datarow.newrow("Users Tab", "Users : mopowered.co.uk", str10, "PASS", driver, selenium);
                }
                else
                {
                    datarow.newrow("Users Tab", "Users : mopowered.co.uk", str10, "FAIL", driver, selenium);
                    this.screenshot.screenshotfailed(driver, selenium);
                    driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management/Accounts/Update/1");
                }
            }
            catch (Exception exception)
            {
                string str11 = exception.ToString();
                Console.Write(exception);
                datarow.newrow("Exception", "Exception Not Expected", str11, "FAIL", driver, selenium);
            }
            finally
            {
                this.screenshot.screenshotfailed(driver, selenium);
                datarow.excelsave("MopayConsole", driver, selenium);
                driver.Quit();
            }
        }
    }
}

// Generated by .NET Reflector from C:\Program Files\Default Company Name\Selenium Test Tool\MoBankUI.exe
namespace MoBankUI
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Selenium;
    using System;
    
    internal class Guest
    {
        public void guest(IWebDriver driver, ISelenium selenium, datarow_TPS datarow)
        {
            if (selenium.IsElementPresent("id=at-GuestUser"))
            {
                selenium.Click("id=at-GuestUser");
                if (selenium.IsElementPresent("//input[@value='Continue']"))
                {
                    selenium.Click("//input[@value='Continue']");
                    selenium.WaitForPageToLoad("30000");
                }
                try
                {
                    decimal xpathCount = selenium.GetXpathCount("//html/body/div[1]/div[2]/div/form/div");
                    for (int i = 1; i <= xpathCount; i++)
                    {
                        if (selenium.IsElementPresent("//html/body/div[1]/div[2]/div/form/div[" + i + "]/label"))
                        {
                            string actual = driver.FindElement(By.XPath("html/body/div[1]/div[2]/div/form/div[" + i + "]/label")).Text;
                            if (((actual.Contains("*") || (actual != "Country: *")) || (actual.Contains("Country") || actual.Contains("Email"))) || (actual != "Continue"))
                            {
                                try
                                {
                                    driver.FindElement(By.XPath("//html/body/div[1]/div[2]/div/form/div[" + i + "]/input")).SendKeys("TEST");
                                    datarow.newrowTPS("Registration Field Name", "", actual, "PASS", driver, selenium);
                                }
                                catch (Exception exception1)
                                {
                                    Exception exception = exception1;
                                    Console.Write(exception);
                                }
                            }
                            if (actual.Contains("Email"))
                            {
                                driver.FindElement(By.XPath("//html/body/div[1]/div[2]/div/form/div[" + i + "]/input")).SendKeys("test@test.com");
                            }
                            if ((actual == "Country: *") || (actual == "Country"))
                            {
                                string[] selectOptions = selenium.GetSelectOptions("id=Country");
                                string str2 = null;
                                foreach (string str3 in selectOptions)
                                {
                                    str2 = str2 + "\r\n" + str3;
                                    new SelectElement(driver.FindElement(By.Id("Country"))).SelectByText(str3);
                                }
                                datarow.newrowTPS("Registration Field Countries", "", str2, "PASS", driver, selenium);
                            }
                            if (actual == "Continue")
                            {
                                selenium.Click("//html/body/div[1]/div[2]/div/form/div[" + i + "]/div/input");
                                selenium.WaitForPageToLoad("30000");
                            }
                        }
                    }
                }
                catch (Exception exception2)
                {
                    string str4 = exception2.ToString();
                    datarow.newrowTPS("Exception", "Exception Not Expected", str4, "FAIL", driver, selenium);
                }
            }
        }
    }
}

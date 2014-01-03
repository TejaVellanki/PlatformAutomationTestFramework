// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe

using System;
using System.Data;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriver_Refining;

namespace MoBankUI
{
    public class MopayAccount : driverdefining
    {
        private GeneralLibrary _genaralLibrary;
        private Screenshot _screenshot = new Screenshot();

        public void Create(IWebDriver driver)
        {
            var datarow = new datarow();
            _genaralLibrary = new GeneralLibrary();
            DataSet excelData = _genaralLibrary.GetExcelData(@"C:\\Input Data\CardDetails.xls", "AccountCreation");
            datarow.col();
            DataTable table = excelData.Tables[0];
            try
            {
                int count = table.Rows.Count;
                for (int i = 0; i <= count; i++)
                {
                    string expected = table.Rows[i]["AccountName"].ToString();
                    string text = table.Rows[i]["Provider"].ToString();
                    string str3 = table.Rows[i]["ReturnURI"].ToString();
                    string str4 = table.Rows[i]["Allow3DSecure"].ToString();
                    if (driver.Title == "Log On : mopowered.co.uk")
                    {
                        driver.FindElement(
                            By.CssSelector(
                                "html body div#Top.page div#Content div.mainContent div#Main div#LogOnSection.section div.box form#LogOnForm.form div div#EmailControl.control div.input input#Email"))
                              .SendKeys("teja.vellanki@mobankgroup.com");
                        driver.FindElement(
                            By.CssSelector(
                                "html body div#Top.page div#Content div.mainContent div#Main div#LogOnSection.section div.box form#LogOnForm.form div div#PasswordControl.control div.input input#Password"))
                              .SendKeys("Apple12345");
                        driver.FindElement(By.Id("LogOn_Action_LogOn")).Click();
                        
                    }
                    driver.FindElement(By.XPath("//div[@id='IndexMenu']/ul/li/ul/li/a")).Click();
                    
                    driver.FindElement(By.LinkText("Create")).Click();
                    driver.FindElement(By.Id("Name")).Clear();
                    driver.FindElement(By.Id("Name")).SendKeys(expected);
                    driver.FindElement(By.CssSelector("#IndexMenu > ul > li.selected > ul > li > a")).Click();
                    
                    if ( driver.PageSource.Contains("Test Client Account"))
                    {
                        driver.FindElement(By.LinkText("Test Client Account")).Click();
                        datarow.newrow("Test Client Tab", "Test Client Tab", "Test Client Account", "PASS", driver
                                       );
                    }
                    new SelectElement(driver.FindElement(By.Id("Provider_Id"))).SelectByText(text);
                    driver.FindElement(By.CssSelector("input.button")).Click();
                    Thread.Sleep(0x1388);
                    string attribute = driver.FindElement(By.Id("Name")).GetAttribute("Value");
                    string actual = driver.FindElement(By.Id("Provider_Id")).GetAttribute("Value");
                    if (expected == attribute)
                    {
                        datarow.newrow("Account Name", expected, attribute, "PASS",driver);
                    }
                    else
                    {
                        datarow.newrow("Account Name", expected, attribute, "FAIL",driver);
                    }
                    if (text == actual)
                    {
                        datarow.newrow("Provider", text, actual, "PASS",driver);
                    }
                    else
                    {
                        datarow.newrow("Provider", text, actual, "FAIL",driver);
                    }
                    string str8 = driver.Title;
                    if (str8 == "Details : mopowered.co.uk")
                    {
                        datarow.newrow("Details Tab", "Details : mopowered.co.uk", str8, "PASS",driver);
                    }
                    else
                    {
                        datarow.newrow("Details Tab", "Details : mopowered.co.uk", str8, "FAIL",driver);
                    }
                    driver.FindElement(By.Id("PayProviderCheckOutReturnUri")).Clear();
                    driver.FindElement(By.Id("PayProviderCheckOutReturnUri")).SendKeys(str3);
                    driver.FindElement(By.CssSelector("input.button")).Click();
                    Thread.Sleep(0x1388);
                    driver.FindElement(By.LinkText("Payment Provider")).Click();
                    
                    new Paymentprovider().Provider(driver, datarow);
                    new Notificationtab().Notifications(driver, datarow);
                }
            }
            catch (Exception exception)
            {
                string str9 = exception.ToString();
                datarow.newrow("Exception", "Not Expected", str9, "FAIL",driver);
                datarow.excelsave("MoPay Account Creation",driver, "teja.vellanki@mobankgroup.com");
            }
            finally
            {
                datarow.excelsave("MoPay Account Creation",driver, "teja.vellanki@mobankgroup.com");
            }
        }
    }
}
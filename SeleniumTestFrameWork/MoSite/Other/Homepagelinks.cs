// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe

using System;
using System.Data;
using OpenQA.Selenium;
using WebDriver_Refining;

namespace MoBankUI
{
    internal class Homepagelinks : Driverdefining
    {
        public void HompageLinks(Datarow datarow, IWebDriver driver)
        {
            DataSet excelData = new GeneralLibrary().GetExcelData(@"C:\\Input Data\Object Repository.xls",
                                                                  "Modrophenia");
            driver.FindElement(By.CssSelector("img")).Click();

            decimal count = driver.FindElements(By.XPath("//html/body/div/div[2]/div/ul/li")).Count;
            int num2 = 0;
            for (int i = 1; i <= count; i++)
            {
                DataTable table = excelData.Tables[0];
                string actual = table.Rows[num2]["HomePageLinks"].ToString();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10.0));
                IWebElement element =
                    driver.FindElement(By.XPath("//html/body/div/div[2]/div/ul/li[" + i + "]/div/div/a/h2"));
                driver.FindElement(By.XPath("//html/body/div/div[2]/div/ul/li[" + i + "]/div/div/a/h2")).Click();

                string expected = driver.Title;
                if (expected == actual)
                {
                    datarow.newrow("Title", expected, actual, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Title", expected, actual, "FAIL", driver);
                }
                num2++;
                driver.Navigate().Back();
            }
        }
    }
}
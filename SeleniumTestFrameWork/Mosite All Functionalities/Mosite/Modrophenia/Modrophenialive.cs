// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;
using DataTable = System.Data.DataTable;

namespace MoBankUI.Mosite.Modrophenia
{
    internal class Modrophenialive : Driverdefining
    {
        private GeneralLibrary generalLibrary;
        public object xml { get; set; }

        public void loop(IWebDriver driver, DataTable dt)
        {
            var num = 1;
            while (true)
            {
                if (!((num != 1) || IsElementPresent(driver, By.LinkText("\x00bb"))))
                {
                    loop1(driver, dt);
                }
                if (!IsElementPresent(driver, By.LinkText("\x00bb")))
                {
                    return;
                }
                if (num > 1)
                {
                    driver.FindElement(By.LinkText("\x00bb")).Click();

                    Thread.Sleep(0x1388);
                }
                var xpathCount = GetXpathCount(driver, "//div[@id='content']/div/div");
                for (var i = 1; i <= xpathCount - 2; i++)
                {
                    string str3;
                    string str4;
                    switch (i)
                    {
                        case 5:
                        case 10:
                        case 15:
                        case 20:
                        case 0x19:
                            i++;
                            break;
                    }
                    //div[@id='content']/div/div[3]/div/a/img 
                    driver.FindElement(By.XPath("//div[@id='content']/div/div[" + i + "]/div/a/img")).Click();


                    var text = driver.FindElement(By.CssSelector("span.isPrice")).Text;
                    var str2 = driver.FindElement(By.CssSelector("h2.productTitle")).Text;
                    var row = dt.NewRow();
                    row[0] = text;
                    row[1] = str2;
                    if (IsElementPresent(driver, By.XPath("//div[@id='productInfo']/div/p[2]")))
                    {
                        str3 = driver.FindElement(By.XPath("//div[@id='productInfo']/div/p[2]")).Text;
                        str4 = driver.FindElement(By.XPath("//div[@id='productInfo']/div/p/strong")).Text;
                        row[2] = str3;
                        row[3] = str4;
                    }
                    else
                    {
                        str3 = driver.FindElement(By.XPath("//div[@id='productInfo']/div/p")).Text;
                        str4 = "Item Number Not Present";
                        row[2] = str3;
                        row[3] = str4;
                    }
                    var con = driver.FindElement(By.Id("attr_1"));
                    IList<IWebElement> selectOptions = con.FindElements(By.TagName("option"));

                    var str5 = selectOptions.Where(str6 => str6.Text != "Please Select").Aggregate<IWebElement, string>(null, (current, str6) => current + "\r\n" + str6);
                    row[4] = str5;
                    dt.Rows.Add(row);
                    driver.Navigate().Back();
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10.0));
                    driver.FindElement(By.XPath("//div[@id='content']/div/div[" + i + "]/div/a/img"));
                }
                num++;
            }
        }

        public void loop1(IWebDriver driver, DataTable dt)
        {
            var xpathCount = GetXpathCount(driver, "//div[@id='content']/div/div");
            for (var i = 1; i <= (xpathCount - 2M); i++)
            {
                string str3;
                string str4;
                switch (i)
                {
                    case 5:
                    case 10:
                    case 15:
                    case 20:
                    case 0x19:
                        i++;
                        break;
                }
                driver.FindElement(By.XPath("//div[@id='content']/div/div[" + i + "]/div/a/img")).Click();

                var text = driver.FindElement(By.CssSelector("span.isPrice")).Text;
                var str2 = driver.FindElement(By.CssSelector("h2.productTitle")).Text;
                var row = dt.NewRow();
                row[0] = text;
                row[1] = str2;

                if (IsElementPresent(driver, By.XPath("//div[@id='productInfo']/div/p[2]")))
                {
                    str3 = driver.FindElement(By.XPath("//div[@id='productInfo']/div/p[2]")).Text;
                    str4 = driver.FindElement(By.XPath("//div[@id='productInfo']/div/p/strong")).Text;
                    row[2] = str3;
                    row[3] = str4;
                }
                else
                {
                    str3 = driver.FindElement(By.XPath("//div[@id='productInfo']/div/p")).Text;
                    str4 = "Item Number Not Present";
                    row[2] = str3;
                    row[3] = str4;
                }
                var con = driver.FindElement(By.Id("attr_1"));
                IList<IWebElement> selectOptions = con.FindElements(By.TagName("option"));

                var str5 = selectOptions.Where(str6 => str6.Text != "Please Select").Aggregate<IWebElement, string>(null, (current, str6) => current + "\r\n" + str6);
                row[4] = str5;
                dt.Rows.Add(row);
                driver.Navigate().Back();

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10.0));
                driver.FindElement(By.XPath("//div[@id='content']/div/div[" + i + "]/div/a/img"));
            }
        }

        public void modrophenialiveproducts(IWebDriver driver)
        {
            try
            {
                generalLibrary = new GeneralLibrary();
                var dt = new DataTable();
                var fileName = "ModrophenialiveProducts";
                var workbook = generalLibrary.CreateAndOpenExcelFile(@"C:\\Input Data", ref fileName, "Products",
                                                                          ".xlsx", false, false);
                var ws = (Worksheet) workbook.Sheets[1];
                new Datarow();
                dt.Columns.Add("Product Price");
                dt.Columns.Add("Product Title");
                dt.Columns.Add("Product Detail");
                dt.Columns.Add("Item Number");
                dt.Columns.Add("Variants");
                driver.Navigate().GoToUrl("http://www.modrophenia.com/");
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10.0));
                driver.FindElement(By.XPath("//div[@id='sidebarBox']/ul[2]/li[2]/a"));
                driver.FindElement(By.LinkText("New Arrivals")).Click();

                loop(driver, dt);
                driver.FindElement(By.LinkText("Sale Items")).Click();

                loop(driver, dt);
                generalLibrary.ConsolidatedXmlExportToExcel(dt, ws, true, false, false);
                generalLibrary.SaveAndCloseExcel(workbook);
            }
            catch (Exception exception)
            {
                Console.Write(exception);
            }
            finally
            {
                foreach (var process in Process.GetProcessesByName("EXCEL").Where(process => process.MainModule.ModuleName.ToUpper().Equals("EXCEL.EXE")))
                {
                    process.Kill();
                    break;
                }
            }
        }
    }
}
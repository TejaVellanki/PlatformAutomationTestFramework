// Generated by .NET Reflector from C:\Program Files\Default Company Name\Selenium Test Tool\MoBankUI.exe
namespace MoBankUI
{
    using Microsoft.Office.Interop.Excel;
    using OpenQA.Selenium;
    using Selenium;
    using System;
    using System.Data;
    using System.Diagnostics;
    using System.Threading;
    
    internal class Modrophenialive
    {
        private GeneralLibrary generalLibrary;
        
        public void loop(IWebDriver driver, ISelenium selenium, System.Data.DataTable dt)
        {
            int num = 1;
            while (true)
            {
                if (!((num != 1) || selenium.IsElementPresent("link=\x00bb")))
                {
                    this.loop1(driver, selenium, dt);
                }
                if (!selenium.IsElementPresent("link=\x00bb"))
                {
                    return;
                }
                if (num > 1)
                {
                    selenium.Click("link=\x00bb");
                    selenium.WaitForPageToLoad("30000");
                    Thread.Sleep(0x1388);
                }
                decimal xpathCount = selenium.GetXpathCount("//div[@id='content']/div/div");
                for (int i = 1; i <= xpathCount-2; i++)
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
                    selenium.Click("//div[@id='content']/div/div[" + i + "]/div/a/img");
                    selenium.WaitForPageToLoad("30000");
                    string text = selenium.GetText("css=span.isPrice");
                    string str2 = selenium.GetText("css=h2.productTitle");
                    DataRow row = dt.NewRow();
                    row[0] = text;
                    row[1] = str2;
                    if (selenium.IsElementPresent("//div[@id='productInfo']/div/p[2]"))
                    {
                        str3 = selenium.GetText("//div[@id='productInfo']/div/p[2]");
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
                    string[] selectOptions = selenium.GetSelectOptions("id=attr_1");
                    string str5 = null;
                    foreach (string str6 in selectOptions)
                    {
                        if (str6 != "Please Select")
                        {
                            str5 = str5 + "\r\n" + str6;
                        }
                    }
                    row[4] = str5;
                    dt.Rows.Add(row);
                    selenium.GoBack();
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10.0));
                    IWebElement element = driver.FindElement(By.XPath("//div[@id='content']/div/div[" + i + "]/div/a/img"));
                }
                num++;
            }
        }
        
        public void loop1(IWebDriver driver, ISelenium selenium, System.Data.DataTable dt)
        {
            decimal xpathCount = selenium.GetXpathCount("//div[@id='content']/div/div");
            for (int i = 1; i <= (xpathCount - 2M); i++)
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
                selenium.Click("//div[@id='content']/div/div[" + i + "]/div/a/img");
                selenium.WaitForPageToLoad("30000");
                string text = selenium.GetText("css=span.isPrice");
                string str2 = selenium.GetText("css=h2.productTitle");
                DataRow row = dt.NewRow();
                row[0] = text;
                row[1] = str2;
                if (selenium.IsElementPresent("//div[@id='productInfo']/div/p[2]"))
                {
                    str3 = selenium.GetText("//div[@id='productInfo']/div/p[2]");
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
                string[] selectOptions = selenium.GetSelectOptions("id=attr_1");
                string str5 = null;
                foreach (string str6 in selectOptions)
                {
                    if (str6 != "Please Select")
                    {
                        str5 = str5 + "\r\n" + str6;
                    }
                }
                row[4] = str5;
                dt.Rows.Add(row);
                selenium.GoBack();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10.0));
                IWebElement element = driver.FindElement(By.XPath("//div[@id='content']/div/div[" + i + "]/div/a/img"));
            }
        }
        
        public void modrophenialiveproducts(ISelenium selenium, IWebDriver driver)
        {
            try
            {
                this.generalLibrary = new GeneralLibrary();
                System.Data.DataTable dt = new System.Data.DataTable();
                string fileName = "ModrophenialiveProducts";
                Workbook workbook = this.generalLibrary.CreateAndOpenExcelFile(@"C:\Selenium\Input Data", ref fileName, "Products", ".xlsx", false, false);
                Worksheet ws = (Worksheet) workbook.Sheets[1];
                datarow datarow = new datarow();
                dt.Columns.Add("Product Price");
                dt.Columns.Add("Product Title");
                dt.Columns.Add("Product Detail");
                dt.Columns.Add("Item Number");
                dt.Columns.Add("Variants");
                driver.Navigate().GoToUrl("http://www.modrophenia.com/");
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10.0));
                IWebElement element = driver.FindElement(By.XPath("//div[@id='sidebarBox']/ul[2]/li[2]/a"));
                selenium.Click("link=New Arrivals");
                selenium.WaitForPageToLoad("30000");
                this.loop(driver, selenium, dt);
                System.Data.DataTable ddd = dt;
                this.generalLibrary.ConsolidatedXmlExportToExcel(dt, ws, true, false, false);
                this.generalLibrary.SaveAndCloseExcel(workbook);
            }
            catch (Exception exception)
            {
                Console.Write(exception);
            }
            finally
            {
                foreach (Process process in Process.GetProcessesByName("EXCEL"))
                {
                    if (process.MainModule.ModuleName.ToUpper().Equals("EXCEL.EXE"))
                    {
                        process.Kill();
                        break;
                    }
                }
            }
        }
    }
}
using System;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;
using System.Data;
//using System.Drawing;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Selenium;
using System.Data.OleDb;
using System.IO;
using System.Timers;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace MoBankUI
{
    class DeleteBasket_TPS
    {
        Screenshot screenshot = new Screenshot();
        public void basket(IWebDriver driver, ISelenium selenium,datarow datarow)
        {
            try
            {
                if (selenium.IsElementPresent("//ul[@id='Basket']/li/a/span"))
                {
                    driver.FindElement(By.XPath("//ul[@id='Basket']/li/a/span")).Click();
                    selenium.WaitForPageToLoad("30000");

                    string value = driver.FindElement(By.Id("BasketInfo")).Text;

                    if (value == "(0)")
                    {
                        datarow.newrow("Delete Basket Value", "(0)",value, "PASS", driver, selenium);

                    }
                    else
                    {
                        datarow.newrow("Delete Basket Value", "(0)", value,"FAIL", driver, selenium);
                        screenshot.screenshotfailed(driver, selenium);

                    }
                    selenium.Click("//*[@id='UpdateBasketForm']/div/div[2]/a/span/span");
                    selenium.WaitForPageToLoad("30000");

                    selenium.Click("css=img");
                    selenium.WaitForPageToLoad("30000");
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                    IWebElement myDynamicElement1 = driver.FindElement(By.XPath("//html/body/div/div[2]/div/ul/li/div/div/a/h2"));
                    driver.FindElement(By.XPath("//html/body/div/div[2]/div/ul/li/div/div/a/h2")).Click();
                    selenium.WaitForPageToLoad("30000");
                    string title = driver.Title.ToString();

                    decimal categorycount = selenium.GetXpathCount("//html/body/div/div[2]/div/ul/li");
                    for (int i = 1; ; i++)
                    {
                        if (selenium.IsElementPresent("//html/body/div/div[2]/div/ul/li/div/div/a/h2"))
                        {
                            driver.FindElement(By.XPath("//html/body/div/div[2]/div/ul/li/div/div/a/h2")).Click();
                            selenium.WaitForPageToLoad("30000");
                            string titlecategory = driver.Title.ToString();
                            string url1 = selenium.GetLocation();

                            if (url1.Contains("category"))
                            {
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    products_TPS prd = new products_TPS();
                    prd.product(driver, selenium, datarow);
                }
                else
                {
                    datarow.newrow("Delete From Basket", "Delete Basket Element Expected", "//ul[@id='Basket']/li/a/span" + "Element Not Present", "FAIL", driver, selenium);
                    screenshot.screenshotfailed(driver, selenium);
                }
            }

            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", driver, selenium);
                screenshot.screenshotfailed(driver, selenium);
            }
        
        }
    }
}

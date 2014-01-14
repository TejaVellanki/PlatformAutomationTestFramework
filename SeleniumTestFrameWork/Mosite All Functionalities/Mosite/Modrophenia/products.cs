// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MoBankUI.Mosite.Modrophenia
{
    internal class Modropheniaproducts : Driverdefining
    {
        private GeneralLibrary _gereneralLibrary;

        public void Comparedatarow(IWebDriver driver, Datarow datarow, DataTable dt)
        {
            _gereneralLibrary = new GeneralLibrary();
            var table =
                _gereneralLibrary.GetExcelData(@"C:\\Input Data\ModrophenialiveProducts.xlsx", "Products").Tables
                    [0];
            for (var i = 1; i < (table.Rows.Count - 1); i++)
            {
                var actual = table.Rows[i]["Product Price"].ToString();
                var str2 = table.Rows[i]["Product Title"].ToString();
                var str3 = table.Rows[i]["Product Detail"].ToString();
                var expected = table.Rows[i]["Item Number"].ToString();
                var str5 = table.Rows[i]["Variants"].ToString();
                var str6 = dt.Rows[i]["Price"].ToString();
                var str7 = dt.Rows[i]["Title"].ToString();
                var str8 = dt.Rows[i]["Detail"].ToString();
                var str9 = dt.Rows[i]["Item Number"].ToString();
                var str10 = dt.Rows[i]["Variants"].ToString();
                datarow.Newrow(str7 + " Price", str6, actual, str6 == actual ? "PASS" : "FAIL", driver);
                datarow.Newrow(str7 + " Title", str7, str2, str7.ToUpper() == str2 ? "PASS" : "FAIL", driver);
                datarow.Newrow(str7 + " Detail", str8, str3, str8 == str3 ? "PASS" : "FAIL", driver);
                datarow.Newrow(str7 + " ItemNumber", expected, str9, expected == str9 ? "PASS" : "FAIL", driver);
                datarow.Newrow(str7 + " Variants", str5, str10,
                    str5.TrimStart(new char[0]) == str10.TrimStart(new char[0]) ? "PASS" : "FAIL", driver);
            }
        }

        public void product(Datarow datarow, IWebDriver driver)
        {
            try
            {
                var dt = new DataTable();
                dt.Columns.Add("Price");
                dt.Columns.Add("Title");
                dt.Columns.Add("Detail");
                dt.Columns.Add("Item Number");
                dt.Columns.Add("Variants");


                driver.Navigate().GoToUrl("https://qamodrophenia.mobankdev.com/");

                driver.FindElement(By.XPath("//*[@id='page-home-index']/div[1]/div[2]/div[1]/ul/li[1]/div/div/a/h2"))
                      .Click();


                loop(datarow, driver, dt);
                driver.Navigate().GoToUrl("https://qamodrophenia.mobankdev.com/");

                driver.FindElement(By.XPath("//body[@id='page-home-index']/div/div[2]/div/ul/li[12]/div/div/a/h2"));
                //iver.FindElement(By.Id()).Click()

                loop(datarow, driver, dt);
                Comparedatarow(driver, datarow, dt);
            }
            catch (Exception exception3)
            {
                var str8 = exception3.ToString();
                datarow.Newrow("Exception", "Not Expected", str8, "FAIL", driver);
            }
        }

        public void loop(Datarow datarow, IWebDriver driver, DataTable dt)
        {
            try
            {
                var num = 1;
                var num2 = 0;
                goto Label_0449;
                Label_0099:

                //*[@id="page-categories-details"]/div[1]/div[2]/div[1]/div/div
                //*[@id="page-categories-details"]/div[1]/div[2]/div[1]/div/div/a[3]/span/span[1]
                if ((num > 1) &&
                    IsElementPresent(driver,
                                     By.XPath("//*[@id='page-categories-details']/div[1]/div[2]/div[1]/div/div/a[3]")))
                {
                    var ele =
                        driver.FindElement(
                            By.XPath("//*[@id='page-categories-details']/div[1]/div[2]/div[1]/div/div/a[3]"));
                    var cource = ele.GetAttribute("outerHTML");
                    if (cource.Contains("ui-disabled"))
                    {
                    }
                    else
                    {
                        driver.FindElement(
                            By.XPath("//*[@id='page-categories-details']/div[1]/div[2]/div[1]/div/div/a[3]")).Click();
                    }
                }
                var xpathCount = GetXpathCount(driver,
                                                   "//*[@id='page-categories-details']/div[1]/div[2]/div[1]/ul/li");
                for (var i = 1; i <= xpathCount; i++)
                {
                    //*[@id="page-categories-details"]/div[1]/div[2]/div[1]/ul/li[32]/div/div/a/div[2]/p
                    string text;
                    string str4;
                    string str5;
                    string str7;
                    driver.FindElement(
                        By.XPath("//*[@id='page-categories-details']/div[1]/div[2]/div[1]/ul/li[" + i +
                                 "]/div/div/a/div[2]/p")).Click();

                    var row = dt.NewRow();
                    var j = 1;
                    var str =
                        driver.FindElement(
                            By.XPath("//*[@id='page-products-details']/div[1]/div[2]/div/div[1]/div[1]/div/p/strong"))
                              .Text;
                    var str2 = driver.FindElement(By.XPath("//html/body/div/div/div[2]/h2")).Text;
                    row[0] = str;
                    row[1] = str2;
                    if (IsElementPresent(driver, By.XPath("//div[@id='Description']/div/div/div/div/p[2]")))
                    {
                        text = driver.FindElement(By.XPath("//div[@id='Description']/div/div/div/div/p[2]")).Text;
                        str4 = driver.FindElement(By.Id("//div[@id='Description']/div/div/div/div/p/strong")).Text;
                        row[2] = text;
                        row[3] = str4;
                    }
                    else
                    {
                        text = driver.FindElement(By.XPath("//div[@id='Description']/div/div/div/div/p")).Text;
                        str4 = "Item Number Not Present";
                        row[2] = text;
                        row[3] = str4;
                    }

                    #region Select Options

                    try
                    {
                        if (
                            GetXpathCount(driver,
                                          "//html/body/div/div[2]/div/div[3]/form/ul/li[2]/fieldset/div[2]/div/label/span") !=
                            1)
                        {
                            try
                            {
                                var con = driver.FindElement(By.Id("Variants_0__OptionValue"));
                                IList<IWebElement> selectOptions = con.FindElements(By.TagName("option"));


                                str5 = null;
                                foreach (var str6 in selectOptions.Where(str6 => str6.Text != "Please Select"))
                                {
                                    str5 = str5 + "\r\n" + str6;
                                    new SelectElement(driver.FindElement(By.Id("Variants_0__OptionValue")))
                                        .SelectByText(str6.Text);
                                }
                                row[4] = str5;
                                j++;
                            }
                            catch (Exception ex)
                            {
                                var e = ex.ToString();
                                datarow.Newrow("Exception", "Exception Not Exopected", e, "FAIL");
                            }
                        } //*[@id="AddToBasketForm"]/ul/li[2]/fieldset/div[2]/div[2]/label
                        else
                        {
                            str7 = GetValue(driver, By.Id("Variants_0__OptionValue"));
                            row[4] = str7;
                            j++;
                        }
                    }
                    catch (Exception exception1)
                    {
                        var exception = exception1;
                        exception.ToString();
                        // datarow.newrow("Exception at Product variants", "Exception Not Expected", str8, "FAIL",driver, );
                    }

                    #endregion

                    #region Radio Buttons

                    try
                    {
                        if (j == 1)
                        {
                            str5 = null;

                            var count =
                                GetXpathCount(driver, "//*[@id='AddToBasketForm']/ul/li[2]/fieldset/div[2]/div");

                            for (var num6 = 0; num6 < count; num6++)
                            {
                                str7 = driver.FindElement(By.Id("OptionValue_" + num6)).GetAttribute("Value");
                                if ((str7 == "Please Select") && (str7 == null)) continue;
                                str5 = str5 + "\r\n" + str7;
                                driver.FindElement(By.Id("OptionValue_" + num6)).Click();
                            }


                            row[4] = str5;
                        }
                    }
                    catch (Exception exception2)
                    {
                        exception2.ToString();
                        //  datarow.newrow("Exception at Product Variants", "Exception Not Expected", str8, "FAIL",driver, );
                    }

                    #endregion

                    dt.Rows.Add(row);
                    driver.Navigate().Back();
                    Thread.Sleep(3000);
                }
                num++;
                var elem =
                    driver.FindElement(By.XPath("//*[@id='page-categories-details']/div[1]/div[2]/div[1]/div/div/a[3]"));
                var courc = elem.GetAttribute("outerHTML");
                if (courc.Contains("ui-disabled"))
                {
                    goto Label_0451;
                }
                num2++;

                Label_0449:
                //flag = true;
                goto Label_0099;
                Label_0451:
                ;
            }
            catch (Exception ex)
            {
                var str8 = ex.ToString();
                datarow.Newrow("Exception", "Not Expected", str8, "FAIL", driver);
            }
        }
    }
}
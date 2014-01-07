﻿// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe

using System;
using System.Threading;
using OpenQA.Selenium;
using WebDriver_Refining;

namespace MoBankUI
{
    public class DeliveryTab : Driverdefining
    {
        public void Delivery(IWebDriver driver, Datarow datarow)
        {
            try
            {
                datarow.newrow("", "", "DELIVERY CONFIGURATION", "", driver);
                driver.FindElement(By.LinkText("Checkout Process")).Click();

                driver.FindElement(By.XPath("(//a[contains(text(),'…')])[2]")).Click();


                Selectanoption(driver, By.Id("Method"), "POST");

                driver.FindElement(By.Id("Url")).Clear();
                driver.FindElement(By.Id("Url")).SendKeys("https://www.the-tickle-company.co.uk/cgi-bin/os000001.pl?");

                driver.FindElement(By.Id("Parameters")).Clear();
                driver.FindElement(By.Id("Parameters")).SendKeys(
                    "RANDOM=0.708711438653157&SEQUENCE=1&ActCheckoutPhase=SHIPPING&ShippingClass={{ShippingClass}}&SHIPUSERDEFINED={{SHIPUSERDEFINED}}&ActCheckoutPhase=TANDC&ActCheckoutPhase=GENERAL&GENERALHOWFOUND={{GENERALHOWFOUND}}&GENERALWHYBUY={{GENERALWHYBUY}}&ACTION_NEXT.x=82&ACTION_NEXT.y=7{{AGREETERMSCONDITIONS}}");
                driver.FindElement(By.Id("Sequence")).Clear();
                driver.FindElement(By.Id("Sequence")).SendKeys("20");
                driver.FindElement(By.Id("LiveScrapeForm_HeaderSelector")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_HeaderSelector"))
                      .SendKeys("#idCheckoutForm > .checkout th.instruction:eq(1)");
                driver.FindElement(By.Id("LiveScrapeForm_SuccessSelector")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_SuccessSelector")).SendKeys("#idPAYMENTMETHOD");
                driver.FindElement(By.Id("LiveScrapeForm_ErrorSelector")).Clear();
                driver.FindElement(By.Id("LiveScrapeForm_ErrorSelector")).SendKeys("#errormessage blockquote");
                driver.FindElement(By.CssSelector("input.button")).Click();


                driver.FindElement(By.Id("LiveScrapeForm_Elements_0__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_0__LabelSelector")).SendKeys(".actrequired");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_0__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_0__KeysValuesSelector"))
                      .SendKeys("select[name=\"ShippingClass\"] option");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_0__Name")).Click();
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_0__Type"), "DropList");

                driver.FindElement(By.Id("LiveScrapeForm_Elements_0__Type")).SendKeys(Keys.Enter);


                driver.FindElement(By.Id("LiveScrapeForm_Elements_1__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_1__LabelSelector"))
                      .SendKeys("label[for=\"SHIPUSERDEFINED\"]");


                driver.FindElement(By.Id("LiveScrapeForm_Elements_2__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_2__LabelSelector"))
                      .SendKeys("label[for=\"idGENERALHOWFOUND\"]");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_2__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_2__KeysValuesSelector"))
                      .SendKeys("select[name=\"GENERALHOWFOUND\"] option");


                driver.FindElement(By.Id("LiveScrapeForm_Elements_3__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_3__LabelSelector"))
                      .SendKeys("label[for=\"GENERALWHYBUY\"]");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_3__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_3__KeysValuesSelector"))
                      .SendKeys("select[name=\"GENERALWHYBUY\"] option");

                driver.FindElement(By.Id("LiveScrapeForm_Elements_3__Name")).Click();
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_3__Type"), "DropList");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_3__Type")).SendKeys(Keys.Enter);


                driver.FindElement(By.Id("LiveScrapeForm_Elements_4__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_4__LabelSelector"))
                      .SendKeys("label[for=\"AGREETERMSCONDITIONS\"]");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_4__Name")).Click();
                driver.FindElement(By.Id("LiveScrapeForm_Elements_4__CheckBoxReplacement"))
                      .SendKeys("&AGREETERMSCONDITIONS=NO");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_4__Name")).Click();
                Selectanoption(driver, By.Id("LiveScrapeForm_Elements_4__Type"), "Check");
                driver.FindElement(By.Id("LiveScrapeForm_Elements_4__Name")).Click();
                driver.FindElement(By.XPath("//div[@id='LiveScrapeForm.Elements[4].NameControl']/div")).Click();


                driver.FindElement(By.CssSelector("input.button")).Click();


                driver.FindElement(By.Id("ScrapedDataValueConfigurations_0__Selector")).Clear();
                driver.FindElement(By.Id("ScrapedDataValueConfigurations_0__Selector"))
                      .SendKeys(".checkout-cart strong:eq(3)");
                Selectanoption(driver, By.Id("ScrapedDataValueConfigurations_0__PropertyPath"), "ShippingChargeAmount");
                driver.FindElement(By.Id("ScrapedDataValueConfigurations_0__PropertyPath")).SendKeys(Keys.Enter);

                driver.FindElement(By.CssSelector("input.button")).Click();

                #region Validation

                string text = driver.FindElement(By.Id("DynamicSourceUrl")).Selected.ToString();
                string attribute = driver.FindElement(By.Id("Parameters")).GetAttribute("Value");
                string actual = driver.FindElement(By.Id("Sequence")).GetAttribute("Value");
                string str4 = driver.FindElement(By.Id("LiveScrapeForm_HeaderSelector")).GetAttribute("Value");
                string str5 = driver.FindElement(By.Id("LiveScrapeForm_SuccessSelector")).GetAttribute("Value");
                string str6 = driver.FindElement(By.Id("LiveScrapeForm_ErrorSelector")).GetAttribute("Value");
                string str7 = driver.FindElement(By.Id("LiveScrapeForm_Elements_0__LabelSelector"))
                                    .GetAttribute("Value");
                string str8 =
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_0__KeysValuesSelector")).GetAttribute("Value");
                string str9 = driver.FindElement(By.Id("LiveScrapeForm_Elements_1__LabelSelector"))
                                    .GetAttribute("Value");
                string str10 =
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_2__LabelSelector")).GetAttribute("Value");
                string str11 =
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_3__LabelSelector")).GetAttribute("Value");
                string str12 =
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_2__KeysValuesSelector")).GetAttribute("Value");
                string str13 =
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_4__LabelSelector")).GetAttribute("Value");
                string str14 =
                    driver.FindElement(By.Id("LiveScrapeForm_Elements_4__CheckBoxReplacement")).GetAttribute("Value");
                string str15 =
                    driver.FindElement(By.Id("ScrapedDataValueConfigurations_0__Selector")).GetAttribute("Value");


                if (text == "https://www.the-tickle-company.co.uk/cgi-bin/os000001.pl?")
                {
                    datarow.newrow("Delivery URL", "https://www.the-tickle-company.co.uk/cgi-bin/os000001.pl?", text,
                                   "PASS", driver);
                }
                else
                {
                    datarow.newrow("Delivery URL", "https://www.the-tickle-company.co.uk/cgi-bin/os000001.pl?", text,
                                   "FAIL", driver);
                }
                if (attribute ==
                    "RANDOM=0.708711438653157&SEQUENCE=1&ActCheckoutPhase=SHIPPING&ShippingClass={{ShippingClass}}&SHIPUSERDEFINED={{SHIPUSERDEFINED}}&ActCheckoutPhase=TANDC&ActCheckoutPhase=GENERAL&GENERALHOWFOUND={{GENERALHOWFOUND}}&GENERALWHYBUY={{GENERALWHYBUY}}&ACTION_NEXT.x=82&ACTION_NEXT.y=7{{AGREETERMSCONDITIONS}}")
                {
                    datarow.newrow("Parameters",
                                   "RANDOM=0.708711438653157&SEQUENCE=1&ActCheckoutPhase=SHIPPING&ShippingClass={{ShippingClass}}&SHIPUSERDEFINED={{SHIPUSERDEFINED}}&ActCheckoutPhase=TANDC&ActCheckoutPhase=GENERAL&GENERALHOWFOUND={{GENERALHOWFOUND}}&GENERALWHYBUY={{GENERALWHYBUY}}&ACTION_NEXT.x=82&ACTION_NEXT.y=7{{AGREETERMSCONDITIONS}}",
                                   attribute, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Parameters",
                                   "RANDOM=0.708711438653157&SEQUENCE=1&ActCheckoutPhase=SHIPPING&ShippingClass={{ShippingClass}}&SHIPUSERDEFINED={{SHIPUSERDEFINED}}&ActCheckoutPhase=TANDC&ActCheckoutPhase=GENERAL&GENERALHOWFOUND={{GENERALHOWFOUND}}&GENERALWHYBUY={{GENERALWHYBUY}}&ACTION_NEXT.x=82&ACTION_NEXT.y=7{{AGREETERMSCONDITIONS}}",
                                   attribute, "FAIL", driver);
                }
                if (actual == "20")
                {
                    datarow.newrow("Sequence", "20", actual, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Sequence", "20", actual, "FAIL", driver);
                }
                if (str4 == "#idCheckoutForm > .checkout th.instruction:eq(1)")
                {
                    datarow.newrow("Header Selector", "#idCheckoutForm > .checkout th.instruction:eq(1)", str4, "PASS",
                                   driver);
                }
                else
                {
                    datarow.newrow("Header Selector", "#idCheckoutForm > .checkout th.instruction:eq(1)", str4, "FAIL",
                                   driver);
                }
                if (str5 == "#idPAYMENTMETHOD")
                {
                    datarow.newrow("Success Selector", "#idPAYMENTMETHOD", str5, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Success Selector", "#idPAYMENTMETHOD", str5, "FAIL", driver);
                }
                if (str6 == "#errormessage blockquote")
                {
                    datarow.newrow("Error Selector", "#errormessage blockquote", str6, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Error Selector", "#errormessage blockquote", str6, "FAIL", driver);
                }
                if (str7 == ".actrequired")
                {
                    datarow.newrow("Label Selector", ".actrequired", str7, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Label Selector", ".actrequired", str7, "FAIL", driver);
                }
                if (str8 == "select[name=\"ShippingClass\"] option")
                {
                    datarow.newrow("Selector Value", "select[name=\"ShippingClass\"] option", str8, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Selector Value", "select[name=\"ShippingClass\"] option", str8, "FAIL", driver);
                }
                if (str9 == "label[for=\"SHIPUSERDEFINED\"]")
                {
                    datarow.newrow("Label Selector1", "label[for=\"SHIPUSERDEFINED\"]", str9, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Label Selector1", "label[for=\"SHIPUSERDEFINED\"]", str9, "FAIL", driver);
                }
                if (str10 == "label[for=\"idGENERALHOWFOUND\"]")
                {
                    datarow.newrow("Label Selector2", "label[for=\"idGENERALHOWFOUND\"]", str10, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Label Selector2", "label[for=\"idGENERALHOWFOUND\"]", str10, "FAIL", driver);
                }
                if (str11 == "label[for=\"GENERALWHYBUY\"]")
                {
                    datarow.newrow("LabelSelector3", "label[for=\"GENERALWHYBUY\"]", str11, "PASS", driver);
                }
                else
                {
                    datarow.newrow("LabelSelector3", "label[for=\"GENERALWHYBUY\"]", str11, "FAIL", driver);
                }
                if (str12 == "select[name=\"GENERALHOWFOUND\"] option")
                {
                    datarow.newrow("Keys Values Selector", "select[name=\"GENERALHOWFOUND\"] option", str12, "PASS",
                                   driver);
                }
                else
                {
                    datarow.newrow("Keys Values Selector", "select[name=\"GENERALHOWFOUND\"] option", str12, "FAIL",
                                   driver);
                }
                if (str13 == "label[for=\"AGREETERMSCONDITIONS\"]")
                {
                    datarow.newrow("Label selector4", "label[for=\"AGREETERMSCONDITIONS\"]", str13, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Label selector4", "label[for=\"AGREETERMSCONDITIONS\"]", str13, "FAIL", driver);
                }
                if (str14 == "&AGREETERMSCONDITIONS=NO")
                {
                    datarow.newrow("CheckBox Replacement", "&AGREETERMSCONDITIONS=NO", str14, "PASS", driver);
                }
                else
                {
                    datarow.newrow("CheckBox Replacement", "&AGREETERMSCONDITIONS=NO", str14, "FAIL", driver);
                }
                if (str15 == ".checkout-cart strong:eq(3)")
                {
                    datarow.newrow("Scrape Data Value", ".checkout-cart strong:eq(3)", str15, "PASS", driver);
                }
                else
                {
                    datarow.newrow("Scrape Data Value", ".checkout-cart strong:eq(3)", str15, "FAIL", driver);
                }

                #endregion
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Excepion Not Expected", e, "FAIL", driver);
            }
            driver.FindElement(By.LinkText("Checkout Process")).Click();

            Thread.Sleep(0x1388);
            new Confirmtab().Confirm(driver, datarow);
        }
    }
}
using System;
using System.Threading;
using ObjectRepository;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium;

namespace MoBankUI
{
    internal class UserData_TPS
    {
        private readonly Screenshot screenshot = new Screenshot();

        public void userdata_TPS(IWebDriver driver, ISelenium selenium, datarow datarow)
        {
          
                string url = driver.PageSource.ToString();

                string field = null;
                string fieldlabel = null;
                string fieldinput = null;
                string fieldcountry = null;
                string countryvalue = null;
                string submitbutton = null;
                string letters = null;
                string termsncond = null;
                string paybutton = null;
                

                var screenshot = new Screenshot();

                if (url.Contains("smallDevice"))
                {
                    field = AddressMapV2.field;
                    fieldlabel = AddressMapV2.fieldlabel;
                    fieldinput = AddressMapV2.fieldinput;
                    fieldcountry = AddressMapV2.fieldcountry;
                    countryvalue = AddressMapV2.coutryvalue;
                    submitbutton = AddressMapV2.submitbutton;
                    letters = AddressMapV2.terms;
                    termsncond = CheckoutMapV2.termsncond;
                    paybutton = CheckoutMapV2.paybutton;

                }
                else
                {
                     field = AddressMapV1.field;
                     fieldlabel = AddressMapV1.fieldlabel;
                     fieldinput = AddressMapV1.fieldinput;
                     fieldcountry = AddressMapV1.fieldcountry;
                     countryvalue = AddressMapV1.coutryvalue;
                     submitbutton = AddressMapV1.submitbutton;
                     letters= AddressMapV1.sendletters;
                     termsncond = CheckoutMapV1.termsncond;
                     paybutton = CheckoutMapV1.paybutton;
                }
                try
                {    
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                IWebElement myDynamicElement8 =driver.FindElement(By.XPath(submitbutton));

                decimal count =selenium.GetXpathCount(field);
                if (count == 0)
                {
                    datarow.newrow("User Data Form Details", "Expected User Form Fields","User Form Fields Doesnot Exist", "FAIL", driver, selenium);
                }
                //Populating Customer Details from Excel Sheet
                for (int i = 1; i <= count; i++)
                {
                    if (selenium.IsElementPresent(""+field+"[" + i + "]"+fieldlabel+""))
                    {
                        string valuet = driver.FindElement(By.XPath("" + field + "[" + i + "]" + fieldlabel + "")).Text;

                        if (!valuet.Contains("Country"))
                        {  
                            driver.FindElement(By.XPath("" + field + "[" + i + "]" + fieldinput + "")).Clear();
                            driver.FindElement(By.XPath("" + field + "[" + i + "]" + fieldinput + "")).SendKeys("TEST");
                            datarow.newrow("Form Field", "", valuet, "PASS", driver, selenium);
                        }
                        #region Country
                        // selecting the country
                        if (valuet.Contains("Country"))
                        {
                            try
                            {
                                int j = i - 1;
                                string id = "id="+fieldcountry+"" + j + ""+countryvalue+"";
                                string[] varinats = selenium.GetSelectOptions("id=" + fieldcountry + "" + j + "" + countryvalue + "");
                                string values = null;
                                foreach (string value in varinats)
                                {
                                    if (!value.Contains("Please") || value != "Select country" )
                                    {
                                        if (value == "United Kingdom")
                                        {
                                            values = values + "\r\n" + value;
                                            new SelectElement(driver.FindElement(By.Id("" + fieldcountry + "" + j + "" + countryvalue + ""))).SelectByText(value);
                                            break;
                                        }
                                        else
                                        {
                                            try
                                            {
                                                values = values + "\r\n" + value;
                                               // new SelectElement(driver.FindElement(By.Id("" + fieldcountry + "" + j + "" + countryvalue + ""))).SelectByText(value);
                                            }
                                            catch (Exception EX)
                                            {

                                                String E = EX.ToString();
                                            }
                                           
                                        }
                                    }
                                }
                                datarow.newrow("Country Field", "", values, "PASS", driver, selenium);
                            }
                            catch (Exception ex)
                            {
                                string e = ex.ToString();
                                datarow.newrow("Country Field Exception", "Exception Not Expected", e, "PASS", driver,selenium);
                            }
                        }
                        #endregion
                        #region Email
                        if (valuet.Contains("Email"))
                        {
                            try
                            {
                                driver.FindElement(By.XPath("" + field + "[" + i + "]" + fieldinput + "")).Clear();
                                driver.FindElement(By.XPath("" + field + "[" + i + "]" + fieldinput + "")).SendKeys("test@test.com");
                            }
                            catch (Exception ex)
                            {
                                string e = ex.ToString();
                                datarow.newrow("Email Field Exception", "Exception Not Expected", e, "FAIL", driver,selenium);
                                screenshot.screenshotfailed(driver, selenium);
                            }
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception in DataForm", "Exception Not Expected", e, "FAIL", driver, selenium);
                screenshot.screenshotfailed(driver, selenium);
            }
            try
            {

                //Email/ Letter sending Confirmation
                if (selenium.IsElementPresent(""+field+"["+ 11 +"]"+ letters +""))
                {
                    driver.FindElement(By.XPath("" + field + "[" + 11 + "]" + letters + "")).Click();
                }
                
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                IWebElement myDynamicElement9 =driver.FindElement(By.XPath(submitbutton));
                driver.FindElement(By.XPath(submitbutton)).Click();
                selenium.WaitForPageToLoad("30000");



                string pagetitle = driver.Title;
                string basval = driver.FindElement(By.Id("BasketInfo")).Text;

                // Terms and Conditions
                if (selenium.IsElementPresent(termsncond))
                {
                    driver.FindElement(By.XPath(termsncond)).Click();
                }
                //Submit button
                if (selenium.IsElementPresent(submitbutton))
                //body[@id='page-checkout-process']/div/div[2]/div/form/fieldset/div[2]/div/button
                {                              //html/body/div/div[7]/div/div[2]/div/button
                    driver.FindElement(By.XPath(submitbutton)).Click();
                    selenium.WaitForPageToLoad("30000");
                    Thread.Sleep(2000);
                }
                //string details = selenium.GetText("css=div.ui-content.ui-body-c > p");

                //Pay Button 
                if (selenium.IsElementPresent(paybutton))
                {    
                    //html/body/div/div[7]/div/div[2]/a/span/span
                    driver.FindElement(By.XPath(paybutton)).Click();
                    selenium.WaitForPageToLoad("30000");
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception in DataForm", "Exception Not Expected", e, "FAIL", driver, selenium);
                screenshot.screenshotfailed(driver, selenium);
            }
        }
    }
}
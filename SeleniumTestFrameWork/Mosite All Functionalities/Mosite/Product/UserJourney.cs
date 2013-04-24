using System;
using System.Threading;
using OpenQA.Selenium;
using Selenium;
//using System.Drawing;

namespace MoBankUI
{
    public class UserJourney_TPS
    {
        private readonly Screenshot screenshot = new Screenshot();
        //General user journey to the checkout page
        public void UserJourn(datarow datarow, IWebDriver driver, ISelenium selenium, string url)
        {
            try
            {
                var Image = new Imagevalidation();
                var footer = new Footer_TPS();
                driver.Navigate().Back();
                driver.Navigate().GoToUrl(url);
                selenium.Click("css=img");
                selenium.WaitForPageToLoad("30000");
                Image.homepageimage(driver, selenium, datarow);
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                IWebElement myDynamicElement1 =
                    driver.FindElement(By.XPath("//html/body/div/div[2]/div/ul/li/div/div/a/h2"));
                driver.FindElement(By.XPath("//html/body/div/div[2]/div/ul/li/div/div/a/h2")).Click();
                selenium.WaitForPageToLoad("30000");
                string title = driver.Title;
                Image.categoryimage(driver, selenium, datarow);
                footer.Footer(driver, selenium, datarow);
                decimal categorycount = selenium.GetXpathCount("//html/body/div/div[2]/div/ul/li");
                for (int i = 1;; i++)
                {
                    if (selenium.IsElementPresent("//html/body/div/div[2]/div/ul/li/div/div/a/h2"))
                    {
                        driver.FindElement(By.XPath("//html/body/div/div[2]/div/ul/li/div/div/a/h2")).Click();
                        selenium.WaitForPageToLoad("30000");
                        Image.subcategoryimage(driver, selenium, datarow);
                        footer.Footer(driver, selenium, datarow);
                        string titlecategory = driver.Title;
                        string url1 = selenium.GetLocation();

                        if (url1.Contains("category"))
                        {
                            datarow.newrow("Category Title", "", titlecategory, "PASS", driver, selenium);
                        }
                        else
                        {
                            datarow.newrow("Product Title", "", titlecategory, "PASS", driver, selenium);
                            break;
                        }
                    }
                    else
                    {
                        if (i == 1)
                        {
                            datarow.newrow("Categories Of Merchant", "Expected Atleast One Category",
                                           "No Category is identified " + "-" +
                                           "//html/body/div/div[2]/div/ul/li/div/div/a/h2(Element Not Identified)",
                                           "FAIL", driver, selenium);
                            screenshot.screenshotfailed(driver, selenium);
                        }
                    }
                }

                var prod = new products_TPS();
                prod.product(driver, selenium, datarow);

                string BasketPage = driver.PageSource;
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Exception Is Not Expected", e, "FAIL", driver, selenium);
                screenshot.screenshotfailed(driver, selenium);
            }
        }
    }
}
// Generated by .NET Reflector from C:\Program Files\Default Company Name\Selenium Test Tool\MoBankUI.exe
namespace MoBankUI
{
    using OpenQA.Selenium;
    using Selenium;
    using System;
    
    internal class DeleteBasket_TPS
    {
        private MoBankUI.Screenshot screenshot = new MoBankUI.Screenshot();
        
        public void basket(IWebDriver driver, ISelenium selenium, datarow_TPS datarow)
        {
            try
            {
                products_TPS s_tps;
                bool flag;
                if (!selenium.IsElementPresent("//ul[@id='Basket']/li/a/span"))
                {
                    goto Label_01D6;
                }
                driver.FindElement(By.XPath("//ul[@id='Basket']/li/a/span")).Click();
                selenium.WaitForPageToLoad("30000");
                string actual = driver.FindElement(By.Id("BasketInfo")).Text;
                if (actual == "(0)")
                {
                    datarow.newrowTPS("Delete Basket Value", "(0)", actual, "PASS", driver, selenium);
                }
                else
                {
                    datarow.newrowTPS("Delete Basket Value", "(0)", actual, "FAIL", driver, selenium);
                    this.screenshot.screenshotfailed(driver, selenium);
                }
                selenium.Click("//body[@id='page-basket-index']/div/div[2]/div/div[2]/a/span/span");
                selenium.WaitForPageToLoad("30000");
                selenium.Click("css=img");
                selenium.WaitForPageToLoad("30000");
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10.0));
                IWebElement element = driver.FindElement(By.XPath("//html/body/div/div[2]/div/ul/li/div/div/a/h2"));
                driver.FindElement(By.XPath("//html/body/div/div[2]/div/ul/li/div/div/a/h2")).Click();
                selenium.WaitForPageToLoad("30000");
                string str2 = driver.Title.ToString();
                decimal xpathCount = selenium.GetXpathCount("//html/body/div/div[2]/div/ul/li");
                int num2 = 1;
                goto Label_01BC;
            Label_014B:
                if (selenium.IsElementPresent("//html/body/div/div[2]/div/ul/li/div/div/a/h2"))
                {
                    driver.FindElement(By.XPath("//html/body/div/div[2]/div/ul/li/div/div/a/h2")).Click();
                    selenium.WaitForPageToLoad("30000");
                    string str3 = driver.Title.ToString();
                    if (!selenium.GetLocation().Contains("category"))
                    {
                        goto Label_01C1;
                    }
                }
                num2++;
            Label_01BC:
                flag = true;
                goto Label_014B;
            Label_01C1:
                s_tps = new products_TPS();
                s_tps.product(driver, selenium, datarow);
                return;
            Label_01D6:
                datarow.newrowTPS("Delete From Basket", "Delete Basket Element Expected", "//ul[@id='Basket']/li/a/spanElement Not Present", "FAIL", driver, selenium);
                this.screenshot.screenshotfailed(driver, selenium);
            }
            catch (Exception exception)
            {
                string str5 = exception.ToString();
                datarow.newrowTPS("Exception", "Exception Not Expected", str5, "FAIL", driver, selenium);
                this.screenshot.screenshotfailed(driver, selenium);
            }
        }
    }
}

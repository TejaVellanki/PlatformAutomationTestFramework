using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium;

namespace MoBankUI
{
    class LookandFeelImages
    {
        public void images(IWebDriver driver, ISelenium selenium,datarow datarow)
        {
            try
            {//*[@id="customisation-page-update-form"]/p/input
               
            driver.FindElement(By.Id("HomeImageImport_Image")).SendKeys("C:\\Users\\teja\\Documents\\GitHub\\PlatformAutomationTestFramework\\SeleniumTestFrameWork\\ObjectRepository\\Images\\ticklelogo.png");
            Thread.Sleep(2000);
            selenium.Click("css=input.button");
            selenium.WaitForPageToLoad("30000");
            pagerefresh(driver,selenium);
            driver.FindElement(By.Id("IconImageImport_Image")).SendKeys("C:\\Users\\teja\\Documents\\GitHub\\PlatformAutomationTestFramework\\SeleniumTestFrameWork\\SeleniumTestFrameWork\\ObjectRepository\\Images\\ion.ico");
            Thread.Sleep(2000);
            selenium.Click("css=input.button");
            selenium.WaitForPageToLoad("30000");
            pagerefresh(driver, selenium);
            new SelectElement(driver.FindElement(By.Id("HomeImageJustification"))).SelectByText("Centre");
            Thread.Sleep(2000);
            selenium.Click("css=input.button");
            selenium.WaitForPageToLoad("30000");
            pagerefresh(driver, selenium);
            driver.FindElement(By.XPath("//form[@id='customisation-page-update-form']/div[10]/h3")).Click();
            selenium.WaitForPageToLoad("30000");
            driver.FindElement(By.Id("CustomBasketImageImport_Image")).SendKeys("C:\\Users\\teja\\Documents\\GitHub\\PlatformAutomationTestFramework\\SeleniumTestFrameWork\\ObjectRepository\\Images\\basket_white.png");
            selenium.Click("css=input.button");
            selenium.WaitForPageToLoad("30000");
            pagerefresh(driver, selenium);
                
                //Add Click TO Call - Still ijn Developement
           //driver.FindElement(By.Id("ClickToCallImage_Image")).SendKeys("C:\\Users\\teja\\Desktop\\Images and catalogues\\Teja Custom Basket Image.png");

            selenium.Click("css=input.button");
            selenium.WaitForPageToLoad("30000");
            driver.FindElement(By.Id("SuccessImageImport_Image")).SendKeys("C:\\Users\\teja\\Documents\\GitHub\\PlatformAutomationTestFramework\\SeleniumTestFrameWork\\ObjectRepository\\Images\\success.png");
            selenium.Click("css=input.button");
            selenium.WaitForPageToLoad("30000");
            pagerefresh(driver, selenium);
            driver.FindElement(By.Id("FailureImageImport_Image")).SendKeys("C:\\Users\\teja\\Documents\\GitHub\\PlatformAutomationTestFramework\\SeleniumTestFrameWork\\ObjectRepository\\Images\\Failure.png");
            selenium.Click("css=input.button");
            selenium.WaitForPageToLoad("30000");
            pagerefresh(driver, selenium);
            #region validations
            if (selenium.IsElementPresent("css=img[alt=\"Home Image\"]"))
                {
                    datarow.newrow("Home Page Logo Uploaded into Console","css=img[alt=\"Home Image\"]","css=img[alt=\"Home Image\"]","PASS");
                }
                else
                {
                     datarow.newrow("Home Page Logo Uploaded into Console","css=img[alt=\"Home Image\"]","css=img[alt=\"Home Image\"]","FAIL");
                }

                if (selenium.IsElementPresent("css=img[alt='Icon']"))
                {
                    datarow.newrow("Home Page Icon Uploaded into Console", "css=img[alt='Icon']", "css=img[alt='Icon']", "PASS");
                }
                else
                {
                    datarow.newrow("Home Page Icon Uploaded into Console", "css=img[alt='Icon']", "css=img[alt='Icon']", "FAIL");
                }

                if (selenium.IsElementPresent("css=img[alt='Custom Basket Image']"))
                {
                    datarow.newrow("Custom Basket Image Uploaded into Console", "css=img[alt='Custom Basket Image']", "css=img[alt='Custom Basket Image']", "PASS");

                }
                else
                {
                    datarow.newrow("Custom Basket Image Uploaded into Console", "css=img[alt='Custom Basket Image']", "css=img[alt='Custom Basket Image']", "FAIL");
                }

                if (selenium.IsElementPresent("css=img[alt=\"Order confirmation success Image\"]"))
                {
                    datarow.newrow("Success Image Uploaded into Console", "css=img[alt='Custom Basket Image']", "css=img[alt='Custom Basket Image']", "PASS");
                }
                else
                {
                    datarow.newrow("Success Image Uploaded into Console", "css=img[alt='Custom Basket Image']", "css=img[alt='Custom Basket Image']", "FAIL");
                }
            
               if (selenium.IsElementPresent("css= img[alt=\"Order confirmation failure Image\"]"))
                {
                    datarow.newrow("Failure Image Uploaded into Console", "css= img[alt=\"Order confirmation failure Image\"]", "css= img[alt=\"Order confirmation failure Image\"]", "PASS");
                }
                 
              else
                 {
                     datarow.newrow("Failure Image Uploaded into Console", "css= img[alt=\"Order confirmation failure Image\"]", "css= img[alt=\"Order confirmation failure Image\"]", "FAIL");
                    
                 }

              

                #endregion
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception","Exceprtion Not Expected",e,"FAIL");
            }

        }

        public void pagerefresh(IWebDriver driver, ISelenium selenium)
        {

            driver.FindElement(By.LinkText("Look & Feel")).Click();
            selenium.WaitForPageToLoad("30000");
            driver.FindElement(By.XPath("(//a[contains(text(),'…')])[2]")).Click();
            selenium.WaitForPageToLoad("30000");
        }
    }
}

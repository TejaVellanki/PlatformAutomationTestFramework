﻿// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
    
namespace MoBankUI
{
    public class CreateAccount
    {
        public void ShopAccount(IWebDriver driver)
        {
            driver.FindElement(By.XPath("(//a[contains(text(),'Shops')])[2]")).Click();
            driver.FindElement(By.LinkText("Create")).Click();
            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).SendKeys("QA -Regression");
            driver.FindElement(By.Id("Identifier")).Clear();
            driver.FindElement(By.Id("Identifier")).SendKeys("qaregression");
            driver.FindElement(By.CssSelector("input.button")).Click();
            Assert.AreEqual("Shop : mobank.co.uk/MoShop", driver.Title);
            driver.FindElement(By.Id("UseSlug")).Click();
            driver.FindElement(By.CssSelector("input.button")).Click();
            driver.FindElement(By.LinkText("Look & Feel")).Click();
            driver.FindElement(By.Id("Customisations_0__Title")).Clear();
            driver.FindElement(By.Id("Customisations_0__Title")).SendKeys("QA-Regression Customisations");
            driver.FindElement(By.XPath("(//input[@id='DefaultCustomisationsId'])[2]")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'…')])[2]")).Click();
            driver.FindElement(By.Id("HomeImage_ImageUpload")).Clear();
            driver.FindElement(By.Id("HomeImage_ImageUpload"))
                  .SendKeys(@"C:\Users\Teja\Desktop\Upload Themes and Logos\Modrophenia");
            driver.FindElement(By.Id("Icon_ImageUpload")).Clear();
            driver.FindElement(By.Id("Icon_ImageUpload"))
                  .SendKeys(@"C:\Users\Teja\Desktop\Upload Themes and Logos\Modrophenia Icon.ico");
            new SelectElement(driver.FindElement(By.Id("HomeImage_Justification"))).SelectByText("Centre");
            new SelectElement(driver.FindElement(By.Id("ExternalLinks_0__ExternalLinkConfigId"))).SelectByText("Facebook");
            driver.FindElement(By.Id("ExternalLinks_0__LinkReplacement")).Clear();
            driver.FindElement(By.Id("ExternalLinks_0__LinkReplacement"))
                  .SendKeys("/pages/modropheniacom-in-mod-we-trust/288054451149");
            driver.FindElement(By.Id("OrderConfirmationOrderNumberText")).Clear();
            driver.FindElement(By.Id("OrderConfirmationOrderNumberText")).SendKeys("Your order number is:{0}");
            driver.FindElement(By.Id("OrderConfirmationSuccessMessage")).Clear();
            driver.FindElement(By.Id("OrderConfirmationSuccessMessage")).SendKeys("Your purchase has been successful");
            driver.FindElement(By.Id("OrderConfirmationSuccessImage_ImageUpload")).Clear();
            driver.FindElement(By.Id("OrderConfirmationSuccessImage_ImageUpload"))
                  .SendKeys(@"C:\Users\Teja\Desktop\Upload Themes and Logos\success.png");
            driver.FindElement(By.Id("OrderConfirmationFailureMessage")).Clear();
            driver.FindElement(By.Id("OrderConfirmationFailureMessage"))
                  .SendKeys("Sorry your order has not been successful.");
            driver.FindElement(By.Id("OrderConfirmationFailureImage_ImageUpload")).Clear();
            driver.FindElement(By.Id("OrderConfirmationFailureImage_ImageUpload"))
                  .SendKeys(@"C:\Users\Teja\Desktop\Upload Themes and Logos\Fail.png");
            driver.FindElement(By.CssSelector("input.button")).Click();
        }
    }
}
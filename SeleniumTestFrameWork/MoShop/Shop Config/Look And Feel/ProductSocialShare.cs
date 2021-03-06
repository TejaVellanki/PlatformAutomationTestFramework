﻿using System;
using OpenQA.Selenium;

namespace MoBankUI.MoShop
{
    internal class ProductSocialShare : Driverdefining
    {
        public void Productsocialshare(IWebDriver driver, Datarow datarow)
        {
            try
            {
                driver.FindElement(By.XPath("//form[@id='customisation-page-update-form']/div[6]/h3")).Click();
                Selectanoption(driver, By.Id("SocialMediaSharingLinks_0__SocialMediaSharingConfigId"), "google plus");
                driver.FindElement(By.CssSelector("input.button")).Click();
                driver.FindElement(By.XPath("//form[@id='customisation-page-update-form']/div[6]/h3")).Click();
                Selectanoption(driver, By.Id("SocialMediaSharingLinks_1__SocialMediaSharingConfigId"), "Facebook");
                driver.FindElement(By.CssSelector("input.button")).Click();
                driver.FindElement(By.XPath("//form[@id='customisation-page-update-form']/div[6]/h3")).Click();
                Selectanoption(driver, By.Id("SocialMediaSharingLinks_2__SocialMediaSharingConfigId"), "Twitter");
                driver.FindElement(By.CssSelector("input.button")).Click();
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.Newrow("Exception", "Exception Not Expected", e, "FAIL", driver);
            }
        }
    }
}
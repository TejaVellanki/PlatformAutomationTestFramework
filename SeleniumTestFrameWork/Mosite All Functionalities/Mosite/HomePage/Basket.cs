﻿using System;
using MoBankUI.ObjectRepository;
using OpenQA.Selenium;

//using System.Drawing;

namespace MoBankUI.Mosite.HomePage
{
    internal class BasketsTps : Driverdefining
    {
        private readonly Screenshot _screenshot = new Screenshot();

        public void Basket(IWebDriver driver, Datarow datarow, string url)
        {
            try
            {
                var title = driver.PageSource;

                var basketempty = title.Contains("user-scalable=yes") ? BasketV2.basketempty : BasketV1.Basketempty;
                try
                {
                    driver.FindElement(By.Id("BasketInfo")).Click();

                    datarow.Newrow("Basket Info Button", "Basket Info Button Is Expected",
                                   "Basket Info Button is Present", "PASS", driver);
                }
                catch (Exception ex)
                {
                    var e = ex.ToString();
                    datarow.Newrow("Basket Info Button", "Basket Info Button Is Expected", e, "FAIL", driver);
                    _screenshot.Screenshotfailed(driver);
                }

                try
                {
                    if (!title.Contains("user-scalable=yes"))
                    {
                        var value = driver.FindElement(By.Id("BasketInfo")).Text;
                        if (value == "(0)")
                        {
                            datarow.Newrow("Basket Value", "(0)", value, "PASS", driver);
                        }
                        else
                        {
                            datarow.Newrow("Basket Value", "(0)", value, "FAIL", driver);
                            _screenshot.Screenshotfailed(driver);
                        }
                    }


                    var basket = driver.FindElement(By.Id(basketempty)).Text;
                    if (basket == "Your basket is empty")
                    {
                        datarow.Newrow("Basket Page Text", "Your basket is empty", basket, "PASS", driver);
                    }
                    else
                    {
                        datarow.Newrow("Basket Page Text", "Your basket is empty", basket, "FAIL", driver);
                        _screenshot.Screenshotfailed(driver);
                    }
                }
                catch (Exception ex)
                {
                    var e = ex.ToString();
                    datarow.Newrow("Basket Info Text", "Basket Info Text Is Expected", e, "FAIL", driver);
                    _screenshot.Screenshotfailed(driver);
                }
                var basketurl = driver.Url;
                var footer = new FooterTps();
                footer.Footer(driver, datarow, basketurl);
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.Newrow("Exception", "Excepetion Not Expected", e, "FAIL", driver);
                _screenshot.Screenshotfailed(driver);
            }
        }
    }
}
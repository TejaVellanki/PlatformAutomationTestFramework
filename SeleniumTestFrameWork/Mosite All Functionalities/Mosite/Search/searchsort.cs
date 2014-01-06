﻿//-----------------------------------------------------------------------
// <copyright company="MoPowered">
//     Copyright (c) MoPowered. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace MoBankUI
{
    public class searchsort
    {
        public void search(IWebDriver driver)
        {
            string _names = null;
            driver.FindElement(By.CssSelector("input.ui-input-text.ui-body-d")).SendKeys("card");
            driver.FindElement(By.CssSelector("input.ui-input-text.ui-body-d")).SendKeys(Keys.Enter);
            ReadOnlyCollection<IWebElement> productnames = driver.FindElements(By.CssSelector("[itemprop='name']"));
            for (int i = 0; i < 32; i++)
            {
                string _name = productnames[i].Text;
                _names = _name + "\n" + _names;
            }

            if (_names != null)
            {
                char[] charArray = _names.ToCharArray();
                Array.Reverse(charArray);
            }
        }
    }
}
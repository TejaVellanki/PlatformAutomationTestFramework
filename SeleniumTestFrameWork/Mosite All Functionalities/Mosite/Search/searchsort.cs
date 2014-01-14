//-----------------------------------------------------------------------
// <copyright company="MoPowered">
//     Copyright (c) MoPowered. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using OpenQA.Selenium;

namespace MoBankUI.Mosite.Search
{
    public class Searchsort
    {
        public void Search(IWebDriver driver)
        {
            string names = null;
            driver.FindElement(By.CssSelector("input.ui-input-text.ui-body-d")).SendKeys("card");
            driver.FindElement(By.CssSelector("input.ui-input-text.ui-body-d")).SendKeys(Keys.Enter);
            var productnames = driver.FindElements(By.CssSelector("[itemprop='name']"));
            for (var i = 0; i < 32; i++)
            {
                var _name = productnames[i].Text;
                names = _name + "\n" + names;
            }

            if (names == null) return;
            var charArray = names.ToCharArray();
            Array.Reverse(charArray);
        }
    }
}
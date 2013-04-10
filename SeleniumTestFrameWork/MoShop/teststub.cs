using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Selenium;
using NUnit.Framework;
using System.Threading;

namespace MoBankUI
{
    class teststub
    {
        public void stub(IWebDriver driver, ISelenium selenium,datarow datarow)
        {
            new Delivery().delivery(driver, selenium, datarow);

        }
    }
}

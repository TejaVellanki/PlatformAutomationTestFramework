using OpenQA.Selenium;
using Selenium;

namespace MoBankUI
{
    internal class teststub
    {
        public void stub(IWebDriver driver, ISelenium selenium, datarow datarow)
        {
            new Delivery().delivery(driver, selenium, datarow);
        }
    }
}
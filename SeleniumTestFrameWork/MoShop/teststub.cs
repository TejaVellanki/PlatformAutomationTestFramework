using OpenQA.Selenium;

namespace MoBankUI
{
    internal class teststub
    {
        public void stub(IWebDriver driver, datarow datarow)
        {
            new DeliveryTab().Delivery(driver, datarow);
        }
    }
}
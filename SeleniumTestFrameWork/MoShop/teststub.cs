using OpenQA.Selenium;

namespace MoBankUI
{
    internal class Teststub
    {
        public void Stub(IWebDriver driver, Datarow datarow)
        {
            new DeliveryTab().Delivery(driver, datarow);
        }
    }
}
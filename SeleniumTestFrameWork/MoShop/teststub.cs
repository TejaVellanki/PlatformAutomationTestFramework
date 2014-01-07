using MoBankUI.MoShop.Checkout.Delivery;
using OpenQA.Selenium;

namespace MoBankUI.MoShop
{
    internal class Teststub
    {
        public void Stub(IWebDriver driver, Datarow datarow)
        {
            new DeliveryTab().Delivery(driver, datarow);
        }
    }
}
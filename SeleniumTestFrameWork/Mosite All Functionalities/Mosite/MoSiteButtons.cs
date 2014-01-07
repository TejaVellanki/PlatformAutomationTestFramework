using MoBankUI.ObjectRepository;
using OpenQA.Selenium;

namespace MoBankUI.Mosite
{
    public class MoSiteButtons : Driverdefining
    {
        private void AddToBasket(IWebDriver driver, Datarow datarow)
        {
            var url = driver.PageSource;
            string AddToBasket = null;
            if (url.Contains("user-scalable=yes"))
            {
                AddToBasket = CollectionMapV2.addtobasket;
            }
            else
            {
                AddToBasket = CollectionMapV1.addtobasket;
            }
            driver.FindElement(By.XPath(AddToBasket)).Click();

            datarow.newrow("Add to Basket Button", "Add To Basket Button is Expected",
                           AddToBasket + "Add To Basket Element Is Present", "PASS", driver);
        }
    }
}
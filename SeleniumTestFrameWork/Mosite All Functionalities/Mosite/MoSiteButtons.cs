using MoBankUI.ObjectRepository;
using OpenQA.Selenium;

namespace MoBankUI.Mosite
{
    public class MoSiteButtons : Driverdefining
    {
        private void AddToBasket(IWebDriver driver, Datarow datarow)
        {
            var url = driver.PageSource;
            var addToBasket = url.Contains("user-scalable=yes") ? CollectionMapV2.addtobasket : CollectionMapV1.addtobasket;
            driver.FindElement(By.XPath(addToBasket)).Click();

            datarow.newrow("Add to Basket Button", "Add To Basket Button is Expected",
                           addToBasket + "Add To Basket Element Is Present", "PASS", driver);
        }
    }
}
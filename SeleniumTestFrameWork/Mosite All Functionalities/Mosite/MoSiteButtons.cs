using MoBankUI.ObjectRepository;
using OpenQA.Selenium;

namespace MoBankUI.Mosite
{
    public class MoSiteButtons : Driverdefining
    {
        private void AddToBasket(IWebDriver driver, Datarow datarow)
        {
            var url = driver.PageSource;
            string addToBasket;
            if (url.Contains("user-scalable=yes"))
            {
                addToBasket = CollectionMapV2.addtobasket;
            }
            else
            {
                addToBasket = CollectionMapV1.addtobasket;
            }
            driver.FindElement(By.XPath(addToBasket)).Click();

            datarow.newrow("Add to Basket Button", "Add To Basket Button is Expected",
                           addToBasket + "Add To Basket Element Is Present", "PASS", driver);
        }
    }
}
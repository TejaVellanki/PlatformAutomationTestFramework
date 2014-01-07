using MoBankUI;
using ObjectRepository;
using OpenQA.Selenium;
using WebDriver_Refining;

namespace MoSite
{
    public class MoSiteButtons : Driverdefining
    {
        private void AddToBasket(IWebDriver driver, Datarow datarow)
        {
            string url = driver.PageSource;
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
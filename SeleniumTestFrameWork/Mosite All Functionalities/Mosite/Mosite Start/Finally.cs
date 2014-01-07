using System;
using OpenQA.Selenium;

//using System.Drawing;

namespace MoBankUI.Mosite
{
    internal class MositeGeneral
    {
        public void Finally(IWebDriver driver, string url, Datarow datarow, string emails)
        {
            new GeneralLibrary();
            try
            {
                //Footer_TPS footer = new Footer_TPS();
                //footer.Footer(driver, , url, datarow);

                //Baskets_TPS basket = new Baskets_TPS();
                //basket.Basket(driver, datarow);

                //links_TPS hom = new links_TPS();
                //hom.Links(datarow,driver, url);

                //UserJourney_TPS userjour = new UserJourney_TPS();
                //userjour.UserJourn(datarow,driver, url);

                //Mopay_TPS Mopay = new Mopay_TPS();
                //Mopay.Mopay(driver, datarow);
            }
            catch (Exception e)
            {
                Console.Write(e);
                var ex = e.ToString();
                var scree = new Screenshot();
                datarow.newrow("Exception", "Not Expected", ex, "FAIL", driver);
                scree.screenshotfailed(driver);
            }
            finally
            {
                var split = url.Split(new[] {' ', ',', '.', '/', '\t'});

                foreach (var sr in split)
                {
                    if (split[2] == "m" || split[2] == "www")
                    {
                        if (sr != split[3]) continue;
                        datarow.consolidatedreport(emails);
                        datarow.excelsave("Mosite-" + sr + "", driver, emails);

                        driver.Quit();
                        break;
                    }
                    if (sr != split[2]) continue;
                    datarow.consolidatedreport(emails);
                    datarow.excelsave("Mosite-" + sr + "", driver, emails);

                    driver.Quit();
                    break;
                }
            }
        }
    }
}
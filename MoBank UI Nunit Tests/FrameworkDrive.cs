
/*
namespace FrameworkDrive
{
    [TestFixture]
    public class frameworkdrive
    {
        public IWebDriver driver;
        public WebDriverBackedSelenium selenium;
        public StringBuilder verificationErrors;
        public MoBankUI.Screenshot screenshot;
        datarow datarow = new datarow();
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            FirefoxProfile firefoxProfile = new FirefoxProfile();
            firefoxProfile.SetPreference("browser.private.browsing.autostart", true);
            driver = new FirefoxDriver(firefoxProfile);
            driver.Manage().Cookies.DeleteAllCookies();
            selenium = new WebDriverBackedSelenium(driver, "https://qaadmin.mobankdev.com/");
            verificationErrors = new StringBuilder();
            selenium.Start();
            
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }


        [Test]
        public void All()
        {
            datarow.col();
            MoShop();
            MoShop_CreateShop();
            MoShop_CScrape();
            MoShop_RunScrape();
            MoShop_RunSite();
        }

        
        public void MoShop() 
        {
           
            driver.Navigate().GoToUrl("https://qaadmin.mobankdev.com/");
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30000));
            MoShopConsole moshop = new MoShopConsole();
            moshop.Homepagetabs(driver, selenium, datarow);
        }

       
        public void MoShop_CreateShop()
        {
           
            datarow.newrow("", "", "Create a Test Shop", "", driver, selenium);
            var testshop = new createShop();
            testshop.Testshop(driver, selenium, datarow);
            new LookandFeel().lookandfeel(driver, selenium, datarow);

        }

      
        public void MoShop_CScrape()
        {
           
            datarow.newrow("", "", "Create a Test Scarpe", "", driver, selenium);
            new Createscrape().createscrape(driver, selenium, datarow);
        }

       
        public void MoShop_RunScrape()
        {
            datarow.newrow("", "", "Run Manual Scrape", "", driver, selenium);
            var run = new RunScrape();
            run.runscrape(driver, selenium, datarow);
        }

       
        public void MoShop_RunSite()
        {
            datarow.newrow("", "", "Run the Test Site", "", driver, selenium);
            driver.Navigate().GoToUrl("http://testshop.mobankdev.com/");
            selenium.WaitForPageToLoad("30000");
            BlobStorage blob = new BlobStorage();
            blob.Blob(selenium, driver, datarow, "http://testshop.mobankdev.com/");
            MoshopBatch moshop =new MoshopBatch();
            moshop.commtest(driver, selenium, datarow);
        }


    }
}
*/

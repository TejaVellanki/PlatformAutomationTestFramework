
/*
namespace FrameworkDrive
{
    [TestFixture]
    public class frameworkdrive
    {
        public IWebDriver driver;
        public WebDriverBacked ;
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
             = new WebDriverBacked(driver, "https://qaadmin.mobankdev.com/");
            verificationErrors = new StringBuilder();
            .Start();
            
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
            moshop.Homepagetabs(driver, datarow);
        }

       
        public void MoShop_CreateShop()
        {
           
            datarow.newrow("", "", "Create a Test Shop", "",driver);
            var testshop = new createShop();
            testshop.Testshop(driver, datarow);
            new LookandFeel().lookandfeel(driver, datarow);

        }

      
        public void MoShop_CScrape()
        {
           
            datarow.newrow("", "", "Create a Test Scarpe", "",driver);
            new Createscrape().createscrape(driver, datarow);
        }

       
        public void MoShop_RunScrape()
        {
            datarow.newrow("", "", "Run Manual Scrape", "",driver);
            var run = new RunScrape();
            run.runscrape(driver, datarow);
        }

       
        public void MoShop_RunSite()
        {
            datarow.newrow("", "", "Run the Test Site", "",driver);
            driver.Navigate().GoToUrl("http://testshop.mobankdev.com/");
            waitforpagetoload(driver,30000);
            BlobStorage blob = new BlobStorage();
            blob.Blob(,driverdatarow, "http://testshop.mobankdev.com/");
            MoshopBatch moshop =new MoshopBatch();
            moshop.commtest(driver, datarow);
        }


    }
}
*/

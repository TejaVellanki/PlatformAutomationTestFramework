namespace MoBankUI
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Android;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Android;
    using Selenium;
    using System;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
    using Next_Mobi;

    public partial class Next : Form
    {
       
        public WebDriverBackedSelenium selenium;       
        private CheckedListBox checkedListBox1;           
        private TextBox textBox1;
        private TextBox textbox3;
        private TextBox textbox4;
        private TextBox textBox2;

        public Next()
        {
            this.InitializeComponent();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                bool mopaytestharness = this.checkBox15.Checked;
                bool Mopayconsole = this.checkBox16.Checked;
                bool Moshop = this.checkBox11.Checked;
                bool MoPayAccount  = this.checkBox17.Checked;
                bool MoSite= this.checkBox12.Checked;
                bool Firefox= this.checkBox14.Checked;
                bool mositetps= this.checkBox13.Checked;
                bool tabletview = checkBox1.Checked;
                bool NextMobi = checkBox2.Checked;
              

                if (mopaytestharness)
                {
                    this.mopaytestharness();
                }
                if (Mopayconsole)
                {
                    this.mopayconsole();
                }
                if (MoPayAccount)
                {
                    this.mopayaccountcreation();
                }
                if (Moshop)
                {
                    this.moshopconsole();
                }
                if (MoSite)
                {
                    this.mositemodro();
                }
                if (tabletview)
                {
                    this.tabletview();
                }
                if (NextMobi)
                {
                    this.nextmobi();
                }
                #region MositeTPS
                if (mositetps == true)
                {
                    if (textBox3.Text != "Please Enter Mosite URL's Seperated By Comma(,)")
                    {
                        datarow datarow = new datarow();
                        datarow.col();
                        string urls = textBox3.Text;
                        if (urls != "")
                        {
                            //Seperating the URL's. 
                            string[] url = urls.Split(',');
                            foreach (string oneurl in url)
                            {
                                datarow.dataflush();
                                mositetp(oneurl, datarow, selenium);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Atleast One Merchant URL To Test in Text Field");
                        }
                        string emails = textBox4.Text;

                    }

                    else
                    {
                        MessageBox.Show("Please Enter Atleast One Merchant URL To Test in Text Field");
                    }


                }
                #endregion             

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }

        }

     

        #region Firefox

        public void mositetp(string url, datarow datarow, ISelenium selenium)
        {
            try
            {
                string item = null;
                foreach (var items in checkedListBox3.CheckedItems)
                {
                    item = item + "," + items;
                }
                if (item == null)
                {
                    MessageBox.Show("Please Select Atleast One Functionality To Test From Options Available");
                }
                else
                {
                    try
                    {
                        // Initialising the firefox driver                    

                        IWebDriver driver = new FirefoxDriver();
                        // An Static url should be given for the browser to launch. 
                        selenium = new WebDriverBackedSelenium(driver, url);
                        selenium.Start();
                        driver.Navigate().GoToUrl(url);
                        selenium.WaitForPageToLoad("30000");
                        FirefoxProfile prof = new FirefoxProfile();
                        //changing the User agent to Iphone 4.
                        prof.SetPreference("general.useragent.override", "Mozilla/5.0 (iPhone; U; CPU iPhone OS 4_0 like Mac OS X; en-us) AppleWebKit/532.9 (KHTML, like Gecko) Version/4.0.5 Mobile/8A293 Safari/6531.22.7");
                        driver = new FirefoxDriver(prof);
                        selenium = new WebDriverBackedSelenium(driver, url);
                        selenium.Start();
                        driver.Navigate().GoToUrl(url);
                        selenium.WaitForPageToLoad("30000");
                        Thread.Sleep(2000);

                        string mobileurl = selenium.GetLocation();
                        if (mobileurl == url)
                        {
                            datarow.newrow("Mobile URL Validation", "Mobile URL", mobileurl, "FAIL", driver, selenium);
                        }
                        else
                        {
                            datarow.newrow("Mobile URL Validation", "Mobile URL", mobileurl, "PASS", driver, selenium);
                        }

                        BatchTesting testing = new BatchTesting();
                        testing.batchtesting(item, url, driver, selenium, datarow);
                        string emails = textBox2.Text;
                        MositeGeneral site = new MositeGeneral();
                        site.Finally(driver, selenium, url, datarow, emails);
                    }
                    catch (Exception ex)
                    {
                        string e = ex.ToString();
                    }


                }
            }
            catch (Exception ex)
            {
                string u = ex.ToString();
                MessageBox.Show(u);
            }


        }

        public void mopayaccountcreation()
        {
            try
            {
                IWebDriver driver = new FirefoxDriver();
                this.selenium = new WebDriverBackedSelenium(driver, "https://devpay.mobankdev.com/Management");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management");
                new MopayAccount().create(driver, this.selenium);
            }
            catch (Exception)
            {
            }
        }
        public void mopayconsole()
        {
            try
            {
                IWebDriver driver = new FirefoxDriver();
                this.selenium = new WebDriverBackedSelenium(driver, "https://devpay.mobankdev.com/Management");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management");
                new MopayConsol().HomepageTabs(driver, this.selenium);
            }
            catch (Exception)
            {
            }
        }
        public void mopaytestharness()
        {
            try
            {
                IWebDriver driver = new FirefoxDriver();
                this.selenium = new WebDriverBackedSelenium(driver, "http://devpaytest.mobankdev.com/");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                driver.Navigate().GoToUrl("http://devpaytest.mobankdev.com/");
                new Mopay().MoPay(driver, this.selenium);
            }
            catch (Exception)
            {
            }
        }
        public void moshopconsole()
        {
            try
            {
                string items = null;
                datarow datarow = new datarow();
                datarow.col();
                int count = checkedListBox2.CheckedItems.Count;
                foreach (var item in checkedListBox2.CheckedItems)
                {
                    items += item.ToString() +",";
                }
                IWebDriver driver = new FirefoxDriver();
                this.selenium = new WebDriverBackedSelenium(driver, "https://qaadmin.mobankdev.com/");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                driver.Navigate().GoToUrl("https://qaadmin.mobankdev.com/");
                MoshopBatch batch = new MoshopBatch();
                batch.batchmoshop(driver, selenium, datarow, items);
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
            }
        }
        public void mositemodro()
        {
            try
            {
                IWebDriver driver = new FirefoxDriver();
                this.selenium = new WebDriverBackedSelenium(driver, "https://qamodrophenia.mobankdev.com");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                driver.Navigate().GoToUrl("https://qamodrophenia.mobankdev.com");
                new MositeStart().Mositestart(driver, this.selenium);
            }
            catch (Exception)
            {
            }
        }
        public void nextmobi()
        {
                string items = null;
                datarow datarow = new datarow();
                datarow.col();
                int count = checkedListBox6.CheckedItems.Count;
                foreach (var item in checkedListBox6.CheckedItems)
                {
                    items += item.ToString() +",";
                }
                IWebDriver driver = new FirefoxDriver();
                this.selenium = new WebDriverBackedSelenium(driver, "http://m.next.co.uk/");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                driver.Navigate().GoToUrl("http://m.next.co.uk/");
             
            mobibatch mobi = new mobibatch();
            mobi.nextmobi(driver, selenium, datarow,items);
            datarow.excelsave("NextMobi", driver, selenium, "vaishali.mongia@mobankgroup.com");
        }

        #endregion 

        #region Chrome
        public void mopayaccountcreationchrome()
        {
            try
            {
                IWebDriver driver = new ChromeDriver(@"C:\Selenium\net40\");
                this.selenium = new WebDriverBackedSelenium(driver, "https://devpay.mobankdev.com/Management");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management");
                new MopayAccount().create(driver, this.selenium);
            }
            catch (Exception)
            {
            }
        }
        public void mopayconsolechrome()
        {
            try
            {
                IWebDriver driver = new ChromeDriver(@"C:\Selenium\net40\");
                this.selenium = new WebDriverBackedSelenium(driver, "https://devpay.mobankdev.com/Management");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management");
                new MopayConsol().HomepageTabs(driver, this.selenium);
            }
            catch (Exception)
            {
            }
        }
        public void mopaytestharnesschrome()
        {
            try
            {
                IWebDriver driver = new ChromeDriver(@"C:\Selenium\net40\");
                this.selenium = new WebDriverBackedSelenium(driver, "http://devpaytest.mobankdev.com/");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                driver.Navigate().GoToUrl("http://devpaytest.mobankdev.com/");
                new Mopay().MoPay(driver, this.selenium);
            }
            catch (Exception)
            {
            }
        }
        public void moshopconsolechrome()
        {
            try
            {
                IWebDriver driver = new ChromeDriver(@"C:\Selenium\net40\");
                this.selenium = new WebDriverBackedSelenium(driver, "https://qaadmin.mobankdev.com/");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                driver.Navigate().GoToUrl("https://qaadmin.mobankdev.com/");
               
            }
            catch (Exception)
            {
            }
        }
        public void mositemodrochrome()
        {
            try
            {
                IWebDriver driver = new ChromeDriver(@"C:\Selenium\net40\");
                this.selenium = new WebDriverBackedSelenium(driver, "https://qamodrophenia.mobankdev.com");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                driver.Navigate().GoToUrl("https://qamodrophenia.mobankdev.com");
                new MositeStart().Mositestart(driver, this.selenium);
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region Internet Explorer


        public void mopayaccountcreationexplorer()
        {
            try
            {
                IWebDriver driver = new InternetExplorerDriver(@"C:\Selenium\net40\");
                this.selenium = new WebDriverBackedSelenium(driver, "https://devpay.mobankdev.com/Management");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management");
                new MopayAccount().create(driver, this.selenium);
            }
            catch (Exception)
            {
            }
        }           

        public void mopayconsoleexplorer()
        {
            try
            {
                IWebDriver driver = new InternetExplorerDriver(@"C:\Selenium\net40\");
                this.selenium = new WebDriverBackedSelenium(driver, "https://devpay.mobankdev.com/Management");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management");
                new MopayConsol().HomepageTabs(driver, this.selenium);
            }
            catch (Exception)
            {
            }
        }           

        public void mopaytestharnessexplorer()
        {
            try
            {
                IWebDriver driver = new InternetExplorerDriver(@"C:\Selenium\net40\");
                this.selenium = new WebDriverBackedSelenium(driver, "http://devpaytest.mobankdev.com/");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                driver.Navigate().GoToUrl("http://devpaytest.mobankdev.com/");
                new Mopay().MoPay(driver, this.selenium);
            }
            catch (Exception)
            {
            }
        }     

        public void moshopconsoleexplorer()
        {
            try
            {
                IWebDriver driver = new InternetExplorerDriver(@"C:\Selenium\net40\");
                this.selenium = new WebDriverBackedSelenium(driver, "https://qaadmin.mobankdev.com/");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                driver.Navigate().GoToUrl("https://qaadmin.mobankdev.com/");
               
            }
            catch (Exception)
            {
            }
        }
        public void mositemodroexplorer()
        {
            try
            {
                IWebDriver driver = new InternetExplorerDriver(@"C:\Selenium\net40\");
                this.selenium = new WebDriverBackedSelenium(driver, "https://qamodrophenia.mobankdev.com");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                driver.Navigate().GoToUrl("https://qamodrophenia.mobankdev.com");
                new MositeStart().Mositestart(driver, this.selenium);
            }
            catch (Exception)
            {
            }
        }

        #endregion

        public void tabletview()
        {
            IWebDriver driver = new AndroidDriver();
            driver.Navigate().GoToUrl("http://tablet.mobankdev.com");



        }
        public void mositemodroandroid()
        {
            try
            {
                IWebDriver driver = new AndroidDriver();
                this.selenium = new WebDriverBackedSelenium(driver, "https://qamodrophenia.mobankdev.com");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                driver.Navigate().GoToUrl("https://qamodrophenia.mobankdev.com");
                new MositeStart().Mositestart(driver, this.selenium);
            }
            catch (Exception)
            {
            }
        }                       

        #region UI 
        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }


       

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void NextMobi_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      
    }
}

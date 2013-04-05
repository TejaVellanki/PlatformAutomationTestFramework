namespace MoBankUI
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Android;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using Selenium;
    using System;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
       
        public WebDriverBackedSelenium selenium;       
        private CheckedListBox checkedListBox1;    
       
        private TextBox textBox1;
        private TextBox textbox3;
        private TextBox textbox4;
        private TextBox textBox2;

        public Form1()
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
                bool Mosite_TPS= this.checkBox13.Checked;
              

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
                #region TPS
                if (Mosite_TPS)
                {
                    if (this.textBox3.Text != null)
                    {
                        datarow_TPS datarowTPS = new datarow_TPS();
                        datarowTPS.colTPS();
                        string text = this.textBox3.Text;
                        if (text != "")
                        {
                            string[] strArray = text.Split(new char[] { ',' });
                            foreach (string str2 in strArray)
                            {
                                datarowTPS.dataflush();
                                this.mositetp(str2, datarowTPS);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Atleast One Merchant URL To Test in Text Field");
                        }
                        string emails = this.textBox4.Text;
                        datarowTPS.consolidatedreport(emails);
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

        public void mositetp(string url, datarow_TPS datarowTPS)
        {
            try
            {
                string items = null;
                foreach (object obj2 in this.checkedListBox1.CheckedItems)
                {
                    items = items + "," + obj2;
                }
                if (items == null)
                {
                    MessageBox.Show("Please Select Atleast One Functionality To Test From Options Available");
                }
                else
                {
                    IWebDriver driver = new FirefoxDriver();
                    this.selenium = new WebDriverBackedSelenium(driver, "https://qaadmin.mobankdev.com/");
                    this.selenium.Start();
                    this.selenium.WindowMaximize();
                    new BatchTesting().batchtesting(items, url, driver, this.selenium, datarowTPS);
                    new MositeGeneral().Mosite(driver, this.selenium, url, datarowTPS);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
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

      
    }
}

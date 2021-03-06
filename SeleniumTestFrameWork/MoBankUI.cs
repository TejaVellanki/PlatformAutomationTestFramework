﻿using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using MoBankUI.MoPay;
using MoBankUI.MoShop;
using MoBankUI.Mosite;
using MoBankUI.Mosite.Modrophenia;
using OpenQA.Selenium;
using OpenQA.Selenium.Android;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace MoBankUI
{
    public partial class Form1 : Form
    {
        /*
                private CheckedListBox _checkedListBox1;
        */
        /*
                private TextBox _textBox1;
        */
        /*
                private TextBox _textbox3;
        */
        /*
                private TextBox _textbox4;
        */
        private readonly TextBox _textBox2;


        public Form1(TextBox textBox2)
        {
            _textBox2 = textBox2;
            InitializeComponent();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                var mopaytestharness = checkBox15.Checked;
                var mopayconsole = checkBox16.Checked;
                var moshop = checkBox11.Checked;
                var moPayAccount = checkBox17.Checked;
                var moSite = checkBox12.Checked;
                var mositetps = checkBox13.Checked;
               

                if (mopaytestharness)
                {
                    Mopaytestharness();
                }
                if (mopayconsole)
                {
                    this.Mopayconsole();
                }
                if (moPayAccount)
                {
                    mopayaccountcreation();
                }
                if (moshop)
                {
                    Moshopconsole();
                }
                if (moSite)
                {
                    Mositemodro();
                }

                #region MositeTPS

                if (!mositetps) return;
                if (textBox3.Text != @"Please Enter Mosite URL's Seperated By Comma(,)")
                {
                    var datarow = new Datarow();
                    datarow.Col();
                    var urls = textBox3.Text;
                    if (urls != "")
                    {
                        //Seperating the URL's. 
                        var url = urls.Split(',');
                        foreach (var oneurl in url)
                        {
                            datarow.Dataflush();
                            Mositetp(oneurl, datarow);
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"Please Enter Atleast One Merchant URL To Test in Text Field");
                    }
                }

                else
                {
                    MessageBox.Show(@"Please Enter Atleast One Merchant URL To Test in Text Field");
                }

                #endregion
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        //tablet View Method which Initializes the process. 


        public void Mositemodroandroid()
        {

            IWebDriver driver = new AndroidDriver();
            driver.Navigate().GoToUrl("https://qamodrophenia.mobankdev.com");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://qamodrophenia.mobankdev.com");
            new MositeStart().Mositestart(driver);

        }

/*
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }
*/

        private void checkedListBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
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

/*
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
*/

/*
        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
        }
*/

/*
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
        }
*/

/*
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
        }
*/

/*
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
        }
*/

/*
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
*/

/*
        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }
*/

/*
        private void Form1_Load(object sender, EventArgs e)
        {
        }
*/


/*
        private void label1_Click(object sender, EventArgs e)
        {
        }
*/

/*
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
*/

/*
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
*/

/*
        private void Form1_Load_1(object sender, EventArgs e)
        {
        }
*/


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

        #region Firefox

        public void Mositetp(string url, Datarow datarow)
        {
            try
            {
                var item = checkedListBox3.CheckedItems.Cast<object>().Aggregate<object, string>(null, (current, items) => current + "," + items);

                if (item == null)
                {
                    MessageBox.Show(@"Please Select Atleast One Functionality To Test From Options Available");
                }
                else
                {
                    try
                    {
                        // Initialising the firefox driver                  

                        // An Static url should be given for the browser to launch. 

                        var prof = new FirefoxProfile();
                        //changing the User agent to Iphone 4.
                        prof.SetPreference("general.useragent.override",
                                           "Mozilla/5.0 (iPhone; U; CPU iPhone OS 4_0 like Mac OS X; en-us) AppleWebKit/532.9 (KHTML, like Gecko) Version/4.0.5 Mobile/8A293 Safari/6531.22.7");
                        IWebDriver driver = new FirefoxDriver(prof);
                        driver.Navigate().GoToUrl(url);

                        Thread.Sleep(2000);

                        var mobileurl = driver.Url;
                        datarow.Newrow("Mobile URL Validation", "Mobile URL", mobileurl,
                            mobileurl == url ? "FAIL" : "PASS", driver);

                        var testing = new BatchTesting();
                        testing.Batchtesting(item, url, driver, datarow);
                        var emails = _textBox2.Text;
                        var site = new MositeGeneral();
                        site.Finally(driver, url, datarow, emails);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                var u = ex.ToString();
                MessageBox.Show(u);
            }
        }

        public void mopayaccountcreation()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management");
            new MopayAccount().Create(driver);
        }

        public void Mopayconsole()
        {

            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management");
            new MopayConsol().HomepageTabs(driver);
        }

        public void Mopaytestharness()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://devpaytest.mobankdev.com/");
            new Mopay().MoPay(driver);
        }

        public void Moshopconsole()
        {
            try
            {
                var datarow = new Datarow();
                datarow.Col();

                var items = checkedListBox2.CheckedItems.Cast<object>().Aggregate<object, string>(null, (current, item) => current + (item + ","));
                var versions = checkedListBox5.CheckedItems.Cast<object>().Aggregate<object, string>(null, (current, version) => current + (version + ","));
                IWebDriver driver = new FirefoxDriver();
                driver.Navigate().GoToUrl("https://qaadmin.mobankdev.com/");
                var batch = new MoshopBatch();
                batch.Batchmoshop(driver, datarow, items, versions);
            }
            catch (Exception)
            {
            }
        }

        public void Mositemodro()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://qamodrophenia.mobankdev.com");
            new MositeStart().Mositestart(driver);
        }

        #endregion

        #region Chrome

        public void Mopayaccountcreationchrome()
        {
            IWebDriver driver = new ChromeDriver(@"C:\\net40\");

            driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management");
            new MopayAccount().Create(driver);
        }

        public void Mopayconsolechrome()
        {
            IWebDriver driver = new ChromeDriver(@"C:\\net40\");

            driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management");
            new MopayConsol().HomepageTabs(driver);
        }

        public void Mopaytestharnesschrome()
        {
            IWebDriver driver = new ChromeDriver(@"C:\\net40\");

            driver.Navigate().GoToUrl("http://devpaytest.mobankdev.com/");
            new Mopay().MoPay(driver);
        }

        public void Moshopconsolechrome()
        {
            IWebDriver driver = new ChromeDriver(@"C:\\net40\");
            driver.Navigate().GoToUrl("https://qaadmin.mobankdev.com/");
        }

        public void Mositemodrochrome()
        {
            IWebDriver driver = new ChromeDriver(@"C:\\net40\");
            driver.Navigate().GoToUrl("https://qamodrophenia.mobankdev.com");
            new MositeStart().Mositestart(driver);
        }

        #endregion

        #region Internet Explorer

        public void Mopayaccountcreationexplorer()
        {
            IWebDriver driver = new InternetExplorerDriver(@"C:\\net40\");
            driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management");
            new MopayAccount().Create(driver);
        }

        public void Mopayconsoleexplorer()
        {
            IWebDriver driver = new InternetExplorerDriver(@"C:\\net40\");
            driver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management");
            new MopayConsol().HomepageTabs(driver);
        }

        public void Mopaytestharnessexplorer()
        {
            IWebDriver driver = new InternetExplorerDriver(@"C:\\net40\");
            driver.Navigate().GoToUrl("http://devpaytest.mobankdev.com/");
            new Mopay().MoPay(driver);
        }

        public void Moshopconsoleexplorer()
        {
            IWebDriver driver = new InternetExplorerDriver(@"C:\\net40\");
            driver.Navigate().GoToUrl("https://qaadmin.mobankdev.com/");
        }

        public void Mositemodroexplorer()
        {
                IWebDriver driver = new InternetExplorerDriver(@"C:\\net40\");
                driver.Navigate().GoToUrl("https://qamodrophenia.mobankdev.com");
                new MositeStart().Mositestart(driver);
        }

        #endregion
    }
}
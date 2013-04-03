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
        private Button button1;
        private Button button2;
        private CheckBox checkBox1;
        private CheckBox checkBox10;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private CheckBox checkBox7;
        private CheckBox checkBox8;
        private CheckBox checkBox9;
        private CheckedListBox checkedListBox1;
        private CheckedListBox checkedListBox2;
        private CheckedListBox checkedListBox3;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Label label1;
        private Label label2;
        public WebDriverBackedSelenium selenium;
        private TextBox textBox1;
        private TextBox textBox2;

        public Form1()
        {
            this.InitializeComponent();
        }



        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                bool flag = this.checkBox15.Checked;
                bool flag2 = this.checkBox16.Checked;
                bool flag3 = this.checkBox11.Checked;
                bool flag4 = this.checkBox17.Checked;
                bool flag5 = this.checkBox12.Checked;
                bool flag9 = this.checkBox14.Checked;
                bool flag10 = this.checkBox13.Checked;


                if (flag)
                {
                    this.mopaytestharness();
                }
                if (flag2)
                {
                    this.mopayconsole();
                }
                if (flag4)
                {
                    this.mopayaccountcreation();
                }
                if (flag3)
                {
                    this.moshopconsole();
                }
                if (flag5)
                {
                    this.mositemodro();
                }
                if (flag10)
                {
                    if (this.textBox1.Text != "Please Enter Mosite URL's Seperated By Comma(,)")
                    {
                        datarow_TPS datarowTPS = new datarow_TPS();
                        datarowTPS.colTPS();
                        string text = this.textBox1.Text;
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
                        string emails = this.textBox2.Text;
                        datarowTPS.consolidatedreport(emails);
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Atleast One Merchant URL To Test in Text Field");
                    }
                }




            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }

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

        /* private void InitializeComponent()
          {
              this.button1 = new Button();
              this.checkBox1 = new CheckBox();
              this.checkBox2 = new CheckBox();
              this.checkBox3 = new CheckBox();
              this.checkBox4 = new CheckBox();
              this.checkBox5 = new CheckBox();
              this.checkBox6 = new CheckBox();
              this.checkBox7 = new CheckBox();
              this.checkBox8 = new CheckBox();
              this.checkBox9 = new CheckBox();
              this.checkBox10 = new CheckBox();
              this.textBox1 = new TextBox();
              this.checkedListBox1 = new CheckedListBox();
              this.groupBox1 = new GroupBox();
              this.groupBox2 = new GroupBox();
              this.groupBox3 = new GroupBox();
              this.groupBox4 = new GroupBox();
              this.textBox2 = new TextBox();
              this.label2 = new Label();
              this.label1 = new Label();
              this.button2 = new Button();
              this.checkedListBox2 = new CheckedListBox();
              this.checkedListBox3 = new CheckedListBox();
              this.groupBox1.SuspendLayout();
              this.groupBox2.SuspendLayout();
              this.groupBox3.SuspendLayout();
              this.groupBox4.SuspendLayout();
              base.SuspendLayout();
              this.button1.BackColor = Color.Transparent;
              this.button1.BackgroundImageLayout = ImageLayout.None;
              this.button1.ForeColor = SystemColors.ActiveCaptionText;
              this.button1.Location = new Point(0x1f, 0x319);
              this.button1.Name = "button1";
              this.button1.Size = new Size(0xd1, 0x21);
              this.button1.TabIndex = 0;
              this.button1.Text = "Run Selenium Test";
              this.button1.UseVisualStyleBackColor = false;
              this.button1.Click += new EventHandler(this.button1_Click_1);
              this.checkBox1.AutoSize = true;
              this.checkBox1.BackColor = Color.Transparent;
              this.checkBox1.ForeColor = SystemColors.ControlText;
              this.checkBox1.Location = new Point(13, 0x9e);
              this.checkBox1.Name = "checkBox1";
              this.checkBox1.Size = new Size(0x81, 0x11);
              this.checkBox1.TabIndex = 6;
              this.checkBox1.Text = "Mopay Test Harness";
              this.checkBox1.UseVisualStyleBackColor = false;
              this.checkBox2.AutoSize = true;
              this.checkBox2.BackColor = Color.Transparent;
              this.checkBox2.ForeColor = SystemColors.ActiveCaptionText;
              this.checkBox2.Location = new Point(0x13f, 0x9e);
              this.checkBox2.Name = "checkBox2";
              this.checkBox2.Size = new Size(0x6b, 0x11);
              this.checkBox2.TabIndex = 7;
              this.checkBox2.Text = "MoPay Console";
              this.checkBox2.UseVisualStyleBackColor = false;
              this.checkBox3.AutoSize = true;
              this.checkBox3.BackColor = Color.Transparent;
              this.checkBox3.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
              this.checkBox3.ForeColor = SystemColors.ActiveCaptionText;
              this.checkBox3.Location = new Point(13, 0x23);
              this.checkBox3.Name = "checkBox3";
              this.checkBox3.Size = new Size(0x53, 0x17);
              this.checkBox3.TabIndex = 8;
              this.checkBox3.Text = "Moshop";
              this.checkBox3.UseVisualStyleBackColor = false;
              this.checkBox4.AutoSize = true;
              this.checkBox4.BackColor = Color.Transparent;
              this.checkBox4.CheckAlign = ContentAlignment.TopLeft;
              this.checkBox4.FlatAppearance.BorderColor = Color.Black;
              this.checkBox4.ForeColor = SystemColors.ActiveCaptionText;
              this.checkBox4.Location = new Point(13, 0xc6);
              this.checkBox4.Name = "checkBox4";
              this.checkBox4.Size = new Size(0x9a, 0x11);
              this.checkBox4.TabIndex = 11;
              this.checkBox4.Text = "Mopay Account Creation";
              this.checkBox4.TextAlign = ContentAlignment.TopCenter;
              this.checkBox4.UseVisualStyleBackColor = false;
              this.checkBox4.CheckedChanged += new EventHandler(this.checkBox4_CheckedChanged);
              this.checkBox5.AutoSize = true;
              this.checkBox5.BackColor = Color.Transparent;
              this.checkBox5.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
              this.checkBox5.ForeColor = SystemColors.ActiveCaptionText;
              this.checkBox5.Location = new Point(0x13f, 0x23);
              this.checkBox5.Name = "checkBox5";
              this.checkBox5.Size = new Size(0x4c, 0x17);
              this.checkBox5.TabIndex = 12;
              this.checkBox5.Text = "Mosite";
              this.checkBox5.TextAlign = ContentAlignment.TopCenter;
              this.checkBox5.UseVisualStyleBackColor = false;
              this.checkBox5.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
              this.checkBox6.AutoSize = true;
              this.checkBox6.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
              this.checkBox6.ForeColor = SystemColors.ActiveCaptionText;
              this.checkBox6.Location = new Point(6, 0x19);
              this.checkBox6.Name = "checkBox6";
              this.checkBox6.Size = new Size(0x4c, 0x17);
              this.checkBox6.TabIndex = 13;
              this.checkBox6.Text = "FireFox";
              this.checkBox6.UseVisualStyleBackColor = true;
              this.checkBox6.CheckedChanged += new EventHandler(this.checkBox6_CheckedChanged);
              this.checkBox7.AutoSize = true;
              this.checkBox7.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
              this.checkBox7.ForeColor = SystemColors.ActiveCaptionText;
              this.checkBox7.Location = new Point(6, 0x33);
              this.checkBox7.Name = "checkBox7";
              this.checkBox7.Size = new Size(0x7d, 0x17);
              this.checkBox7.TabIndex = 14;
              this.checkBox7.Text = "Google Chrome";
              this.checkBox7.UseVisualStyleBackColor = true;
              this.checkBox8.AutoSize = true;
              this.checkBox8.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
              this.checkBox8.ForeColor = SystemColors.ActiveCaptionText;
              this.checkBox8.Location = new Point(6, 0x4a);
              this.checkBox8.Name = "checkBox8";
              this.checkBox8.Size = new Size(130, 0x17);
              this.checkBox8.TabIndex = 15;
              this.checkBox8.Text = "Internet Explorer";
              this.checkBox8.UseVisualStyleBackColor = true;
              this.checkBox9.AutoSize = true;
              this.checkBox9.Font = new Font("Times New Roman", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
              this.checkBox9.ForeColor = SystemColors.ActiveCaptionText;
              this.checkBox9.Location = new Point(6, 0x61);
              this.checkBox9.Name = "checkBox9";
              this.checkBox9.Size = new Size(0x4e, 0x17);
              this.checkBox9.TabIndex = 0x10;
              this.checkBox9.Text = "Android";
              this.checkBox9.UseVisualStyleBackColor = true;
              this.checkBox10.AutoSize = true;
              this.checkBox10.BackColor = Color.Transparent;
              this.checkBox10.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
              this.checkBox10.ForeColor = SystemColors.ActiveCaptionText;
              this.checkBox10.Location = new Point(0x13, 0x13);
              this.checkBox10.Name = "checkBox10";
              this.checkBox10.Size = new Size(0x74, 0x17);
              this.checkBox10.TabIndex = 0x12;
              this.checkBox10.Text = "Mosite _TPS";
              this.checkBox10.UseVisualStyleBackColor = false;
              this.checkBox10.CheckedChanged += new EventHandler(this.checkBox10_CheckedChanged);
              this.textBox1.BackColor = SystemColors.HighlightText;
              this.textBox1.ForeColor = SystemColors.WindowText;
              this.textBox1.Location = new Point(13, 0xf9);
              this.textBox1.Name = "textBox1";
              this.textBox1.Size = new Size(0x22e, 0x1a);
              this.textBox1.TabIndex = 0x13;
              this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
              this.checkedListBox1.BackColor = SystemColors.ActiveCaption;
              this.checkedListBox1.Font = new Font("Times New Roman", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
              this.checkedListBox1.FormattingEnabled = true;
              this.checkedListBox1.Items.AddRange(new object[] { "Test All Links in Mosite", "Test Footer Links", "Test Basket Functionality", "Test Product page - Test Add Product to Basket", "Test Delete From Basket - Test product Unavailable", "Test Registration/Login - CheckOut Pages", "Test Mopay" });
              this.checkedListBox1.Location = new Point(13, 0x1c);
              this.checkedListBox1.Name = "checkedListBox1";
              this.checkedListBox1.ScrollAlwaysVisible = true;
              this.checkedListBox1.Size = new Size(0x159, 0x7c);
              this.checkedListBox1.TabIndex = 20;
              this.checkedListBox1.SelectedIndexChanged += new EventHandler(this.checkedListBox1_SelectedIndexChanged_1);
              this.groupBox1.BackColor = SystemColors.ActiveCaption;
              this.groupBox1.Controls.Add(this.checkedListBox3);
              this.groupBox1.Controls.Add(this.checkedListBox2);
              this.groupBox1.Controls.Add(this.checkBox5);
              this.groupBox1.Controls.Add(this.checkBox3);
              this.groupBox1.Controls.Add(this.checkBox2);
              this.groupBox1.Controls.Add(this.checkBox1);
              this.groupBox1.Controls.Add(this.checkBox4);
              this.groupBox1.Font = new Font("Times New Roman", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
              this.groupBox1.Location = new Point(12, 0x1c);
              this.groupBox1.Name = "groupBox1";
              this.groupBox1.Size = new Size(0x261, 0xff);
              this.groupBox1.TabIndex = 0x16;
              this.groupBox1.TabStop = false;
              this.groupBox1.Text = "Framework-QA";
              this.groupBox2.Controls.Add(this.checkBox6);
              this.groupBox2.Controls.Add(this.checkBox7);
              this.groupBox2.Controls.Add(this.checkBox9);
              this.groupBox2.Controls.Add(this.checkBox8);
              this.groupBox2.Location = new Point(0x17f, 0x30);
              this.groupBox2.Name = "groupBox2";
              this.groupBox2.Size = new Size(0xc2, 0x9e);
              this.groupBox2.TabIndex = 0x17;
              this.groupBox2.TabStop = false;
              this.groupBox2.Text = "Browsers";
              this.groupBox3.Controls.Add(this.groupBox4);
              this.groupBox3.Controls.Add(this.textBox2);
              this.groupBox3.Controls.Add(this.label2);
              this.groupBox3.Controls.Add(this.label1);
              this.groupBox3.Controls.Add(this.checkBox10);
              this.groupBox3.Controls.Add(this.groupBox2);
              this.groupBox3.Controls.Add(this.textBox1);
              this.groupBox3.Font = new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
              this.groupBox3.Location = new Point(12, 0x181);
              this.groupBox3.Name = "groupBox3";
              this.groupBox3.Size = new Size(0x261, 0x185);
              this.groupBox3.TabIndex = 0x18;
              this.groupBox3.TabStop = false;
              this.groupBox3.Text = "Team TPS";
              this.groupBox4.Controls.Add(this.checkedListBox1);
              this.groupBox4.Location = new Point(6, 0x30);
              this.groupBox4.Name = "groupBox4";
              this.groupBox4.Size = new Size(0x173, 0x9e);
              this.groupBox4.TabIndex = 0x1b;
              this.groupBox4.TabStop = false;
              this.groupBox4.Text = "Select Options ";
              this.textBox2.Location = new Point(13, 0x13e);
              this.textBox2.Name = "textBox2";
              this.textBox2.Size = new Size(0x237, 0x1a);
              this.textBox2.TabIndex = 0x1a;
              this.textBox2.TextChanged += new EventHandler(this.textBox2_TextChanged);
              this.label2.AutoSize = true;
              this.label2.Location = new Point(0x10, 0x11d);
              this.label2.Name = "label2";
              this.label2.Size = new Size(0x12d, 0x13);
              this.label2.TabIndex = 0x19;
              this.label2.Text = "Email Addresses For the Reports to be Sent";
              this.label1.AutoSize = true;
              this.label1.Location = new Point(0x10, 0xdb);
              this.label1.Name = "label1";
              this.label1.Size = new Size(0x1c0, 0x13);
              this.label1.TabIndex = 0x18;
              this.label1.Text = "Please Enter Mosite URL's To Be Tested Seperated by Comma(,)";
              this.button2.Location = new Point(0x191, 0x319);
              this.button2.Name = "button2";
              this.button2.Size = new Size(0xb0, 0x21);
              this.button2.TabIndex = 0x19;
              this.button2.Text = "Stop Selenium Test";
              this.button2.UseVisualStyleBackColor = true;
              this.button2.Click += new EventHandler(this.button2_Click);
              this.checkedListBox2.BackColor = SystemColors.ActiveCaption;
              this.checkedListBox2.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
              this.checkedListBox2.FormattingEnabled = true;
              this.checkedListBox2.Items.AddRange(new object[] { "Validate Products Against Live Website", "General User Journey" });
              this.checkedListBox2.Location = new Point(0x149, 0x40);
              this.checkedListBox2.Name = "checkedListBox2";
              this.checkedListBox2.Size = new Size(0xfb, 0x48);
              this.checkedListBox2.TabIndex = 13;
              this.checkedListBox3.BackColor = SystemColors.ActiveCaption;
              this.checkedListBox3.Font = new Font("Times New Roman", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
              this.checkedListBox3.FormattingEnabled = true;
              this.checkedListBox3.Items.AddRange(new object[] { "Create a Test Shop", "Create a Test Scrape", "Run Manual Scarpe", "Validate Localisation Feature", "Vslidate Custom Domain Name Feature" });
              this.checkedListBox3.Location = new Point(0x26, 0x40);
              this.checkedListBox3.Margin = new Padding(3, 3, 3, 10);
              this.checkedListBox3.Name = "checkedListBox3";
              this.checkedListBox3.ScrollAlwaysVisible = true;
              this.checkedListBox3.Size = new Size(0xed, 0x48);
              this.checkedListBox3.TabIndex = 14;
             // base.AutoScaleMode = AutoScaleMode.None;
              this.BackColor = SystemColors.ActiveCaption;
              this.BackgroundImageLayout = ImageLayout.Zoom;
              base.ClientSize = new Size(0x282, 0x346);
              base.Controls.Add(this.button2);
              base.Controls.Add(this.groupBox3);
              base.Controls.Add(this.groupBox1);
              base.Controls.Add(this.button1);
              this.Font = new Font("Times New Roman", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
              base.FormBorderStyle = FormBorderStyle.Fixed3D;
              base.Name = "Form1";
              this.RightToLeft = RightToLeft.No;
              this.Text = "MoBank Selenium Automation Tool";
              base.TransparencyKey = Color.Blue;
              base.Load += new EventHandler(this.Form1_Load);
              this.groupBox1.ResumeLayout(false);
              this.groupBox1.PerformLayout();
              this.groupBox2.ResumeLayout(false);
              this.groupBox2.PerformLayout();
              this.groupBox3.ResumeLayout(false);
              this.groupBox3.PerformLayout();
              this.groupBox4.ResumeLayout(false);
              base.ResumeLayout(false);
          }
          */
        private void label1_Click(object sender, EventArgs e)
        {
        }

        public void mopayaccountcreation()
        {
            try
            {
                IWebDriver baseDriver = new FirefoxDriver();
                this.selenium = new WebDriverBackedSelenium(baseDriver, "https://devpay.mobankdev.com/Management");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                baseDriver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management");
                new MopayAccount().create(baseDriver, this.selenium);
            }
            catch (Exception)
            {
            }
        }

        public void mopayaccountcreationchrome()
        {
            try
            {
                IWebDriver baseDriver = new ChromeDriver(@"C:\Selenium\net40\");
                this.selenium = new WebDriverBackedSelenium(baseDriver, "https://devpay.mobankdev.com/Management");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                baseDriver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management");
                new MopayAccount().create(baseDriver, this.selenium);
            }
            catch (Exception)
            {
            }
        }

        public void mopayaccountcreationexplorer()
        {
            try
            {
                IWebDriver baseDriver = new InternetExplorerDriver(@"C:\Selenium\net40\");
                this.selenium = new WebDriverBackedSelenium(baseDriver, "https://devpay.mobankdev.com/Management");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                baseDriver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management");
                new MopayAccount().create(baseDriver, this.selenium);
            }
            catch (Exception)
            {
            }
        }

        public void mopayconsole()
        {
            try
            {
                IWebDriver baseDriver = new FirefoxDriver();
                this.selenium = new WebDriverBackedSelenium(baseDriver, "https://devpay.mobankdev.com/Management");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                baseDriver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management");
                new MopayConsol().HomepageTabs(baseDriver, this.selenium);
            }
            catch (Exception)
            {
            }
        }

        public void mopayconsolechrome()
        {
            try
            {
                IWebDriver baseDriver = new ChromeDriver(@"C:\Selenium\net40\");
                this.selenium = new WebDriverBackedSelenium(baseDriver, "https://devpay.mobankdev.com/Management");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                baseDriver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management");
                new MopayConsol().HomepageTabs(baseDriver, this.selenium);
            }
            catch (Exception)
            {
            }
        }

        public void mopayconsoleexplorer()
        {
            try
            {
                IWebDriver baseDriver = new InternetExplorerDriver(@"C:\Selenium\net40\");
                this.selenium = new WebDriverBackedSelenium(baseDriver, "https://devpay.mobankdev.com/Management");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                baseDriver.Navigate().GoToUrl("https://devpay.mobankdev.com/Management");
                new MopayConsol().HomepageTabs(baseDriver, this.selenium);
            }
            catch (Exception)
            {
            }
        }

        public void mopaytestharness()
        {
            try
            {
                IWebDriver baseDriver = new FirefoxDriver();
                this.selenium = new WebDriverBackedSelenium(baseDriver, "http://devpaytest.mobankdev.com/");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                baseDriver.Navigate().GoToUrl("http://devpaytest.mobankdev.com/");
                new Mopay().MoPay(baseDriver, this.selenium);
            }
            catch (Exception)
            {
            }
        }

        public void mopaytestharnesschrome()
        {
            try
            {
                IWebDriver baseDriver = new ChromeDriver(@"C:\Selenium\net40\");
                this.selenium = new WebDriverBackedSelenium(baseDriver, "http://devpaytest.mobankdev.com/");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                baseDriver.Navigate().GoToUrl("http://devpaytest.mobankdev.com/");
                new Mopay().MoPay(baseDriver, this.selenium);
            }
            catch (Exception)
            {
            }
        }

        public void mopaytestharnessexplorer()
        {
            try
            {
                IWebDriver baseDriver = new InternetExplorerDriver(@"C:\Selenium\net40\");
                this.selenium = new WebDriverBackedSelenium(baseDriver, "http://devpaytest.mobankdev.com/");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                baseDriver.Navigate().GoToUrl("http://devpaytest.mobankdev.com/");
                new Mopay().MoPay(baseDriver, this.selenium);
            }
            catch (Exception)
            {
            }
        }

        public void moshopconsole()
        {
            try
            {
                IWebDriver baseDriver = new FirefoxDriver();
                this.selenium = new WebDriverBackedSelenium(baseDriver, "https://qaadmin.mobankdev.com/");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                baseDriver.Navigate().GoToUrl("https://qaadmin.mobankdev.com/");
                new MoShopConsole().Homepagetabs(baseDriver, this.selenium);
            }
            catch (Exception)
            {
            }
        }

        public void moshopconsolechrome()
        {
            try
            {
                IWebDriver baseDriver = new ChromeDriver(@"C:\Selenium\net40\");
                this.selenium = new WebDriverBackedSelenium(baseDriver, "https://qaadmin.mobankdev.com/");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                baseDriver.Navigate().GoToUrl("https://qaadmin.mobankdev.com/");
                new MoShopConsole().Homepagetabs(baseDriver, this.selenium);
            }
            catch (Exception)
            {
            }
        }

        public void moshopconsoleexplorer()
        {
            try
            {
                IWebDriver baseDriver = new InternetExplorerDriver(@"C:\Selenium\net40\");
                this.selenium = new WebDriverBackedSelenium(baseDriver, "https://qaadmin.mobankdev.com/");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                baseDriver.Navigate().GoToUrl("https://qaadmin.mobankdev.com/");
                new MoShopConsole().Homepagetabs(baseDriver, this.selenium);
            }
            catch (Exception)
            {
            }
        }

        public void mositemodro()
        {
            try
            {
                IWebDriver baseDriver = new FirefoxDriver();
                this.selenium = new WebDriverBackedSelenium(baseDriver, "https://qamodrophenia.mobankdev.com");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                baseDriver.Navigate().GoToUrl("https://qamodrophenia.mobankdev.com");
                new MositeStart().Mositestart(baseDriver, this.selenium);
            }
            catch (Exception)
            {
            }
        }

        public void mositemodroandroid()
        {
            try
            {
                IWebDriver baseDriver = new AndroidDriver();
                this.selenium = new WebDriverBackedSelenium(baseDriver, "https://qamodrophenia.mobankdev.com");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                baseDriver.Navigate().GoToUrl("https://qamodrophenia.mobankdev.com");
                new MositeStart().Mositestart(baseDriver, this.selenium);
            }
            catch (Exception)
            {
            }
        }

        public void mositemodrochrome()
        {
            try
            {
                IWebDriver baseDriver = new ChromeDriver(@"C:\Selenium\net40\");
                this.selenium = new WebDriverBackedSelenium(baseDriver, "https://qamodrophenia.mobankdev.com");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                baseDriver.Navigate().GoToUrl("https://qamodrophenia.mobankdev.com");
                new MositeStart().Mositestart(baseDriver, this.selenium);
            }
            catch (Exception)
            {
            }
        }

        public void mositemodroexplorer()
        {
            try
            {
                IWebDriver baseDriver = new InternetExplorerDriver(@"C:\Selenium\net40\");
                this.selenium = new WebDriverBackedSelenium(baseDriver, "https://qamodrophenia.mobankdev.com");
                this.selenium.Start();
                this.selenium.WindowMaximize();
                baseDriver.Navigate().GoToUrl("https://qamodrophenia.mobankdev.com");
                new MositeStart().Mositestart(baseDriver, this.selenium);
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
                    IWebDriver baseDriver = new FirefoxDriver();
                    this.selenium = new WebDriverBackedSelenium(baseDriver, "https://qaadmin.mobankdev.com/");
                    this.selenium.Start();
                    this.selenium.WindowMaximize();
                    new BatchTesting().batchtesting(items, url, baseDriver, this.selenium, datarowTPS);
                    new MositeGeneral().Mosite(baseDriver, this.selenium, url, datarowTPS);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
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
    }
}

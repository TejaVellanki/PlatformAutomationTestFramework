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


namespace MoBankUI
{
    public class tabletbatchcs
    {
        public void user(IWebDriver driver)
        {
            new TabUserJour().tabuserjourney(driver);
        }
    }
}

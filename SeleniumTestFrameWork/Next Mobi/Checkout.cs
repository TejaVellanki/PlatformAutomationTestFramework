using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoBankUI;
using Selenium;
using System.Threading;
using System.Text.RegularExpressions;
using NUnit.Framework;


namespace Next_Mobi
{
    class Checkout
    {
        public void checkout(ISelenium selenium, datarow datarow)
        {
            try
            {
                selenium.Open("http://m.next.co.uk");
                selenium.WaitForPageToLoad("20000");
                selenium.Click("link=Clearance");
                selenium.WaitForPageToLoad("30000");
                selenium.Click("link=Womenswear");
                selenium.WaitForPageToLoad("20000");
           //     selenium.Click("link=Bags");
                selenium.Click("//html/body/div/div[3]/div[7]/ul/li/a");
                selenium.WaitForPageToLoad("30000");
                Thread.Sleep(3000);
                selenium.Click("//html/body/div/div[3]/div/div[2]/div/div[2]/div[4]/div/div/a/img");
         //       selenium.Click("/html/body/div/div[3]/div/div[2]/div/div[2]/div[2]/div/div/a/img");
                selenium.Click("//html/body/div/div[3]/div/div/div[2]/div/div/div/div[2]/div[2]/div/div[4]/a/span");
                Thread.Sleep(3000);
                selenium.Click("//html/body/div/div/a/span/span/img");
                selenium.Click("link=Men");
                selenium.WaitForPageToLoad("20000");
                selenium.Click("//html/body/div/div[3]/div[6]/ul/li[2]/a");
           //     selenium.Click("link=Bags & Wallets");
                selenium.WaitForPageToLoad("20000");
                selenium.Click("//html/body/div/div[3]/div/div[3]/div/div[3]/div/div/div/a/img");
                selenium.Click("//html/body/div/div[3]/div/div/div[2]/div/div/div/div[2]/div[2]/div/div[5]/a/span");
                selenium.Click("//html/body/div/div/div/ul/li/div/a/span/span/img");
                selenium.Click("//html/body/div/div[3]/div/div/div/div/div[2]/a/span");
                selenium.WaitForPageToLoad("30000");
                Thread.Sleep(3000);
                selenium.Type("id=email", "SQ119478");
                Thread.Sleep(1000);
                selenium.Type("id=password", "Tester1982");

                selenium.TypeKeys("id=password", "\\13");
          //      selenium.KeyDown("id=password", "\\13");
                Thread.Sleep(10000);
                selenium.Click("id=btnloginemail");
                selenium.WaitForPageToLoad("30000");
                Thread.Sleep(2000);

                datarow.newrow("Order Page", "Billing Address Page displayed", "As Expected", "PASS", selenium);
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Billing Address page not displayed", "Exception Not Expected", e, "FAIL", selenium);
            }



        }
    }
}

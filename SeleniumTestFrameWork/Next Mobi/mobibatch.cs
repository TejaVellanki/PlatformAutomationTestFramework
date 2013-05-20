using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Selenium;
using MoBankUI;

namespace Next_Mobi
{
    class mobibatch
    {
        public void nextmobi(IWebDriver driver, ISelenium selenium, datarow datarow, string items)
        {
            string[] selectedvalue = items.Split(',');
            int i = 0;
            foreach (string function in selectedvalue)
            {
                try
                {

                    if (function == "Mens")
                    {
                        Men men = new Men();
                        men.product(selenium, datarow);
                    }
                    if (function == "Clearance")
                    {
                        Clearance c = new Clearance();
                        c.clearance(selenium, datarow);
                        c.clear(selenium, datarow);
                    }
                }
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", selenium);


                }


            }
        }
    }
}
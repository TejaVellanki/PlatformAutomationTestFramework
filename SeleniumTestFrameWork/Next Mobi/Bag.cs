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
    class Bag
    {
        public void bag(ISelenium selenium, datarow datarow)

        {
            selenium.Open("http://m.next.co.uk");
            int add=1;
            try
            {
                selenium.Click("link=Men");
                {
                    selenium.WaitForPageToLoad("30000");
                    decimal count1 = selenium.GetXpathCount("//html/body/div/div[3]/div[6]/ul/li");

                    for (int a = 1; a <= 2;a++)
                    {
                        //if (a == 1)
                        //{
                            //clicking on Subcategory page  
                            selenium.Click("//html/body/div/div[3]/div[6]/ul/li[" + a + "]/a");
                            selenium.WaitForPageToLoad("30000");
                       //}


                        decimal count2 = selenium.GetXpathCount("//html/body/div/div[3]/div/div[3]/div/div[3]/div/div");
                        for (int j = 1; j <= 1; j++)
                        {
                            selenium.Click("//html/body/div/div[3]/div/div[3]/div/div[3]/div[" + j + "]/div/div/a/img");
                            selenium.WaitForPageToLoad("20000");
                            Variants v = new Variants();
                            v.variants(selenium, add, datarow);
                            add = add + 1;

                            selenium.WaitForPageToLoad("20000");
                            Thread.Sleep(2000);

                            selenium.Click("//html/body/div/div[3]/div/div/div/div/div/span/span/span");                  //Edit button 
                            Thread.Sleep(2000);
                            selenium.Click("//html/body/div/div[3]/div/div[3]/div/div/div[2]/div[2]/img");                //Delete button
                            Thread.Sleep(2000);

                            if (selenium.IsTextPresent("Sorry, Your current shopping bag is empty."))

                         //   if (Assert.IsTrue(selenium.IsTextPresent("Sorry, Your current shopping bag is empty.")))
                            {

                                datarow.newrow("Bag", "Bag Empty", "Sorry, Your current shopping bag is empty", "PASS", selenium);
                            }


                            else
                            {
                                datarow.newrow("Bag", "Bag Not Empty", "Bag not empty", "FAIL", selenium);
                            }
                            selenium.GoBack();
                            selenium.GoBack();
                        }
                        selenium.Open("http://m.next.co.uk/");
                        selenium.WaitForPageToLoad("30000");
                        selenium.Click("link=Men");
                        selenium.WaitForPageToLoad("30000");
                        Thread.Sleep(5000);
                    }
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

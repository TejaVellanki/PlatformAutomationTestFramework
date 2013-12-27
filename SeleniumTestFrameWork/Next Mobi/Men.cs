using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using MoBankUI;

namespace Next_Mobi
{
    class Men
    {
        public void product(ISelenium selenium,datarow datarow)
        {
            try
            {
                int add = 1;

                //Select Men
                selenium.Click("link=Men");

                // selenium.WaitForPageToLoad("30000");
                Thread.Sleep(6000);

                //Sub Category page category count (For loop for Selecting a sub category )
                               
                decimal count = selenium.GetXpathCount("//html/body/div/div[3]/div[6]/ul/li");

                for (int i = 1; i <= 2; )
                {
                    //clicking on Subcategory page  

                    if (i == 1)
                    {
                        selenium.Click("//html/body/div/div[3]/div[6]/ul/li[" + i + "]/a");
                        selenium.WaitForPageToLoad("30000");
                      //  i++; (Able to see Coats and jackets)
                    }

                    Thread.Sleep(2000);
                    string url = selenium.GetLocation();

                    try
                    {
                        if (selenium.IsElementPresent("id=Imgtoggle"))
                        {
                            datarow.newrow("Toggle", "Toggle should be Present", "id=Imgtoggle is Present", "PASS", selenium);
                        }
                        else
                        {
                            datarow.newrow("Toggle", "Toggle should be Present", "id=Imgtoggle is not Present", "FAIL", selenium);
                        }
                        if (selenium.IsElementPresent("id=ddlSort"))
                        {
                            datarow.newrow("Sort", "Sort button should be Present", "id=ddlSort is Present", "PASS", selenium);
                        }
                        else
                        {
                            datarow.newrow("Toggle", "Sort button should be Present", "id=ddlSort is not Present", "FAIL", selenium);
                        }
                        Thread.Sleep(5000);


                    }
                    catch (Exception ex)
                    {
                        string e = ex.ToString();
                        Console.WriteLine(e);
                    }

                    // product list
                    #region Productloop

                    decimal count1 = selenium.GetXpathCount("//html/body/div/div[3]/div/div[3]/div/div[3]/div/div");

                    for (int k = 1; k <= 1; k++)
                    {
                        selenium.Click("//html/body/div/div[3]/div/div[3]/div/div[3]/div[" + k + "]/div/div/a/img");
                        selenium.WaitForPageToLoad("30000");
                        Thread.Sleep(3000);                      

                        Variants v = new Variants();
                        v.variants(selenium, add,datarow);
                        add = add + 1;

                        selenium.Open(url);                       
                        selenium.WaitForPageToLoad("30000");
                    }

                    #endregion

                    selenium.Open("http://m.next.co.uk/");
                    selenium.WaitForPageToLoad("30000");
                    selenium.Click("link=Men");
                    selenium.WaitForPageToLoad("30000");
                    Thread.Sleep(5000);
                    i++;

                    //For Designer and Lipsy categories
                    //string subcatname = selenium.GetText("//html/body/div/div[3]/div[6]/ul/li[" + i + "]/a");

                    //if (i == 30)
                    //{
                    //    i = i + 2;
                    //    Thread.Sleep(2000);
                    //}


                    selenium.Click("//html/body/div/div[3]/div[6]/ul/li[" + i + "]/a");

                    selenium.WaitForPageToLoad("30000");

                }

                Thread.Sleep(3000);

            }

        catch (Exception ex)
         {
           string e = ex.ToString();
           datarow.newrow("Exception", "Exception Not Expected", e, "FAIL", selenium);
           }

            //finally
            //{
            //    selenium.Close();
            //}
        }

        
    }
}

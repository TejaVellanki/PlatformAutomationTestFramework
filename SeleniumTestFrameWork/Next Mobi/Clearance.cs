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
    public class Clearance
    {
        public string itemdescm;                                                                     //String to store title title of the product for mobi          
        public string itemidm;                                                                       //String to store item id for mobi
        public string oldpricem;
        public string newpricem;
        public string itemdesc;
        public string itemid;
        public string oldprice;
        public string newprice;
        public int k = 1;  //This element is declared so that the output in the report can be printed only in 1 row and not in 2 rows

        public void clearance(ISelenium selenium, datarow datarow)
        {

            try
            {
                //Reading Product from Clearance>Womenswear>Bags

                selenium.Open("http://m.next.co.uk");
                selenium.WaitForPageToLoad("20000");
                selenium.Click("link=Clearance");
                Thread.Sleep(6000);
                selenium.Click("link=Womenswear");
                selenium.WaitForPageToLoad("20000");
                selenium.Click("link=Bags");
                selenium.WaitForPageToLoad("30000");
                Thread.Sleep(3000);

               // selenium.Click("//html/body/div/div[3]/div/div[2]/div/div[2]/div[15]/div/div/a/img");                                        //Click the product 


                selenium.Click("//html/body/div/div[3]/div/div[2]/div/div[2]/div[19]/div/div/a/img");
                        
                selenium.WaitForPageToLoad("30000");

                itemdescm = selenium.GetText("//html/body/div/div[3]/div/div/div[2]/div/div/div/div/div/h1");                                         //Store the title of the product in this string
                
         
                Thread.Sleep(3000);
                itemidm=selenium.GetText("//html/body/div/div[3]/div/div/div[2]/div/div/div[2]/div[2]/div/div[2]");                              //Store Item id
                itemidm = itemidm.Remove(itemidm.LastIndexOf('G')); 

                Thread.Sleep(2000);
                oldpricem = selenium.GetText("//html/body/div/div[3]/div/div/div[2]/div/div/div[2]/div[2]/div/div[3]");                            //Store Old Price
                Thread.Sleep(3000);
                newpricem = selenium.GetText("//html/body/div/div[3]/div/div/div[2]/div/div/div[2]/div[2]/div/div[4]");                           //Store New Price

            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                Console.WriteLine(e);
            }

        }
        public void clear(ISelenium selenium, datarow datarow)
        {

            try
            {
                //Validating the product clicked before to desktop next site

                selenium.Open("http://www.next.co.uk/");                                                                              //Click Live Desktop site
                selenium.WaitForPageToLoad("20000");
                Thread.Sleep(2000);
                selenium.Click("link=Clearance");                                                                                     //Select Clearance
                Thread.Sleep(5000);
                selenium.Click("link=Womens");                                                                                       //Select Womens
                selenium.WaitForPageToLoad("20000");
                selenium.Select("id=group", "label=Bags");                                                                           //Select Bags from the dropdown
                selenium.Click("id=button2");                                                                                       //Click Search button
                selenium.WaitForPageToLoad("20000");

                decimal count = selenium.GetXpathCount("//html/body/div[2]/div[4]/form[2]/div/div");                                         //Count XPaths for all the items on this (Clearance>Bags) page
                try
                {
                    for (int i = 1; i <= count; i++)
                    {
                        try
                        {
                            itemdesc = selenium.GetText("//html/body/div[2]/div[4]/form[2]/div/div[" + i + "]/fieldset/h3/label");
                        }
                        catch (Exception ex)
                        {
                            string e = ex.ToString();
                           
                        }
                        
                        //Storing the text of all the Bags in this element 
                       
                            if (itemdesc == itemdescm)            //Item desc matches for both mobi and live
                            {
                                 string it=null;

                                itemid = selenium.GetText("//html/body/div[2]/div[4]/form[2]/div/div/fieldset/p[2]");
                                oldprice = selenium.GetText("//html/body/div[2]/div[4]/form[2]/div/div/fieldset/p[3]/strong");
                                newprice = selenium.GetText("//html/body/div[2]/div[4]/form[2]/div/div/fieldset/p[3]/strong[2]");

                                if (itemid.Contains("-"))
                                {
                                    itemid = itemid.Replace("-","");
                                    string [] item = itemid.Split('\r');
                                    foreach(string itm in item)
                                    {
                                       it = itm;
                                        break;                                      

                                    }
                                }

                              //  if(itemid.Contains("\r\n From Christmas Brochure 2012\r\nPage: 242\r\n\r\nSizes still available:\r\n ONE"))
                              // {
                             //      itemid = itemid.Replace("\r\n From Christmas Brochure 2012\r\nPage: 242\r\n\r\nSizes still available:\r\n ONE", "");
                                 //  itemid = itemid.Remove(itemid.LastIndexOf('\r'));
                                 //  itemid = itemid.TrimStart('\r', '\n');

                               // }

                                if (oldprice.Contains("Was"))
                                {
                                    oldprice = oldprice.Replace("Was", "was");
                                }
                                if (oldprice.Contains(":"))
                                {
                                    oldprice = oldprice.Replace(":","");
                                }
                                if (newprice.Contains(":"))
                                {
                                    newprice=newprice.Replace(":","");
                                }

                                //  if (it== itemidm && oldprice == oldpricem && newprice == newpricem)                                               //Comapring the item id,old price and new price

                                //  if (itemdesc == a && itemdesc == b && itemdesc == c && itemdesc == d)                                                //If the title,item number,old price and new price of Desktop Site = All the variants of Clearance Mobi       
                               
                                if (it == itemidm)
                                {
                                    datarow.newrow("Bag Title", "Product present", "As expected", "PASS", selenium);                                    //Then print Pass
                                    k++;                                                                                                               //This prevents from publishing the rows twice.It will only print 1 row per item
                                    
                                }
                                if (oldprice == oldpricem)
                                {
                                    datarow.newrow("Old Price","Old price matches","As expected","PASS",selenium);
                                }
                                if (newprice ==newpricem)
                                {
                                    datarow.newrow("New Price","New price matches","As expected","PASS",selenium);
                                }

                                break;
                            }
                        }
                    }
                
                catch (Exception ex)
                {
                    string e = ex.ToString();
                    Console.WriteLine(e);
                }
                    if (k == 1)                                                                                                                //This is the fail statement.
                  

                    {
                        datarow.newrow("Bag Name", "Product present", "Not As expected", "FAIL", selenium);                     //Else Print Fail

                    }

                }

            catch (Exception ex)
            {
                string e = ex.ToString();
                Console.WriteLine(e);
            }
        }
    
    }

    }


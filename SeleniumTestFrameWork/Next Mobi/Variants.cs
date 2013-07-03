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
    [TestFixture]
    public class Variants
    {

        [Test]
        public void variants(ISelenium selenium, int add,datarow datarow)
        {
            // selenium.WindowMaximize();



            //  ---------------------------------------------------------------------------------
            //   Selecting Men
            //    --------------------------------------------------------------------------------         


            try
            {

           

                string a = selenium.GetText("//html/body/div/div[3]/div/div/div[2]/div/div/div/div/div[2]/h1");
                string b = selenium.GetText("//div[@id='productImageAndActionContainer']/div[2]/div/div/div/div/div/select");
                string c = selenium.GetText("//div[@id='productImageAndActionContainer']/div[2]/div/div[2]/div/div/div/select");

          
                //Selecting Color/Variants
                if (selenium.IsElementPresent("//div[@id='productImageAndActionContainer']/div[2]/div/div/div/div/div/select"))
                {
                    string[] _col = selenium.GetSelectOptions("//div[@id='productImageAndActionContainer']/div[2]/div/div/div/div/div/select");
                    foreach (string value in _col)
                    {
                        if (value.Contains("Sold Out") || value.Contains("Select"))                          //Verifying Sold Out condition and Select Size
                        // if (value1 == &"Sold Out")
                        {
                            Console.WriteLine("Sold Out or Select Size");

                        }
                        else
                        {
                            selenium.Select("//div[@id='productImageAndActionContainer']/div[2]/div/div/div/div/div/select", value);
                        }

                    }
                }

                Thread.Sleep(3000);

                //Selecting Size 
                if (selenium.IsElementPresent("//div[@id='productImageAndActionContainer']/div[2]/div/div[2]/div/div/div/select"))
                {
                    string[] _size = selenium.GetSelectOptions("//div[@id='productImageAndActionContainer']/div[2]/div/div[2]/div/div/div/select");
                    foreach (string value1 in _size)
                    {
                        if (value1.Contains("Sold Out") || value1.Contains("Select"))                          //Verifying Sold Out condition
                        // if (value1 == &"Sold Out")
                        {
                            Console.WriteLine("Sold Out or Please");

                        }
                        else
                        {
                            selenium.Select("//div[@id='productImageAndActionContainer']/div[2]/div/div[2]/div/div/div/select", value1);      //Returning the products without Sold Out condition

                        }
                    }
                }
           
            //Add to Bag

         //   if (add == 1) (Just to add 1 item to bag)
         //   {
                selenium.Click("//div[@id='activeBtnAddToBag']/a/span");
                selenium.Click("//div[@id='mainmenu']/ul/li/div/a/span/span/img");
                selenium.WaitForPageToLoad("30000");

               

                string d = selenium.GetText("//html/body/div/div[3]/div/div[3]/div/div/div/h1[2]/span");
                string f = selenium.GetText("//html/body/div/div[3]/div/div[3]/div/div/div[2]/div/div[2]/div/label");
                string g = selenium.GetText("//html/body/div/div[3]/div/div[3]/div/div/div[2]/div/div[2]/div[2]/label[2]");

                //Comparision from Product Detail Page to Bag page
                if (a == d && b == f && c == g)
                {
                    Console.WriteLine("Script Successfull");
                }
                else
                {
                    Console.WriteLine("Script Fails");
                }

        //    }
            
               
               


            }
             catch (Exception ex)
            {
                string e = ex.ToString();
                Console.WriteLine(e);
                datarow.newrow("Exception", "Exception not Expected", e, "FAIL", selenium);
            }


        }
    }
}
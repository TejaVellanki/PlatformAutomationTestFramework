using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;
using Selenium;
using MoBankUI;

namespace Tablet_View
{
    class BlobStorage
    {
       public void Blob(ISelenium selenium,IWebDriver driver,datarow datarow)
       {
           // Validating the Cache control and Cache - Public
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://tablet.mobankdev.com");
          request.Method = "GET";
           request.ServicePoint.Expect100Continue = false;
           request.ContentType = "application/x-www-form-urlencoded";

          using (WebResponse response = request.GetResponse())
          {
              using (StreamReader reader = new StreamReader(response.GetResponseStream()))
              {
                 string responseString;
                 responseString = reader.ReadToEnd();
                 var rawHeaders = request.GetResponse().Headers.ToString();
                  if (rawHeaders.Contains("public"))
                  {
                      datarow.newrow("Cache Control", "Cache Control is Public", rawHeaders, "PASS");
                  }
                  else
                  {
                      datarow.newrow("Cache Control", "Cache Control is not Public", rawHeaders, "PASS");
                  }

              }
         }
           
           // Validating CSS URL from the page source
           string css = selenium.GetHtmlSource();
           string[] selectedvalue = css.Split('<');
           foreach (string s in selectedvalue)
           {
               string ss = s.ToString();
               if (ss.Contains("themes"))
               {
                   if (ss.Contains("http") || ss.Contains("https") || ss.Contains("blob"))
                   {
                       datarow.newrow("CSS Validation", "Http/Https and Blob shouldnot be contained inside the CSS Url", ss, "PASS");
                   }
                   else
                   {
                       datarow.newrow("CSS Validation", "Http/Https and Blob shouldnot be contained inside the CSS Url", ss, "FAIL");
                   }


                   break;
               }
           }
         
           Imagevalidation image = new Imagevalidation();
           image.homepageimage(driver,selenium,datarow);
        
          




       }

    }
}

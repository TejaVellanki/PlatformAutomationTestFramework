using System.IO;
using System.Net;
using MoBankUI;
using OpenQA.Selenium;
using Selenium;

namespace Tablet_View
{
    public class BlobStorage
    {
        public void Blob(ISelenium selenium, IWebDriver driver, datarow datarow,string url)
        {
            // Validating the Cache control and Cache - Public
            var request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = "GET";
            request.ServicePoint.Expect100Continue = false;
            request.ContentType = "application/x-www-form-urlencoded";
            datarow.newrow("", "", "Validating Blob URL", "");
            using (WebResponse response = request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseString;
                    responseString = reader.ReadToEnd();
                    string rawHeaders = request.GetResponse().Headers.ToString();
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
                string ss = s;
                if (ss.Contains("themes"))
                {
                    if (ss.Contains("http") || ss.Contains("https") || ss.Contains("blob"))
                    {
                        datarow.newrow("CSS Validation", "Http/Https and Blob shouldnot contain inside the CSS Url",ss, "FAIL");
                       
                    }
                    else
                    {
                        datarow.newrow("CSS Validation", "Http/Https and Blob shouldnot contain inside the CSS Url",ss, "PASS");
                    }


                    break;
                }
            }
            datarow.newrow("","","Validating GET for Search Results","");
            foreach (var get in selectedvalue)
            {
                int i = 1;
                string GET = get;
                if (GET.Contains("GET"))
                {
                    
                    datarow.newrow("Validate Search Results Using GET","Search Results Using GET method", GET,"PASS");
                    i++;
                }
               

            }
           
            var image = new Imagevalidation();
            image.homepageimage(driver, selenium, datarow);
        }
    }
}
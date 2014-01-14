using System;
using System.IO;
using System.Linq;
using System.Net;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MoBankUI
{
    public class BlobStorage
    {
        [Test]
        public void Blob(IWebDriver driver, Datarow datarow, string url)
        {
            try
            {
                // Validating the Cache control and Cache - Public
                var request = (HttpWebRequest) WebRequest.Create(url);
                request.Method = "GET";
                request.ServicePoint.Expect100Continue = false;
                request.ContentType = "application/x-www-form-urlencoded";
                datarow.newrow("", "", "Validating Blob URL", "");
                using (var response = request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        reader.ReadToEnd();
                        var rawHeaders = request.GetResponse().Headers.ToString();
                        if (rawHeaders.Contains("public"))
                        {
                            datarow.newrow("Cache Control", "Cache Control is Public", rawHeaders, "PASS");
                            var cache = rawHeaders.Split('f');
                            foreach (var s in cache.Where(s => s.Contains("Date")))
                            {
                                datarow.newrow("Cache Control", "Cache Limit is Set to 30 Mins", s, "PASS");
                            }
                        }
                        else
                        {
                            datarow.newrow("Cache Control", "Cache Control is not Public", rawHeaders, "PASS");
                        }
                    }
                }

                // Validating CSS URL from the page source
                var css = driver.PageSource;
                var selectedvalue = css.Split('<');
                foreach (var ss in selectedvalue.Where(ss => ss.Contains("themes")))
                {
                    if (ss.Contains("http") || ss.Contains("https") || ss.Contains("blob"))
                    {
                        datarow.newrow("CSS Validation", "Http/Https and Blob shouldnot contain inside the CSS Url",
                            ss, "FAIL");
                    }
                    else
                    {
                        datarow.newrow("CSS Validation", "Http/Https and Blob shouldnot contain inside the CSS Url",
                            ss, "PASS");
                    }


                    break;
                }
                datarow.newrow("", "", "Validating GET for Search Results", "");
                foreach (var GET in selectedvalue.Where(GET => GET.Contains("GET")))
                {
                    datarow.newrow("Validate Search Results Using GET", "Search Results Using GET method", GET,
                        "PASS");
                }

                var image = new Imagevalidation();
                image.Homepageimage(driver, datarow);
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
                datarow.newrow("Exception", "Exception Not Expected", e, "FAIL");
            }
        }
    }
}
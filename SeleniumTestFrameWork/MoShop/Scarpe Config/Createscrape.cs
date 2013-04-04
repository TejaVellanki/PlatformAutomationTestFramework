// Generated by .NET Reflector from C:\Program Files\Default Company Name\Selenium Test Tool\MoBankUI.exe
namespace MoBankUI
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Selenium;
    using System;
    using System.Threading;
    
    internal class Createscrape
    {
        public void createscrape(IWebDriver driver, ISelenium selenium, datarow datarow)
        {
            driver.Navigate().GoToUrl("https://qaadmin.mobankdev.com/");
            Thread.Sleep(0x1388);
            driver.FindElement(By.LinkText("Manage")).Click();
            selenium.WaitForPageToLoad("30000");
            string actual = driver.Title.ToString();
            if (actual == "mobank.co.uk/MoShop")
            {
                datarow.newrow("HomePage Title", "mobank.co.uk/MoShop", actual, "PASS", driver, selenium);
            }
            else
            {
                datarow.newrow("HomePage Title", "mobank.co.uk/MoShop", actual, "FAIL", driver, selenium);
            }
            driver.FindElement(By.LinkText("Scrapes")).Click();
            selenium.WaitForPageToLoad("30000");
            string str2 = driver.Title.ToString();
            if (str2 == "Scrapes : mobank.co.uk/MoShop")
            {
                datarow.newrow("Scrape Page Title", "Scrapes :  mobank.co.uk/MoShop", str2, "PASS", driver, selenium);
            }
            else
            {
                datarow.newrow("Scrape Page Title", "Scrapes :  mobank.co.uk/MoShop", str2, "FAIL", driver, selenium);
            }
           

            driver.FindElement(By.LinkText("Create")).Click();
            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).SendKeys("TestShop-Scrape");
            driver.FindElement(By.CssSelector("p.submit.submitInline > input.button")).Click();
            selenium.WaitForPageToLoad("30000");
            new SelectElement(driver.FindElement(By.Id("Profiles_0__Shop_Value"))).SelectByText("Test Shop");
            driver.FindElement(By.CssSelector("input.button")).Click();
            selenium.WaitForPageToLoad("30000");

            string str3 = driver.Title.ToString();
            if (str3 == "Scrape : mobank.co.uk/MoShop")
            {
                datarow.newrow("Scrape Title", "Scrape :  mobank.co.uk/MoShop", str3, "PASS", driver, selenium);
            }
            else
            {
                datarow.newrow("Scrape Title", "Scrape :  mobank.co.uk/MoShop", str3, "FAIL", driver, selenium);
            }
            driver.FindElement(By.Id("Profiles_0__RootUrl")).Clear();
            driver.FindElement(By.Id("Profiles_0__RootUrl")).SendKeys("http://www.the-tickle-company.co.uk/");
            new SelectElement(driver.FindElement(By.Id("Profiles_0__Encoding"))).SelectByText("iso-8859-1 - Western European (ISO)");
            driver.FindElement(By.CssSelector("input.button")).Click();
            selenium.WaitForPageToLoad("30000");
            string attribute = driver.FindElement(By.Id("Profiles_0__RootUrl")).GetAttribute("Value");
            string str5 = driver.FindElement(By.Id("Profiles_0__Encoding")).GetAttribute("Value");
            if (attribute == "http://www.the-tickle-company.co.uk/")
            {
                datarow.newrow("Root URL", "http://www.the-tickle-company.co.uk/", attribute, "PASS", driver, selenium);
            }
            else
            {
                datarow.newrow("Root URL", "http://www.the-tickle-company.co.uk/", attribute, "FAIL", driver, selenium);
            }
            driver.FindElement(By.Id("Pages_0__Name")).Clear();
            driver.FindElement(By.Id("Pages_0__Name")).SendKeys("Categories");
            new SelectElement(driver.FindElement(By.Id("Pages_0__ObjectTypeName"))).SelectByText("Category");
            driver.FindElement(By.CssSelector("input.button")).Click();
            selenium.WaitForPageToLoad("30000");
            string str6 = driver.FindElement(By.Id("Pages_0__Name")).GetAttribute("Value");
            string str7 = driver.FindElement(By.Id("Pages_0__ObjectTypeName")).GetAttribute("Value");
            if (str6 == "Categories")
            {
                datarow.newrow("Page Name", "Categories", str6, "PASS", driver, selenium);
            }
            else
            {
                datarow.newrow("Page Name", "Categories", str6, "FAIL", driver, selenium);
            }
            driver.FindElement(By.XPath("(//a[contains(text(),'…')])[2]")).Click();
            selenium.WaitForPageToLoad("30000");
            if(selenium.IsTextPresent("Server Error in '/' Application."))
            {
                selenium.GoBack();
                selenium.WaitForPageToLoad("30000");
                driver.FindElement(By.CssSelector("input.button")).Click();
                selenium.WaitForPageToLoad("30000");
                 driver.FindElement(By.XPath("(//a[contains(text(),'…')])[2]")).Click();
                 selenium.WaitForPageToLoad("30000");

            }
            new CategoryScrape().ScarpeCategory(driver, selenium, datarow);
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Android;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Android;


namespace MoBankUI
{
   
    public class TabUserJour
    {
      
        public void tabuserjourney(IWebDriver driver)
        {
          
            driver.FindElement(By.XPath("//div[@id='categoryList']/div/article/a/span")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(30));
            driver.FindElement(By.XPath("//div[@id='categoryList']/div/article/a/span")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(30));
            driver.FindElement(By.CssSelector("img[alt=\"Picture of Three Today Birthday Card\"]")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(30));
            driver.FindElement(By.CssSelector("button.ui-btn-hidden")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(30));
            driver.FindElement(By.XPath("//div[@id='notificationsPanel']/div/p")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(30));
            // Warning: verifyTextPresent may require manual changes
         
            driver.FindElement(By.CssSelector("#BasketInfo > span.ui-btn-inner > span.ui-btn-text")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(30));
            driver.FindElement(By.XPath("//div[@id='mainPage']/div[7]/div/div[2]/a/span/span")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(30));
            driver.FindElement(By.Id("FormData_0__Value")).Clear();
            driver.FindElement(By.Id("FormData_0__Value")).SendKeys("test");
            driver.FindElement(By.Id("FormData_1__Value")).Clear();
            driver.FindElement(By.Id("FormData_1__Value")).SendKeys("test");
            driver.FindElement(By.Id("FormData_2__Value")).Clear();
            driver.FindElement(By.Id("FormData_2__Value")).SendKeys("test");
            driver.FindElement(By.Id("FormData_3__Value")).Clear();
            driver.FindElement(By.Id("FormData_3__Value")).SendKeys("test");
            driver.FindElement(By.Id("FormData_4__Value")).Clear();
            driver.FindElement(By.Id("FormData_4__Value")).SendKeys("yesy");
            driver.FindElement(By.Id("FormData_5__Value")).Clear();
            driver.FindElement(By.Id("FormData_5__Value")).SendKeys("yesy");
            new SelectElement(driver.FindElement(By.Id("FormData_6__Value"))).SelectByText("United Kingdom");
            driver.FindElement(By.Id("FormData_7__Value")).Clear();
            driver.FindElement(By.Id("FormData_7__Value")).SendKeys("test");
            driver.FindElement(By.XPath("(//button[@type='submit'])[2]")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(30));
            driver.FindElement(By.XPath("//form[@id='checkoutForm']/section/div/div[3]/fieldset/div[2]/div/label/span/span[2]")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(30));
            driver.FindElement(By.XPath("(//button[@type='submit'])[2]")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(30));
            driver.FindElement(By.CssSelector("#PayButton > span.ui-btn-inner")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(30));
            new SelectElement(driver.FindElement(By.Id("Card_Type"))).SelectByText("Visa Debit");
            driver.FindElement(By.CssSelector("option[value=\"VDEB\"]")).Click();
            driver.FindElement(By.Id("Card_Name")).Clear();
            driver.FindElement(By.Id("Card_Name")).SendKeys("tst");
            new SelectElement(driver.FindElement(By.Id("Card_ExpiryDate_Month"))).SelectByText("11");
            new SelectElement(driver.FindElement(By.Id("Card_ExpiryDate_Year"))).SelectByText("20");
            driver.FindElement(By.Name("PostAction[Complete]")).Click();
            driver.FindElement(By.XPath("(//input[@name='PostAction[Complete]'])[2]")).Click();
            driver.Manage().Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(30));
        }
      
    }
}

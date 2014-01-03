using OpenQA.Selenium;

//using System.Drawing;

namespace TPS
{
    internal class countryhouseregister
    {
        public void register(IWebDriver driver)
        {
            //country house registration process

            driver.FindElement(By.Id("Pagecontent_TextBoxFirstName")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextBoxFirstName")).SendKeys("TEST");
            driver.FindElement(By.Id("Pagecontent_TextBoxLastName")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextBoxLastName")).SendKeys("TEST");
            driver.FindElement(By.Id("Pagecontent_TextBoxPostalCode")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextBoxPostalCode")).SendKeys("SE1 7TL");
            driver.FindElement(By.Id("Pagecontent_TextBoxStreetAddress")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextBoxStreetAddress")).SendKeys("TEST");
            driver.FindElement(By.Id("Pagecontent_TextBoxTown_City")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextBoxTown_City")).SendKeys("TEST");
            driver.FindElement(By.Id("Pagecontent_TextBoxTelephone")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextBoxTelephone")).SendKeys("01234567890");
            driver.FindElement(By.XPath("//form[@id='ctl00']/section/div[14]/div/label/span/span[2]")).Click();
            driver.FindElement(By.Id("Pagecontent_TextBoxPassword")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextBoxPassword")).SendKeys("M0Test08");
            driver.FindElement(By.Id("Pagecontent_TextBoxConfirmPassword")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextBoxConfirmPassword")).SendKeys("M0Test08");
            driver.FindElement(By.Id("Pagecontent_ButtonRegister")).Click();
            driver.FindElement(By.Id("Pagecontent_TextBoxStateText")).Clear();
            driver.FindElement(By.Id("Pagecontent_TextBoxStateText")).SendKeys("TEST");
            driver.FindElement(By.Id("Pagecontent_ButtonRegister")).Click();
        }
    }
}
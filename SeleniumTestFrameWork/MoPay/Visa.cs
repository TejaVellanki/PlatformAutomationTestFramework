// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe

using OpenQA.Selenium;

namespace MoBankUI.MoPay
{
    internal class VisaDebit
    {
        public void Visadebit(IWebDriver driver, Datarow datarow)
        {
            var attribute = driver.FindElement(By.Id("NumberPattern")).GetAttribute("value");
            if (attribute == "^4")
            {
                datarow.Newrow("Number Pattern", "^4", "^4", "PASS", driver);
            }
            else
            {
                datarow.Newrow("Number Pattern", "^4", attribute, "FAIL", driver);
            }
            var actual = driver.FindElement(By.Id("NumberMinLength")).GetAttribute("value");
            if (actual == "16")
            {
                datarow.Newrow("Minimum Length", "16", "16", "PASS", driver);
            }
            else
            {
                datarow.Newrow("Minimum Length", "16", actual, "FAIl", driver);
            }
            var str3 = driver.FindElement(By.Id("NumberMaxLength")).GetAttribute("value");
            datarow.Newrow("Minimum Length", "16", str3 == "16" ? "16" : str3, "PASS", driver);
            var str4 = driver.FindElement(By.Id("NumberChecksumResult")).GetAttribute("value");
            if (str4 == "0")
            {
                datarow.Newrow("NumberChecksumResult", "0", "0", "PASS", driver);
            }
            else
            {
                datarow.Newrow("NumberChecksumResult", "0", str4, "FAIL", driver);
            }
            var str5 = driver.FindElement(By.Id("SecurityCodeMinLength")).GetAttribute("value");
            if (str5 == "3")
            {
                datarow.Newrow("Security code Min Length", "3", "3", "PASS", driver);
            }
            else
            {
                datarow.Newrow("Security code Min Length", "3", str5, "FAIL", driver);
            }
            var str6 = driver.FindElement(By.Id("SecurityCodeMaxLength")).GetAttribute("value");
            if (str6 == "3")
            {
                datarow.Newrow("Security code Min Length", "3", "3", "PASS", driver);
            }
            else
            {
                datarow.Newrow("Security code Min Length", "3", str6, "FAIL", driver);
            }
        }
    }
}
// Generated by .NET Reflector from C:\Program Files\Default Company Name\ Test Tool\MoBankUI.exe

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriver_Refining; 

namespace MoBankUI
{
    internal class Addressconfig : driverdefining
    {
        public void addressconfig(IWebDriver driver, datarow datarow)
        {
            try
            {

            datarow.newrow("", "", "ADDRESS CONFIGURATION", "", driver);
            driver.FindElement(By.Id("DynamicSourceUrl")).Clear();
            driver.FindElement(By.Id("DynamicSourceUrl")).SendKeys("https://www.the-tickle-company.co.uk/cgi-bin/os000001.pl?ACTION=Start");
            Selectanoption(driver, By.Id("Method"), "POST");
            //new SelectElement(driver.FindElement(By.Id("Method"))).SelectByText("POST");
            driver.FindElement(By.Id("Url")).Clear();
            driver.FindElement(By.Id("Url")).SendKeys("https://www.the-tickle-company.co.uk/cgi-bin/os000001.pl");
            driver.FindElement(By.Id("LiveScrapeForm_HeaderSelector")).Clear();
            driver.FindElement(By.Id("LiveScrapeForm_HeaderSelector")).SendKeys("#idTableCheckoutSection h2");
            driver.FindElement(By.Id("LiveScrapeForm_SuccessSelector")).Clear();
            driver.FindElement(By.Id("LiveScrapeForm_SuccessSelector")).SendKeys("#GENERALHOWFOUND");
            driver.FindElement(By.Id("LiveScrapeForm_ErrorSelector")).Clear();
            driver.FindElement(By.Id("LiveScrapeForm_ErrorSelector")).SendKeys("#errormessage blockquote");
            driver.FindElement(By.Id("Parameters")).Clear();
            driver.FindElement(By.Id("Parameters")).SendKeys("RANDOM=0.346205551018105&SEQUENCE=0&ActCheckoutPhase=INVOICE&ActCheckoutPhase=DELIVER&ActCheckoutPhase=PRELIM&INVOICENAME={{FirstName}}+{{LastName}}&DELIVERNAME={{FirstName}}+{{LastName}}&INVOICEPOSTALCODE={{INVOICEPOSTALCODE}}&DELIVERPOSTALCODE={{INVOICEPOSTALCODE}}&INVOICEADDRESS1={{INVOICEADDRESS1}}&DELIVERADDRESS1={{INVOICEADDRESS1}}&INVOICEADDRESS2={{INVOICEADDRESS2}}&DELIVERADDRESS2={{INVOICEADDRESS2}}&INVOICEADDRESS3={{INVOICEADDRESS3}}&DELIVERADDRESS3={{INVOICEADDRESS3}}&LocationInvoiceCountry={{INVOICECOUNTRY}}&INVOICECOUNTRY={{INVOICECOUNTRY}}&LocationDeliveryCountry={{INVOICECOUNTRY}}&LocationInvoiceRegion=UndefinedRegion&INVOICEADDRESS4={{INVOICEADDRESS4}}&LocationDeliveryRegion=UndefinedRegion&DELIVERADDRESS4={{INVOICEADDRESS4}}&INVOICEPHONE={{INVOICEPHONE}}&DELIVERPHONE={{INVOICEPHONE}}&INVOICEEMAIL={{INVOICEEMAIL}}&DELIVEREMAIL={{INVOICEEMAIL}}&INVOICEEMAIL_CONFIRM={{INVOICEEMAIL}}&DELIVEREMAIL_CONFIRM={{INVOICEEMAIL}}&INVOICEUSERDEFINED={{INVOICEUSERDEFINED}}&ACTION_NEXT.x=87&ACTION_NEXT.y=12");
            driver.FindElement(By.CssSelector("input.button")).Click();
            waitforpagetoload(driver,30000);

            #region validations

            string attribute = driver.FindElement(By.Id("DynamicSourceUrl")).GetAttribute("Value");
            string actual = driver.FindElement(By.Id("Url")).GetAttribute("Value");
            string str3 = driver.FindElement(By.Id("LiveScrapeForm_HeaderSelector")).GetAttribute("Value");
            string str4 = driver.FindElement(By.Id("LiveScrapeForm_SuccessSelector")).GetAttribute("Value");
            string str5 = driver.FindElement(By.Id("LiveScrapeForm_ErrorSelector")).GetAttribute("Value");
            string str6 = driver.FindElement(By.Id("Parameters")).GetAttribute("Value");

           
            if (attribute == "https://www.the-tickle-company.co.uk/cgi-bin/os000001.pl?ACTION=Start")
            {
                datarow.newrow("Dynamic Source URL",
                               "https://www.the-tickle-company.co.uk/cgi-bin/os000001.pl?ACTION=Start", attribute,"PASS", driver);
            }
            else
            {
                datarow.newrow("Dynamic Source URL",
                               "https://www.the-tickle-company.co.uk/cgi-bin/os000001.pl?ACTION=Start", attribute,"FAIL", driver);
            }
            if (actual == "https://www.the-tickle-company.co.uk/cgi-bin/os000001.pl")
            {
                datarow.newrow("URL", "https://www.the-tickle-company.co.uk/cgi-bin/os000001.pl", actual, "PASS", driver);
            }
            else
            {
                datarow.newrow("URL", "https://www.the-tickle-company.co.uk/cgi-bin/os000001.pl", actual, "FAIL", driver);
            }
            if (str3 == "#idTableCheckoutSection h2")
            {
                datarow.newrow("Header Selector", "#idTableCheckoutSection h2", str3, "PASS", driver);
            }
            else
            {
                datarow.newrow("Header Selector", "#idTableCheckoutSection h2", str3, "FAIL", driver);
            }
            if (str4 == "#GENERALHOWFOUND")
            {
                datarow.newrow("Success Selector", "#GENERALHOWFOUND", str4, "PASS", driver);
            }
            else
            {
                datarow.newrow("Success Selector", "#GENERALHOWFOUND", str4, "FAIL", driver);
            }
            if (str5 == "#errormessage blockquote")
            {
                datarow.newrow("Error Selector", "#errormessage blockquote", str5, "PASS", driver);
            }
            else
            {
                datarow.newrow("Error Selector", "#errormessage blockquote", str5, "FAIL", driver);
            }
            if (str6 ==
                "RANDOM=0.346205551018105&SEQUENCE=0&ActCheckoutPhase=INVOICE&ActCheckoutPhase=DELIVER&ActCheckoutPhase=PRELIM&INVOICENAME={{FirstName}}+{{LastName}}&DELIVERNAME={{FirstName}}+{{LastName}}&INVOICEPOSTALCODE={{INVOICEPOSTALCODE}}&DELIVERPOSTALCODE={{INVOICEPOSTALCODE}}&INVOICEADDRESS1={{INVOICEADDRESS1}}&DELIVERADDRESS1={{INVOICEADDRESS1}}&INVOICEADDRESS2={{INVOICEADDRESS2}}&DELIVERADDRESS2={{INVOICEADDRESS2}}&INVOICEADDRESS3={{INVOICEADDRESS3}}&DELIVERADDRESS3={{INVOICEADDRESS3}}&LocationInvoiceCountry={{INVOICECOUNTRY}}&INVOICECOUNTRY={{INVOICECOUNTRY}}&LocationDeliveryCountry={{INVOICECOUNTRY}}&LocationInvoiceRegion=UndefinedRegion&INVOICEADDRESS4={{INVOICEADDRESS4}}&LocationDeliveryRegion=UndefinedRegion&DELIVERADDRESS4={{INVOICEADDRESS4}}&INVOICEPHONE={{INVOICEPHONE}}&DELIVERPHONE={{INVOICEPHONE}}&INVOICEEMAIL={{INVOICEEMAIL}}&DELIVEREMAIL={{INVOICEEMAIL}}&INVOICEEMAIL_CONFIRM={{INVOICEEMAIL}}&DELIVEREMAIL_CONFIRM={{INVOICEEMAIL}}&INVOICEUSERDEFINED={{INVOICEUSERDEFINED}}&ACTION_NEXT.x=87&ACTION_NEXT.y=12")
            {
                datarow.newrow("Parameters",
                               "RANDOM=0.346205551018105&SEQUENCE=0&ActCheckoutPhase=INVOICE&ActCheckoutPhase=DELIVER&ActCheckoutPhase=PRELIM&INVOICENAME={{FirstName}}+{{LastName}}&DELIVERNAME={{FirstName}}+{{LastName}}&INVOICEPOSTALCODE={{INVOICEPOSTALCODE}}&DELIVERPOSTALCODE={{INVOICEPOSTALCODE}}&INVOICEADDRESS1={{INVOICEADDRESS1}}&DELIVERADDRESS1={{INVOICEADDRESS1}}&INVOICEADDRESS2={{INVOICEADDRESS2}}&DELIVERADDRESS2={{INVOICEADDRESS2}}&INVOICEADDRESS3={{INVOICEADDRESS3}}&DELIVERADDRESS3={{INVOICEADDRESS3}}&LocationInvoiceCountry={{INVOICECOUNTRY}}&INVOICECOUNTRY={{INVOICECOUNTRY}}&LocationDeliveryCountry={{INVOICECOUNTRY}}&LocationInvoiceRegion=UndefinedRegion&INVOICEADDRESS4={{INVOICEADDRESS4}}&LocationDeliveryRegion=UndefinedRegion&DELIVERADDRESS4={{INVOICEADDRESS4}}&INVOICEPHONE={{INVOICEPHONE}}&DELIVERPHONE={{INVOICEPHONE}}&INVOICEEMAIL={{INVOICEEMAIL}}&DELIVEREMAIL={{INVOICEEMAIL}}&INVOICEEMAIL_CONFIRM={{INVOICEEMAIL}}&DELIVEREMAIL_CONFIRM={{INVOICEEMAIL}}&INVOICEUSERDEFINED={{INVOICEUSERDEFINED}}&ACTION_NEXT.x=87&ACTION_NEXT.y=12",str6, "PASS", driver);
            }
            else
            {
                datarow.newrow("Parameters",
                               "RANDOM=0.346205551018105&SEQUENCE=0&ActCheckoutPhase=INVOICE&ActCheckoutPhase=DELIVER&ActCheckoutPhase=PRELIM&INVOICENAME={{FirstName}}+{{LastName}}&DELIVERNAME={{FirstName}}+{{LastName}}&INVOICEPOSTALCODE={{INVOICEPOSTALCODE}}&DELIVERPOSTALCODE={{INVOICEPOSTALCODE}}&INVOICEADDRESS1={{INVOICEADDRESS1}}&DELIVERADDRESS1={{INVOICEADDRESS1}}&INVOICEADDRESS2={{INVOICEADDRESS2}}&DELIVERADDRESS2={{INVOICEADDRESS2}}&INVOICEADDRESS3={{INVOICEADDRESS3}}&DELIVERADDRESS3={{INVOICEADDRESS3}}&LocationInvoiceCountry={{INVOICECOUNTRY}}&INVOICECOUNTRY={{INVOICECOUNTRY}}&LocationDeliveryCountry={{INVOICECOUNTRY}}&LocationInvoiceRegion=UndefinedRegion&INVOICEADDRESS4={{INVOICEADDRESS4}}&LocationDeliveryRegion=UndefinedRegion&DELIVERADDRESS4={{INVOICEADDRESS4}}&INVOICEPHONE={{INVOICEPHONE}}&DELIVERPHONE={{INVOICEPHONE}}&INVOICEEMAIL={{INVOICEEMAIL}}&DELIVEREMAIL={{INVOICEEMAIL}}&INVOICEEMAIL_CONFIRM={{INVOICEEMAIL}}&DELIVEREMAIL_CONFIRM={{INVOICEEMAIL}}&INVOICEUSERDEFINED={{INVOICEUSERDEFINED}}&ACTION_NEXT.x=87&ACTION_NEXT.y=12",str6, "FAIL", driver);
            }

            #endregion

            new AddressElements().elements(driver,datarow);

            #region Validations

            string str13 = driver.FindElement(By.Id("LiveScrapeForm_Elements_0__Label")).GetAttribute("Value");
            if (str13 == "First Name: *")
            {
                datarow.newrow("First Name", "First Name: *", str13, "PASS", driver);
            }
            else
            {
                datarow.newrow("First Name", "First Name: *", str13, "FAIL", driver);
            }
            string str14 = Option(driver,By.Id("LiveScrapeForm_Elements_0__PropertyPath"),30);
            if (str14 == "FirstName")
            {
                datarow.newrow("FirstName Property", "FirstName", str14, "PASS", driver);
            }
            else
            {
                datarow.newrow("FirstName Property", "FirstName", str14, "FAIL", driver);
            }
            string str15 = driver.FindElement(By.Id("LiveScrapeForm_Elements_1__Label")).GetAttribute("Value");
            if (str15 == "Last Name: *")
            {
                datarow.newrow("LastName", "Last Name: *", str15, "PASS", driver);
            }
            else
            {
                datarow.newrow("LastName", "Last Name: *", str15, "FAIL", driver);
            }
            string str16 = Option(driver,By.Id("LiveScrapeForm_Elements_1__PropertyPath"),30);
            if (str16 == "LastName")
            {
                datarow.newrow("Last Name Property", "LastName", str16, "PASS", driver);
            }
            else
            {
                datarow.newrow("Last Name Property", "LastName", str16, "FAIL", driver);
            }
            string str17 = driver.FindElement(By.Id("LiveScrapeForm_Elements_2__Label")).GetAttribute("Value");
            if (str17 == "Post Code: *")
            {
                datarow.newrow("PostCode", "Post Code: *", str17, "PASS", driver);
            }
            else
            {
                datarow.newrow("PostCode", "Post Code: *", str17, "FAIL", driver);
            }
            string str18 = GetValue(driver,By.Id("LiveScrapeForm_Elements_2__LabelSelector"),30);
            if (str18 == ".actrequired:eq(1)")
            {
                datarow.newrow("PostCode Equation", ".actrequired:eq(1)", str18, "PASS", driver);
            }
            else
            {
                datarow.newrow("PostCode Equation", ".actrequired:eq(1)", str18, "FAIL", driver);
            }
            string str19 = Option(driver,By.Id("LiveScrapeForm_Elements_2__PropertyPath"),30);
            if (str19 == "PostCode")
            {
                datarow.newrow("Postcode Property", "PostCode", str19, "PASS", driver);
            }
            else
            {
                datarow.newrow("Postcode Property", "PostCode", str19, "FAIL", driver);
            }
            string str20 = driver.FindElement(By.Id("LiveScrapeForm_Elements_3__LabelSelector")).GetAttribute("Value");
            if (str20 == ".actrequired:eq(2)")
            {
                datarow.newrow("Address Equation", ".actrequired:eq(2)", str20, "PASS", driver);
            }
            else
            {
                datarow.newrow("Address Equation", ".actrequired:eq(2)", str20, "FAIL", driver);
            }
            string str21 = driver.FindElement(By.Id("LiveScrapeForm_Elements_3__Label")).GetAttribute("Value");
            if (str21 == "Address Line 1: *")
            {
                datarow.newrow("Address", "Address Line 1: *", str21, "PASS", driver);
            }
            else
            {
                datarow.newrow("Address", "Address Line 1: *", str21, "FAIL", driver);
            }
            string text = GetValue(driver, By.Id("id=LiveScrapeForm_Elements_3__PropertyPath"), 30);
            if (text == "Address1")
            {
                datarow.newrow("Address Property", "Address1", text, "PASS", driver);
            }
            else
            {
                datarow.newrow("Address Property", "Address1", text, "PASS", driver);
            }
            string str23 = driver.FindElement(By.Id("LiveScrapeForm_Elements_4__LabelSelector")).GetAttribute("Value");
            if (str23 == "#idBothAddressesTable tr:eq(5) td:eq(0)")
            {
                datarow.newrow("Address Equation2", "#idBothAddressesTable tr:eq(5) td:eq(0)", str23, "PASS", driver);
            }
            else
            {
                datarow.newrow("Address Equation2", "#idBothAddressesTable tr:eq(5) td:eq(0)", str23, "FAIL", driver);
            }
            string str24 = driver.FindElement(By.Id("LiveScrapeForm_Elements_4__Label")).GetAttribute("Value");
            if (str24 == "Address Line 2:")
            {
                datarow.newrow("Address2", "Address Line 2:", str24, "PASS", driver);
            }
            else
            {
                datarow.newrow("Address2", "Address Line 2:", str24, "FAIL", driver);
            }
            string str25 = Option(driver,By.Id("LiveScrapeForm_Elements_4__PropertyPath"),30);
            if (str25 == "Address2")
            {
                datarow.newrow("Address2Property", "Address2", str25, "PASS", driver);
            }
            else
            {
                datarow.newrow("Address2Property", "Address2", str25, "FAIL", driver);
            }
            string str26 = driver.FindElement(By.Id("LiveScrapeForm_Elements_5__LabelSelector")).GetAttribute("Value");
            if (str26 == ".actrequired:eq(3)")
            {
                datarow.newrow("City Equation", ".actrequired:eq(3)", str26, "PASS", driver);
            }
            else
            {
                datarow.newrow("City Equation", ".actrequired:eq(3)", str26, "FAIL", driver);
            }
            string str27 = driver.FindElement(By.Id("LiveScrapeForm_Elements_5__Label")).GetAttribute("Value");
            if (str27 == "City/Town: *")
            {
                datarow.newrow("Billing City", "City/Town: *", str27, "PASS", driver);
            }
            else
            {
                datarow.newrow("Billing City", "City/Town: *", str27, "FAIL", driver);
            }
            string str28 = Option(driver,By.Id("LiveScrapeForm_Elements_5__PropertyPath"),30);
            if (str28 == "BillingCity")
            {
                datarow.newrow("Billing City Property", "BillingCity", str28, "PASS", driver);
            }
            else
            {
                datarow.newrow("Billing City Property", "BillingCity", str28, "FAIL", driver);
            }
            string str29 = driver.FindElement(By.Id("LiveScrapeForm_Elements_6__LabelSelector")).GetAttribute("Value");
            if (str29 == "#idBothAddressesTable tr:eq(7) td:eq(0)")
            {
                datarow.newrow("Country Eqaution", "#idBothAddressesTable tr:eq(7) td:eq(0)", str29, "PASS", driver);
            }
            else
            {
                datarow.newrow("Country Eqaution", "#idBothAddressesTable tr:eq(7) td:eq(0)", str29, "FAIL", driver);
            }
            string str30 = driver.FindElement(By.Id("LiveScrapeForm_Elements_6__Label")).GetAttribute("Value");
            if (str30 == "Country: *")
            {
                datarow.newrow("Country", "Country: *", str30, "PASS", driver);
            }
            else
            {
                datarow.newrow("Country", "Country: *", str30, "FAIL", driver);
            }
            string str31 =
                driver.FindElement(By.Id("LiveScrapeForm_Elements_6__KeysValuesSelector")).GetAttribute("Value");
            if (str31 == "#lstInvoiceCountry option")
            {
                datarow.newrow("Country Option", "#lstInvoiceCountry option", str31, "PASS", driver);
            }
            else
            {
                datarow.newrow("Country Option", "#lstInvoiceCountry option", str31, "FAIL", driver);
            }
            string str32 = Option(driver,By.Id("LiveScrapeForm_Elements_6__PropertyPath"),30);
            if (str32 == "Country")
            {
                datarow.newrow("Country Property", "Country", str32, "PASS", driver);
            }
            else
            {
                datarow.newrow("Country Property", "Country", str32, "FAIL", driver);
            }
            if (driver.FindElement(By.Id("LiveScrapeForm_Elements_7__LabelSelector")).GetAttribute("Value") ==
                "#idBothAddressesTable tr:eq(8) td:eq(0)")
            {
                datarow.newrow("County Equation", "#idBothAddressesTable tr:eq(8) td:eq(0)", str29, "PASS", driver);
            }
            else
            {
                datarow.newrow("County Equation", "#idBothAddressesTable tr:eq(8) td:eq(0)", str29, "FAIL", driver);
            }
            string str34 = driver.FindElement(By.Id("LiveScrapeForm_Elements_7__Label")).GetAttribute("Value");
            if (str34 == "County:")
            {
                datarow.newrow("County", "County:", str34, "PASS", driver);
            }
            else
            {
                datarow.newrow("County", "County:", str34, "FAIL", driver);
            }
            string str35 = GetValue(driver,By.Id("LiveScrapeForm_Elements_7__PropertyPath"),30);
            if (str35 == "County")
            {
                datarow.newrow("County Property", "County", str35, "PASS", driver);
            }
            else
            {
                datarow.newrow("County Property", "County", str35, "PASS", driver);
            }
            string str36 = GetValue(driver,By.Id("LiveScrapeForm_Elements_8__LabelSelector"),30);
            if (str36 == "#idBothAddressesTable tr:eq(9) td:eq(0)")
            {
                datarow.newrow("Phone Equation", "#idBothAddressesTable tr:eq(9) td:eq(0)", str36, "PASS", driver);
            }
            else
            {
                datarow.newrow("Phone Equation", "#idBothAddressesTable tr:eq(9) td:eq(0)", str36, "FAIL", driver);
            }
            string str37 = driver.FindElement(By.Id("LiveScrapeForm_Elements_8__Label")).GetAttribute("Value");
            if (str37 == "Phone Number:")
            {
                datarow.newrow("Phone Number", "Phone Number:", str37, "PASS", driver);
            }
            else
            {
                datarow.newrow("Phone Number", "Phone Number:", str37, "FAIL", driver);
            }
            string str38 = Option(driver,By.Id("LiveScrapeForm_Elements_8__PropertyPath"),30);
            if (str38 == "Phone")
            {
                datarow.newrow("Phone Property", "Phone", str38, "PASS", driver);
            }
            else
            {
                datarow.newrow("Phone Property", "Phone", str38, "FAIL", driver);
            }
            string str39 = GetValue(driver,By.Id("LiveScrapeForm_Elements_9__LabelSelector"),30);
            if (str39 == "#idINVOICEEMAILlabel")
            {
                datarow.newrow("Email Equation", "#idINVOICEEMAILlabel", str39, "PASS", driver);
            }
            else
            {
                datarow.newrow("Email Equation", "#idINVOICEEMAILlabel", str39, "FAIL", driver);
            }
            string str40 = GetValue(driver,By.Id("LiveScrapeForm_Elements_9__Label"),30);
            if (str40 == "Email Address: *")
            {
                datarow.newrow("Email", "Email Address: *", str40, "PASS", driver);
            }
            else
            {
                datarow.newrow("Email", "Email Address: *", str40, "FAIL", driver);
            }
            string str41 = Option(driver,By.Id("LiveScrapeForm_Elements_9__PropertyPath"),30);
            if (str41 == "Email")
            {
                datarow.newrow("Email Property", "Email", str41, "PASS", driver);
            }
            else
            {
                datarow.newrow("Email Property", "Email", str41, "FAIL", driver);
            }

            #endregion


            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                datarow.newrow("Exception", "Exception not expectd", e, "FAIL");
            }

            new Delivery().delivery(driver, datarow);
        }
    }
}
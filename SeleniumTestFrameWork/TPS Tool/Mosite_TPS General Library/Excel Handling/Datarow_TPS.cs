using System;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;
using System.Data;
using System.Collections;
using System.Web;
using System.Drawing;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium;
using System.Data.OleDb;
using System.IO;
using System.Timers;
using System.Net;
using System.Net.Mail;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace MoBankUI
{
   
    public class datarow
    {
        GeneralLibrary generalLibrary;
        
        Screenshot screenshot = new Screenshot();
       
        System.Data.DataTable mergeTable = new System.Data.DataTable();
        System.Data.DataTable clonetable= new System.Data.DataTable();
        System.Data.DataTable dt = new System.Data.DataTable();
        string TotalPass = null;
        string TotalFail = null;
        public void dataflush()
        {
            dt.Clear();
        }
        public void col()
        {
            
            dt.Columns.Add("Field Validated");
            dt.Columns.Add("Expected Result");
            dt.Columns.Add("Actual Result");
            dt.Columns.Add("PASS or FAIL");
            dt.Columns.Add("Total Number Of Test Cases Passed/Failed");
            mergeTable.Columns.Add("Merchant Name");
            mergeTable.Columns.Add("Total Number of Test Cases Passed/Failed");

        }
        public void newrow(string validation, string expected, string actual, string passorfail, IWebDriver driver, ISelenium selenium)
        {
            DataRow newrow = dt.NewRow();
            newrow[0] = validation;
            newrow[1] = expected;
            newrow[2] = actual;
            newrow[3] = passorfail;
            dt.Rows.Add(newrow);
        }

        public void excelsave(string ReportName, IWebDriver driver, ISelenium selenium,string email)
        {
            try
            {

                int p = 0;
                int f = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string value = dt.Rows[i]["PASS or FAIL"].ToString();
                    if (value == "PASS")
                    {
                        p = p + 1;
                    }
                    if (value == "FAIL")
                    {
                        f = f + 1;
                    }

                }
                string P = p.ToString();
                string F = f.ToString();

                TotalPass = P + TotalPass;
                TotalFail = F + TotalFail;

                int d = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    if (d == 0)
                    {
                        //need to set value to MyRow column
                        dr[4] = "Total Number of Test Cases Passed" + "-" + P;
                    }
                    // or set it to some other value
                    if (d == 1)
                    {
                        dr[4] = "Total Number of Test Cases Failed" + "-" + F;
                        break;
                    }
                    d++;
                }

                generalLibrary = new GeneralLibrary();
                Workbook wb = generalLibrary.CreateAndOpenExcelFile(@"C:\Selenium\Input Data", ref ReportName, "Report", ".xlsx", false, true);
                Worksheet ws = wb.Sheets[1];
                generalLibrary.ConsolidatedXmlExportToExcelTPS(dt, ws, true, false, false);
                generalLibrary.SaveAndCloseExcelTPS(wb);
                GenerateEmail ghdg = new GenerateEmail();
                ghdg.SendEMail(ReportName,email);
                clonetable = dt.Copy();
                //mergeTable.Merge(clonetable);
                int s = 0;
                foreach (DataRow sourcerow in clonetable.Rows)
                {
                    if (s <= 2)
                    {
                        DataRow destRow = mergeTable.NewRow();
                        destRow["Total Number of Test Cases Passed/Failed"] = sourcerow["Total Number of Test Cases Passed/Failed"];
                        if (s == 0)
                        {
                            destRow["Merchant Name"] = ReportName;
                        }
                        mergeTable.Rows.Add(destRow);
                        s++;
                    }
                    else
                    {
                        break;
                    }
                }

                s = 0;

                dt.TableName = "MyTable";

                try
                {

                    ConverttoHTML Html = new ConverttoHTML();
                    Html.ConvertDataTableToHtml(dt, ReportName,P,F);
                }
                catch(Exception ex)
                {
                    

                }

                dt.WriteXml(@"C:\Selenium\Input Data\XML Reports\" + ReportName + ".xml");
                foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
                {
                    if (process.MainModule.ModuleName.ToUpper().Equals("EXCEL.EXE"))
                    {
                        process.Kill();
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                string e = ex.ToString();
               
            }
        }

        public void consolidatedreport(string emails)
        {
            try
            {
                int p = 0;
                int f = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string value = dt.Rows[i]["PASS or FAIL"].ToString();
                    if (value == "PASS")
                    {
                        p = p + 1;
                    }
                    if (value == "FAIL")
                    {
                        f = f + 1;
                    }

                }
                string P = p.ToString();
                string F = f.ToString();


                int d = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    if (d == 0)
                    {
                        //need to set value to MyRow column
                        dr[4] = "Total Number of Test Cases Passed" + "-" + P;
                    }
                    // or set it to some other value
                    if (d == 1)
                    {
                        dr[4] = "Total Number of Test Cases Failed" + "-" + F;
                        break;
                    }
                    d++;
                }

                string ReportName = "Consolidated Report";

                generalLibrary = new GeneralLibrary();

                Workbook wb = generalLibrary.CreateAndOpenExcelFile(@"C:\Selenium\Input Data", ref ReportName, "Report", ".xlsx", false, true);
                Worksheet ws = wb.Sheets[1];
                generalLibrary.ConsolidatedXmlExportToExcelTPS(mergeTable, ws, true, false, false);
                generalLibrary.SaveAndCloseExcelTPS(wb);
                GenerateEmail ghdg = new GenerateEmail();
                ghdg.SendEMail(ReportName, emails);
                
                try
                {
                    ConverttoHTML Html = new ConverttoHTML();
                    Html.ConvertDataTableToHtml(mergeTable, ReportName,P,F);
                }
                catch (Exception ex)
                {
                }
                foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
                {
                    if (process.MainModule.ModuleName.ToUpper().Equals("EXCEL.EXE"))
                    {
                        process.Kill();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
               
            }
            }
           
        
        



    }
}











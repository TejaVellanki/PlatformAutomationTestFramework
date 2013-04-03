// Generated by .NET Reflector from C:\Program Files\Default Company Name\Selenium Test Tool\MoBankUI.exe
namespace MoBankUI
{
    using Microsoft.Office.Interop.Excel;
    using OpenQA.Selenium;
    using Selenium;
    using System;
    using System.Data;
    using System.Diagnostics;
    
    public class datarow_TPS
    {
        private System.Data.DataTable clonetable = new System.Data.DataTable();
        private System.Data.DataTable dt = new System.Data.DataTable();
        private GeneralLibrary generalLibrary;
        private System.Data.DataTable mergeTable = new System.Data.DataTable();
        private MoBankUI.Screenshot screenshot = new MoBankUI.Screenshot();
        private string TotalFail = null;
        private string TotalPass = null;
        
        public void colTPS()
        {
            this.dt.Columns.Add("Field Validated");
            this.dt.Columns.Add("Expected Result");
            this.dt.Columns.Add("Actual Result");
            this.dt.Columns.Add("PASS or FAIL");
            this.dt.Columns.Add("Total Number Of Test Cases Passed/Failed");
            this.mergeTable.Columns.Add("Merchant Name");
            this.mergeTable.Columns.Add("Total Number of Test Cases Passed/Failed");
        }
        
        public void consolidatedreport(string emails)
        {
            try
            {
                string str4;
                int num = 0;
                int num2 = 0;
                for (int i = 0; i < this.dt.Rows.Count; i++)
                {
                    switch (this.dt.Rows[i]["PASS or FAIL"].ToString())
                    {
                        case "PASS":
                            num++;
                            break;
                        
                        case "FAIL":
                            num2++;
                            break;
                    }
                }
                string p = num.ToString();
                string f = num2.ToString();
                int num4 = 0;
                foreach (DataRow row in this.dt.Rows)
                {
                    switch (num4)
                    {
                        case 0:
                            row[4] = "Total Number of Test Cases Passed-" + p;
                            break;
                        
                        case 1:
                            row[4] = "Total Number of Test Cases Failed-" + f;
                            goto Label_0135;
                    }
                    num4++;
                }
            Label_0135:
                str4 = "Consolidated Report";
                this.generalLibrary = new GeneralLibrary();
                Workbook workbook = this.generalLibrary.CreateAndOpenExcelFile(@"C:\Selenium\Input Data", ref str4, "Report", ".xlsx", false, true);
                Worksheet ws = (Worksheet) workbook.Sheets[1];
                this.generalLibrary.ConsolidatedXmlExportToExcel(this.mergeTable, ws, true, false, false);
                this.generalLibrary.SaveAndCloseExcel(workbook);
                new GenerateEmail().SendEMail(str4, emails);
                try
                {
                    new ConverttoHTML().ConvertDataTableToHtml(this.mergeTable, str4, p, f);
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                }
                foreach (Process process in Process.GetProcessesByName("EXCEL"))
                {
                    if (process.MainModule.ModuleName.ToUpper().Equals("EXCEL.EXE"))
                    {
                        process.Kill();
                        return;
                    }
                }
            }
            catch (Exception exception2)
            {
                string str5 = exception2.ToString();
            }
        }
        
        public void dataflush()
        {
            this.dt.Clear();
        }
        
        public void excelsaveTPS(string ReportName, IWebDriver driver, ISelenium selenium)
        {
            try
            {
                int num = 0;
                int num2 = 0;
                for (int i = 0; i < this.dt.Rows.Count; i++)
                {
                    switch (this.dt.Rows[i]["PASS or FAIL"].ToString())
                    {
                        case "PASS":
                            num++;
                            break;
                        
                        case "FAIL":
                            num2++;
                            break;
                    }
                }
                string p = num.ToString();
                string f = num2.ToString();
                this.TotalPass = p + this.TotalPass;
                this.TotalFail = f + this.TotalFail;
                int num4 = 0;
                foreach (DataRow row in this.dt.Rows)
                {
                    switch (num4)
                    {
                        case 0:
                            row[4] = "Total Number of Test Cases Passed-" + p;
                            break;
                        
                        case 1:
                            row[4] = "Total Number of Test Cases Failed-" + f;
                            goto Label_015B;
                    }
                    num4++;
                }
            Label_015B:
                this.generalLibrary = new GeneralLibrary();
                Workbook workbook = this.generalLibrary.CreateAndOpenExcelFile(@"C:\Selenium\Input Data", ref ReportName, "Report", ".xlsx", false, true);
                Worksheet ws = (Worksheet) workbook.Sheets[1];
                this.generalLibrary.ConsolidatedXmlExportToExcel(this.dt, ws, true, false, false);
                this.generalLibrary.SaveAndCloseExcel(workbook);
                this.clonetable = this.dt.Copy();
                int num5 = 0;
                foreach (DataRow row2 in this.clonetable.Rows)
                {
                    if (num5 > 2)
                    {
                        break;
                    }
                    DataRow row3 = this.mergeTable.NewRow();
                    row3["Total Number of Test Cases Passed/Failed"] = row2["Total Number of Test Cases Passed/Failed"];
                    if (num5 == 0)
                    {
                        row3["Merchant Name"] = ReportName;
                    }
                    this.mergeTable.Rows.Add(row3);
                    num5++;
                }
                num5 = 0;
                this.dt.TableName = "MyTable";
                try
                {
                    new ConverttoHTML().ConvertDataTableToHtml(this.dt, ReportName, p, f);
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                }
                this.dt.WriteXml(@"C:\Selenium\Input Data\XML Reports\" + ReportName + ".xml");
                foreach (Process process in Process.GetProcessesByName("EXCEL"))
                {
                    if (process.MainModule.ModuleName.ToUpper().Equals("EXCEL.EXE"))
                    {
                        process.Kill();
                        return;
                    }
                }
            }
            catch (Exception exception2)
            {
                string str4 = exception2.ToString();
            }
        }
        
        public void newrowTPS(string validation, string expected, string actual, string passorfail, IWebDriver driver, ISelenium selenium)
        {
            DataRow row = this.dt.NewRow();
            row[0] = validation;
            row[1] = expected;
            row[2] = actual;
            row[3] = passorfail;
            this.dt.Rows.Add(row);
        }
    }
}

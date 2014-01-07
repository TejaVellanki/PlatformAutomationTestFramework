using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;
using DataTable = System.Data.DataTable;

namespace MoBankUI
{
    public class Datarow
    {
        public readonly DataTable mergeTable = new DataTable();
        public string TotalFail;
        public string TotalPass;
        public DataTable clonetable = new DataTable();
        public DataTable dt = new DataTable();
        public GeneralLibrary generalLibrary;

        private Screenshot screenshot = new Screenshot();

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

        public void newrow(string validation, string expected, string actual, string passorfail)
        {
            var newrow = dt.NewRow();

            newrow[0] = validation;
            newrow[1] = expected;
            newrow[2] = actual;
            newrow[3] = passorfail;
            dt.Rows.Add(newrow);
        }


        public void excelsave(string ReportName, IWebDriver driver, string email)
        {
            try
            {
                var p = 0;
                var f = 0;
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    var value = dt.Rows[i]["PASS or FAIL"].ToString();
                    if (value == "PASS")
                    {
                        p = p + 1;
                    }
                    if (value == "FAIL")
                    {
                        f = f + 1;
                    }
                }
                var P = p.ToString(CultureInfo.InvariantCulture);
                var F = f.ToString(CultureInfo.InvariantCulture);

                TotalPass = P + TotalPass;
                TotalFail = F + TotalFail;

                var d = 0;
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
                var wb = generalLibrary.CreateAndOpenExcelFile(@"C:\Selenium\Input Data", ref ReportName, "Report",
                                                                    ".xlsx", false, true);
                Worksheet ws = wb.Sheets[1];
                generalLibrary.ConsolidatedXmlExportToExcel(dt, ws, true, false, false);
                generalLibrary.SaveAndCloseExcel(wb);
                var ghdg = new GenerateEmail();
                ghdg.SendEMail(ReportName, email);
                clonetable = dt.Copy();
                //mergeTable.Merge(clonetable);
                var s = 0;
                foreach (DataRow sourcerow in clonetable.Rows)
                {
                    if (s <= 2)
                    {
                        var destRow = mergeTable.NewRow();
                        destRow["Total Number of Test Cases Passed/Failed"] =
                            sourcerow["Total Number of Test Cases Passed/Failed"];
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

                dt.TableName = "MyTable";

                try
                {
                    var Html = new ConverttoHtml();
                    Html.ConvertDataTableToHtml(dt, ReportName, P, F);
                }
                catch (Exception ex)
                {
                }

                dt.WriteXml(@"C:\Selenium\Input Data\XML Reports\" + ReportName + ".xml");
                foreach (var process in Process.GetProcessesByName("EXCEL"))
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
                var e = ex.ToString();
            }
        }

        public void consolidatedreport(string emails)
        {
            try
            {
                var p = 0;
                var f = 0;
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    var value = dt.Rows[i]["PASS or FAIL"].ToString();
                    if (value == "PASS")
                    {
                        p = p + 1;
                    }
                    if (value == "FAIL")
                    {
                        f = f + 1;
                    }
                }
                var P = p.ToString(CultureInfo.InvariantCulture);
                var F = f.ToString(CultureInfo.InvariantCulture);


                var d = 0;
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

                var ReportName = "Consolidated Report";

                generalLibrary = new GeneralLibrary();

                var wb = generalLibrary.CreateAndOpenExcelFile(@"C:\Selenium\Input Data", ref ReportName, "Report",
                                                                    ".xlsx", false, true);
                Worksheet ws = wb.Sheets[1];
                generalLibrary.ConsolidatedXmlExportToExcel(mergeTable, ws, true, false, false);
                generalLibrary.SaveAndCloseExcel(wb);
                var ghdg = new GenerateEmail();
                ghdg.SendEMail(ReportName, emails);

                try
                {
                    var Html = new ConverttoHtml();
                    Html.ConvertDataTableToHtml(mergeTable, ReportName, P, F);
                }
                catch (Exception ex)
                {
                }
                foreach (var process in Process.GetProcessesByName("EXCEL"))
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
                var e = ex.ToString();
            }
        }

        public void newrow(string validation, string expected, string actual, string passorfail, IWebDriver driver)
        {
            var newrow = dt.NewRow();
            newrow[0] = validation;
            newrow[1] = expected;
            newrow[2] = actual;
            newrow[3] = passorfail;
            dt.Rows.Add(newrow);
        }
    }
}
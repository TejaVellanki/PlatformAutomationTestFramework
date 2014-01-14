using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;
using DataTable = System.Data.DataTable;

namespace MoBankUI
{
    public class Datarow
    {
        public readonly DataTable MergeTable = new DataTable();
        public string TotalFail;
        public string TotalPass;
        public DataTable Clonetable = new DataTable();
        public DataTable Dt = new DataTable();
        public GeneralLibrary GeneralLibrary;

/*
        private Screenshot screenshot = new Screenshot();
*/

        public void Dataflush()
        {
            Dt.Clear();
        }

        public void Col()
        {
            Dt.Columns.Add("Field Validated");
            Dt.Columns.Add("Expected Result");
            Dt.Columns.Add("Actual Result");
            Dt.Columns.Add("PASS or FAIL");
            Dt.Columns.Add("Total Number Of Test Cases Passed/Failed");
            MergeTable.Columns.Add("Merchant Name");
            MergeTable.Columns.Add("Total Number of Test Cases Passed/Failed");
        }

        public void Newrow(string validation, string expected, string actual, string passorfail)
        {
            var newrow = Dt.NewRow();

            newrow[0] = validation;
            newrow[1] = expected;
            newrow[2] = actual;
            newrow[3] = passorfail;
            Dt.Rows.Add(newrow);
        }


        public void excelsave(string ReportName, IWebDriver driver, string email)
        {
            try
            {
                var p = 0;
                var f = 0;
                for (var i = 0; i < Dt.Rows.Count; i++)
                {
                    var value = Dt.Rows[i]["PASS or FAIL"].ToString();
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
                foreach (DataRow dr in Dt.Rows)
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

                GeneralLibrary = new GeneralLibrary();
                var wb = GeneralLibrary.CreateAndOpenExcelFile(@"C:\Selenium\Input Data", ref ReportName, "Report",
                                                                    ".xlsx", false, true);
                Worksheet ws = wb.Sheets[1];
                GeneralLibrary.ConsolidatedXmlExportToExcel(Dt, ws, true, false, false);
                GeneralLibrary.SaveAndCloseExcel(wb);
                var ghdg = new GenerateEmail();
                ghdg.SendEMail(ReportName, email);
                Clonetable = Dt.Copy();
                //mergeTable.Merge(clonetable);
                var s = 0;
                foreach (DataRow sourcerow in Clonetable.Rows)
                {
                    if (s <= 2)
                    {
                        var destRow = MergeTable.NewRow();
                        destRow["Total Number of Test Cases Passed/Failed"] =
                            sourcerow["Total Number of Test Cases Passed/Failed"];
                        if (s == 0)
                        {
                            destRow["Merchant Name"] = ReportName;
                        }
                        MergeTable.Rows.Add(destRow);
                        s++;
                    }
                    else
                    {
                        break;
                    }
                }

                Dt.TableName = "MyTable";

                var Html = new ConverttoHtml();
                Html.ConvertDataTableToHtml(Dt, ReportName, P, F);

                Dt.WriteXml(@"C:\Selenium\Input Data\XML Reports\" + ReportName + ".xml");
                foreach (var process in Process.GetProcessesByName("EXCEL").Where(process => process.MainModule.ModuleName.ToUpper().Equals("EXCEL.EXE")))
                {
                    process.Kill();
                    break;
                }
            }
            catch (Exception)
            {
            }
        }

        public void consolidatedreport(string emails)
        {
            try
            {
                var p = 0;
                var f = 0;
                for (var i = 0; i < Dt.Rows.Count; i++)
                {
                    var value = Dt.Rows[i]["PASS or FAIL"].ToString();
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
                foreach (DataRow dr in Dt.Rows)
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

                GeneralLibrary = new GeneralLibrary();

                var wb = GeneralLibrary.CreateAndOpenExcelFile(@"C:\Selenium\Input Data", ref ReportName, "Report",
                                                                    ".xlsx", false, true);
                Worksheet ws = wb.Sheets[1];
                GeneralLibrary.ConsolidatedXmlExportToExcel(MergeTable, ws, true, false, false);
                GeneralLibrary.SaveAndCloseExcel(wb);
                var ghdg = new GenerateEmail();
                ghdg.SendEMail(ReportName, emails);

                var Html = new ConverttoHtml();
                Html.ConvertDataTableToHtml(MergeTable, ReportName, P, F);

                foreach (var process in Process.GetProcessesByName("EXCEL").Where(process => process.MainModule.ModuleName.ToUpper().Equals("EXCEL.EXE")))
                {
                    process.Kill();
                    break;
                }
            }
            catch (Exception)
            {
            }
        }

        public void Newrow(string validation, string expected, string actual, string passorfail, IWebDriver driver)
        {
            var newrow = Dt.NewRow();
            newrow[0] = validation;
            newrow[1] = expected;
            newrow[2] = actual;
            newrow[3] = passorfail;
            Dt.Rows.Add(newrow);
        }
    }
}
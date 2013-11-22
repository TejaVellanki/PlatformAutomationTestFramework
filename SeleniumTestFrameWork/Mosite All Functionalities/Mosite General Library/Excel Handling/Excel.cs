using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace MoBankUI
{
    public class GeneralLibrary
    {
        private Application xlApp;

        #region GetExcelData

        /// <summary>
        ///     GetExcelData
        /// </summary>
        /// <param name="excelFile"></param>
        /// <param name="sheetname"></param>
        /// <returns></returns>
        public DataSet GetExcelData(string excelFile, string sheetname)
        {
            var recordTypes = new List<string>();

            string sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + excelFile + ";" +
                                       "Extended Properties=Excel 12.0;";

            var objConn = new OleDbConnection(sConnectionString);

            objConn.Open();

            string sqlquery = "SELECT * FROM [" + sheetname + "$]";

            var objCmdSelect = new OleDbCommand(sqlquery, objConn);

            var objAdapter1 = new OleDbDataAdapter();

            objAdapter1.SelectCommand = objCmdSelect;

            var objDataset = new DataSet();

            objDataset.Locale = CultureInfo.InvariantCulture;

            objAdapter1.Fill(objDataset);

            objConn.Close();

            return objDataset;
        }

        #endregion

        #region CreateAndOpenExcelFile

        /// <summary>
        ///  CreateAndOpenExcelFile
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <param name="sheetName"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public Workbook CreateAndOpenExcelFile(string filePath, ref string fileName, string sheetName, string extension,
                                               bool displayAlerts, bool appendDateField)
        {
            try
            {
                xlApp = new Application();

                xlApp.DisplayAlerts = displayAlerts;

                xlApp.ScreenUpdating = displayAlerts;

                xlApp.Visible = displayAlerts;

                xlApp.UserControl = displayAlerts;

                xlApp.Interactive = displayAlerts;

                if (appendDateField)
                {
                    string randomNumber = GenerateRandomNumber();

                    fileName = fileName + "-" + randomNumber;
                }


                Workbook workbook = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);

                workbook.SaveAs(filePath + "\\" + fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing,
                                Type.Missing,
                                Type.Missing);

                if (!String.IsNullOrEmpty(sheetName))
                {
                    Sheets sheets = workbook.Worksheets;

                    int currentSheetCount = workbook.Sheets.Count;

                    var reqSheetConsolidated = (Worksheet)sheets.Item[currentSheetCount];

                    var newSheetConsolidated =
                        (Worksheet)sheets.Add(Type.Missing, reqSheetConsolidated, 1, Type.Missing);

                    newSheetConsolidated.Name = sheetName;

                    for (int sheetCount = 1; sheetCount <= workbook.Sheets.Count; sheetCount++)
                    {
                        var verSheet = (Worksheet)workbook.Worksheets.get_Item(sheetCount);

                        if ("Sheet1" == verSheet.Name)
                        {
                            verSheet.Delete();

                            workbook.Save();

                            break;
                        }
                    }
                }


                return workbook;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region GenerateRandomNumber

        public string GenerateRandomNumber()
        {
            string randomNumber = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture) + "-" +
                                  DateTime.Now.Month.ToString(CultureInfo.InvariantCulture) + "-"
                                  +
                                  DateTime.Now.Day.ToString(CultureInfo.InvariantCulture) + "_"
                                  +
                                  DateTime.Now.Hour.ToString(CultureInfo.InvariantCulture) + "-"
                                  +
                                  DateTime.Now.Minute.ToString(CultureInfo.InvariantCulture) + "-"
                                  +
                                  DateTime.Now.Second.ToString(CultureInfo.InvariantCulture);

            return randomNumber;
        }

        #endregion

        #region SaveAndCloseExcel

        public void SaveAndCloseExcel(_Workbook workbook)
        {
            for (int sheetCount = 1; sheetCount <= workbook.Sheets.Count; sheetCount++)
            {
                var verSheet = (Worksheet)workbook.Worksheets.get_Item(sheetCount);

                if ("Sheet1" == verSheet.Name)
                {
                    workbook.Save();

                    verSheet.Delete();

                    workbook.Save();

                    break;
                }
            }

            workbook.Save();

            workbook.Close(null, null, null);

            if (xlApp != null)
            {
                xlApp.Quit();

                xlApp =
                    null;
            }

            GC.Collect();
        }

        #endregion

        #region ConsolidatedXMLExportToExcel

        /// <summary>
        ///     ConsolidatedXMLExportToExcel
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ws"></param>
        /// <param name="statusFlag"></param>
        public string ConsolidatedXmlExportToExcel(DataTable dt, _Worksheet ws, bool nextRow, bool isCompare,
                                                   bool isPolicyWiseSummary)
        {
            // Copy the DataTable to an object array

            var rawData = new object[dt.Rows.Count + 1, dt.Columns.Count];

            int intRowNum = 0;

            if (nextRow)
            {
                if (ws.UsedRange.Rows.Count == 1)
                {
                    intRowNum = ws.UsedRange.Rows.Count;

                    if (isCompare)
                    {
                        intRowNum = intRowNum + 2;
                    }
                }

                else
                {
                    ////intRowNum = ws.UsedRange.Rows.Count + 1;

                    if (isPolicyWiseSummary)
                    {
                        intRowNum = ws.UsedRange.Rows.Count;
                    }

                    else
                    {
                        intRowNum = ws.UsedRange.Rows.Count + 1;
                    }
                }
            }

            else
            {
                intRowNum = ws.UsedRange.Rows.Count;
            }

            if (!(intRowNum > 1))
            {
                // Copy the column names to the first row of the object array

                for (int col = 0; col < dt.Columns.Count; col++)
                {
                    rawData[0, col] = dt.Columns[col].ColumnName;
                }

                // Copy the values to the object array

                for (int col = 0; col < dt.Columns.Count; col++)
                {
                    for (int row = 0; row < dt.Rows.Count; row++)
                    {
                        rawData[row + 1, col] = dt.Rows[row].ItemArray[col];
                    }
                }

                //if (dt.Rows.Count > 0)

                //{

                // ((Range)ws.Rows[intRowNum + dt.Rows.Count, Type.Missing]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                //}
            }

            else
            {
                if (isCompare || isPolicyWiseSummary)
                {
                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        rawData[0, col] = dt.Columns[col].ColumnName;
                    }

                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        for (int row = 0; row < dt.Rows.Count; row++)
                        {
                            rawData[row + 1, col] = dt.Rows[row].ItemArray[col];
                        }
                    }
                }

                else
                {
                    // Copy the values to the object array

                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        for (int row = 0; row < dt.Rows.Count; row++)
                        {
                            rawData[row, col] = dt.Rows[row].ItemArray[col];
                        }
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    ((Range)ws.Rows[intRowNum + dt.Rows.Count, Type.Missing]).Interior.Color =
                        ColorTranslator.ToOle(Color.Yellow);
                }
            }

            // Calculate the final column letter

            string finalColLetter = string.Empty;

            string colCharset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int colCharsetLen = colCharset.Length;

            if (dt.Columns.Count > colCharsetLen)
            {
                finalColLetter = colCharset.Substring(
                    (dt.Columns.Count - 1) / colCharsetLen - 1, 1);
            }

            finalColLetter += colCharset.Substring(
                (dt.Columns.Count - 1) % colCharsetLen, 1);

            string excelRange = string.Empty;

            if (intRowNum > 1)
            {
                if (nextRow)
                {
                    excelRange =
                        string.Format(CultureInfo.InvariantCulture, "A{1}:{0}{2}",
                                      finalColLetter, intRowNum, (intRowNum + dt.Rows.Count));
                }

                else
                {
                    excelRange =
                        string.Format(CultureInfo.InvariantCulture, "A{1}:{0}{2}",
                                      finalColLetter, intRowNum + 1, (intRowNum + dt.Rows.Count));
                }
            }

            else
            {
                excelRange =
                    string.Format(CultureInfo.InvariantCulture, "A{1}:{0}{2}",
                                  finalColLetter, intRowNum, ws.UsedRange.Rows.Count + dt.Rows.Count);
            }

            intRowNum = intRowNum + dt.Rows.Count + dt.Rows.Count;

            ws.get_Range(excelRange, Type.Missing).NumberFormat = "@";

            ws.get_Range(excelRange,
                         Type.Missing).Value2 = rawData;

            ws.get_Range(excelRange,
                         Type.Missing).EntireColumn.AutoFit();

            //ws.get_Range(excelRange, Type.Missing).AutoFit();

            // Mark the first row as BOLD

            int j = 2;

            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ((Range)ws.Rows[1, Type.Missing]).Font.Bold = true;
                    ((Range)ws.Rows[1, Type.Missing]).Font.Color = ColorTranslator.ToOle(Color.LightGray);
                    ((Range)ws.Rows[1, Type.Missing]).Interior.Color = Color.Blue;

                    ((Range)ws.Rows[j, Type.Missing]).Borders.Color = ColorTranslator.ToOle(Color.Black);
                    ((Range)ws.Rows[j, Type.Missing]).Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                    string text = dt.Rows[i]["Total Number Of Test Cases Passed/Failed"].ToString();
                    string value = dt.Rows[i]["PASS or FAIL"].ToString();
                    if (value == "PASS")
                    {
                        ((Range)ws.Columns[1, Type.Missing].Rows[j, Type.Missing]).Interior.Color =
                            ColorTranslator.ToOle(Color.LightGreen);
                        ((Range)ws.Columns[2, Type.Missing].Rows[j, Type.Missing]).Interior.Color =
                            ColorTranslator.ToOle(Color.LightGreen);
                        ((Range)ws.Columns[3, Type.Missing].Rows[j, Type.Missing]).Interior.Color =
                            ColorTranslator.ToOle(Color.LightGreen);
                        ((Range)ws.Columns[4, Type.Missing].Rows[j, Type.Missing]).Interior.Color =
                            ColorTranslator.ToOle(Color.LightGreen);
                    }
                    if (value == "FAIL")
                    {
                        ((Range)ws.Columns[1, Type.Missing].Rows[j, Type.Missing]).Interior.Color =
                            ColorTranslator.ToOle(Color.Red);
                        ((Range)ws.Columns[2, Type.Missing].Rows[j, Type.Missing]).Interior.Color =
                            ColorTranslator.ToOle(Color.Red);
                        ((Range)ws.Columns[3, Type.Missing].Rows[j, Type.Missing]).Interior.Color =
                            ColorTranslator.ToOle(Color.Red);
                        ((Range)ws.Columns[4, Type.Missing].Rows[j, Type.Missing]).Interior.Color =
                            ColorTranslator.ToOle(Color.Red);
                    }
                    j++;
                    //   if (text.Contains("Passed"))
                    // {
                    //     ((Range)ws.Columns[5, Type.Missing]).Rows[2, Type.Missing].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                    //  }
                    //   if (text.Contains("Failed"))
                    //   {
                    //       ((Range)ws.Columns[5, Type.Missing]).Rows[3, Type.Missing].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                    //   }
                }
            }
            catch (Exception ex)
            {
            }
            return finalColLetter + "," + intRowNum;
        }

        #endregion
    }
}
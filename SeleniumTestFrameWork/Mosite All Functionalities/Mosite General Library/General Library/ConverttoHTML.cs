using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MoBankUI
{
    public class ConverttoHtml
    {
        private Control _c = new Control();

        public string ConvertDataTableToHtml(DataTable targetTable, string reportname, string P, string F)
        {
            #region TimeStamp

            var randomNumber = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture) + "-" +
                                  DateTime.Now.Month.ToString(CultureInfo.InvariantCulture) + "-"
                                  +
                                  DateTime.Now.Day.ToString(CultureInfo.InvariantCulture) + "_"
                                  +
                                  DateTime.Now.Hour.ToString(CultureInfo.InvariantCulture) + "-"
                                  +
                                  DateTime.Now.Minute.ToString(CultureInfo.InvariantCulture) + "-"
                                  +
                                  DateTime.Now.Second.ToString(CultureInfo.InvariantCulture);

            #endregion

            string htmlString;

            if (targetTable == null)
            {
                throw new ArgumentNullException("targetTable");
            }

            var htmlBuilder = new StringBuilder();

            //Create Top Portion of HTML Document
            htmlBuilder.Append("<html>");
            htmlBuilder.Append("<head>");
            htmlBuilder.Append(
                "<script type=\"text/javascript\" src=\"attachment/file/filterTable/filterTable.js\"> </script>");
            htmlBuilder.Append("<title>");
            htmlBuilder.Append("Page-");
            htmlBuilder.Append(Guid.NewGuid());
            htmlBuilder.Append("</title>");
            htmlBuilder.Append("</head>");
            htmlBuilder.Append("<body>");
            htmlBuilder.Append("<BODY bgcolor=\"LightGray\">");
            //style=\"width:500px\"

            htmlBuilder.Append("<div id=\"container\">");
            htmlBuilder.Append("<div id=\"header\" style=\"background-color:#B8B8B8;\">");
            htmlBuilder.Append("<h1 align='middle' style=\"margin-bottom:0;\">Automation Test Report</h1></div>");
            htmlBuilder.Append(
                "<img border='0' src=\"http://www.mopowered.co.uk/wp-content/themes/starkers/images/header-logo.png\"/ align ='left'width ='100px' height =100px>");
            htmlBuilder.Append(
                "<div id=\"menu\"  face =\"Times New Roman\" size = '2' style=\"background-color:#66CDAA ;height:100px;width:250px;float:left;\">");
            if (reportname.Contains("Consolidated Report"))
            {
                htmlBuilder.Append("<b>Test Run Name<br>Date And Time</b></div>");
                htmlBuilder.Append(
                    "<div id=\"content\"  face =\"Times New Roman\" size = '2' style=\"background-color:#CCFFFF;height:100px;width:300px;float:left;align='middle';\">");
                htmlBuilder.Append("" + reportname + "<br>" + randomNumber + "</div>");
            }
            else
            {
                htmlBuilder.Append(
                    "<b>Test Run Name<br>Date And Time<br>Number Of Test cases Passed<br>Number Of Test Cases Failed</b></div>");
                htmlBuilder.Append(
                    "<div id=\"content\"  face =\"Times New Roman\" size = '2' style=\"background-color:#CCFFFF;height:100px;width:300px;float:left;align='middle';\">");
                htmlBuilder.Append("" + reportname + "<br>" + randomNumber + "<br>" + P + "<br>" + F + "</div>");
            }

            htmlBuilder.Append("<div id=\"footer\" style=\"background-color:#E8E8E8;clear:both;text-align:center;\">");
            htmlBuilder.Append("</div>"); //                

            htmlBuilder.Append("<table class=\"filterable\" border='1px' cellpadding='5' cellspacing='0' ");
            htmlBuilder.Append("style='border: solid 1px Black; font-size: small;'>");
            //Create Header Row
            htmlBuilder.Append("<tr align='left' valign='top'>");
            htmlBuilder.Append("<tr style=\"background-color:LightBlue;\">");

            #region Table 

            foreach (DataColumn targetColumn in targetTable.Columns)
            {
                htmlBuilder.Append("<td align='left' face =\"Times New Roman\" size = '2' valign='top'>");
                htmlBuilder.Append(targetColumn.ColumnName);
                htmlBuilder.Append("</td>");
            }
            htmlBuilder.Append("</tr>");

            //Create Data Rows
            foreach (DataRow myRow in targetTable.Rows)
            {
                try
                {
                    htmlBuilder.Append("<tr align='left' valign='top'>");

                    foreach (DataColumn targetColumn in targetTable.Columns)
                    {
                        var columnname = targetColumn.ToString();
                        if (columnname == "Field Validated" || columnname == "Expected Result" ||
                            columnname == "Actual Result" || columnname == "PASS or FAIL" ||
                            columnname == "Total Number Of Test Cases Passed/Failed")
                        {
                            var value = myRow[3].ToString();
                            var valu = myRow[4].ToString();

                            if (value == "PASS")
                            {
                                if (columnname != "Total Number Of Test Cases Passed/Failed")
                                {
                                    htmlBuilder.Append(
                                        "<td align='left' valign='top' face =\"Times New Roman\" size = '2' style=\"background-color:LightGreen;\">");
                                    htmlBuilder.Append(myRow[targetColumn.ColumnName]);
                                    htmlBuilder.Append("</td>");
                                }

                                else if (columnname == "Total Number Of Test Cases Passed/Failed")
                                {
                                    htmlBuilder.Append(
                                        "<td align='left' valign='top' face =\"Times New Roman\" size = '2' style=\"background-color:Grey;\">");
                                    htmlBuilder.Append(myRow[targetColumn.ColumnName]);
                                    htmlBuilder.Append("</td>");
                                }
                            }

                            else if (value == "FAIL")
                            {
                                if (columnname != "Total Number Of Test Cases Passed/Failed")
                                {
                                    htmlBuilder.Append(
                                        "<td align='left' valign='top' face =\"Times New Roman\" size = '2' style=\"background-color:Red;\">");
                                    htmlBuilder.Append(myRow[targetColumn.ColumnName]);
                                    htmlBuilder.Append("</td>");
                                }
                                else if (columnname == "Total Number Of Test Cases Passed/Failed")
                                {
                                    htmlBuilder.Append(
                                        "<td align='left' valign='top' face =\"Times New Roman\" size = '2' style=\"background-color:Grey;\">");
                                    htmlBuilder.Append(myRow[targetColumn.ColumnName]);
                                    htmlBuilder.Append("</td>");
                                }
                            }
                            else
                            {
                                htmlBuilder.Append(
                                    "<td align='left' valign='top' face =\"Times New Roman\" size = '2' style=\"background-color:LightGrey;\">");
                                htmlBuilder.Append(myRow[targetColumn.ColumnName]);
                                htmlBuilder.Append("</td>");
                            }
                        }
                        else
                        {
                            htmlBuilder.Append(
                                "<td align='left' valign='top' face =\"Times New Roman\" size = '2' style=\"background-color:LightGrey;\">");
                            htmlBuilder.Append(myRow[targetColumn.ColumnName]);
                            htmlBuilder.Append("</td>");
                        }
                    }


                    htmlBuilder.Append("</tr>");
                }
                catch (Exception ex)
                {
                }
            }

            #endregion

            //Create Bottom Portion of HTML Document
            htmlBuilder.Append("</table>");

            htmlBuilder.Append("<script>");
            htmlBuilder.Append(" function filter (term, _id, cellNr)");
            htmlBuilder.Append("{");
            htmlBuilder.Append("var suche = term.value.toLowerCase();");
            htmlBuilder.Append("var table = document.getElementById(_id);");
            htmlBuilder.Append("var ele;");
            htmlBuilder.Append("for (var r = 1; r < " + targetTable + ".rows.length; r++){");
            htmlBuilder.Append("ele =table.rows[r].cells[cellNr].innerHTML.replace(/<[^>]+>/g,'');");
            htmlBuilder.Append("if (ele.toLowerCase().indexOf(suche)>=0 )");
            htmlBuilder.Append("table.rows[r].style.display = '';");
            htmlBuilder.Append("else table.rows[r].style.display = 'none';");
            htmlBuilder.Append("}");
            htmlBuilder.Append("}");
            htmlBuilder.Append("</script>");
            htmlBuilder.Append("</body>");
            htmlBuilder.Append("</html>");

            //Create String to be Returned
            htmlString = htmlBuilder.ToString();

            var SW = File.CreateText(@"C:\Selenium\Input Data\HTML Reports\" + reportname + ".html");
            SW.Close();

            // Write text to the Text file:
            SW = File.AppendText(@"C:\Selenium\Input Data\HTML Reports\" + reportname + ".html");
            SW.WriteLine(htmlString);
            SW.Close();
            return htmlString;
        }
    }
}
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using PdfReport.Reporting.MigraDoc.Internal;

namespace PLANCHECK.PDFReport
{
    internal class DoseObjectiveList
    {
        public void Add(Section section, ReportData data)
        {
            // AddHeading(section, PROI);
            AddPlanCheckResultsChart(section, data);     
        }


        /*
          private void AddHeading(Section section, List<ROI.ROI> PROI)
          {
              section.AddParagraph(PROI.Id, StyleNames.Heading1);
              section.AddParagraph($"Image {PROI.Image.Id} " +
                                   $"taken {PROI.Image.CreationTime:g}");
          }
      */


        private void AddPlanCheckResultsChart(Section section, ReportData data)
        {
           // string str = "DOSE OBJECTIVE REPORT FOR ,'S PLAN";

          //  str.Insert(26, patient.LastName);
          //  str.Insert(28, patient.FirstName);
          //  str.Insert(36, plan.Id);

            AddTableTitle(section, "EXTERNAL BEAM PLAN SAFETY AND INTEGRITY CHECK REPORT ");
            AddResultChart(section, data);
        }

        private void AddTableTitle(Section section, string title)
        {
            var p = section.AddParagraph(title, StyleNames.Heading2);
            p.Format.KeepWithNext = true;
        }

        private void AddResultChart(Section section, ReportData data)
        {
            var table = section.AddTable();

            FormatTable(table);
            AddColumnsAndHeaders(table);
            AddPlanCheckResultRows(table, data);
            AddLastRowBorder(table);
           // AlternateRowShading(table);
        }

        private static void FormatTable(Table table)
        {
            table.LeftPadding = 0;
            table.TopPadding = Size.TableCellPadding;
            table.RightPadding = 0;
            table.BottomPadding = Size.TableCellPadding;
            table.Format.LeftIndent = Size.TableCellPadding;
            table.Format.RightIndent = Size.TableCellPadding;
        }

        private void AddColumnsAndHeaders(Table table)
        {
            var width = Size.GetWidth(table.Section);
            table.AddColumn(width * 0.35);
            table.AddColumn(width * 0.55);
            table.AddColumn(width * 0.10);

            var headerRow = table.AddRow();
            headerRow.Borders.Bottom.Width = 1;

            AddHeader(headerRow.Cells[0], "Name");
            AddHeader(headerRow.Cells[1], "Comment");
            AddHeader(headerRow.Cells[2], "Status");
        }

        private void AddHeader(Cell cell, string header)
        {
            var p = cell.AddParagraph();
            p.Style = CustomStyles.ColumnHeader;
            FormattedText formattedText = new FormattedText();
            formattedText = p.AddFormattedText(header);
        }

        private void AddPlanCheckResultRows(Table table, ReportData data)
        {
            string STATUS = null;
            foreach (PLANCHECKRESULTS result in data.CheckResults)
            {
                

                var row = table.AddRow();
                row.VerticalAlignment = VerticalAlignment.Center;

                if (result.status == "PASS")
                {
                    STATUS = "PASS";
                    row.Cells[2].Shading.Color = Color.FromRgb(0, 255, 0);
                }
                else if(result.status == "FAIL")
                {
                    STATUS = "FAIL";
                    row.Cells[2].Shading.Color = Color.FromRgb(255, 0, 0);
                }
                else if(result.status == "REVIEW")
                {
                    STATUS = "REVIEW";
                    row.Cells[2].Shading.Color = Color.FromRgb(255, 255, 0);
                }
                else if (result.status == "NA")
                {
                    STATUS = "Not Applicable";
                }



                row.Cells[0].AddParagraph(result.Name);
                row.Cells[1].AddParagraph(result.comment);
                row.Cells[2].AddParagraph(STATUS);
            }
        }

        private void AddLastRowBorder(Table table)
        {
            var lastRow = table.Rows[table.Rows.Count - 1];
            lastRow.Borders.Bottom.Width = 2;
        }

      /*  private void AlternateRowShading(Table table)
        {
            // Start at i = 1 to skip column headers
            for (var i = 1; i < table.Rows.Count; i++)
            {
                if (i % 2 == 0)  // Even rows
                {
                    table.Rows[i].Shading.Color = Color.FromRgb(216, 216, 216);
                }
            }
        }
        */

    }
}
using System;
using MigraDoc.DocumentObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLANCHECK;

namespace PdfReport.Reporting.MigraDoc.Internal
{
    internal class FirstPageStuff
    {
        public void Add(Section section, ReportData data)
        {
            Paragraph stuff = new Paragraph();
            stuff.Format.AddTabStop(Size.GetWidth(section), TabAlignment.Right);

            stuff.AddFormattedText($"{data.PatLastName}, {data.PatFirstName} (ID: {data.PatId}) - {data.PatSex} ", TextFormat.Bold);

            stuff.AddTab();

            stuff.AddText("Plan: ");
            stuff.AddFormattedText(data.PlanId + " - " + data.ApprovalStatus, TextFormat.Bold);
            


            stuff.AddLineBreak();
            stuff.AddText("Primary Oncologist: " + data.DocName);

            section.Add(stuff);
        }

    }
}









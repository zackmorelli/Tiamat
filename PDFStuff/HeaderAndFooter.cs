using System;
using System.Windows;
using MigraDoc.DocumentObjectModel;
using PLANCHECK;

namespace PdfReport.Reporting.MigraDoc.Internal
{
    internal class HeaderAndFooter
    {
        public void Add(Section section, ReportData data)
        {
           // MessageBox.Show("Trigger main Header ADD1");
            AddHeader(section, data);    
            AddFooter(section, data);
           // MessageBox.Show("Trigger main Header ADD2");
        }

        private string Format(DateTime birthdate)
        {
            return $"{birthdate:d} (age {Age(birthdate)})";
        }

        // See http://stackoverflow.com/a/1404/1383366
        private int Age(DateTime birthdate)
        {
            var today = DateTime.Today;
            int age = today.Year - birthdate.Year;
            return birthdate.AddYears(age) > today ? age - 1 : age;
        }

        private void AddHeader(Section section, ReportData data)
        {
            var header = section.Headers.Primary.AddParagraph();
            header.Format.AddTabStop(Size.GetWidth(section), TabAlignment.Right);

            /*
            MessageBox.Show(data.Patient.LastName);
            MessageBox.Show(data.Patient.FirstName);
            MessageBox.Show(data.Plan.Id);
            MessageBox.Show(data.Patient.Doctor.Name);
            MessageBox.Show(data.Hospital.Address);
            MessageBox.Show(data.Plan.ApprovalStatus);
            */

            header.AddText($"Generated {DateTime.Now:g}  By: {data.UserName}");           //first line  ( g is the General Date Short Time Format Specifier)
          
            header.AddTab();
            header.AddText($"{data.PatHospitalName}, {data.PatHospitalAddress} ");

            header.Format.Borders.Bottom = new Border() { Width = "1pt", Color = Colors.DarkGray };
        }

       
        private void AddFooter(Section section, ReportData data)
        {
            var footer = section.Footers.Primary.AddParagraph();
            footer.Format.AddTabStop(Size.GetWidth(section), TabAlignment.Right);
            footer.Format.Borders.Top = new Border() { Width = "1pt", Color = Colors.DarkGray };

            footer.AddFormattedText($"{data.PatLastName}, {data.PatFirstName} (ID: {data.PatId}) - {data.PatSex} ", TextFormat.Bold);

            footer.AddLineBreak();

            footer.AddText("Course: " + data.CourseId);
            
            footer.AddLineBreak();

            footer.AddText("Plan: " + data.PlanId + " - " + data.ApprovalStatus);    
            
            footer.AddTab();
            footer.AddText("Page ");
            footer.AddPageField();
            footer.AddText(" of ");
            footer.AddNumPagesField();

            footer.AddLineBreak();
            footer.AddText("Treatment Site: " + data.TreatmentSite);
            
            footer.AddLineBreak();
            footer.AddText("Plan Created: ");
            footer.AddText(data.CreationDateTime.ToString() + " By " + data.CreationUser.ToString());    
            
            footer.AddLineBreak();
            
            footer.AddText("Plan Last Modified: ");
            footer.AddText(data.LastModifiedDateTime.ToString() + " By " + data.LastModifiedUser.ToString());
            
        }
    }
}
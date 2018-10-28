using System.Windows.Forms;
using System.IO;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;

namespace MMPI_Try_2.Generation
{
    class PDFGeneration
    {
        private string baseFolder;
        private string scaleNamesPath;

        private string critOutputPrimary;
        private string critOutputSecondary;

        private Grader.PersonalInfo testTaker;

        private CheckBox barLabel;

        private string indivBasePath;

        // This one is a string because it is going to be output
        private string gender;

        public PDFGeneration(string baseFolder,
                             string critOutputPrimary,
                             string critOutputSecondary,
                             Grader.PersonalInfo testTaker, 
                             
                             CheckBox barLabel)
        {
            this.baseFolder = baseFolder;
            this.testTaker = testTaker;
            if (testTaker.gender)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }

            indivBasePath = @"C:\MMPI2\" + testTaker.lastName + testTaker.firstName + @"\";
            scaleNamesPath = baseFolder + "scaleNames.txt";

            this.critOutputPrimary = critOutputPrimary;
            this.critOutputSecondary = critOutputSecondary;

            this.barLabel = barLabel;
        }

        public bool generatePdf()
        {
            if (!File.Exists(scaleNamesPath))
            {
                MessageBox.Show(scaleNamesPath + " is not a valid scale names file");
                return false;
            }
            string[] scaleNames = File.ReadAllLines(scaleNamesPath);

            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = "My First PDF";
            XFont font = new XFont("Microsoft Sans Serif", 12, XFontStyle.Regular);

            // Set all the page sizes and orientation
            PdfPage basicPage = pdf.AddPage();
            basicPage.Orientation = PageOrientation.Landscape;
            basicPage.Width = XUnit.FromInch(11);
            basicPage.Height = XUnit.FromInch(8.5);
            XGraphics graphBasic = XGraphics.FromPdfPage(basicPage);

            PdfPage page2 = pdf.AddPage();
            page2.Orientation = PageOrientation.Landscape;
            page2.Width = XUnit.FromInch(11);
            page2.Height = XUnit.FromInch(8.5);
            XGraphics graph2 = XGraphics.FromPdfPage(page2);

            PdfPage page3 = pdf.AddPage();
            page3.Orientation = PageOrientation.Landscape;
            page3.Width = XUnit.FromInch(11);
            page3.Height = XUnit.FromInch(8.5);
            XGraphics graph3 = XGraphics.FromPdfPage(page3);

            PdfPage page4 = pdf.AddPage();
            page4.Orientation = PageOrientation.Landscape;
            page4.Width = XUnit.FromInch(11);
            page4.Height = XUnit.FromInch(8.5);
            XGraphics graph4 = XGraphics.FromPdfPage(page4);

            PdfPage page5 = pdf.AddPage();
            page5.Orientation = PageOrientation.Landscape;
            page5.Width = XUnit.FromInch(11);
            page5.Height = XUnit.FromInch(8.5);
            XGraphics gfx = XGraphics.FromPdfPage(page5);
            XGraphicsState gs = gfx.Save();
            gfx.TranslateTransform(600, 750);
            gfx.RotateTransform(-90);
            gfx.TranslateTransform(-600, -750);
            XTextFormatter tf = new XTextFormatter(gfx);
            tf.DrawString(critOutputPrimary, font, XBrushes.Black, new XRect(800, 200, 500, 500), XStringFormats.TopLeft);
            gfx.Restore(gs);

            // If the person has too many entries on the crit items page
            // It overflows here to another page
            if (critOutputSecondary != "")
            {
                PdfPage page6 = pdf.AddPage();
                page6.Orientation = PageOrientation.Landscape;
                page6.Width = XUnit.FromInch(11);
                page6.Height = XUnit.FromInch(8.5);
                XGraphics gfx2 = XGraphics.FromPdfPage(page6);
                XGraphicsState gs2 = gfx2.Save();
                gfx2.TranslateTransform(600, 750);
                //gfx.ScaleTransform(0.6);
                gfx2.RotateTransform(-90);
                gfx2.TranslateTransform(-600, -750);
                XTextFormatter tf2 = new XTextFormatter(gfx2);
                tf2.DrawString(critOutputSecondary, font, XBrushes.Black, new XRect(800, 200, 500, 500), XStringFormats.TopLeft);
                //gfx.RotateTransform(-90);
                gfx2.Restore(gs2);
            }

            string[] userInfo = {"Name: " + testTaker.lastName + ", " + testTaker.firstName,
                                 "Gender: " + gender + "  Address:______________________________",
                                 "Occupation:____________________   Date Tested: " + testTaker.date,
                                 "Education:_______  Age: " + testTaker.age + "  Marital Status:________________",
                                 "Referred By:_________________________________________",
                                 "MMPI Code:_________________________________________"};
    
            for (int i = 0; i < 6; i++)
            {
                graphBasic.DrawString(userInfo[i], font, XBrushes.Black, new XRect(430, (i * 15) + 15, 0, 0), XStringFormats.TopLeft);
            }

            // Logo in upper left
            graphBasic.DrawImage(XImage.FromFile(baseFolder + "logo.jpg"), new XRect(40, 15, 250, 110));

            // Draw the charts onto the pdf
            try
            {
                graphBasic.DrawImage(XImage.FromFile(indivBasePath + "\\" + testTaker.lastName + testTaker.firstName + "1.png"), new XRect(30, 120, 760, 450));
                graph2.DrawImage(XImage.FromFile(indivBasePath + "\\" + testTaker.lastName + testTaker.firstName + "2.png"), new XRect(-25, 0, 830, 615));
                graph3.DrawImage(XImage.FromFile(indivBasePath + "\\" + testTaker.lastName + testTaker.firstName + "3.png"), new XRect(-25, 0, 830, 615));
                graph4.DrawImage(XImage.FromFile(indivBasePath + "\\" + testTaker.lastName + testTaker.firstName + "4.png"), new XRect(-25, 0, 830, 615));
            }
            catch (Exception)
            {
                MessageBox.Show("PDF Failed: Image in use - Try restarting the program");
                return false;
            }

            if (barLabel.Checked)
            {
                graph2.RotateAtTransform(-90, new XPoint(430, 430));
                graph3.RotateAtTransform(-90, new XPoint(430, 430));
                graph4.RotateAtTransform(-90, new XPoint(430, 430));

                for (int i = 0; i < 26; i++)
                {
                    graph2.DrawString(scaleNames[i], font, XBrushes.White, new XRect(330, (i * 28.66) + 41, 0, 0), XStringFormats.TopLeft);
                    graph3.DrawString(scaleNames[i + 26], font, XBrushes.White, new XRect(328, (i * 28.66) + 41, 0, 0), XStringFormats.TopLeft);
                }

                
                for (int i = 0; i < 22; i++)
                {
                    graph4.DrawString(scaleNames[i + 52], font, XBrushes.White, new XRect(328, (i * 33.96) + 43, 0, 0), XStringFormats.TopLeft);
                }
            }
            
            string pdfFilename = indivBasePath + testTaker.lastName + testTaker.firstName + ".pdf";
            pdf.Save(pdfFilename);
            if (File.Exists(pdfFilename))
                MessageBox.Show("PDF Success at " + pdfFilename);
            else
            {
                MessageBox.Show("PDF Failed at " + pdfFilename);
                return false;
            }

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using MMPI_Try_2.Static;
using MMPI_Try_2.Grading;
using MMPI_Try_2.Generation;

namespace MMPI_Try_2
{
    public class Grader
    {
        public struct PersonalInfo
        {
            public string firstName;
            public string lastName;
            public bool gender;
            public string age;
            public string date;
        };
        public PersonalInfo testTaker;      

        public string indivFilePath;
        public string indivBasePath = @"C:\MMPI2\";
        public string baseFolder = @"C:\MMPI2\";

        // Text output for critical item set
        public string[] critOutput;

        public List<List<int>> categoryTotals = new List<List<int>>(); // Completed calculations of users
        public List<List<int>> unscaledTotals = new List<List<int>>();
        public List<List<int[]>> rawScales; // Result of population data below
        
        // Nullable for non-answers
        public List<bool?> userAnswers = new List<bool?>();

        private PrimaryUI.UIElements form1Elements;

        public Grader()
        {
            // TODO
        }

        public void setUIElements(PrimaryUI.UIElements passedUIElements)
        {
            form1Elements.chart1 = passedUIElements.chart1;
            form1Elements.chart2 = passedUIElements.chart2;
            form1Elements.chart3 = passedUIElements.chart3;
            form1Elements.chart4 = passedUIElements.chart4;
            form1Elements.mainOutput = passedUIElements.mainOutput;
            form1Elements.barLabel = passedUIElements.barLabel;
        }


        public void catCopier()
        {
            List<int> subList0 = new List<int>();
            List<int> subList1 = new List<int>();
            List<int> subList2 = new List<int>();
            List<int> subList3 = new List<int>();
            List<int> subList4 = new List<int>();

            int counter = 0; // Iterates over the main 5 scales
            for (int y = 0; y < categoryTotals[counter].Count; y++)
            {
                subList0.Add(categoryTotals[counter][y]);
            }
            counter++;

            for (int y = 0; y < categoryTotals[counter].Count; y++)
            {
                subList1.Add(categoryTotals[counter][y]);
            }
            counter++;

            for (int y = 0; y < categoryTotals[counter].Count; y++)
            {
                subList2.Add(categoryTotals[counter][y]);
            }
            counter++;

            for (int y = 0; y < categoryTotals[counter].Count; y++)
            {
                subList3.Add(categoryTotals[counter][y]);
            }
            counter++;

            for (int y = 0; y < categoryTotals[counter].Count; y++)
            {
                subList4.Add(categoryTotals[counter][y]);
            }
            
            unscaledTotals.Add(subList0);
            unscaledTotals.Add(subList1);
            unscaledTotals.Add(subList2);
            unscaledTotals.Add(subList3);
            unscaledTotals.Add(subList4);
        }

        public void basicInfoToFile()
        {
            StreamWriter indivOutFile = new StreamWriter(indivFilePath, false);
            indivOutFile.Write(testTaker.lastName + "," + testTaker.firstName + "," + testTaker.age + "," + testTaker.date + "\n");
            if (testTaker.gender)
            {
                indivOutFile.Write("Male\n");
            }
            else
            {
                indivOutFile.Write("Female\n");
            }
            indivOutFile.Close();
        }

        public int singleUserEntry(bool? userChoice)
        {
            StreamWriter appender = File.AppendText(indivFilePath);
            appender.WriteLine(userChoice);
            appender.Close();
            return 0;
        }

        public void openUserFile(string appName, string processArgs)
        {
            Process openDB = new Process();
            openDB.StartInfo.FileName = appName;
            openDB.StartInfo.Arguments = processArgs;
            openDB.Start();
        }

        public void gradeUserFile()
        {
            // Read the first two lines to figure out gender
            bool? qChoice; // Non-answer is possible

            string line0 = File.ReadLines(indivFilePath).Skip(0).Take(1).First();
            testTaker.lastName = line0.Substring(0, line0.IndexOf(','));
            line0 = line0.Substring(line0.IndexOf(',') + 1, (line0.Length - 1) - line0.IndexOf(','));
            testTaker.firstName = line0.Substring(0, line0.IndexOf(','));
            line0 = line0.Substring(line0.IndexOf(',') + 1, (line0.Length - 1) - line0.IndexOf(','));
            testTaker.age = line0.Substring(0, line0.IndexOf(','));
            testTaker.date = line0.Substring(line0.IndexOf(',') + 1, (line0.Length - 1) - line0.IndexOf(','));
            string line1 = File.ReadLines(indivFilePath).Skip(1).Take(1).First();
            string line1Strip = line1.Substring(0, 1);
            indivBasePath = indivFilePath.Substring(0, indivFilePath.LastIndexOf('\\'));

            // Pass the gender to the RawScale population class
            RawScales staticRawScales = new RawScales();
            if (line1Strip == "M" || line1Strip == "m")
            {
                testTaker.gender = true; // Male 
                staticRawScales.setGender(true);
            }
            else
            {
                testTaker.gender = false; // Female
                staticRawScales.setGender(false);
            }

            // Populates scales now that the gender has been passed in
            staticRawScales.populateScales();

            // TODO: put this back in the file validation test
            for (int i = 2; i < 569; i++)
            {
                string line = File.ReadLines(indivFilePath).Skip(i).Take(1).First();
                if (line == "True" || line == "TRUE")
                    qChoice = true;
                else if (line == "False" || line == "FALSE")
                    qChoice = false;
                else
                    qChoice = null;
                userAnswers.Add(qChoice);
            }

            // Populate and get raw scaling data
            rawScales = staticRawScales.getRawScales();

            // Grade based off the scales
            RawToSubscales categoryTotalGrader = new RawToSubscales(userAnswers, rawScales);
            categoryTotals = categoryTotalGrader.gradeRawAnswers();
        }

        public void finalCalc()
        {
            // Creates a copy of the final
            catCopier();
            // Populate the adjusted scales based on gender
            SubscalesToFinalCalc finalGrader = new SubscalesToFinalCalc(categoryTotals, userAnswers, testTaker.gender);
            categoryTotals = finalGrader.getFinalScores();
            critOutput = finalGrader.getCriticalItems();

            // Pass the controls the necessary elements to the chart generator
            ChartGenerator chartGen = new ChartGenerator(this.indivFilePath, 
                                                         form1Elements.chart1,
                                                         form1Elements.chart2,
                                                         form1Elements.chart3,
                                                         form1Elements.chart4,
                                                         categoryTotals,
                                                         unscaledTotals);
            if (chartGen.generateChart())
            {
                form1Elements.mainOutput.Text += "Charts Generated Successfully\r\n";
            }
            else
            {
                throw new Exception("Error with chart generation");
            }

            PDFGeneration pdfGen = new PDFGeneration(baseFolder,
                                                     critOutput[1], 
                                                     critOutput[2],
                                                     testTaker,
                                                     form1Elements.barLabel);
            if (pdfGen.generatePdf())
            {
                form1Elements.mainOutput.Text += "PDF Generated Successfully\r\n";
            }
        }

        public bool fileChecker()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog(); // Choose File
            openFileDialog1.Filter = "CSV Files (.csv)|*.csv";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;
            if (indivBasePath != @"C:\MMPI2\")
            {
                openFileDialog1.InitialDirectory = indivBasePath;
            }
            DialogResult result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK) // Escape if no choice is made
            {
                return false;
            }
            form1Elements.mainOutput.AppendText(openFileDialog1.FileName); // put the filename in the output box
            indivFilePath = openFileDialog1.FileName; // Feed to backend class

            // TODO: change this to read all lines at once
            string[] allLines = File.ReadAllLines(openFileDialog1.FileName);
            if (allLines.Length != 569)
            {
                return false;
            }
            for (int i = 2; i < 569; i++)
            {
                // Just in case someone edits the csv with wacky info
                if (allLines[i] != "True" && allLines[i] != "False" && allLines[i] != "TRUE" && allLines[i] != "FALSE" && allLines[i] != "")
                {
                    return false;
                }
            }
            return true;
        }
    }
}

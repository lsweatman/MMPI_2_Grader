using System;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using MMPI_Try_2.Static;
using System.Windows.Forms.DataVisualization.Charting;

namespace MMPI_Try_2
{
	public partial class PrimaryUI : Form
	{
		// Initializer
		public PrimaryUI()
		{
			InitializeComponent();
			Load += new EventHandler(Form1_Load);
            form1Elements.chart1 = chart1;
            form1Elements.chart2 = chart2;
            form1Elements.chart3 = chart3;
            form1Elements.chart4 = chart4;
            form1Elements.mainOutput = mainOutput;
            form1Elements.barLabel = BarLabel;
        }

        public struct UIElements
        {
            public Chart chart1;
            public Chart chart2;
            public Chart chart3;
            public Chart chart4;
            public TextBox mainOutput;
            public CheckBox barLabel;
        }

        private UIElements form1Elements;

        // Keeps track of what Question the person is on
        public int question = 1;

        // initialize keydown event for the [ and ] keys
        private void Form1_Load(object sender, EventArgs e)
		{
			BringToFront();
			Focus();
			KeyPreview = true;
			KeyDown += new KeyEventHandler(Form1_KeyDown);
		}

        //Sends a true or false button click event if the bracket keys are clicked
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (falseButton.Enabled == true && trueButton.Enabled == true)
            {
                if (e.KeyCode == Keys.OemOpenBrackets)
                {
                    trueButton_Click(this, new EventArgs());
                }
                else if (e.KeyCode == Keys.OemCloseBrackets)
                {
                    falseButton_Click(this, new EventArgs());
                }
            }
        }
        
		private Grader grader = new Grader(); // Grader class

        // Allows user to enter the new test taker's info
		private void enterDataButton_Click(object sender, EventArgs e)
		{
			firstNameTextBox.ReadOnly = false;
			lastNameTextBox.ReadOnly = false;
			genderTextBox.ReadOnly = false;
			ageTextBox.ReadOnly = false;
			monthTextBox.ReadOnly = false;
			dayTextBox.ReadOnly = false;
			yearTextBox.ReadOnly = false;
			confirmUser.Visible = true;
		}

        // Locks in the users information
		private void confirmUser_Click(object sender, EventArgs e)
		{
			firstNameTextBox.ReadOnly = true;
			lastNameTextBox.ReadOnly = true;
			genderTextBox.ReadOnly = true;
			ageTextBox.ReadOnly = true;
			monthTextBox.ReadOnly = true;
			dayTextBox.ReadOnly = true;
			yearTextBox.ReadOnly = true;
			confirmUser.Visible = false;
			undoButton.Enabled = true;
			grader.testTaker.firstName = firstNameTextBox.Text;
            grader.testTaker.lastName = lastNameTextBox.Text;
            if (genderTextBox.Text[0] == 'm' || genderTextBox.Text[0] == 'M')
            {
                grader.testTaker.gender = true;
            }
            else
            {
                grader.testTaker.gender = false;
            }
            grader.testTaker.age = ageTextBox.Text;
			string day = dayTextBox.Text;
			string month = monthTextBox.Text;
			string year = yearTextBox.Text;
            grader.testTaker.date = month + "/" + day + "/" + year;

			grader.basicToFile();
            
            mainOutput.Text += grader.testTaker.lastName + ", " + grader.testTaker.firstName + "\r\n";
            mainOutput.Text += grader.testTaker.date + "\r\n";
            mainOutput.Text += genderTextBox.Text + "\r\n";

			falseButton.Enabled = true;
			trueButton.Enabled = true;
            nonAnswer.Enabled = true;

			mainOutput.Focus();
		}
        
		private void viewUserFile_Click(object sender, EventArgs e)
		{
			grader.openUserFile("EXCEL.EXE",grader.indivFilePath);
		}

        private void scoreDataButton_Click(object sender, EventArgs e)
        {
            // Pass the controls for chart generation and reporting
            grader.setUIElements(form1Elements);

            bool isValidFile = grader.fileChecker();

            // TODO: Show line invalid
            if (!isValidFile)
                MessageBox.Show("File not Compatible!", "File not Compatible!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                // Enable Buttons
                printCurrentButton.Enabled = true;

                // Get back the non-adjust scale values
                grader.gradeUserFile();

                // Get category abbreviations
                ScaleAbbreviations abbrevStatic = new ScaleAbbreviations();
                List<List<string>> categoryAbbrev = abbrevStatic.getCategoryAbbrev();

                // Output the scores of each category pre adjusted
                for (int x = 0; x < grader.categoryTotals.Count; x++)
                {
                    for (int y = 0; y < grader.categoryTotals[x].Count; y++)
                    {
                        this.mainOutput.Text += ("\r\n" + categoryAbbrev[x][y] + ": " + grader.categoryTotals[x][y]);
                    }
                    this.mainOutput.Text += "\r\n" + "----------";
                }

                // Calculate 
                grader.finalCalc();

                // Output the calculated final scores
                for (int x = 0; x < grader.categoryTotals.Count; x++)
                {
                    for (int y = 0; y < grader.categoryTotals[x].Count; y++)
                    {
                        this.mainOutput.Text += ("\r\n" + categoryAbbrev[x][y] + ": " + grader.categoryTotals[x][y]);
                    }
                    this.mainOutput.Text += "\r\n" + "----------";
                }

                // Print out the critical output text section
                this.mainOutput.Text += grader.critOutput;
            }
        }

        private void printCurrentButton_Click(object sender, EventArgs e)
        {
            string printArgument = "/p " + grader.indivFilePath.Remove(grader.indivFilePath.Length - 3) + "pdf";
            Process printPDF = new Process();
            printPDF.StartInfo.FileName = "Acrobat.exe";
            printPDF.StartInfo.Arguments = printArgument;
            try
            {
                printPDF.Start();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("You need to install Adobe Acrobat to use the print function!");
            }
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(grader.indivFilePath))
            {
                string[] originFileData = File.ReadAllLines(grader.indivFilePath);
                originFileData = originFileData.Take(originFileData.Count() - 1).ToArray();
                File.WriteAllLines(grader.indivFilePath, originFileData);
            }
            else
            {
                MessageBox.Show("File Error: Does not exist");
            }

            string oldTextbox = mainOutput.Text;
            int pos = oldTextbox.LastIndexOf(':');
            string newTextbox = oldTextbox.Substring(0, pos);
            pos = newTextbox.LastIndexOf('\r');
            newTextbox = oldTextbox.Substring(0, pos);
            string newTextboxV2 = newTextbox + "\r\n";
            mainOutput.Text = newTextboxV2;
            question -= 1;
        }

        private void trueButton_Click(object sender, EventArgs e)
		{
			if (grader.indivFilePath == null)
				return;
			if (question <= 567)
			{
				grader.singleUserEntry(true);
                mainOutput.Text += question + ": True\r\n";
				question++;
			}
			else
			{
				mainOutput.Text += "You have entered all 567 questions!\r\n";
				trueButton.Enabled = false;
				falseButton.Enabled = false;
                nonAnswer.Enabled = false;
			}			
			mainOutput.SelectionStart = mainOutput.Text.Length;
			mainOutput.ScrollToCaret();
		}

        private void nonAnswer_Click(object sender, EventArgs e)
        {
            if (grader.indivFilePath == null)
                return;
            if (question <= 567)
            {
                grader.singleUserEntry(null);
                //Console.SetOut(new ControlWriter(mainOutput));
                mainOutput.Text += question + ": No Answer\r\n";
                question++;
            }
            else
            {
                mainOutput.Text += "You have entered all 567 questions!\r\n";
                trueButton.Enabled = false;
                falseButton.Enabled = false;
                nonAnswer.Enabled = false;

            }
            mainOutput.SelectionStart = mainOutput.Text.Length;
            mainOutput.ScrollToCaret();
        }

        private void falseButton_Click(object sender, EventArgs e)
		{
			if (grader.indivFilePath == null)
				return;
			if (question <= 567)
			{
				grader.singleUserEntry(false);
                mainOutput.Text += question + ": False\r\n";
				question++;
			}
			else
			{
				mainOutput.Text += "You have entered all 567 questions!\r\n";
				trueButton.Enabled = false;
				falseButton.Enabled = false;
                nonAnswer.Enabled = false;
            }
			mainOutput.SelectionStart = mainOutput.Text.Length;
			mainOutput.ScrollToCaret();
		}

        private void resetButton_Click(object sender, EventArgs e)
        {
            grader = new Grader();
            mainOutput.Text = "";
            question = 1;
            chart1.ChartAreas[0].AxisX.CustomLabels.Clear();
            chart2.ChartAreas[0].AxisX.CustomLabels.Clear();
            chart3.ChartAreas[0].AxisX.CustomLabels.Clear();
            chart4.ChartAreas[0].AxisX.CustomLabels.Clear();
        }
    }
}

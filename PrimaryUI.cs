using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using MMPI_Try_2.Static;
using MMPI_Try_2.ScanAnalysis;
using System.Windows.Forms.DataVisualization.Charting;
using System.Text.RegularExpressions;

namespace MMPI_Try_2
{
	public partial class PrimaryUI : Form
	{
        private Grader grader; // Grader class

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
            grader = new Grader();
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
            scanScore.Enabled = true;
            scoreDataButton.Enabled = false;
            resetButton.Enabled = true;
            enterDataButton.Enabled = false;

            // Check that there are values in every box
            if (!Regex.IsMatch(firstNameTextBox.Text, @"^[a-zA-Z]+$") ||     // Letters only
                !Regex.IsMatch(lastNameTextBox.Text, @"^[a-zA-Z]+$") ||
                !Regex.IsMatch(genderTextBox.Text, @"^[a-zA-Z]+$") ||
                !Regex.IsMatch(ageTextBox.Text, @"^[0-9]+$") ||             // Numbers only
                !Regex.IsMatch(monthTextBox.Text, @"^[0-9][0-9]$") ||
                !Regex.IsMatch(dayTextBox.Text, @"^[0-9][0-9]$") ||
                !Regex.IsMatch(yearTextBox.Text, @"^[0-9][0-9][0-9][0-9]$"))
            {
                MessageBox.Show("Invalid user input");
                enterDataButton.Enabled = true;
                return;
            }

			grader.testTaker.firstName = firstNameTextBox.Text;
            grader.testTaker.lastName = lastNameTextBox.Text;
            if (genderTextBox.Text[0] == 'm' || genderTextBox.Text[0] == 'M')
            {
                grader.testTaker.gender = true;
                genderTextBox.Text = "Male";
            }
            else
            {
                grader.testTaker.gender = false;
                genderTextBox.Text = "Female";
            }
            grader.testTaker.age = ageTextBox.Text;
			string day = dayTextBox.Text;
			string month = monthTextBox.Text;
			string year = yearTextBox.Text;
            grader.testTaker.date = month + "/" + day + "/" + year;

            string indivEnd = grader.testTaker.lastName + grader.testTaker.firstName + ".csv";
            string indivDirPath = grader.indivBasePath + grader.testTaker.lastName + grader.testTaker.firstName;
            DirectoryInfo di = Directory.CreateDirectory(indivDirPath);
            grader.indivFilePath = indivDirPath + "\\" + indivEnd;
            grader.indivBasePath = indivDirPath + "\\";

            grader.basicInfoToFile();
            
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
			grader.openUserFile("EXCEL.EXE", grader.indivFilePath);
		}

        private void scoreDataButton_Click(object sender, EventArgs e)
        {
            // Pass the controls for chart generation and reporting
            grader.setUIElements(form1Elements);

            // TODO: Show line invalid
            if (!grader.fileChecker())
                MessageBox.Show("File not compatible!", "File not Compatible!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                // Enable Buttons
                printCurrentButton.Enabled = true;
                resetButton.Enabled = true;

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
                if (originFileData.Length <= 2)
                {
                    return;
                }
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
            scanScore.Enabled = false;
            if (grader.indivFilePath == null)
				return;
            if (question == 567)
            {
                grader.singleUserEntry(true);
                mainOutput.Text += question + ": True\r\n";
                mainOutput.Text += "You have entered all 567 questions!\r\n";
                trueButton.Enabled = false;
                falseButton.Enabled = false;
                nonAnswer.Enabled = false;
                undoButton.Enabled = false;
                scoreDataButton.Enabled = true;
            }
			else if (question < 567)
			{
				grader.singleUserEntry(true);
                mainOutput.Text += question + ": True\r\n";
				question++;
			}			
			mainOutput.SelectionStart = mainOutput.Text.Length;
			mainOutput.ScrollToCaret();
		}

        private void nonAnswer_Click(object sender, EventArgs e)
        {
            scanScore.Enabled = false;
            if (grader.indivFilePath == null)
                return;
            if (question == 567)
            {
                grader.singleUserEntry(null);
                mainOutput.Text += question + ": No Answer\r\n";
                mainOutput.Text += "You have entered all 567 questions!\r\n";
                trueButton.Enabled = false;
                falseButton.Enabled = false;
                nonAnswer.Enabled = false;
                undoButton.Enabled = false;
                scoreDataButton.Enabled = true;
            }
            else if (question < 567)
            {
                grader.singleUserEntry(null);
                mainOutput.Text += question + ": No Answer\r\n";
                question++;
            }
            mainOutput.SelectionStart = mainOutput.Text.Length;
            mainOutput.ScrollToCaret();
        }

        private void falseButton_Click(object sender, EventArgs e)
		{
            scanScore.Enabled = false;
            if (grader.indivFilePath == null)
				return;
            if (question == 567)
            {
                grader.singleUserEntry(false);
                mainOutput.Text += question + ": False\r\n";
                mainOutput.Text += "You have entered all 567 questions!\r\n";
                trueButton.Enabled = false;
                falseButton.Enabled = false;
                nonAnswer.Enabled = false;
                undoButton.Enabled = false;
                scoreDataButton.Enabled = true;
            }
            else if (question < 567)
			{
				grader.singleUserEntry(false);
                mainOutput.Text += question + ": False\r\n";
				question++;
			}
			mainOutput.SelectionStart = mainOutput.Text.Length;
			mainOutput.ScrollToCaret();
		}

        private void resetButton_Click(object sender, EventArgs e)
        {
            grader = new Grader();
            // Reset all the text fields
            mainOutput.Text = "";
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            genderTextBox.Text = "";
            ageTextBox.Text = "";
            monthTextBox.Text = "";
            dayTextBox.Text = "";
            yearTextBox.Text = "";

            question = 1;
            chart1.ChartAreas[0].AxisX.CustomLabels.Clear();
            chart2.ChartAreas[0].AxisX.CustomLabels.Clear();
            chart3.ChartAreas[0].AxisX.CustomLabels.Clear();
            chart4.ChartAreas[0].AxisX.CustomLabels.Clear();

            // Disable/Enable Buttons
            scoreDataButton.Enabled = true;
            scanScore.Enabled = false;
            resetButton.Enabled = false;
            printCurrentButton.Enabled = false;
            trueButton.Enabled = false;
            nonAnswer.Enabled = false;
            falseButton.Enabled = false;
            undoButton.Enabled = false;
        }
        
        private void scanScore_Click(object sender, EventArgs e)
        {
            trueButton.Enabled = false;
            nonAnswer.Enabled = false;
            falseButton.Enabled = false;
            undoButton.Enabled = false;
            scoreDataButton.Enabled = false;

            // Create dialog box for image selection
            OpenFileDialog imageDialog = new OpenFileDialog();
            imageDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.png)|*.BMP;*.JPG;*.GIF;*.png";
            imageDialog.FilterIndex = 1;
            imageDialog.Multiselect = false;
            imageDialog.InitialDirectory = @"C:\MMPI2\" + grader.testTaker.lastName + grader.testTaker.firstName;
            DialogResult imageResult = imageDialog.ShowDialog();
            if (imageResult != DialogResult.OK) // Escape if no choice is made
            {
                trueButton.Enabled = true;
                nonAnswer.Enabled = true;
                falseButton.Enabled = true;
                undoButton.Enabled = true;
                return;
            }
            mainOutput.Text += "Loading and Scanning Image! This might take a few seconds\r\n";
            ImageVerify verifyPage = new ImageVerify(imageDialog.FileName);
            if (!verifyPage.getFileValidity())
            {
                // Warning messages handled in verification class
                MessageBox.Show(verifyPage.getErrorMessage(), "Image Verification Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            mainOutput.Text += "Page is valid\n";

            // Will open the markup image in windows photo viewer
            UserAnswersPage populateScores = new UserAnswersPage(imageDialog.FileName, verifyPage.getCoordPairings());
            List<bool?> newInfo = populateScores.getUserInfo();

            if (newInfo.Count != 567)
            {
                resetButton_Click(sender, e);
                return;
            }
            GC.Collect();

            // Launches new form modally
            using (EditAnswer answerChanger = new EditAnswer(newInfo, populateScores.getNonAnswers(), populateScores.getDoubleAnswers()))
            {
                answerChanger.ShowDialog();
                newInfo = answerChanger.getNewInfo();
                answerChanger.Dispose();
            }
            
            int nullCounter = 0;
            foreach (bool? answer in newInfo)
            {
                if (answer == null)
                {
                    nullCounter++;
                }
            }
            if (nullCounter > 6)
            {
                MessageBox.Show("There are too many non-answer/double answers.\r\nTotal: " + nullCounter);
                trueButton.Enabled = true;
                nonAnswer.Enabled = true;
                falseButton.Enabled = true;
                undoButton.Enabled = true;
                return;
            }
            if (File.Exists(grader.indivFilePath))
            {
                File.Delete(grader.indivFilePath);
            }
            grader.basicInfoToFile();
            foreach (bool? answer in newInfo)
            {
                grader.singleUserEntry(answer);
                question++;
            }
            scoreDataButton.Enabled = true;
            scoreDataButton_Click(this, new EventArgs());
        }
    }
}

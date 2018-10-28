using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMPI_Try_2
{
    public partial class EditAnswer : Form
    {
        public List<bool?> answers;
        public List<int> nonAnswersList;
        public List<int> doubleAnswersList;

        public EditAnswer(List<bool?> userAnswers, List<int> nonAnswers, List<int> doubleAnswers)
        {
            InitializeComponent();
            answers = userAnswers;
            nonAnswersList = nonAnswers;
            doubleAnswersList = doubleAnswers;

            // Make the checkboxes read only until valid entry
            trueCheckBox.Enabled = false;
            falseCheckBox.Enabled = false;
            foreach (int nonAnswerItem in nonAnswers)
            {
                NonAnswerLabel.Text += (nonAnswerItem + 1) + " ";
            }
            foreach (int doubleAnswerItem in doubleAnswers)
            {
                DoubleAnswerLabel.Text += (doubleAnswerItem + 1 ) + " ";
            }
        }

        private void checkAnswer_Click(object sender, EventArgs e)
        {
            // Check if the input is in bounds
            int answerToChange;

            try
            {
                answerToChange = Convert.ToInt32(questionBox.Text) - 1;
            }
            catch (Exception)
            {
                MessageBox.Show("Not a valid input");
                return;
            }
            
            if (answerToChange >= 0 && answerToChange <= 566)
            {
                // Re enable checkboxes
                trueCheckBox.Enabled = true;
                falseCheckBox.Enabled = true;

                if (answers[answerToChange] == true)
                {
                    trueCheckBox.Checked = true;
                    falseCheckBox.Checked = false;
                }
                else if (answers[answerToChange] == false)
                {
                    trueCheckBox.Checked = false;
                    falseCheckBox.Checked = true;
                }
                else
                {
                    trueCheckBox.Checked = false;
                    falseCheckBox.Checked = false;
                }
            }
            else
            {
                trueCheckBox.Enabled = false;
                falseCheckBox.Enabled = false;
            }
        }

        private void trueCheckBox_Click(object sender, EventArgs e)
        {
            // If they are both checked then favor last clicked
            if (trueCheckBox.Checked && falseCheckBox.Checked)
            {
                falseCheckBox.Checked = false;
            }

            // Neither is filled in
            if (!trueCheckBox.Checked)
            {
                answers[Convert.ToInt32(questionBox.Text) - 1] = null;
            }
            else
            {
                answers[Convert.ToInt32(questionBox.Text) - 1] = true;
            }
            if (nonAnswersList.Contains(Convert.ToInt32(questionBox.Text) - 1))
            {
                NonAnswerLabel.Text = NonAnswerLabel.Text.Replace(questionBox.Text + " ", "");
            }
            if (doubleAnswersList.Contains(Convert.ToInt32(questionBox.Text) - 1))
            {
                DoubleAnswerLabel.Text = DoubleAnswerLabel.Text.Replace(questionBox.Text + " ", "");
            }
        }

        private void falseCheckBox_Click(object sender, EventArgs e)
        {
            // If they are both checked then favor last clicked
            if (trueCheckBox.Checked && falseCheckBox.Checked)
            {
                trueCheckBox.Checked = false;
            }

            // Neither is filled in
            if (!falseCheckBox.Checked)
            {
                answers[Convert.ToInt32(questionBox.Text) - 1] = null;
            }
            else
            {
                answers[Convert.ToInt32(questionBox.Text) - 1] = false;
            }
            if (nonAnswersList.Contains(Convert.ToInt32(questionBox.Text) - 1))
            {
                NonAnswerLabel.Text = NonAnswerLabel.Text.Replace(questionBox.Text + " ", "");
            }
            if (doubleAnswersList.Contains(Convert.ToInt32(questionBox.Text) - 1))
            {
                DoubleAnswerLabel.Text = DoubleAnswerLabel.Text.Replace(questionBox.Text + " ", "");
            }
        }

        private void EditAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkAnswer_Click(this, new EventArgs());
            }
        }

        public List<bool?> getNewInfo()
        {
            return answers;
        }
    }
}

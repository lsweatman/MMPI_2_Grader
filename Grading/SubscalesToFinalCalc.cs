using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using MMPI_Try_2.Static;

namespace MMPI_Try_2.Grading
{
    class SubscalesToFinalCalc
    {
        private List<List<int>> categoryTotals;
        private List<bool?> userAnswers;

        private AdjustedScales adjustClass;
        private List<List<int[]>> adjustScales;

        private string critOutput = "";
        private string critPage1 = "";
        private string critPage2 = "";

        public SubscalesToFinalCalc(List<List<int>> categoryTotals, List<bool?> userAnswers, bool gender)
        {
            this.categoryTotals = categoryTotals;
            this.userAnswers = userAnswers;

            // Grab the correct adjusted scales for this gender
            adjustClass = new AdjustedScales(gender);
            adjustScales = adjustClass.getAdjustScales();
        }

        public List<List<int>> getFinalScores()
        {
            int rawK = categoryTotals[0][2];
            for (int x = 0; x < categoryTotals.Count; x++) // Iterates over the main 5
            {
                for (int y = 0; y < categoryTotals[x].Count; y++) // Iterates of the subscales of the main 5
                {
                    if (x == 0)
                    {
                        if (y == 3)
                        {
                            double doubleK = categoryTotals[0][3] + (0.5 * rawK);
                            int result;
                            result = Convert.ToInt32(doubleK);
                            categoryTotals[0][3] = result;
                        }
                        else if (y == 6)
                        {
                            double doubleK = categoryTotals[0][6] + (0.4 * rawK);
                            int result;
                            result = Convert.ToInt32(doubleK);
                            categoryTotals[0][6] = result;
                        }
                        else if (y == 9)
                        {
                            double doubleK = categoryTotals[0][9] + (rawK);
                            int result;
                            result = Convert.ToInt32(doubleK);
                            categoryTotals[0][9] = result;
                        }
                        else if (y == 10)
                        {
                            double doubleK = categoryTotals[0][10] + (rawK);
                            int result;
                            result = Convert.ToInt32(doubleK);
                            categoryTotals[0][10] = result;
                        }
                        else if (y == 11)
                        {
                            double doubleK = categoryTotals[0][11] + (0.2 * rawK);
                            int result;
                            result = Convert.ToInt32(doubleK);
                            categoryTotals[0][11] = result;
                        }
                    }
                    try
                    {
                        categoryTotals[x][y] = adjustScales[x][y][categoryTotals[x][y]];
                    }
                    catch
                    {
                        categoryTotals[x][y] = adjustScales[x][y].Last();
                    }
                }
            }
            return categoryTotals;
        }

        // Returns one long string with all the critical items
        // Used in PDF Generation
        public string[] getCriticalItems()
        {
            int lineCounter = 0;
            string line;
            int outputtedLines = 0;
            string critFilePath = @"C:\MMPI2\critItemsDB.txt";
            StreamReader critItemFile = new StreamReader(critFilePath);
            line = critItemFile.ReadLine();
            // Loops over all the lines in the file
            while (line != null)
            {
                // New set
                if (line[0] == ':')
                {
                    line.Remove(0, 1);
                    critOutput += "\r\n" + line.Substring(1, line.Length - 1) + "\r\n";
                    if (outputtedLines > 40)
                    {
                        critPage2 += "\r\n" + line.Substring(1, line.Length - 1) + "\r\n";
                    }
                    else
                    {
                        critPage1 += "\r\n" + line.Substring(1, line.Length - 1) + "\r\n";
                        outputtedLines++;
                    }
                }
                // Entries within each set
                else
                {
                    int colonPosition = line.IndexOf(':');
                    string question = line.Substring(colonPosition + 1, line.Length - colonPosition - 1);
                    string sQuestionTF = line.Substring(colonPosition - 1, 1);
                    string sQuestionNumber = line.Substring(0, line.Length - question.Length - 2);
                    int questionNumber;
                    questionNumber = Int32.Parse(sQuestionNumber);
                    bool questionTF;
                    if (sQuestionTF == "T")
                        questionTF = true;
                    else
                        questionTF = false;
                    if (userAnswers[questionNumber - 1] == questionTF && outputtedLines > 40)
                    {
                        critPage2 += line + "\r\n";
                        outputtedLines++;
                    }
                    else if (userAnswers[questionNumber - 1] == questionTF && outputtedLines <= 40)
                    {
                        critPage1 += line + "\r\n";
                        outputtedLines++;
                    }
                    if (userAnswers[questionNumber - 1] == questionTF)
                    {
                        critOutput += line + "\r\n";
                    }
                }
                line = critItemFile.ReadLine();
                lineCounter++;
            }
            string[] critTotal = { critOutput, critPage1, critPage2 };
            return critTotal;
        }
    }
}

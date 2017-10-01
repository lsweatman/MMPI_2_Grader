using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMPI_Try_2.Grading
{
    class RawToSubscales
    {
        private List<bool?> userAnswers = new List<bool?>();

        // 2D array for populated raw scales
        private List<List<int[]>> rawScales = new List<List<int[]>>();

        // Container for the graded categories
        private List<List<int>> categoryTotals = new List<List<int>>();

        // These two declared here out of sheer convenience 
        // Variable Response
        private static int[] varResponseAnswers = new int[134] {3,39,6,90,6,90,9,56,28,59,31,299,32,316,40,176,46,265,48,184,49,280,73,377,81,284,81,284,83,288,
                                                                84,105,86,359,95,388,99,138,103,344,110,374,110,374,116,430,125,195,125,195,135,482,136,507,136,
                                                                507,152,464,161,185,161,185,165,565,166,268,166,268,167,243,167,243,196,415,199,467,199,467,226,
                                                                267,259,333,262,275,290,556,290,556,339,394,349,515,349,515,350,521,353,370,353,370,364,554,369,
                                                                421,372,405,372,405,380,562,395,435,395,435,396,403,396,403,411,485,411,485,472,533,472,533,491,
                                                                509,506,520,506,520,513,542}; //VRIN

        private static bool[] varResponseTF = new bool[134] { true, true, true, false, false, true, false, false, true, false, true, false, false, true,
                                                        true, true, true, false, true, true, true, false, true, false, true, false, false, true, true,
                                                        true, true, false, true, false, false, true, false, true, true, false, true, false, false, true,
                                                        true, false, true, true, false, false, false, true, true, false, false, true, false, false, true,
                                                        false, false, true, false, false, true, false, false, true, true, false, false, true, false, true,
                                                        true, false, false, true, true, false, false, true, false, false, true, false, false, true, false,
                                                        true, true, false, false, true, false, true, true, false, false, true, false, true, false, true,
                                                        true, false, false, true, true, false, true, false, false, true, true, false, false, true, true,
                                                        false, false, true, true, false, false, true, true, false, true, false, false, true, true, false };

        // True Response 
        int[] trueResponseAnswers = new int[28] { 3, 39, 12, 166, 40, 176, 48, 184, 63, 127, 65, 95, 73, 239, 83, 288, 99, 314, 125, 195,
                                                    209, 351, 359, 367, 377, 534, 556, 560 }; //TRIN
        int[] falseResponseAnswers = new int[18] { 9, 56, 65, 95, 125, 195, 140, 196, 152, 464, 165, 565, 262, 275, 265, 360, 359, 367 };

        public RawToSubscales(List<bool?> answers, List<List<int[]>> scales)
        {
            userAnswers = answers;
            rawScales = scales;
        }

        public List<List<int>> gradeRawAnswers()
        {
            for (int x = 0; x < 5; x++) // Iterates through 5 major scales
            {
                List<int> emptyMajorScales = new List<int>(); // Add empty list
                categoryTotals.Add(emptyMajorScales);
                for (int y = 0; y < rawScales[x].Count; y += 2) // Iterates through each true/false pair in the scales
                {
                    int categorySubTotal = 0;
                    for (int bank = 0; bank < rawScales[x][y].Length; bank++)
                    {
                        if (userAnswers[(rawScales[x][y][bank]) - 1] == true) // Needed to add == for (bool?) to work
                            categorySubTotal++;
                    }
                    for (int bank = 0; bank < rawScales[x][y + 1].Length; bank++)
                    {
                        if (userAnswers[(rawScales[x][y + 1][bank]) - 1] == false)
                            categorySubTotal++;
                    }
                    categoryTotals[x].Add(categorySubTotal);
                }
            }

            // Add the variable and true/false response sections back in
            // I don't know why they jammed it in the middle of the other sections
            insertResponseSection();
            return categoryTotals;
        }

        private void insertResponseSection()
        {
            // Get subtotal for the variable responses
            int variableCategoryTotal = 0;
            for (int i = 0; i < varResponseAnswers.Length; i += 2)
            {
                if ((userAnswers[varResponseAnswers[i] - 1] == varResponseTF[i]) && 
                    (userAnswers[varResponseAnswers[i + 1] - 1] == varResponseTF[i + 1]))
                {
                    variableCategoryTotal++;
                }
            }
            
            // Get subtotal for the true/false responses
            int tfCategoryTotal = 9;
            for (int i = 0; i < trueResponseAnswers.Length; i += 2)
            {
                if ((userAnswers[trueResponseAnswers[i] - 1] == true) && 
                    (userAnswers[trueResponseAnswers[i + 1] - 1] == true))
                {
                    tfCategoryTotal++;
                }
            }
            for (int i = 0; i < falseResponseAnswers.Length; i += 2)
            {
                if ((userAnswers[falseResponseAnswers[i] - 1] == false) && 
                    (userAnswers[falseResponseAnswers[i + 1] - 1] == false))
                {
                    tfCategoryTotal++;
                }
            }

            // Insert into the category totals
            categoryTotals[4].Insert(5, variableCategoryTotal);
            categoryTotals[4].Insert(6, tfCategoryTotal);
        } 
    }
}

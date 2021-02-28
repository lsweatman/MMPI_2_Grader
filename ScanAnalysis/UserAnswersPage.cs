using System.Drawing;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace MMPI_Try_2.ScanAnalysis
{
    public class UserAnswersPage
    {
        public struct CoordPairings
        {
            public int[] trueCoord;
            public int[] falseCoord; 
        };

        private Bitmap page;
        private Graphics g;
        private List<bool?> userAnswers = new List<bool?>();
        private List<int> yPositions = new List<int>();
        private List<int> xPositions;
        public List<CoordPairings> allCoords;
        // Testing
        private List<int> confidenceLevel;
        private List<int> nonAnswers = new List<int>();
        private List<int> doubleAnswers = new List<int>();

        public UserAnswersPage(string file, List<CoordPairings> foundCoords)
        {
            Image preFlipImage = Image.FromFile(file);
            if (preFlipImage.Width > preFlipImage.Height) // Flip if needed
            {
                preFlipImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            Bitmap original = (Bitmap)preFlipImage;
            page = new Bitmap(original, new Size(4960, 6480)); // Transform to correct size
            g = Graphics.FromImage(page);
            
            allCoords = foundCoords;
            confidenceLevel = new List<int>();
            //populateCoords();
            checkPairings();

            // verifyCorrectPairings();

            // Create new file name by appending "Markup" to the end
            string newFileName = file.Substring(0, file.Length - 4) + "Markup.png";
            page.Save(newFileName);
            Process.Start(newFileName);

            /*if (nonAnswers.Count > 6 && doubleAnswers.Count > 0)
            {
                MessageBox.Show("There are " + nonAnswers.Count +
                                " non-answers. \r\nThere are also " + doubleAnswers.Count +
                                " double answers. (If unchanged, they will count as non-answers.");
            }
            else if (nonAnswers.Count > 6)
            {
                MessageBox.Show("There are " + nonAnswers.Count + " non-answers." );
            }
            else if (doubleAnswers.Count > 0)
            {
                MessageBox.Show("There are " + doubleAnswers.Count +
                                " double answers. (If unchanged, they will count as non-answers.");
            }*/
        }

        ~UserAnswersPage()
        {
            page = null;
        }

        public List<bool?> getUserInfo()
        {
            return userAnswers;
        } 

        public List<int> getNonAnswers()
        {
            return nonAnswers;
        }

        public List<int> getDoubleAnswers()
        {
            return doubleAnswers;
        }

        private void populateCoords()
        {
            // Step 1: Grab the y positions of the center of the black bars
            int yCoord = 0;
            double yAxisGuides = page.Width * 0.967578;


            while (yCoord < page.Height)
            {
                Color pixel = page.GetPixel(Convert.ToInt32(yAxisGuides), yCoord);
                if (pixel.R <= 128 && pixel.G <= 128 && pixel.B <= 128) // Gray or greater
                {
                    // Used to average to get box center
                    int lowPosition = yCoord;
                    page.SetPixel(Convert.ToInt32(yAxisGuides), yCoord, Color.Red); // Test markup
                    while (pixel.R <= 200 && pixel.G <= 200 && pixel.B <= 200)
                    {
                        yCoord++;
                        pixel = page.GetPixel(Convert.ToInt32(yAxisGuides), yCoord);
                    }
                    // Put the center in the List
                    yPositions.Add((yCoord + lowPosition) / 2);
                }
                if (yPositions.Count == 58)
                {
                    break;
                }
                yCoord++;
            }

            // Trim off the 2 extra y coords
            yPositions.RemoveAt(31);
            yPositions.RemoveAt(15);

            // Step 2: Hardcode x coordinates. Spacing 100 between T and F - 300 between sets
            //xPositions = new List<int> { 584, 683, 984, 1083,
            //                             1386, 1485, 1787, 1886,
            //                             2187, 2287, 2589, 2687,
            //                             2989, 3089, 3390, 3490,
            //                             3790, 3890, 4190, 4290,
            //                             4590, 4690 }; // Luke Scanner
            xPositions = new List<int> { 601, 700, 991, 1089,
                                        1379, 1475, 1769, 1865,
                                        2157, 2255, 2547, 2643,
                                        2935, 3031, 3323, 3421,
                                        3711, 3809, 4099, 4197,
                                        4489, 4585}; // MTI Scanner
            // Step 3: Create coordinate pairings for each question (T and F)
            for (int x = 0; x < xPositions.Count; x += 2)
            {
                // Compensate for the first gap
                if (x < 4)
                {
                    for (int y = 15; y < yPositions.Count; y++)
                    {
                        if (y == 45)
                        {
                            y++;
                        }
                        CoordPairings newPairing = new CoordPairings();
                        newPairing.trueCoord = new int[2];
                        newPairing.falseCoord = new int[2];

                        newPairing.trueCoord[0] = xPositions[x];
                        newPairing.trueCoord[1] = yPositions[y];

                        newPairing.falseCoord[0] = xPositions[x + 1];
                        newPairing.falseCoord[1] = yPositions[y];
                        allCoords.Add(newPairing);
                    }
                }
                // Compensate for the last gap
                else if (x == 20)
                {
                    for (int y = 0; y < yPositions.Count - 9; y++)
                    {
                        CoordPairings newPairing = new CoordPairings();
                        newPairing.trueCoord = new int[2];
                        newPairing.falseCoord = new int[2];

                        newPairing.trueCoord[0] = xPositions[x];
                        newPairing.trueCoord[1] = yPositions[y];

                        newPairing.falseCoord[0] = xPositions[x + 1];
                        newPairing.falseCoord[1] = yPositions[y];
                        allCoords.Add(newPairing);
                    }
                }
                else
                {
                    for (int y = 0; y < yPositions.Count; y++)
                    {
                        if (y == 45)
                        {
                            y++;
                        }
                        CoordPairings newPairing = new CoordPairings();
                        newPairing.trueCoord = new int[2];
                        newPairing.falseCoord = new int[2];

                        newPairing.trueCoord[0] = xPositions[x];
                        newPairing.trueCoord[1] = yPositions[y];

                        newPairing.falseCoord[0] = xPositions[x + 1];
                        newPairing.falseCoord[1] = yPositions[y];
                        allCoords.Add(newPairing);
                    }
                }
            }
        }

        // Testing only
        private void verifyCorrectPairings()
        {
            foreach (CoordPairings item in allCoords)
            {
                //drawBox(item.trueCoord[0], item.trueCoord[1], 2, 2);
                //drawBox(item.falseCoord[0], item.falseCoord[1], 2, 2);
                page.SetPixel(item.trueCoord[0], item.trueCoord[1], Color.Blue);
                page.SetPixel(item.falseCoord[0], item.falseCoord[1], Color.Blue);
            }
        }
        
        private void checkPairings()
        {
            for (int i = 0; i < allCoords.Count; i++)
            {
                // Will switch to true if confident
                bool trueUserEntry = false;
                bool falseUserEntry = false;

                // Determine if one, none, or both are circled
                if (checkBubble(allCoords[i].trueCoord[0], allCoords[i].trueCoord[1]) > 60)
                {
                    drawBoxOutline(allCoords[i].trueCoord[0], allCoords[i].trueCoord[1], 65, 65, 5, Color.Blue);
                    trueUserEntry = true;
                }
                if (checkBubble(allCoords[i].falseCoord[0], allCoords[i].falseCoord[1]) > 60)
                {
                    drawBoxOutline(allCoords[i].falseCoord[0], allCoords[i].falseCoord[1], 65, 65, 5, Color.Blue);
                    falseUserEntry = true;
                }

                // If both have been circled 
                if (trueUserEntry && falseUserEntry)
                {
                    doubleAnswers.Add(i);
                    userAnswers.Add(null);
                    drawBoxOutline(allCoords[i].trueCoord[0], allCoords[i].trueCoord[1], 65, 150, 9, Color.Red);
                }
                // If neither have been circled
                else if (!trueUserEntry && !falseUserEntry)
                {
                    drawBoxOutline(allCoords[i].trueCoord[0], allCoords[i].trueCoord[1], 65, 150, 9, Color.Green);
                    userAnswers.Add(null);
                    nonAnswers.Add(i);
                }
                else
                {
                    bool response = (trueUserEntry) ? true : false;
                    userAnswers.Add(response);
                }
            }
        }

        // returns how confident the function thinks that the bubble is filled
        private int checkBubble(int xCoord, int yCoord)
        {
            int confidence = 0;
            // Checks 20x20 box - 400 pixels
            for (int x = xCoord - 10; x < xCoord + 10; x++)
            {
                for (int y = yCoord; y < yCoord + 10; y++)
                {
                    // Check if the pixel is in bounds
                    if (x >= 0 && x <= page.Size.Width && y >= 0 && y <= page.Size.Height)
                    {
                        Color pixel = page.GetPixel(x, y);

                        // Check for gray tones - pencil comes out very light
                        if (pixel.R <= 210 && pixel.G <= 210 && pixel.B <= 210)
                        {
                            confidence += 2;
                        }
                    }
                }
            }
            confidenceLevel.Add(confidence / 4);
            return confidence / 4;
        }

        private void drawBoxSolid(int xCenter, int yCenter, int height, int width)
        {
            for (int x = xCenter - (width / 2); x < xCenter + (width / 2); x++)
            {
                for (int y = yCenter - (height / 2); y < yCenter + (height / 2); y++)
                {
                    // Checks that pixel is in bounds
                    if (x >= 0 && x <= page.Size.Width && y >= 0 && y <= page.Size.Height)
                    {
                        page.SetPixel(x, y, Color.Blue);
                    }
                }
            }
        }

        private void drawBoxOutline(int xCenter, int yCenter, int height,
                                    int width, int thickness, Color boxColor)
        {
            Rectangle rect = new Rectangle(xCenter - (height/2), yCenter - (height/2), width, height);
            Pen pen = new Pen(boxColor, thickness);
            pen.Alignment = PenAlignment.Inset; //<-- this
            g.DrawRectangle(pen, rect);
        }
    }
}

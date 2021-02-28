using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace MMPI_Try_2.ScanAnalysis
{
    public class ImageVerify
    {
        public struct Padding
        {
            public int topPadding;
            public int bottomPadding;
            public int leftPadding;
            public int rightPadding;
        };

        private struct Coordinate
        {
            public int x;
            public int y;
        }

        private Bitmap page;
        private Padding pagePadding;
        private double yAxisGuides;
        private bool isValid;
        private string errorMessage;
        private Coordinate[] allRightBoxes = new Coordinate[63];
        private Coordinate[] allBottomBoxes = new Coordinate[8]; // These will be in reverse order!
        private List<UserAnswersPage.CoordPairings> trueFalseHolder = new List<UserAnswersPage.CoordPairings>();

        public ImageVerify(string file)
        {
            // Rotates the image if landscape is detected
            Image preFlipImage = Image.FromFile(file);
            if (preFlipImage.Width > preFlipImage.Height)
            {
                preFlipImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            Bitmap original = (Bitmap)preFlipImage;
            page = new Bitmap(original, new Size(4960, 6480));
            //page.Save(file);

            // Order of things to complete to validate 
            // Step 1: Find the y axis values
            // Step 1.1: Find the top right center of box
            /*using (CornerSelector userCornerPick = new CornerSelector(page))
            {
                string instructions = "Please click on the center of the black boxes in the lower left" +
                " and upper right corners. (Arrows will show where they are typically located";
                MessageBox.Show(instructions, "Scanning Instructions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                userCornerPick.ShowDialog();
            }*/
            if (!populateReferenceBoxes())
            {
                isValid = false;
                return;
            }
            populateBubbleCoords();
          
            isValid = true;
        }

        ~ImageVerify()
        {
            page = null;
        }

        public bool getFileValidity()
        {
            return isValid;
        }

        public List<UserAnswersPage.CoordPairings> getCoordPairings()
        {
            return trueFalseHolder;
        }

        public string getErrorMessage()
        {
            return errorMessage;
        }

        private void populateBubbleCoords()
        {
            int bottomPixelDistance = allBottomBoxes[6].x - allBottomBoxes[7].x;
            // The bottom 5 don't matter
            /*for (int i = 0; i < allRightBoxes.Length - 5; i++)
            {
                // Skip the gaps in the middle
                if (i == 15 || i == 31)
                {
                    i++;
                }
                if (i == 47) // Grab those pesky two 
                {
                    drawBoxSolid(allBottomBoxes[1].x, allRightBoxes[i].y, 20, 20, Color.Red);
                    drawBoxSolid(allBottomBoxes[1].x - bottomPixelDistance, allRightBoxes[i].y, 20, 20, Color.Red);
                    i++;
                }
                for (int x = 0; x < 10; x+=4) // First fourth using the second bottom marker
                {
                    if (i < 15) // For the box in the top corner
                    {
                        x = 8;
                    }
                    drawBoxSolid(allBottomBoxes[6].x + (bottomPixelDistance * x), allRightBoxes[i].y, 20, 20, Color.Red);
                    drawBoxSolid(allBottomBoxes[6].x + (bottomPixelDistance * (x + 1)), allRightBoxes[i].y, 20, 20, Color.Red);
                }
                for (int x = 0; x < 14; x+=4)// second fourth using 5th marker
                {
                    drawBoxSolid(allBottomBoxes[3].x - (bottomPixelDistance * x), allRightBoxes[i].y, 20, 20, Color.Red);
                    drawBoxSolid(allBottomBoxes[3].x - (bottomPixelDistance * (x + 1)), allRightBoxes[i].y, 20, 20, Color.Red);
                }
                for (int x = 0; x < 15; x+=4)
                {
                    drawBoxSolid(allBottomBoxes[2].x - (bottomPixelDistance * x), allRightBoxes[i].y, 20, 20, Color.Red);
                    drawBoxSolid(allBottomBoxes[2].x - (bottomPixelDistance * (x + 1)), allRightBoxes[i].y, 20, 20, Color.Red);
                }
                if (i < 49)// the very last column 
                {
                    drawBoxSolid(allBottomBoxes[1].x, allRightBoxes[i].y, 20, 20, Color.Red);
                    drawBoxSolid(allBottomBoxes[1].x - bottomPixelDistance, allRightBoxes[i].y, 20, 20, Color.Red);
                }
            }*/
            int offset = 0;
            for (int i = 1; i <= 11; i++) // There are 11 columns on the answer page
            {
                if (i == 1 || i == 2)
                {
                    for (int vertical = 16; vertical < allRightBoxes.Length - 5; vertical++)
                    {
                        if (vertical == 31 || vertical == 47) // the two gaps in the middle
                        {
                            vertical++;
                        }

                        int[] truePairing = new int[2];
                        int[] falsePairing = new int[2];
                        UserAnswersPage.CoordPairings tempCoordPairings;
                        tempCoordPairings.trueCoord = truePairing;
                        tempCoordPairings.falseCoord = falsePairing;

                        truePairing[0] = allBottomBoxes[6].x + (bottomPixelDistance * offset);
                        truePairing[1] = allRightBoxes[vertical].y;
                        drawBoxSolid(allBottomBoxes[6].x + (bottomPixelDistance * offset), allRightBoxes[vertical].y, 15, 15, Color.Blue);
                        falsePairing[0] = allBottomBoxes[6].x + (bottomPixelDistance * (offset + 1));
                        falsePairing[1] = allRightBoxes[vertical].y;
                        drawBoxSolid(allBottomBoxes[6].x + (bottomPixelDistance * (offset + 1)), allRightBoxes[vertical].y, 15, 15, Color.Blue);
                        trueFalseHolder.Add(tempCoordPairings);
                    }
                }
                else if (i == 3)
                {
                    for (int vertical = 0; vertical < allRightBoxes.Length - 5; vertical++)
                    {
                        if (vertical == 15 || vertical == 31 || vertical == 47) // the two gaps in the middle
                        {
                            vertical++;
                        }

                        int[] truePairing = new int[2];
                        int[] falsePairing = new int[2];
                        UserAnswersPage.CoordPairings tempCoordPairings;
                        tempCoordPairings.trueCoord = truePairing;
                        tempCoordPairings.falseCoord = falsePairing;

                        truePairing[0] = allBottomBoxes[6].x + (bottomPixelDistance * offset);
                        truePairing[1] = allRightBoxes[vertical].y;
                        drawBoxSolid(allBottomBoxes[6].x + (bottomPixelDistance * offset), allRightBoxes[vertical].y, 15, 15, Color.Blue);
                        falsePairing[0] = allBottomBoxes[6].x + (bottomPixelDistance * (offset + 1));
                        falsePairing[1] = allRightBoxes[vertical].y;
                        drawBoxSolid(allBottomBoxes[6].x + (bottomPixelDistance * (offset + 1)), allRightBoxes[vertical].y, 15, 15, Color.Blue);
                        trueFalseHolder.Add(tempCoordPairings);
                    }
                }
                else if (i == 4)
                {
                    offset = -3;
                    for (int vertical = 0; vertical < allRightBoxes.Length - 5; vertical++)
                    {
                        if (vertical == 15 || vertical == 31 || vertical == 47) // the two gaps in the middle
                        {
                            vertical++;
                        }

                        int[] truePairing = new int[2];
                        int[] falsePairing = new int[2];
                        UserAnswersPage.CoordPairings tempCoordPairings;
                        tempCoordPairings.trueCoord = truePairing;
                        tempCoordPairings.falseCoord = falsePairing;

                        truePairing[0] = allBottomBoxes[5].x + (bottomPixelDistance * (offset));
                        truePairing[1] = allRightBoxes[vertical].y;
                        drawBoxSolid(allBottomBoxes[5].x + (bottomPixelDistance * (offset)), allRightBoxes[vertical].y, 15, 15, Color.Blue);
                        falsePairing[0] = allBottomBoxes[5].x + (bottomPixelDistance * (offset + 1));
                        falsePairing[1] = allRightBoxes[vertical].y;
                        drawBoxSolid(allBottomBoxes[5].x + (bottomPixelDistance * (offset + 1)), allRightBoxes[vertical].y, 15, 15, Color.Blue);
                        trueFalseHolder.Add(tempCoordPairings);
                    }
                }
                else if (i == 5)
                {
                    offset = 1;
                    for (int vertical = 0; vertical < allRightBoxes.Length - 5; vertical++)
                    {
                        if (vertical == 15 || vertical == 31 || vertical == 47) // the two gaps in the middle
                        {
                            vertical++;
                        }

                        int[] truePairing = new int[2];
                        int[] falsePairing = new int[2];
                        UserAnswersPage.CoordPairings tempCoordPairings;
                        tempCoordPairings.trueCoord = truePairing;
                        tempCoordPairings.falseCoord = falsePairing;

                        truePairing[0] = allBottomBoxes[5].x + (bottomPixelDistance * (offset));
                        truePairing[1] = allRightBoxes[vertical].y;
                        drawBoxSolid(allBottomBoxes[5].x + (bottomPixelDistance * (offset)), allRightBoxes[vertical].y, 15, 15, Color.Blue);
                        falsePairing[0] = allBottomBoxes[5].x + (bottomPixelDistance * (offset + 1));
                        falsePairing[1] = allRightBoxes[vertical].y;
                        drawBoxSolid(allBottomBoxes[5].x + (bottomPixelDistance * (offset + 1)), allRightBoxes[vertical].y, 15, 15, Color.Blue);
                        trueFalseHolder.Add(tempCoordPairings);
                    }
                }
                else if (i == 6)
                {
                    offset = -2;
                    for (int vertical = 0; vertical < allRightBoxes.Length - 5; vertical++)
                    {
                        if (vertical == 15 || vertical == 31 || vertical == 47) // the two gaps in the middle
                        {
                            vertical++;
                        }

                        int[] truePairing = new int[2];
                        int[] falsePairing = new int[2];
                        UserAnswersPage.CoordPairings tempCoordPairings;
                        tempCoordPairings.trueCoord = truePairing;
                        tempCoordPairings.falseCoord = falsePairing;

                        truePairing[0] = allBottomBoxes[4].x + (bottomPixelDistance * (offset));
                        truePairing[1] = allRightBoxes[vertical].y;
                        drawBoxSolid(allBottomBoxes[4].x + (bottomPixelDistance * (offset)), allRightBoxes[vertical].y, 15, 15, Color.Blue);
                        falsePairing[0] = allBottomBoxes[4].x + (bottomPixelDistance * (offset + 1));
                        falsePairing[1] = allRightBoxes[vertical].y;
                        drawBoxSolid(allBottomBoxes[4].x + (bottomPixelDistance * (offset + 1)), allRightBoxes[vertical].y, 15, 15, Color.Blue);
                        trueFalseHolder.Add(tempCoordPairings);
                    }
                }
                else if (i == 7)
                {
                    offset = -1;
                    for (int vertical = 0; vertical < allRightBoxes.Length - 5; vertical++)
                    {
                        if (vertical == 15 || vertical == 31 || vertical == 47) // the two gaps in the middle
                        {
                            vertical++;
                        }

                        int[] truePairing = new int[2];
                        int[] falsePairing = new int[2];
                        UserAnswersPage.CoordPairings tempCoordPairings;
                        tempCoordPairings.trueCoord = truePairing;
                        tempCoordPairings.falseCoord = falsePairing;

                        truePairing[0] = allBottomBoxes[3].x + (bottomPixelDistance * (offset));
                        truePairing[1] = allRightBoxes[vertical].y;
                        drawBoxSolid(allBottomBoxes[3].x + (bottomPixelDistance * (offset)), allRightBoxes[vertical].y, 15, 15, Color.Blue);
                        falsePairing[0] = allBottomBoxes[3].x + (bottomPixelDistance * (offset + 1));
                        falsePairing[1] = allRightBoxes[vertical].y;
                        drawBoxSolid(allBottomBoxes[3].x + (bottomPixelDistance * (offset + 1)), allRightBoxes[vertical].y, 15, 15, Color.Blue);
                        trueFalseHolder.Add(tempCoordPairings);
                    }
                }
                else if (i == 8)
                {
                    offset = 3;
                    for (int vertical = 0; vertical < allRightBoxes.Length - 5; vertical++)
                    {
                        if (vertical == 15 || vertical == 31 || vertical == 47) // the two gaps in the middle
                        {
                            vertical++;
                        }

                        int[] truePairing = new int[2];
                        int[] falsePairing = new int[2];
                        UserAnswersPage.CoordPairings tempCoordPairings;
                        tempCoordPairings.trueCoord = truePairing;
                        tempCoordPairings.falseCoord = falsePairing;

                        truePairing[0] = allBottomBoxes[3].x + (bottomPixelDistance * (offset));
                        truePairing[1] = allRightBoxes[vertical].y;
                        drawBoxSolid(allBottomBoxes[3].x + (bottomPixelDistance * (offset)), allRightBoxes[vertical].y, 15, 15, Color.Blue);
                        falsePairing[0] = allBottomBoxes[3].x + (bottomPixelDistance * (offset + 1));
                        falsePairing[1] = allRightBoxes[vertical].y;
                        drawBoxSolid(allBottomBoxes[3].x + (bottomPixelDistance * (offset + 1)), allRightBoxes[vertical].y, 15, 15, Color.Blue);
                        trueFalseHolder.Add(tempCoordPairings);
                    }
                }
                else if (i == 9)
                {
                    offset = -5;
                    for (int vertical = 0; vertical < allRightBoxes.Length - 5; vertical++)
                    {
                        if (vertical == 15 || vertical == 31 || vertical == 47) // the two gaps in the middle
                        {
                            vertical++;
                        }

                        int[] truePairing = new int[2];
                        int[] falsePairing = new int[2];
                        UserAnswersPage.CoordPairings tempCoordPairings;
                        tempCoordPairings.trueCoord = truePairing;
                        tempCoordPairings.falseCoord = falsePairing;

                        truePairing[0] = allBottomBoxes[2].x + (bottomPixelDistance * (offset));
                        truePairing[1] = allRightBoxes[vertical].y;
                        drawBoxSolid(allBottomBoxes[2].x + (bottomPixelDistance * (offset)), allRightBoxes[vertical].y, 15, 15, Color.Blue);
                        falsePairing[0] = allBottomBoxes[2].x + (bottomPixelDistance * (offset + 1));
                        falsePairing[1] = allRightBoxes[vertical].y;
                        drawBoxSolid(allBottomBoxes[2].x + (bottomPixelDistance * (offset + 1)), allRightBoxes[vertical].y, 15, 15, Color.Blue);
                        trueFalseHolder.Add(tempCoordPairings);
                    }
                }
                else if (i == 10)
                {
                    offset = -1;
                    for (int vertical = 0; vertical < allRightBoxes.Length - 5; vertical++)
                    {
                        if (vertical == 15 || vertical == 31 || vertical == 47) // the two gaps in the middle
                        {
                            vertical++;
                        }

                        int[] truePairing = new int[2];
                        int[] falsePairing = new int[2];
                        UserAnswersPage.CoordPairings tempCoordPairings;
                        tempCoordPairings.trueCoord = truePairing;
                        tempCoordPairings.falseCoord = falsePairing;

                        truePairing[0] = allBottomBoxes[2].x + (bottomPixelDistance * (offset));
                        truePairing[1] = allRightBoxes[vertical].y;
                        drawBoxSolid(allBottomBoxes[2].x + (bottomPixelDistance * (offset)), allRightBoxes[vertical].y, 15, 15, Color.Blue);
                        falsePairing[0] = allBottomBoxes[2].x + (bottomPixelDistance * (offset + 1));
                        falsePairing[1] = allRightBoxes[vertical].y;
                        drawBoxSolid(allBottomBoxes[2].x + (bottomPixelDistance * (offset + 1)), allRightBoxes[vertical].y, 15, 15, Color.Blue);
                        trueFalseHolder.Add(tempCoordPairings);
                    }
                }
                else if (i == 11)
                {
                    offset = -1;
                    for (int vertical = 0; vertical < allRightBoxes.Length - 14; vertical++)
                    {
                        if (vertical == 15 || vertical == 31) // the two gaps in the middle
                        {
                            vertical++;
                        }

                        int[] truePairing = new int[2];
                        int[] falsePairing = new int[2];
                        UserAnswersPage.CoordPairings tempCoordPairings;
                        tempCoordPairings.trueCoord = truePairing;
                        tempCoordPairings.falseCoord = falsePairing;

                        truePairing[0] = allBottomBoxes[1].x + (bottomPixelDistance * (offset));
                        truePairing[1] = allRightBoxes[vertical].y;
                        drawBoxSolid(allBottomBoxes[1].x + (bottomPixelDistance * (offset)), allRightBoxes[vertical].y, 15, 15, Color.Blue);
                        falsePairing[0] = allBottomBoxes[1].x + (bottomPixelDistance * (offset + 1));
                        falsePairing[1] = allRightBoxes[vertical].y;
                        drawBoxSolid(allBottomBoxes[1].x + (bottomPixelDistance * (offset + 1)), allRightBoxes[vertical].y, 15, 15, Color.Blue);
                        trueFalseHolder.Add(tempCoordPairings);
                    }
                }
                offset += 4;
            }
            //page.Save(@"C:\MMPI2\first2.png");
            isValid = true;
        }

        private bool populateReferenceBoxes()
        {
            // Finds the first black pixel in the corner
            int startXCoord = page.Width - 1;
            int startYCoord = 0;

            Color comparisonPixel = page.GetPixel(startXCoord, startYCoord);
            //int test = allRightBoxes.Length;
            bool validYCoords = false;
            while (startYCoord < 500) // Should be in the first 500 pixels
            {
                for (int i = 0; i < 180; i++)
                {
                    comparisonPixel = page.GetPixel(startXCoord, startYCoord);
                    if (comparisonPixel.R <= 128 && comparisonPixel.G <= 128 && comparisonPixel.B <= 128) // Pixel is black
                    {
                        drawBoxSolid(startXCoord, startYCoord, 5, 5, Color.Red);
                        validYCoords = true;
                        break;
                    }
                    else
                    {
                        page.SetPixel(startXCoord, startYCoord, Color.Blue);
                    }
                    
                    startXCoord--;
                }
                if (validYCoords)
                {
                    // need to give a little buffer room
                    //startXCoord -= 45;
                    startYCoord += 5;
                    break;
                }
                startXCoord = page.Width - 1;
                startYCoord++;
            }
            // Find the center of the black box
            int rightMostBlack = 0;
            for (int i = startXCoord+1; i < page.Width; i++)
            {
                Color pixel = page.GetPixel(i, startYCoord);
                if (pixel.R >= 128 && pixel.G >= 128 && pixel.B >= 128) //White or greater
                {
                    rightMostBlack = i;
                    break;
                }
                page.SetPixel(i, startYCoord, Color.Orange);
            }

            int leftMostBlack = 0;
            for (int i = startXCoord - 1; i > 4700; i--)
            {
                Color pixel = page.GetPixel(i, startYCoord);
                if (pixel.R >= 128 && pixel.G >= 128 && pixel.B >= 128) //White or greater
                {
                    leftMostBlack = i;
                    break;
                }
                page.SetPixel(i, startYCoord, Color.Aqua);
            }
            if (rightMostBlack == 0 || leftMostBlack == 0)
            {
                errorMessage = "Unable to find the center of the upper right box";
                return false;
            }
            startXCoord = (rightMostBlack + leftMostBlack) / 2;

            if (!validYCoords)
            {
                errorMessage = "Can't find any black pixels in the upper right corner";
                return false;
            }
            // Debug
            //page.Save(@"C:\MMPI2\cornerTest.png");

            // This section goes down the page and gets the position of all the estimated centers
            //double yAxisGuides = page.Width * 0.967578;
            int counter = 0;
            while (startYCoord < page.Height)
            {
                Color pixel = page.GetPixel(startXCoord, startYCoord);
                if (pixel.R <= 128 && pixel.G <= 128 && pixel.B <= 128) // Gray or greater
                {
                    
                    // Used to average to get box center
                    int lowPosition = startYCoord;
                    page.SetPixel(startXCoord, startYCoord, Color.Red); // Test markup
                    while (pixel.R <= 200 && pixel.G <= 200 && pixel.B <= 200)
                    {
                        startYCoord++;
                        pixel = page.GetPixel(startXCoord, startYCoord);
                    }
                    // Put the center in the List
                    drawBoxSolid(startXCoord, (startYCoord + lowPosition) / 2, 15, 15, Color.Red);
                    allRightBoxes[counter].x = startXCoord;
                    allRightBoxes[counter].y = (startYCoord + lowPosition) / 2;
                    
                    counter++;
                }
                if (counter == 63) 
                {
                    //Make sure that center is where the x values start their search
                    startYCoord = allRightBoxes[counter - 1].y;
                    break;
                }
                startYCoord++;
                
            }
            //page.Save(@"C:\MMPI2\rightTest.png");
            if (counter < 63)
            {
                errorMessage = "Couldn't find all the boxes along the right side\nSee C:\\MMPI2\\rightTest.png";
                return false;
            }
            else if (counter > 63)
            {
                errorMessage = "Found too many boxes along the right side\nSee C:\\MMPI2\\rightTest.png";
                return false;
            }
            // Debug
            

            // Get all the boxes on the bottom
            counter = 0;
            while (startXCoord > 0)
            {
                Color pixel = page.GetPixel(startXCoord, startYCoord);
                if (pixel.R <= 128 && pixel.G <= 128 && pixel.B <= 128) // Gray or greater
                {

                    // Used to average to get box center
                    int lowPosition = startXCoord;
                    page.SetPixel(startXCoord, startYCoord, Color.Red); // Test markup
                    while (pixel.R <= 200 && pixel.G <= 200 && pixel.B <= 200)
                    {
                        startXCoord--;
                        pixel = page.GetPixel(startXCoord, startYCoord);
                    }
                    // Put the center in the List
                    drawBoxSolid((startXCoord + lowPosition) / 2, startYCoord, 15, 15, Color.Red);
                    allBottomBoxes[counter].x = (startXCoord + lowPosition) / 2;
                    allBottomBoxes[counter].y = startYCoord;

                    counter++;
                }
                if (counter == 8)
                {
                    break;
                }
                startXCoord--;
            }
            if (counter < 8)
            {
                errorMessage = "Didn't find enough boxes along the bottom\nSee C:\\MMPI2\\bottomTest.png";
                return false;
            }
            else if (counter > 8)
            {
                errorMessage = "Found too many boxes along the bottom\nSee C:\\MMPI2\\bottomTest.png";
                return false;
            }
            //Debug
            //page.Save(@"C:\MMPI2\bottomTest.png");

            return validYCoords;
        }

        private bool verifyXAxis(int yCoord)
        {
            //int[] boxXPositions = { 505 - pagePadding.leftPadding, 608 - pagePadding.leftPadding,
            //                        2067 - pagePadding.leftPadding, 2756 - pagePadding.leftPadding,
            //                        3055 - pagePadding.leftPadding, 4238 - pagePadding.leftPadding,
            //                        4629 - pagePadding.leftPadding}; // All these should have darker pixels

            // Luke values
            //int[] boxXPositions = { 505 , 608 ,
            //                        2067 , 2756 ,
            //                        3055 , 4238 ,
            //                        4629 }; // All these should have darker pixels
            
            // MTI values
            int[] boxXPositions = { 505 , 601 ,
                                    2063 , 2742 ,
                                    3035 , 4200 ,
                                    4590 };
            foreach (int item in boxXPositions)
            {
                drawBoxSolid(item, yCoord, 45, 45, Color.Red);
            }
            //page.Save(@"C:\MMPI2\test.png");
            Color pixel;
            foreach (int position in boxXPositions)
            {
                pixel = page.GetPixel(position, yCoord);
                if (pixel.R >= 128 && pixel.G >= 128 && pixel.B >= 128)
                {
                    //page.Save(@"C:\MMPI2\test.png");
                    return false;
                }
                else
                {
                    drawBoxSolid(position, yCoord, 30, 50, Color.Blue);
                }
            }
            return true;
        }

        private int verifyYAxis()
        {
            int foundBoxes = 0;
            int yCoord = 0;
            while (yCoord < page.Height)
            {
                Color pixel = page.GetPixel(Convert.ToInt32(yAxisGuides), yCoord);
                if (pixel.R <= 128 && pixel.G <= 128 && pixel.B <= 128) // Gray or greater
                {
                    page.SetPixel(Convert.ToInt32(yAxisGuides), yCoord, Color.Red); // Test markup
                    while (pixel.R <= 200 && pixel.G <= 200 && pixel.B <= 200)
                    {
                        yCoord++;
                        pixel = page.GetPixel(Convert.ToInt32(yAxisGuides), yCoord);
                        drawBoxSolid(Convert.ToInt32(yAxisGuides), yCoord, 2, 50, Color.Blue); // Test markup
                    }
                    foundBoxes++;
                }
                if (foundBoxes == 63)
                {
                    return yCoord;
                }
                yCoord++;
            }
            return 0;
        }

        // Recolors a part of the black boxes on the x and y axis
        private void drawBoxSolid(int xCenter, int yCenter, int height, int width, Color boxColor)
        {
            for (int x = xCenter - (width / 2); x < xCenter + (width / 2); x++)
            {
                for (int y = yCenter - (height / 2); y < yCenter + (height / 2); y++)
                {
                    // Checks that pixel is in bounds
                    if (x >= 0 && x <= page.Size.Width && y >= 0 && y <= page.Size.Height)
                    {
                        page.SetPixel(x, y, boxColor);
                    }
                }
            }
        }
    }
}

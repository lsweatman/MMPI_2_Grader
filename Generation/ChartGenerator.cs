using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using MMPI_Try_2.Static;

namespace MMPI_Try_2
{
    class ChartGenerator
    {
        // Used to pass in the chart from the UI class
        private Chart basicChart;
        private Chart chartSection2;
        private Chart chartSection3;
        private Chart chartSection4;

        private List<List<int>> finalTotals;
        private List<List<int>> nonAdjustedTotals;

        private string filePath;

        // Scale abbrevation class
        private ScaleAbbreviations abbrevHolder = new ScaleAbbreviations();
        private List<List<string>> categoryAbbrev;

        private Font labelFont = new Font("Trebuchet MS", 16F, System.Drawing.FontStyle.Bold);

        public ChartGenerator(string filePath,
                              Chart chart1, 
                              Chart chart2, 
                              Chart chart3, 
                              Chart chart4,
                              List<List<int>> finalTotals,
                              List<List<int>> nonAdjustedTotals
                              )
        {
            this.filePath = filePath;

            basicChart = chart1;
            chartSection2 = chart2;
            chartSection3 = chart3;
            chartSection4 = chart4;

            this.finalTotals = finalTotals;
            this.nonAdjustedTotals = nonAdjustedTotals;

            categoryAbbrev = abbrevHolder.getCategoryAbbrev();

        }

        public bool generateChart()
        {
            basicChart.Series["Annotated Overlay"].Points.Clear();
            chartSection2.Series["Annotated Overlay"].Points.Clear();
            chartSection3.Series["Annotated Overlay"].Points.Clear();
            chartSection4.Series["Annotated Overlay"].Points.Clear();

            int majorScale = 1;
            int minorScale = 0;

            #region BASIC 
            // Set axis bounds
            basicChart.ChartAreas[0].AxisY.Maximum = 120;
            basicChart.ChartAreas[0].AxisY.Minimum = 0;
            basicChart.ChartAreas[0].AxisY.Interval = 10;
            basicChart.ChartAreas[0].AxisX.Interval = 1;
            basicChart.ChartAreas[0].AxisX.Maximum = 12;
            basicChart.ChartAreas[0].AxisX.Minimum = 0;
            //basicChart.Series["Guide Lines"].Points.AddXY(-1, 60);

            // Add all the points from the basic adjusted scales
            for (int i = 0; i < finalTotals[0].Count; i++)
            {
                basicChart.Series["Annotated Overlay"].Points.AddXY(i, finalTotals[0][i]);
                basicChart.Series["65 Line"].Points.AddXY(i, 65);
                basicChart.Series["50 Line"].Points.AddXY(i, 50);
            }

            // Labels at each scale
            for (int i = 0; i < 13; i++)
            {
                basicChart.ChartAreas[0].AxisX.CustomLabels.Add(i - 0.5, i + 0.5, finalTotals[0][i] + "-" + categoryAbbrev[0][i] + "\r\n" + nonAdjustedTotals[0][i]);
            }
            //basicChart.Series["Guide Lines"].Points.AddXY(13, 60);

            #endregion

            #region PAGE1

            // Set axis
            chartSection2.ChartAreas[0].AxisY.Maximum = 120;
            chartSection2.ChartAreas[0].AxisY.Minimum = 0;
            chartSection2.ChartAreas[0].AxisY.Interval = 10;
            chartSection2.ChartAreas[0].AxisX.Interval = 1;
            chartSection2.ChartAreas[0].AxisX.Maximum = 26;
            chartSection2.ChartAreas[0].AxisX.Minimum = 0;

            // Add data points
            // Always add 26 per page
            for (int i = 0; i < 26; i++)
            {
                // Skip to the next major scale if all minor scales looped through
                if (minorScale > finalTotals[majorScale].Count - 1)
                {
                    majorScale++;
                    minorScale = 0;
                }
                
                chartSection2.Series["Annotated Overlay"].Points.AddXY(i + .5, finalTotals[majorScale][minorScale]);
                chartSection2.Series["65 Line"].Points.AddXY(i, 65);
                chartSection2.Series["50 Line"].Points.AddXY(i, 50);
                chartSection2.ChartAreas[0].AxisX.CustomLabels.Add(i, i + 1, finalTotals[majorScale][minorScale] + "-" + 
                                                                                categoryAbbrev[majorScale][minorScale] + "\r\n" + 
                                                                                nonAdjustedTotals[majorScale][minorScale]);
                minorScale++;
            }
            chartSection2.Series["50 Line"].Points.AddXY(27, 50);
            chartSection2.Series["65 Line"].Points.AddXY(27, 65);

            chartSection2.Series["Annotated Overlay"]["PixelPointWidth"] = "32";
            chartSection2.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chartSection2.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            chartSection2.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            chartSection2.ChartAreas[0].AxisY.LabelStyle.Angle = -90;
            chartSection2.Series["Annotated Overlay"].LabelAngle = -90;
            chartSection2.Series["Annotated Overlay"].SmartLabelStyle.Enabled = false;
            chartSection2.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.None;
            chartSection2.ChartAreas[0].AxisX.LabelStyle.Font = labelFont;
            chartSection2.ChartAreas[0].AxisY.LabelAutoFitStyle = LabelAutoFitStyles.None;
            chartSection2.ChartAreas[0].AxisY.LabelStyle.Font = labelFont;


            // chartSection2.Visible = false;
            // basicChart.Visible = true;

            #endregion

            #region PAGE2
            chartSection3.ChartAreas[0].AxisY.Maximum = 120;
            chartSection3.ChartAreas[0].AxisY.Minimum = 0;
            chartSection3.ChartAreas[0].AxisY.Interval = 10;
            chartSection3.ChartAreas[0].AxisX.Interval = 1;
            chartSection3.ChartAreas[0].AxisX.Maximum = 26;
            chartSection3.ChartAreas[0].AxisX.Minimum = 0;
            
            // Fill page with 26 scales
            for (int i = 0; i < 26; i++)
            {
                if (minorScale > finalTotals[majorScale].Count - 1)
                {
                    majorScale++;
                    minorScale = 0;
                }
                //basicChart.Series["Basic Scales"].Points.AddXY(categoryNames[0][i], finalTotals[0][i]);
                chartSection3.Series["Annotated Overlay"].Points.AddXY(i + .5, finalTotals[majorScale][minorScale]);
                chartSection3.Series["65 Line"].Points.AddXY(i, 65);
                chartSection3.Series["50 Line"].Points.AddXY(i, 50);
                chartSection3.ChartAreas[0].AxisX.CustomLabels.Add(i, i + 1, finalTotals[majorScale][minorScale] + "-" + 
                                                                                categoryAbbrev[majorScale][minorScale] + "\r\n" + 
                                                                                nonAdjustedTotals[majorScale][minorScale]);
                minorScale++;
            }
            chartSection3.Series["50 Line"].Points.AddXY(27, 50);
            chartSection3.Series["65 Line"].Points.AddXY(27, 65);

            chartSection3.Series["Annotated Overlay"]["PixelPointWidth"] = "32";
            chartSection3.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chartSection3.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            chartSection3.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            chartSection3.ChartAreas[0].AxisY.LabelStyle.Angle = -90;
            chartSection3.Series["Annotated Overlay"].LabelAngle = -90;
            chartSection3.Series["Annotated Overlay"].SmartLabelStyle.Enabled = false;
            chartSection3.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.None;
            chartSection3.ChartAreas[0].AxisX.LabelStyle.Font = labelFont;
            chartSection3.ChartAreas[0].AxisY.LabelAutoFitStyle = LabelAutoFitStyles.None;
            chartSection3.ChartAreas[0].AxisY.LabelStyle.Font = labelFont;

            #endregion

            #region PAGE3
            chartSection4.ChartAreas[0].AxisY.Maximum = 120;
            chartSection4.ChartAreas[0].AxisY.Minimum = 0;
            chartSection4.ChartAreas[0].AxisY.Interval = 10;
            chartSection4.ChartAreas[0].AxisX.Interval = 1;
            chartSection4.ChartAreas[0].AxisX.Maximum = 22;
            chartSection4.ChartAreas[0].AxisX.Minimum = 0;
            
            for (int i = 0; i < 26; i++)
            {
                if (minorScale > finalTotals[majorScale].Count - 1)
                {
                    majorScale++;
                    minorScale = 0;
                }
                if (majorScale > finalTotals.Count - 1)
                {
                    break;
                }
                //basicChart.Series["Basic Scales"].Points.AddXY(categoryNames[0][i], finalTotals[0][i]);
                chartSection4.Series["Annotated Overlay"].Points.AddXY(i + .5, finalTotals[majorScale][minorScale]);
                chartSection4.Series["65 Line"].Points.AddXY(i, 65);
                chartSection4.Series["50 Line"].Points.AddXY(i, 50);
                chartSection4.ChartAreas[0].AxisX.CustomLabels.Add(i, i + 1, finalTotals[majorScale][minorScale] + "-" + 
                                                                                categoryAbbrev[majorScale][minorScale] + "\r\n" + 
                                                                                nonAdjustedTotals[majorScale][minorScale]);
                minorScale++;
            }
            chartSection4.Series["50 Line"].Points.AddXY(23, 50);
            chartSection4.Series["65 Line"].Points.AddXY(23, 65);

            chartSection4.Series["Annotated Overlay"]["PixelPointWidth"] = "35";
            chartSection4.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chartSection4.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            chartSection4.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            chartSection4.ChartAreas[0].AxisY.LabelStyle.Angle = -90;
            chartSection4.Series["Annotated Overlay"].LabelAngle = -90;
            chartSection4.Series["Annotated Overlay"].SmartLabelStyle.Enabled = false;
            chartSection4.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.None;
            chartSection4.ChartAreas[0].AxisX.LabelStyle.Font = labelFont;
            chartSection4.ChartAreas[0].AxisY.LabelAutoFitStyle = LabelAutoFitStyles.None;
            chartSection4.ChartAreas[0].AxisY.LabelStyle.Font = labelFont;

            #endregion

            string imageNamer = filePath;
            imageNamer = imageNamer.Substring(0, imageNamer.Length - 4);
            basicChart.SaveImage(imageNamer + "1.png", ChartImageFormat.Png);
            chartSection2.SaveImage(imageNamer + "2.png", ChartImageFormat.Png);
            chartSection3.SaveImage(imageNamer + "3.png", ChartImageFormat.Png);
            chartSection4.SaveImage(imageNamer + "4.png", ChartImageFormat.Png);
            return true;
        }
    }
}

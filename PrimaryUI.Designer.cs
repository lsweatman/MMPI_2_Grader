namespace MMPI_Try_2
{
    partial class PrimaryUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrimaryUI));
            this.enterDataButton = new System.Windows.Forms.Button();
            this.scoreDataButton = new System.Windows.Forms.Button();
            this.printCurrentButton = new System.Windows.Forms.Button();
            this.mainOutput = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.monthTextBox = new System.Windows.Forms.TextBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.genderTextBox = new System.Windows.Forms.TextBox();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.genderLabel = new System.Windows.Forms.Label();
            this.ageLabel = new System.Windows.Forms.Label();
            this.trueButton = new System.Windows.Forms.Button();
            this.falseButton = new System.Windows.Forms.Button();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.confirmUser = new System.Windows.Forms.Button();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.dayTextBox = new System.Windows.Forms.TextBox();
            this.monthLabel = new System.Windows.Forms.Label();
            this.dayLabel = new System.Windows.Forms.Label();
            this.yearLabel = new System.Windows.Forms.Label();
            this.viewUserFile = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.undoButton = new System.Windows.Forms.Button();
            this.BarLabel = new System.Windows.Forms.CheckBox();
            this.nonAnswer = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            this.SuspendLayout();
            // 
            // enterDataButton
            // 
            this.enterDataButton.Location = new System.Drawing.Point(550, 78);
            this.enterDataButton.Name = "enterDataButton";
            this.enterDataButton.Size = new System.Drawing.Size(150, 98);
            this.enterDataButton.TabIndex = 27;
            this.enterDataButton.Text = "1. Enter Data";
            this.enterDataButton.UseVisualStyleBackColor = true;
            this.enterDataButton.Click += new System.EventHandler(this.enterDataButton_Click);
            // 
            // scoreDataButton
            // 
            this.scoreDataButton.Location = new System.Drawing.Point(550, 286);
            this.scoreDataButton.Name = "scoreDataButton";
            this.scoreDataButton.Size = new System.Drawing.Size(150, 98);
            this.scoreDataButton.TabIndex = 22;
            this.scoreDataButton.Text = "3. Score Data";
            this.scoreDataButton.UseVisualStyleBackColor = true;
            this.scoreDataButton.Click += new System.EventHandler(this.scoreDataButton_Click);
            // 
            // printCurrentButton
            // 
            this.printCurrentButton.Enabled = false;
            this.printCurrentButton.Location = new System.Drawing.Point(550, 390);
            this.printCurrentButton.Name = "printCurrentButton";
            this.printCurrentButton.Size = new System.Drawing.Size(150, 101);
            this.printCurrentButton.TabIndex = 25;
            this.printCurrentButton.Text = "4. Print Current User";
            this.printCurrentButton.UseVisualStyleBackColor = true;
            this.printCurrentButton.Click += new System.EventHandler(this.printCurrentButton_Click);
            // 
            // mainOutput
            // 
            this.mainOutput.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mainOutput.Location = new System.Drawing.Point(28, 78);
            this.mainOutput.Multiline = true;
            this.mainOutput.Name = "mainOutput";
            this.mainOutput.ReadOnly = true;
            this.mainOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mainOutput.Size = new System.Drawing.Size(516, 516);
            this.mainOutput.TabIndex = 8;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(88, 12);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.ReadOnly = true;
            this.firstNameTextBox.Size = new System.Drawing.Size(175, 20);
            this.firstNameTextBox.TabIndex = 1;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(25, 14);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(63, 13);
            this.firstNameLabel.TabIndex = 7;
            this.firstNameLabel.Text = "First Name: ";
            // 
            // monthTextBox
            // 
            this.monthTextBox.Location = new System.Drawing.Point(347, 45);
            this.monthTextBox.Name = "monthTextBox";
            this.monthTextBox.ReadOnly = true;
            this.monthTextBox.Size = new System.Drawing.Size(42, 20);
            this.monthTextBox.TabIndex = 5;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(280, 48);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(30, 13);
            this.dateLabel.TabIndex = 9;
            this.dateLabel.Text = "Date";
            // 
            // genderTextBox
            // 
            this.genderTextBox.Location = new System.Drawing.Point(88, 45);
            this.genderTextBox.Name = "genderTextBox";
            this.genderTextBox.ReadOnly = true;
            this.genderTextBox.Size = new System.Drawing.Size(51, 20);
            this.genderTextBox.TabIndex = 3;
            // 
            // ageTextBox
            // 
            this.ageTextBox.Location = new System.Drawing.Point(209, 45);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.ReadOnly = true;
            this.ageTextBox.Size = new System.Drawing.Size(54, 20);
            this.ageTextBox.TabIndex = 4;
            // 
            // genderLabel
            // 
            this.genderLabel.AutoSize = true;
            this.genderLabel.Location = new System.Drawing.Point(25, 48);
            this.genderLabel.Name = "genderLabel";
            this.genderLabel.Size = new System.Drawing.Size(45, 13);
            this.genderLabel.TabIndex = 12;
            this.genderLabel.Text = "Gender:";
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Location = new System.Drawing.Point(171, 48);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(32, 13);
            this.ageLabel.TabIndex = 13;
            this.ageLabel.Text = "Age: ";
            // 
            // trueButton
            // 
            this.trueButton.Enabled = false;
            this.trueButton.Location = new System.Drawing.Point(120, 600);
            this.trueButton.Name = "trueButton";
            this.trueButton.Size = new System.Drawing.Size(99, 64);
            this.trueButton.TabIndex = 14;
            this.trueButton.Text = "True";
            this.trueButton.UseVisualStyleBackColor = true;
            this.trueButton.Click += new System.EventHandler(this.trueButton_Click);
            // 
            // falseButton
            // 
            this.falseButton.Enabled = false;
            this.falseButton.Location = new System.Drawing.Point(328, 600);
            this.falseButton.Name = "falseButton";
            this.falseButton.Size = new System.Drawing.Size(99, 64);
            this.falseButton.TabIndex = 15;
            this.falseButton.Text = "False";
            this.falseButton.UseVisualStyleBackColor = true;
            this.falseButton.Click += new System.EventHandler(this.falseButton_Click);
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(280, 14);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(61, 13);
            this.lastNameLabel.TabIndex = 16;
            this.lastNameLabel.Text = "Last Name:";
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(347, 12);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.ReadOnly = true;
            this.lastNameTextBox.Size = new System.Drawing.Size(195, 20);
            this.lastNameTextBox.TabIndex = 2;
            // 
            // confirmUser
            // 
            this.confirmUser.Location = new System.Drawing.Point(550, 20);
            this.confirmUser.Name = "confirmUser";
            this.confirmUser.Size = new System.Drawing.Size(107, 45);
            this.confirmUser.TabIndex = 18;
            this.confirmUser.Text = "Confirm User Information";
            this.confirmUser.UseVisualStyleBackColor = true;
            this.confirmUser.Visible = false;
            this.confirmUser.Click += new System.EventHandler(this.confirmUser_Click);
            // 
            // yearTextBox
            // 
            this.yearTextBox.Location = new System.Drawing.Point(504, 45);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.ReadOnly = true;
            this.yearTextBox.Size = new System.Drawing.Size(37, 20);
            this.yearTextBox.TabIndex = 7;
            // 
            // dayTextBox
            // 
            this.dayTextBox.Location = new System.Drawing.Point(424, 45);
            this.dayTextBox.Name = "dayTextBox";
            this.dayTextBox.ReadOnly = true;
            this.dayTextBox.Size = new System.Drawing.Size(34, 20);
            this.dayTextBox.TabIndex = 6;
            // 
            // monthLabel
            // 
            this.monthLabel.AutoSize = true;
            this.monthLabel.Location = new System.Drawing.Point(316, 48);
            this.monthLabel.Name = "monthLabel";
            this.monthLabel.Size = new System.Drawing.Size(25, 13);
            this.monthLabel.TabIndex = 28;
            this.monthLabel.Text = "MM";
            // 
            // dayLabel
            // 
            this.dayLabel.AutoSize = true;
            this.dayLabel.Location = new System.Drawing.Point(395, 48);
            this.dayLabel.Name = "dayLabel";
            this.dayLabel.Size = new System.Drawing.Size(23, 13);
            this.dayLabel.TabIndex = 29;
            this.dayLabel.Text = "DD";
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(464, 48);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(35, 13);
            this.yearLabel.TabIndex = 30;
            this.yearLabel.Text = "YYYY";
            // 
            // viewUserFile
            // 
            this.viewUserFile.Location = new System.Drawing.Point(550, 182);
            this.viewUserFile.Name = "viewUserFile";
            this.viewUserFile.Size = new System.Drawing.Size(150, 98);
            this.viewUserFile.TabIndex = 31;
            this.viewUserFile.Text = "2. View User File";
            this.viewUserFile.UseVisualStyleBackColor = true;
            this.viewUserFile.Click += new System.EventHandler(this.viewUserFile_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(776, 79);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Black;
            series1.IsValueShownAsLabel = true;
            series1.Name = "Annotated Overlay";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Black;
            series2.MarkerBorderWidth = 2;
            series2.Name = "65 Line";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Black;
            series3.Name = "50 Line";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(824, 513);
            this.chart1.TabIndex = 32;
            this.chart1.TabStop = false;
            this.chart1.Text = "Basic Chart";
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Location = new System.Drawing.Point(156, 148);
            this.chart2.Name = "chart2";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.Black;
            series4.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series4.IsValueShownAsLabel = true;
            series4.Name = "Annotated Overlay";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Black;
            series5.Name = "65 Line";
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.Black;
            series6.Name = "50 Line";
            this.chart2.Series.Add(series4);
            this.chart2.Series.Add(series5);
            this.chart2.Series.Add(series6);
            this.chart2.Size = new System.Drawing.Size(2000, 1505);
            this.chart2.TabIndex = 36;
            this.chart2.Text = "chart2";
            this.chart2.Visible = false;
            // 
            // chart3
            // 
            chartArea3.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea3);
            this.chart3.Location = new System.Drawing.Point(310, 103);
            this.chart3.Name = "chart3";
            series7.BorderWidth = 3;
            series7.ChartArea = "ChartArea1";
            series7.Color = System.Drawing.Color.Black;
            series7.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series7.IsValueShownAsLabel = true;
            series7.Name = "Annotated Overlay";
            series8.BorderWidth = 2;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Color = System.Drawing.Color.Black;
            series8.Name = "65 Line";
            series9.BorderWidth = 2;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Color = System.Drawing.Color.Black;
            series9.Name = "50 Line";
            this.chart3.Series.Add(series7);
            this.chart3.Series.Add(series8);
            this.chart3.Series.Add(series9);
            this.chart3.Size = new System.Drawing.Size(2000, 1505);
            this.chart3.TabIndex = 37;
            this.chart3.Text = "chart3";
            this.chart3.Visible = false;
            // 
            // chart4
            // 
            chartArea4.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea4);
            this.chart4.Location = new System.Drawing.Point(88, 114);
            this.chart4.Name = "chart4";
            series10.BorderWidth = 3;
            series10.ChartArea = "ChartArea1";
            series10.Color = System.Drawing.Color.Black;
            series10.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series10.IsValueShownAsLabel = true;
            series10.Name = "Annotated Overlay";
            series11.BorderWidth = 2;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Color = System.Drawing.Color.Black;
            series11.Name = "65 Line";
            series12.BorderWidth = 2;
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Color = System.Drawing.Color.Black;
            series12.Name = "50 Line";
            this.chart4.Series.Add(series10);
            this.chart4.Series.Add(series11);
            this.chart4.Series.Add(series12);
            this.chart4.Size = new System.Drawing.Size(2000, 1505);
            this.chart4.TabIndex = 40;
            this.chart4.Text = "chart4";
            this.chart4.Visible = false;
            // 
            // undoButton
            // 
            this.undoButton.Enabled = false;
            this.undoButton.Image = ((System.Drawing.Image)(resources.GetObject("undoButton.Image")));
            this.undoButton.Location = new System.Drawing.Point(80, 600);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(37, 30);
            this.undoButton.TabIndex = 45;
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // BarLabel
            // 
            this.BarLabel.AutoSize = true;
            this.BarLabel.Checked = true;
            this.BarLabel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BarLabel.Location = new System.Drawing.Point(432, 600);
            this.BarLabel.Name = "BarLabel";
            this.BarLabel.Size = new System.Drawing.Size(76, 17);
            this.BarLabel.TabIndex = 46;
            this.BarLabel.Text = "Bar Labels";
            this.BarLabel.UseVisualStyleBackColor = true;
            // 
            // nonAnswer
            // 
            this.nonAnswer.Enabled = false;
            this.nonAnswer.Location = new System.Drawing.Point(224, 600);
            this.nonAnswer.Name = "nonAnswer";
            this.nonAnswer.Size = new System.Drawing.Size(99, 64);
            this.nonAnswer.TabIndex = 47;
            this.nonAnswer.Text = "No Answer";
            this.nonAnswer.UseVisualStyleBackColor = true;
            this.nonAnswer.Click += new System.EventHandler(this.nonAnswer_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(550, 497);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(150, 98);
            this.resetButton.TabIndex = 48;
            this.resetButton.Text = "5. Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // PrimaryUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(746, 675);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.nonAnswer);
            this.Controls.Add(this.BarLabel);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.viewUserFile);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.dayLabel);
            this.Controls.Add(this.monthLabel);
            this.Controls.Add(this.dayTextBox);
            this.Controls.Add(this.yearTextBox);
            this.Controls.Add(this.confirmUser);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.falseButton);
            this.Controls.Add(this.trueButton);
            this.Controls.Add(this.ageLabel);
            this.Controls.Add(this.genderLabel);
            this.Controls.Add(this.ageTextBox);
            this.Controls.Add(this.genderTextBox);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.monthTextBox);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.mainOutput);
            this.Controls.Add(this.printCurrentButton);
            this.Controls.Add(this.scoreDataButton);
            this.Controls.Add(this.enterDataButton);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(762, 714);
            this.MinimumSize = new System.Drawing.Size(762, 714);
            this.Name = "PrimaryUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MMPI Grader";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enterDataButton;
        private System.Windows.Forms.Button scoreDataButton;
        private System.Windows.Forms.Button printCurrentButton;
        private System.Windows.Forms.TextBox mainOutput;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.TextBox monthTextBox;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.TextBox genderTextBox;
        private System.Windows.Forms.TextBox ageTextBox;
        private System.Windows.Forms.Label genderLabel;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.Button trueButton;
        private System.Windows.Forms.Button falseButton;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Button confirmUser;
        private System.Windows.Forms.TextBox yearTextBox;
        private System.Windows.Forms.TextBox dayTextBox;
        private System.Windows.Forms.Label monthLabel;
        private System.Windows.Forms.Label dayLabel;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Button viewUserFile;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart4;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.CheckBox BarLabel;
        private System.Windows.Forms.Button nonAnswer;
        private System.Windows.Forms.Button resetButton;
    }
}


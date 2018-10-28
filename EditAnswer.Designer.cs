namespace MMPI_Try_2
{
    partial class EditAnswer
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
            this.trueCheckBox = new System.Windows.Forms.CheckBox();
            this.falseCheckBox = new System.Windows.Forms.CheckBox();
            this.questionBox = new System.Windows.Forms.TextBox();
            this.checkAnswer = new System.Windows.Forms.Button();
            this.NonAnswerLabel = new System.Windows.Forms.Label();
            this.DoubleAnswerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // trueCheckBox
            // 
            this.trueCheckBox.AutoSize = true;
            this.trueCheckBox.Location = new System.Drawing.Point(164, 14);
            this.trueCheckBox.Name = "trueCheckBox";
            this.trueCheckBox.Size = new System.Drawing.Size(48, 17);
            this.trueCheckBox.TabIndex = 0;
            this.trueCheckBox.Text = "True";
            this.trueCheckBox.UseVisualStyleBackColor = true;
            this.trueCheckBox.Click += new System.EventHandler(this.trueCheckBox_Click);
            // 
            // falseCheckBox
            // 
            this.falseCheckBox.AutoSize = true;
            this.falseCheckBox.Location = new System.Drawing.Point(218, 14);
            this.falseCheckBox.Name = "falseCheckBox";
            this.falseCheckBox.Size = new System.Drawing.Size(51, 17);
            this.falseCheckBox.TabIndex = 1;
            this.falseCheckBox.Text = "False";
            this.falseCheckBox.UseVisualStyleBackColor = true;
            this.falseCheckBox.CheckedChanged += new System.EventHandler(this.falseCheckBox_Click);
            this.falseCheckBox.Click += new System.EventHandler(this.falseCheckBox_Click);
            // 
            // questionBox
            // 
            this.questionBox.Location = new System.Drawing.Point(12, 12);
            this.questionBox.Name = "questionBox";
            this.questionBox.Size = new System.Drawing.Size(100, 20);
            this.questionBox.TabIndex = 2;
            // 
            // checkAnswer
            // 
            this.checkAnswer.Location = new System.Drawing.Point(118, 10);
            this.checkAnswer.Name = "checkAnswer";
            this.checkAnswer.Size = new System.Drawing.Size(40, 23);
            this.checkAnswer.TabIndex = 3;
            this.checkAnswer.Text = "Load";
            this.checkAnswer.UseVisualStyleBackColor = true;
            this.checkAnswer.Click += new System.EventHandler(this.checkAnswer_Click);
            // 
            // NonAnswerLabel
            // 
            this.NonAnswerLabel.AutoSize = true;
            this.NonAnswerLabel.Location = new System.Drawing.Point(12, 39);
            this.NonAnswerLabel.Name = "NonAnswerLabel";
            this.NonAnswerLabel.Size = new System.Drawing.Size(76, 13);
            this.NonAnswerLabel.TabIndex = 4;
            this.NonAnswerLabel.Text = "Non-Answers: ";
            // 
            // DoubleAnswerLabel
            // 
            this.DoubleAnswerLabel.AutoSize = true;
            this.DoubleAnswerLabel.Location = new System.Drawing.Point(12, 56);
            this.DoubleAnswerLabel.Name = "DoubleAnswerLabel";
            this.DoubleAnswerLabel.Size = new System.Drawing.Size(90, 13);
            this.DoubleAnswerLabel.TabIndex = 5;
            this.DoubleAnswerLabel.Text = "Double Answers: ";
            // 
            // EditAnswer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 82);
            this.Controls.Add(this.DoubleAnswerLabel);
            this.Controls.Add(this.NonAnswerLabel);
            this.Controls.Add(this.checkAnswer);
            this.Controls.Add(this.questionBox);
            this.Controls.Add(this.falseCheckBox);
            this.Controls.Add(this.trueCheckBox);
            this.KeyPreview = true;
            this.Name = "EditAnswer";
            this.Text = "Edit Answer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditAnswer_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox trueCheckBox;
        private System.Windows.Forms.CheckBox falseCheckBox;
        private System.Windows.Forms.TextBox questionBox;
        private System.Windows.Forms.Button checkAnswer;
        private System.Windows.Forms.Label NonAnswerLabel;
        private System.Windows.Forms.Label DoubleAnswerLabel;
    }
}
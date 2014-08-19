namespace NaiveBayesClassifier
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnLearnAndClassify = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tBoxTrainingData = new System.Windows.Forms.TextBox();
            this.tBoxTrainingLabels = new System.Windows.Forms.TextBox();
            this.tBoxTestData = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tBoxTestLabels = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nUDSmoothCount = new System.Windows.Forms.NumericUpDown();
            this.cBoxUseMLClassification = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tBoxDim1 = new System.Windows.Forms.TextBox();
            this.tBoxDim2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cBoxToggle = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nUDSmoothCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLearnAndClassify
            // 
            this.btnLearnAndClassify.Location = new System.Drawing.Point(370, 384);
            this.btnLearnAndClassify.Name = "btnLearnAndClassify";
            this.btnLearnAndClassify.Size = new System.Drawing.Size(252, 37);
            this.btnLearnAndClassify.TabIndex = 0;
            this.btnLearnAndClassify.Text = "&Learn && Classify!";
            this.btnLearnAndClassify.UseVisualStyleBackColor = true;
            this.btnLearnAndClassify.Click += new System.EventHandler(this.btnLearnAndClassify_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(831, 384);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(132, 37);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Training data:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Training labels:";
            // 
            // tBoxTrainingData
            // 
            this.tBoxTrainingData.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tBoxTrainingData.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.tBoxTrainingData.Location = new System.Drawing.Point(152, 44);
            this.tBoxTrainingData.Name = "tBoxTrainingData";
            this.tBoxTrainingData.Size = new System.Drawing.Size(781, 26);
            this.tBoxTrainingData.TabIndex = 4;
            this.tBoxTrainingData.Text = "C:\\Courses\\cs440\\MP #3\\digitdata\\trainingimages";
            // 
            // tBoxTrainingLabels
            // 
            this.tBoxTrainingLabels.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tBoxTrainingLabels.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.tBoxTrainingLabels.Location = new System.Drawing.Point(152, 92);
            this.tBoxTrainingLabels.Name = "tBoxTrainingLabels";
            this.tBoxTrainingLabels.Size = new System.Drawing.Size(781, 26);
            this.tBoxTrainingLabels.TabIndex = 5;
            this.tBoxTrainingLabels.Text = "C:\\Courses\\cs440\\MP #3\\digitdata\\traininglabels";
            // 
            // tBoxTestData
            // 
            this.tBoxTestData.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tBoxTestData.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.tBoxTestData.Location = new System.Drawing.Point(152, 256);
            this.tBoxTestData.Name = "tBoxTestData";
            this.tBoxTestData.Size = new System.Drawing.Size(781, 26);
            this.tBoxTestData.TabIndex = 8;
            this.tBoxTestData.Text = "C:\\Courses\\cs440\\MP #3\\digitdata\\testimages";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Test data:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Test labels:";
            // 
            // tBoxTestLabels
            // 
            this.tBoxTestLabels.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tBoxTestLabels.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.tBoxTestLabels.Location = new System.Drawing.Point(152, 304);
            this.tBoxTestLabels.Name = "tBoxTestLabels";
            this.tBoxTestLabels.Size = new System.Drawing.Size(781, 26);
            this.tBoxTestLabels.TabIndex = 9;
            this.tBoxTestLabels.Text = "C:\\Courses\\cs440\\MP #3\\digitdata\\testlabels";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Smooth count (k):";
            // 
            // nUDSmoothCount
            // 
            this.nUDSmoothCount.Location = new System.Drawing.Point(153, 147);
            this.nUDSmoothCount.Maximum = new decimal(new int[] {
            1234567890,
            0,
            0,
            0});
            this.nUDSmoothCount.Name = "nUDSmoothCount";
            this.nUDSmoothCount.Size = new System.Drawing.Size(120, 26);
            this.nUDSmoothCount.TabIndex = 11;
            this.nUDSmoothCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cBoxUseMLClassification
            // 
            this.cBoxUseMLClassification.AutoSize = true;
            this.cBoxUseMLClassification.Location = new System.Drawing.Point(306, 149);
            this.cBoxUseMLClassification.Name = "cBoxUseMLClassification";
            this.cBoxUseMLClassification.Size = new System.Drawing.Size(184, 24);
            this.cBoxUseMLClassification.TabIndex = 12;
            this.cBoxUseMLClassification.Text = "Use ML classification";
            this.cBoxUseMLClassification.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(659, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Dimensions:";
            // 
            // tBoxDim1
            // 
            this.tBoxDim1.Location = new System.Drawing.Point(761, 144);
            this.tBoxDim1.Name = "tBoxDim1";
            this.tBoxDim1.Size = new System.Drawing.Size(65, 26);
            this.tBoxDim1.TabIndex = 14;
            this.tBoxDim1.Text = "28";
            // 
            // tBoxDim2
            // 
            this.tBoxDim2.Location = new System.Drawing.Point(854, 144);
            this.tBoxDim2.Name = "tBoxDim2";
            this.tBoxDim2.Size = new System.Drawing.Size(65, 26);
            this.tBoxDim2.TabIndex = 15;
            this.tBoxDim2.Text = "28";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(832, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "x";
            // 
            // cBoxToggle
            // 
            this.cBoxToggle.AutoSize = true;
            this.cBoxToggle.Location = new System.Drawing.Point(663, 195);
            this.cBoxToggle.Name = "cBoxToggle";
            this.cBoxToggle.Size = new System.Drawing.Size(83, 24);
            this.cBoxToggle.TabIndex = 17;
            this.cBoxToggle.Text = "Toggle";
            this.cBoxToggle.UseVisualStyleBackColor = true;
            this.cBoxToggle.CheckedChanged += new System.EventHandler(this.cBoxToggle_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 443);
            this.Controls.Add(this.cBoxToggle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tBoxDim2);
            this.Controls.Add(this.tBoxDim1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cBoxUseMLClassification);
            this.Controls.Add(this.nUDSmoothCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tBoxTestLabels);
            this.Controls.Add(this.tBoxTestData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tBoxTrainingLabels);
            this.Controls.Add(this.tBoxTrainingData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLearnAndClassify);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Digit Classifier";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nUDSmoothCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLearnAndClassify;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBoxTrainingData;
        private System.Windows.Forms.TextBox tBoxTrainingLabels;
        private System.Windows.Forms.TextBox tBoxTestData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBoxTestLabels;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nUDSmoothCount;
        private System.Windows.Forms.CheckBox cBoxUseMLClassification;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tBoxDim1;
        private System.Windows.Forms.TextBox tBoxDim2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cBoxToggle;
    }
}


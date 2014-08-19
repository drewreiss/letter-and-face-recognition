using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NaiveBayesClassifier
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cBoxToggle_CheckedChanged(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLearnAndClassify_Click(object sender, EventArgs e)
        {
            //1a - Read traininglabels file, line by line, and update the prior hashtable
            //1b - Read trainingimages file, read it every dim1 lines, update that digits corresponding likelihood
            //2 - Compute probabilities
            //3 - Classify the test data
            //4 - Evaluate

            //Step 1
            string[] trainingData = File.ReadAllLines(tBoxTrainingData.Text);
            int j = 0;
            Dictionary<int, double> prior = new Dictionary<int, double>();            //dictionary for holding priors
            Dictionary<int, Dictionary<int, double>> likelihoods = new Dictionary<int, Dictionary<int, double>>();
            int numTrainingDigits = 0;                  //holds the number of training digits
            foreach(string line in File.ReadAllLines(tBoxTrainingLabels.Text))
            {
                
                int digit = int.Parse(line);

                if (!prior.ContainsKey(digit))
                {
                    prior.Add(digit, 1.0);
                }else{
                    prior[digit]++;
                }

                numTrainingDigits++;

                if(!likelihoods.ContainsKey(digit))
                {
                    addInitializedDictionary(likelihoods, digit);
                }

                Dictionary<int, double> likelihood = likelihoods[digit];


                for (int i = 0; i < int.Parse(tBoxDim1.Text); i++, j++)
                {
                   
                    for (int k = 0; k < int.Parse(tBoxDim2.Text); k++)
                    {
                        if (trainingData[j][k] != ' ')
                        {
                            likelihood[i * 10000 + k]++;
                            
                        }
                    }
                }

                //for (int F = 0; F < 11; F++)
                //{
                   
                //    Console.WriteLine("[likelihood matrix for number " + F + " ]:\n");

                //    for (int i = 0; i < int.Parse(tBoxDim1.Text); i++, j++)
                //    {
                //        Console.WriteLine("\n");
                //        for (int k = 0; k < int.Parse(tBoxDim2.Text); k++)
                //        {
                           
                //                double write = likelihood[i * 10000 + k];
                //                Console.Write(write);

                            
                //        }
                //    }
                //}

            }

            //2 - Convert the counts to probabilities
            computeProbabilities(prior, likelihoods, numTrainingDigits);

            //3 - Classify the test data
            string outFile = classify(prior, likelihoods);

            

            //4 - Evaluation of results
            evaluate(outFile);
        }

        public void addInitializedDictionary(Dictionary<int, Dictionary<int, double>> likelihoods, int digit)
        {
            Dictionary<int, double> temp = new Dictionary<int, double>();

            for (int i = 0; i < int.Parse(tBoxDim1.Text); i++)
            {
                for (int j = 0; j < int.Parse(tBoxDim2.Text); j++)
                {
                    temp.Add(i*10000 + j, 0);
                }
            }
            likelihoods.Add(digit, temp);
        }

        public void computeProbabilities(Dictionary<int, double> prior, Dictionary<int, Dictionary<int, double>> likelihoods, int numTrainingDigits)
        {
            List<int> classes = likelihoods.Keys.ToList();          //classes are nothing but digits here

            foreach (var digit in classes)
            {
//                Console.WriteLine("\n[likelihood matrix for number " + digit + " ]:\n");

                var likelihood = likelihoods[digit];
                int count = 0;
                foreach (var feature in likelihood.Keys.ToList())
                {
                    
//                    if (count % 60 == 0)
//                        Console.WriteLine("++");
                    likelihood[feature] = (likelihood[feature] + (double)nUDSmoothCount.Value)/ (prior[digit] + (double)nUDSmoothCount.Value * 2);         //here: likelihood.Key = digit, and likelihood.Value = hashtable for features; also do the smoothing, now divide by k*V
//                    Console.Write(Math.Log10(likelihood[feature]) + "#");
//                    count++;
                    
}


             

            }
            
            foreach (var key in prior.Keys.ToList())
            {
                prior[key] = prior[key] / numTrainingDigits;
            }
        }

        public string classify(Dictionary<int, double> prior, Dictionary<int, Dictionary<int, double>> likelihoods)
        { 
            Dictionary<int, double> posteriors = new Dictionary<int, double>();
            int numClasses;
            
            if (cBoxToggle.Checked) { numClasses = 2; }
            else { numClasses = 10;}

            double[,] typicalInstanceIndex = new double[numClasses, 4];           //holds the starting-line index vs. the max value for the image which is typical for each digit

            string[] testData = File.ReadAllLines(tBoxTestData.Text);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < testData.Length;)
            {
                posteriors.Clear();                 //flush the posteriors
                foreach (var digit in prior.Keys.ToList())
                {
                    if (cBoxUseMLClassification.Checked)
                    {
                        posteriors.Add(digit, 0);                       //user has asked for ML estimation, so omitting the prior and just initializing by 0
                    }
                    else {
                        posteriors.Add(digit, Math.Log(prior[digit]));  //initialize everything to prior
                    }
                }

                for (int line = 0; line < int.Parse(tBoxDim1.Text); line++, i++)
                {
                    for (int k = 0; k < int.Parse(tBoxDim2.Text); k++)
                    {
                        if (testData[i][k] != ' ')
                        {
                            foreach (var digit in likelihoods.Keys)
                                posteriors[digit] = posteriors[digit] + Math.Log(likelihoods[digit][line * 10000 + k]);
                        }
                        else
                        {
                            foreach (var digit in likelihoods.Keys)
                            {
                                posteriors[digit] = posteriors[digit] + Math.Log(1 - (likelihoods[digit][line * 10000 + k]));
                            }
                        }
                    }

                }

                double mapDecision = posteriors.Values.Max();

                //initialize everything to the least value possible (since 0 won't work, as you'll be comparing with negative values from log)
                for(int digit = 0; digit < typicalInstanceIndex.GetLength(0); digit++)
                {
                    typicalInstanceIndex[digit, 1] = double.MinValue;
                    typicalInstanceIndex[digit, 3] = double.MaxValue;
                }

                foreach (var kvp in posteriors)
                {
                    if (kvp.Value == mapDecision)
                    {
                        sb.Append(kvp.Key + System.Environment.NewLine);                 //This is the predicted class of this digit

                        if (typicalInstanceIndex[kvp.Key, 1] < kvp.Value)               //for checking if this is typical image for this digit or not
                        {
                            typicalInstanceIndex[kvp.Key, 1] = kvp.Value;
                            typicalInstanceIndex[kvp.Key, 0] = i - int.Parse(tBoxDim1.Text);                //start the image from here!
                        }

                        if (typicalInstanceIndex[kvp.Key, 3] > kvp.Value)           //for checking incorrect interesting classification
                        {
                            typicalInstanceIndex[kvp.Key, 3] = kvp.Value;
                            typicalInstanceIndex[kvp.Key, 2] = i - int.Parse(tBoxDim1.Text);                //start the image from here!
                        }

                        break;
                    }                    
                }
            }

            if (sb.Length > 0)
            {
                sb.Length = sb.Length - 1;              //to remove the last extra newline you might have added
            }

            string outFile = Path.Combine(Path.GetDirectoryName(tBoxTestData.Text), "classifierOutput.txt");

            File.WriteAllText(outFile, sb.ToString());

            if (MessageBox.Show("Test data has been classified, please check the output here:\n\n" + outFile + "\n\nCopy path to clipboard?", "Info...", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Clipboard.SetText(outFile);
            }

            printTypicalExamples(typicalInstanceIndex, testData, 0);

            return outFile;
        }

        public void evaluate(string outFile)
        {
            string[] classifiedLabels = File.ReadAllLines(outFile);
            string[] testLabels = File.ReadAllLines(tBoxTestLabels.Text);

            int numClasses;

            if (cBoxToggle.Checked) { numClasses = 2;}
            else { numClasses = 10; }

            int[] countOfTestLabels = new int[numClasses];              //maintains the count for how many test digits of each type were encountered
            double[,] confusionMatrix = new double[numClasses, numClasses];
            double[,] interestingInstanceIndex = new double[numClasses, 2];
            
            //initialize everything to the least value possible (since 0 won't work, as you'll be comparing with negative values from log)
            for (int digit = 0; digit < interestingInstanceIndex.GetLength(0); digit++)
            {
                interestingInstanceIndex[digit, 1] = double.MaxValue;
            }

            Dictionary<int, double[]> precision = new Dictionary<int, double[]>();

            for (int i = 0; i < classifiedLabels.Length; i++)
            {
                countOfTestLabels[int.Parse(testLabels[i])]++;          //increment the count

                if (int.Parse(testLabels[i]) != int.Parse(classifiedLabels[i]))           //if label was incorrectly indentified
                {
                    if (!precision.ContainsKey(int.Parse(testLabels[i])))
                    {
                        precision.Add(int.Parse(testLabels[i]), new double[] { 0.0, 1.0 });            //eg. <0, [#correctly_classfied, #incorrectly_classified]}>
                    }
                    else
                    {
                        precision[int.Parse(testLabels[i])][1]++;
                    }

                    if (interestingInstanceIndex[int.Parse(testLabels[i]), 1] == double.MaxValue)           //for checking incorrect interesting classification
                    {
                        interestingInstanceIndex[int.Parse(testLabels[i]), 1] = int.Parse(classifiedLabels[i]);
                        interestingInstanceIndex[int.Parse(testLabels[i]), 0] = i * int.Parse(tBoxDim1.Text);                //start the image from here!
                    }

                }
                else
                {                                              //if label was correctly indentified
                    if (!precision.ContainsKey(int.Parse(testLabels[i])))
                    {
                        precision.Add(int.Parse(testLabels[i]), new double[] { 1.0, 0.0 });            //eg. <0, [#correctly_classfied, #incorrectly_classified]}>
                    }
                    else
                    {
                        precision[int.Parse(testLabels[i])][0]++;
                    }
                }

                confusionMatrix[int.Parse(testLabels[i]), int.Parse(classifiedLabels[i])]++;
            }

            convertToPercentages(countOfTestLabels, confusionMatrix);           //convert all the counts to percentages

            precision = precision.OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);          //sorting by key, so that's it's more beautiful to look in the output
            Console.WriteLine("Classification rate for each class:");
            Console.WriteLine("Class\tRate");
            foreach (KeyValuePair<int, double[]>kvp in precision)
            {
                double percentage = ((double)kvp.Value[0] / (kvp.Value[0] + kvp.Value[1])*100);
                Console.WriteLine("{0}\t{1}%", kvp.Key, Math.Round(percentage, 2));
            }

            Console.WriteLine("---------------------------------------------\n");
            Console.WriteLine("[confusionMatrix]:\n");
            for (int i = 0; i < confusionMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < confusionMatrix.GetLength(1); j++)
                {
                    Console.Write("{0}\t", confusionMatrix[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("---------------------------------------------\n");
            printTypicalExamples(interestingInstanceIndex, File.ReadAllLines(tBoxTestData.Text), 1);
        }

        public void convertToPercentages(int[] countOfTestLabels, double[,] confusionMatrix)
        {
            for (int i = 0; i < confusionMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < confusionMatrix.GetLength(1); j++)
                {
                    confusionMatrix[i, j] = Math.Round((confusionMatrix[i, j] / countOfTestLabels[i])*100, 2);
                }
            
            }
        
        }

        public void printTypicalExamples(double[,] typicalInstanceIndex, string[] testData, int mode)
        {
            for (int digit = 0; digit < typicalInstanceIndex.GetLength(0); digit++)
            { 
                int index = (int)typicalInstanceIndex[digit, 0];
                
                Console.WriteLine("-------------------------------------");

                switch (mode)
                {
                    case 0: Console.WriteLine("TypicalImage[{0}]:", digit);
                        for (int i = 0; i < int.Parse(tBoxDim1.Text); i++, index++)
                        {
                            Console.WriteLine(testData[index]);
                        }
                        break;
                    case 1: Console.WriteLine("InterestingImage[{0}] identified as {1}:", digit, (int)typicalInstanceIndex[digit, 1]);
                        for (int i = 0; i < int.Parse(tBoxDim1.Text); i++, index++)
                        {
                            Console.WriteLine(testData[index]);
                        }
                        break;
                }

                Console.WriteLine("-------------------------------------\n");
            }
        }

        private void cBoxToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxToggle.Checked)
            {
                tBoxDim1.Text = 70.ToString();
                tBoxDim2.Text = 60.ToString();
                tBoxTrainingData.Text = @"C:\Courses\cs440\MP #3\facedata\facedatatrain";
                tBoxTrainingLabels.Text = @"C:\Courses\cs440\MP #3\facedata\facedatatrainlabels";
                tBoxTestData.Text = @"C:\Courses\cs440\MP #3\facedata\facedatatest";
                tBoxTestLabels.Text = @"C:\Courses\cs440\MP #3\facedata\facedatatestlabels";
            }
            else {
                tBoxDim1.Text = 28.ToString();
                tBoxDim2.Text = 28.ToString();
                tBoxTrainingData.Text = @"C:\Courses\cs440\MP #3\digitdata\trainingimages";
                tBoxTrainingLabels.Text = @"C:\Courses\cs440\MP #3\digitdata\traininglabels";
                tBoxTestData.Text = @"C:\Courses\cs440\MP #3\digitdata\testimages";
                tBoxTestLabels.Text = @"C:\Courses\cs440\MP #3\digitdata\testlabels";
            }
        }

    }
}

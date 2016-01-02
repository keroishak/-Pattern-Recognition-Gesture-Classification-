using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestureClassification.ViewModel.Validation;
using GestureClassification.ViewModel;
using GestureClassification.ViewModel.Classifiers;
using GestureClassification.Model;
using System.Diagnostics;
namespace GestureClassification.View
{
    public partial class MainForm : Form
    {
        TextBox[] inputarr = new TextBox[40];
        public MainForm()
        {
            InitializeComponent();
            // Utility.LoadDataFromDirectory(DatasetType.Training);
            this.KNNTextBox.Text = "3";
            this.KTextBox.Text = "2";
            this.NumofTimesTextBox.Text = "1";
            this.comboBox1.SelectedIndex = 0;
            int y = splitContainer2.Location.Y + 10;
            for (int i = 1; i <= 20; ++i)
            {
                inputarr[i] = new TextBox();
                inputarr[i + 1] = new TextBox();
                inputarr[i].Name = "X" + i.ToString();
                inputarr[i + 1].Name = "Y" + i.ToString();
                splitContainer2.Panel1.Controls.Add(inputarr[i]);
                splitContainer2.Panel1.Controls.Add(inputarr[i + 1]);
                inputarr[i].Location = new Point(15, y);
                inputarr[i + 1].Location = new Point(75, y);
                inputarr[i].Size = new System.Drawing.Size(50, 20);
                inputarr[i + 1].Size = new System.Drawing.Size(50, 20);
                y += 25;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            KFoldCrossValidation validation = null;
           // Stopwatch a = new Stopwatch();
           // a.Start();
            List<Data> trainingDataset = Utility.LoadDataset(DatasetType.Training);
           // a.Stop();
           // MessageBox.Show("Time : " + a.Elapsed.TotalSeconds);
            if (comboBox1.SelectedIndex == 0)
                validation = new KFoldCrossValidation(trainingDataset, 3, ClassifierType.Bayesian, ViewModel.FeatureExtraction.FeatureExtractionType.EuclideanDistance);
            else if (comboBox1.SelectedIndex == 1)
                validation = new KFoldCrossValidation(trainingDataset, 3, ClassifierType.KNearestNeighbour, ViewModel.FeatureExtraction.FeatureExtractionType.EuclideanDistance, int.Parse(KTextBox.Text));
            validation.Validate(int.Parse(NumofTimesTextBox.Text));
            ErrorMeanLabel.Text = validation.MeanError.ToString();
            OverallAccuracyLabel.Text = validation.Accuracy.ToString();
            ErrorVarianceLabel.Text = validation.VarianceError.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            List<Data> Trainingdataset = Utility.LoadDataset(DatasetType.Training);
            List<Data> Testingingdataset = Utility.LoadDataset(DatasetType.Testing);
            TrainModel train = null;
            if (comboBox1.SelectedIndex == 0)
                train = new TrainModel(ViewModel.FeatureExtraction.FeatureExtractionType.EuclideanDistance, ClassifierType.Bayesian);
            else if (comboBox1.SelectedIndex == 1)
                train = new TrainModel(ViewModel.FeatureExtraction.FeatureExtractionType.EuclideanDistance, ClassifierType.KNearestNeighbour);
            train.Train(Trainingdataset);
            ScoreModel score = new ScoreModel(train, int.Parse(KNNTextBox.Text));
            score.Score(Testingingdataset);
            dataGridView1.Rows.Clear();
            for (int i = 0; i < score.ConfussionMatrix.GetLength(0); ++i)
            {
                string[] arr = new string[score.ConfussionMatrix.GetLength(1)];
                for (int j = 0; j < score.ConfussionMatrix.GetLength(1); ++j)
                    arr[j] = score.ConfussionMatrix[i, j].ToString();
                dataGridView1.Rows.Add(arr);
            }
            OverallAccuracyLabel.Text = score.Accuracy.ToString();
        }

        private void ClassificationButton_Click(object sender, EventArgs e)
        {
            List<Data> Trainingdataset = Utility.LoadDataset(DatasetType.Training);
            TrainModel train = null;
            if (comboBox1.SelectedIndex == 0)
                train = new TrainModel(ViewModel.FeatureExtraction.FeatureExtractionType.EuclideanDistance, ClassifierType.Bayesian);
            else if (comboBox1.SelectedIndex == 1)
                train = new TrainModel(ViewModel.FeatureExtraction.FeatureExtractionType.EuclideanDistance, ClassifierType.KNearestNeighbour);
            train.Train(Trainingdataset);
            OpenFileDialog f = new OpenFileDialog();
            if (DialogResult.OK == f.ShowDialog())
            {

                ScoreModel score = new ScoreModel(train, int.Parse(KNNTextBox.Text));
                List<Vector2> features = Utility.LoadPoints(f.FileName);

                int estimatedClass = score.Classify(features);
                ExpectedClassLabel.Text = estimatedClass.ToString();
                AppModel app = new AppModel(@"C:\Program Files (x86)\Notepad++\notepad++.exe");
                try
                {
                    if (estimatedClass == 0)
                        app.Close();
                    else if (estimatedClass == 1)
                        app.Minimize();
                    else if (estimatedClass == 2)
                        app.Open();
                    else if (estimatedClass == 3)
                        app.Restore();
                }
                catch
                {
                    MessageBox.Show("Couldn't take that action, please make sure that the specified program is already opened");
                }
            }
            /*for(int i=0;i<40;)
            {
                Vector2 a = new Vector2();
                a.x = double.Parse(inputarr[i++].Text);
                a.y = double.Parse(inputarr[i++].Text);
                features.Add(a);
            }*/
        }
    }
}

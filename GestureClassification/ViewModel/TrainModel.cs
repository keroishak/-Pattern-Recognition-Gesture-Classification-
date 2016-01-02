//This Class 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using GestureClassification.ViewModel.FeatureExtraction;
using GestureClassification.ViewModel.Classifiers;
using GestureClassification.Model;
namespace GestureClassification.ViewModel
{
    class TrainModel
    {
        public bool Trained { get; private set; }
        public IExtract featureExtraction { get; private set; }
        public ClassifierType cType { get; private set; }
        public bool[] Badass{ get; private set; }
        public int NumberofClasses { get; private set; }
        public int FeaturesDimension { get; private set; }
        public Dictionary<byte, List<List<double>>> TrainingData { get; private set; }
        public Matrix Mu { get; private set; }
        public List<Matrix> Covariance { get; private set; }
        public TrainModel(FeatureExtractionType eType, ClassifierType cType)
        {
            this.cType = cType;
            Trained = false;
            if (eType == FeatureExtractionType.EuclideanDistance)
                featureExtraction = new EuclideanDistance(14);

        }
        public TrainModel(FeatureExtractionType eType, int EuclideanCentroidPointIndex, ClassifierType cType)
        {
            this.cType = cType;
            Trained = false;
            if (eType == FeatureExtractionType.EuclideanDistance)
                featureExtraction = new EuclideanDistance(EuclideanCentroidPointIndex);

        }
        private void PrepareData(List<Data> trainingData)
        {
            TrainingData = new Dictionary<byte, List<List<double>>>();
            Badass = new bool[19];
            Badass[1] = Badass[8] = Badass[10] = Badass[12] = Badass[13] = Badass[15] = Badass[16] = true;
            for (int i = 0; i < trainingData.Count; ++i)
            {
                List<double> arr = featureExtraction.Extract(trainingData[i].Points);
                List<double> filtered = new List<double>();
                    for (int h = 0; h < arr.Count; ++h)
                        if (!Badass[h])
                            filtered.Add(arr[h]);
               
                if (!TrainingData.ContainsKey(trainingData[i].Class))
                {
                    TrainingData.Add(trainingData[i].Class, new List<List<double>>());
                }
                TrainingData[trainingData[i].Class].Add(filtered);
            }
        }
        public void Train(List<Data> trainingData)
        {
            PrepareData(trainingData);
            NumberofClasses = TrainingData.Keys.Count;
            FeaturesDimension = TrainingData[0][0].Count;
            #region BayesianTraining
            if (cType == ClassifierType.Bayesian)
            {
                Covariance = new List<Matrix>(NumberofClasses);
                Mu = new Matrix(FeaturesDimension, NumberofClasses);
                for (byte c = 0; c < NumberofClasses; ++c)
                {
                    for (int j = 0; j < FeaturesDimension; ++j)
                    {
                        for (int i = 0; i < TrainingData[c].Count; ++i)
                            Mu[j, c] += TrainingData[c][i][j];

                        Mu[j, c] /= TrainingData[c].Count;
                    }
                }
                for (byte c = 0; c < NumberofClasses; ++c)
                {
                    Covariance.Add(new Matrix(FeaturesDimension, FeaturesDimension));
                    for (int j = 0; j < FeaturesDimension; ++j)
                    {
                        for (int l = 0; l < FeaturesDimension; ++l)
                        {
                            for (int i = 0; i < TrainingData[c].Count; ++i)
                            {

                                Covariance[c][j, l] += (Mu[j, c] - TrainingData[c][i][j]) * ((Mu[l, c] - TrainingData[c][i][l]));
                            }
                            Covariance[c][j, l] /= TrainingData[c].Count;
                        }
                    }
                }
            }
            #endregion
            Trained = true;
        }
    }
}

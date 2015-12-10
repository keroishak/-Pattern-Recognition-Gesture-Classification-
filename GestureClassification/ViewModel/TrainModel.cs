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
        public ClassifierType CType { get; private set; }
        public int NumberofClasses { get; private set; }
        public int FeaturesDimension { get; private set; }
        public Dictionary<byte, List<List<double>>> TrainingData { get; private set; }
        public Matrix Mu { get; private set; }
        public List<Matrix> Covariance { get; private set; }
        public TrainModel(FeatureExtractionType eType, ClassifierType cType)
        {
            CType = cType;
            Trained = false;
            if (eType == FeatureExtractionType.EuclideanDistance)
                featureExtraction = new EuclideanDistance(13);

        }
        public TrainModel(FeatureExtractionType eType, int EuclideanCentroidPointIndex, ClassifierType cType)
        {
            CType = cType;
            Trained = false;
            if (eType == FeatureExtractionType.EuclideanDistance)
                featureExtraction = new EuclideanDistance(EuclideanCentroidPointIndex);

        }
        private void PrepareData(List<Data> trainingData)
        {
            for (int i = 0; i < trainingData.Count; ++i)
            {
                List<double> arr = featureExtraction.Extract(trainingData[i].Points);
                if (!TrainingData.ContainsKey(trainingData[i].Class))
                {
                    TrainingData.Add(trainingData[i].Class, new List<List<double>>());
                }
                TrainingData[trainingData[i].Class].Add(arr);
            }
        }
        public void Train(List<Data> trainingData)
        {
            PrepareData(trainingData);
            NumberofClasses = TrainingData.Keys.Count;
            FeaturesDimension = TrainingData[0][0].Count;
            #region BayesianTraining
            if (CType == ClassifierType.Bayesian)
            {
                Covariance = new List<Matrix>(NumberofClasses);
                Mu = new Matrix(FeaturesDimension, NumberofClasses);
                for (byte c = 0; c < NumberofClasses; ++c)
                {
                    for (int j = 0; j < FeaturesDimension; ++j)
                    {
                        for (int i = 0; i < TrainingData[c][j].Count; ++i)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestureClassification.Model;
using GestureClassification.ViewModel.Classifiers;
namespace GestureClassification.ViewModel
{
    class ScoreModel
    {
        public int[,] ConfussionMatrix { get; private set; }
        public double Accuracy { get; private set; }
        public int MissedRows { get; private set; }
        TrainModel trainedModel;
        IClassifier classifier;
        public ScoreModel(TrainModel trainedModel, int K = 3)
        {
            if (!trainedModel.Trained)
                throw new Exception("TrainModel must be trained first");
            this.trainedModel = trainedModel;
            ConfussionMatrix = new int[trainedModel.NumberofClasses, trainedModel.NumberofClasses];
            if (trainedModel.cType == ClassifierType.Bayesian)
                classifier = new BayesianClassifier(trainedModel);
            else if (trainedModel.cType == ClassifierType.KNearestNeighbour)
                classifier = new KNearestNeighbour(trainedModel, K);
        }
        public void Score(List<Data> TestingData)
        {
            int estimatedClass;
            for (int i = 0; i < TestingData.Count; ++i)
            {
                List<double> features = trainedModel.featureExtraction.Extract(TestingData[i].Points);
                List<double> filtered= new List<double>();
                    for (int h = 0; h < features.Count; ++h)
                        if (!trainedModel.Badass[h])
                            filtered.Add(features[h]);              

                estimatedClass = classifier.Classify(filtered);
                ++ConfussionMatrix[TestingData[i].Class, estimatedClass];
                if (estimatedClass != (int)TestingData[i].Class)
                    ++MissedRows;
            }
            Accuracy = ((double)(TestingData.Count - MissedRows) * 100) / TestingData.Count;
        }
        public int Classify(List<Vector2> Features)
        {
            List<double> features = trainedModel.featureExtraction.Extract(Features);
            List<double> filtered = new List<double>();
            for (int h = 0; h < features.Count; ++h)
                if (!trainedModel.Badass[h])
                    filtered.Add(features[h]);
            return classifier.Classify(filtered);
        }
    }
}

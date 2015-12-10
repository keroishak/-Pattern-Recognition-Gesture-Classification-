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
        int[,] ConfussionMatrix;
        public double Accuracy { get; private set; }
        public int MissedRows { get; private set; }
        TrainModel trainedModel;
        IClassifier classifier;
        public ScoreModel(TrainModel trainedModel)
        {
            if (!trainedModel.Trained)
                throw new Exception("TrainModel must be trained first");
            this.trainedModel = trainedModel;
            ConfussionMatrix = new int[trainedModel.NumberofClasses, trainedModel.NumberofClasses];
            if (trainedModel.CType == ClassifierType.Bayesian)
                classifier = new BayesianClassifier(trainedModel);
            else if (trainedModel.CType == ClassifierType.KNearestNeighbour)
                classifier = new KNearestNeighbour(trainedModel);
        }
        public void Score(List<Data> TestingData)
        {
            int estimatedClass;
            for (int i = 0; i < TestingData.Count; ++i)
            {
                List<double> features = trainedModel.featureExtraction.Extract(TestingData[i].Points);
                estimatedClass = classifier.Classify(features);
                ++ConfussionMatrix[TestingData[i].Class, estimatedClass];
                if (estimatedClass != (int)TestingData[i].Class)
                    ++MissedRows;
            }
        }

    }
}

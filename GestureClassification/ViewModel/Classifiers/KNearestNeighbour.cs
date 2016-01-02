using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestureClassification.ViewModel.Classifiers
{
    class KNearestNeighbour : IClassifier
    {
        TrainModel trainedModel;
        int k;
        public KNearestNeighbour(TrainModel trainModel, int K)
        {
            this.trainedModel = trainModel;
            k = K;
        }
        public KNearestNeighbour(TrainModel trainModel)
        {
            this.trainedModel = trainModel;
            k = 3;
        }
        public int Classify(List<double> Features)
        {
            if (Features.Count != trainedModel.FeaturesDimension)
                throw new Exception("Dimensionality Fault!");
            List<Tuple<byte, double>> nearest = new List<Tuple<byte, double>>();
            double x;
            for (byte c = 0; c < trainedModel.NumberofClasses; ++c)
                for (int i = 0; i < trainedModel.TrainingData[c].Count; ++i)
                {
                    x = 0;
                    for (int j = 0; j < Features.Count; ++j)
                    {

                        x += Math.Pow(Features[j] - trainedModel.TrainingData[c][i][j], 2);
                    }
                    nearest.Add(Tuple.Create(c, Math.Sqrt(x)));
                }
            nearest.Sort(delegate(Tuple<byte, double> t1, Tuple<byte, double> t2) { return t1.Item2.CompareTo(t2.Item2); });
            double[] highestK = new double[trainedModel.NumberofClasses];
            for (int i = 0; i < k; ++i)
                ++highestK[nearest[i].Item1];
            x = 0; int estimatedClass = 0;
            for (int i = 0; i < trainedModel.NumberofClasses; ++i)
                if (highestK[i] / k > x)
                {
                    x = highestK[i] / k;
                    estimatedClass = i;
                }
            return estimatedClass;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestureClassification.Model;
namespace GestureClassification.ViewModel.Classifiers
{
    class BayesianClassifier : IClassifier
    {
        private double prior;
        private TrainModel trainedModel;
        public BayesianClassifier(TrainModel trainedModel)
        {
            this.trainedModel = trainedModel;
            prior = 1.0 / trainedModel.NumberofClasses;
        }
        public int Classify(List<double> X)
        {
            int index = 0; double greaterProp = double.MinValue, value;
            for (int i = 0; i < trainedModel.NumberofClasses; ++i)
            {
                Matrix XMU = new Matrix(trainedModel.FeaturesDimension, 1);

                for (int j = 0; j < trainedModel.FeaturesDimension; ++j)
                    XMU[j, 0] = X[j] - trainedModel.Mu[j, i];

                Matrix transXMU = Matrix.Transpose(XMU);
                transXMU = -0.5 * transXMU;
                Matrix invertedsigma = trainedModel.Covariance[i].Invert();
                transXMU = transXMU * invertedsigma * XMU;
                value = transXMU[0, 0] + Math.Log(prior, Math.E);
                if (value > greaterProp)
                {
                    greaterProp = value;
                    index = i;
                }
            }
            return index;
        }
    }
}

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
        public int Classify(List<double> x)
        {
            int index = 0; double greaterProp = double.MinValue, value;
            Matrix X=new Matrix(trainedModel.FeaturesDimension, 1);
            Matrix res;
            for(int i=0;i<trainedModel.FeaturesDimension;++i)
            X[i,0]=x[i];
            for (int i = 0; i < trainedModel.NumberofClasses; ++i)
            {
                value = 0;
                Matrix invertedMatrix = trainedModel.Covariance[i].Invert();
                 res= (-0.5 * Matrix.Transpose(X) * invertedMatrix * X);
                 value += res[0, 0];
                Matrix Mu=trainedModel.Mu.GetCol(i);
                res = Matrix.Transpose(invertedMatrix * Mu) * X;
                value += res[0, 0];
                res = -0.5 * Matrix.Transpose(Mu) * invertedMatrix * Mu;
                value += res[0, 0];
                value += -0.5 * Math.Log(trainedModel.Covariance[i].Det(), Math.E);
                /*Matrix XMU = new Matrix(trainedModel.FeaturesDimension, 1);

                for (int j = 0; j < trainedModel.FeaturesDimension; ++j)
                    XMU[j, 0] = X[j] - trainedModel.Mu[j, i];

                Matrix transXMU = Matrix.Transpose(XMU);
                transXMU = -0.5 * transXMU;
                Matrix invertedsigma = trainedModel.Covariance[i].Invert();
                transXMU = transXMU * invertedsigma * XMU;
                value = transXMU[0, 0] + Math.Log(prior, Math.E);*/
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestureClassification.Model;
namespace GestureClassification.ViewModel.Classifiers
{
    enum ClassifierType { Bayesian, KNearestNeighbour };
    interface IClassifier
    {
        int Classify(List<double> Features);
    }
}

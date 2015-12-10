using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestureClassification.ViewModel.Classifiers
{
    class KNearestNeighbour:IClassifier
    {
        public KNearestNeighbour(TrainModel trainModel)
        { }
        public int Classify(List<double> Features)
        {
            throw new NotImplementedException();
        }
    }
}

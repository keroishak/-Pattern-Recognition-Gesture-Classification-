using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestureClassification.Model;
namespace GestureClassification.ViewModel.FeatureExtraction
{
    enum FeatureExtractionType { EuclideanDistance};
    interface IExtract
    {
        List<double> Extract(List<Vector2> data);
    }
}

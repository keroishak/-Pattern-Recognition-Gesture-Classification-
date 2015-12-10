using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestureClassification.ViewModel.FeatureExtraction
{
    class EuclideanDistance:IExtract
    {
        int CentroidIndex;
        public EuclideanDistance(int CentroidIndex)
        {
            this.CentroidIndex = CentroidIndex;
        }
        public List<double> Extract(List<Model.Vector2> data)
        {
            List<double>distances=new List<double>();
            double X;
            for (int i = 0; i < data.Count;++i )
            {
                if (i != CentroidIndex)
                {
                    X = Math.Sqrt(Math.Pow(data[i].x - data[CentroidIndex].x, 2) + Math.Pow(data[i].y - data[CentroidIndex].y, 2));
                    distances.Add(X);
                }
            }
            return distances;
        }
    }
}

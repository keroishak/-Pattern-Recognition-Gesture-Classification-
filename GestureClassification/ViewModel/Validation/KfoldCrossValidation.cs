using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestureClassification.ViewModel.FeatureExtraction;
using GestureClassification.ViewModel.Classifiers;
using GestureClassification.Model;
namespace GestureClassification.ViewModel.Validation
{
    class KFoldCrossValidation
    {
        private int Kfold, K;
        private List<Data> Data;
        private List<int> chunckSize;
        public double Accuracy { get; private set; }
        public double MeanError { get; private set; }
        public double VarianceError { get; private set; }
        Random r;
        ClassifierType cType;
        FeatureExtractionType fType;
        public KFoldCrossValidation(List<Data> data, int k_fold, ClassifierType cType, FeatureExtractionType fType, int K = 3)
        {
            Kfold = k_fold;
            this.K = K;
            this.cType = cType;
            this.fType = fType;
            Data = data;
            r = new Random();
            chunckSize = new List<int>(Kfold);
            for (int i = 0; i < Kfold - 1; ++i)
            {
                chunckSize.Add(Data.Count / Kfold);
            }
            chunckSize.Add(Data.Count - ((Kfold - 1) * (Data.Count / Kfold)));
        }
        // this method shuffle the data of a list randomly at each call
        private List<T> ShuffleList<T>(List<T> inputList)
        {
            List<T> randomList = new List<T>();
            int randomIndex = 0;
            int count = inputList.Count - 1;
            while (count >= 0)
            {
                randomIndex = (int)(r.NextDouble() * count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList[randomIndex] = inputList[count]; //remove to avoid duplicates
                --count;
            }
            return randomList; //return the new random list
        }
        public void Validate(int NumberofTimes)
        {
            double error;
            Accuracy = 0; int size = 0;
            MeanError = VarianceError = 0;
            List<double> errors = new List<double>(NumberofTimes);
            for (int h = 0; h < NumberofTimes; ++h)
            {
                error = 0;
                // shufflling all data randomly and sperate it to list of lists each list contains (datasize/#Ks) data 
                Data = ShuffleList<Data>(Data);
                //0 list is for training, and 1 list is for testing
                List<List<Data>> ShuffledData = new List<List<Data>>(K);
                //List<Data> lst = new List<Data>();
                for (int i = 0; i < Kfold; i++)
                {
                    List<Data> lst = new List<Data>();
                    for (int j = 0; j < chunckSize[i]; j++)
                        lst.Add(Data[i * chunckSize[0] + j]);
                    ShuffledData.Add(lst);
                }
                List<Data> Training = new List<Data>();
                List<Data> Testing = null;
                for (int i = 0; i < K; ++i)
                {
                    for (int j = 0; j < K; ++j)
                        if (j != i)
                            Training.AddRange(ShuffledData[j]);
                        else
                            Testing = ShuffledData[j];
                    // train and test k-folds
                    TrainModel train = new TrainModel(fType, cType);
                    train.Train(Training);
                    ScoreModel score = new ScoreModel(train, K);
                    score.Score(Testing);
                    error += score.MissedRows;
                    Accuracy += Testing.Count - score.MissedRows;
                    size += Testing.Count;
                }
                error /= Data.Count;
                errors.Add(error);
                MeanError += error;
            }
            error = 0;
            MeanError /= NumberofTimes;
            for (int i = 0; i < NumberofTimes; ++i)
                error += Math.Pow(MeanError - errors[i], 2);
            VarianceError = error / (NumberofTimes - 1);
            Accuracy /= size * 100 ;
        }
    }
}

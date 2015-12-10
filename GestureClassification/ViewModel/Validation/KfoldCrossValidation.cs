using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestureClassification.ViewModel.Validation
{
    public class KfoldCrossValidation
    {
        private int Kfold;
        private List<double> Data;
        private List<int> chunckSize; 
        public KfoldCrossValidation(List<double> data, int k)
        {
            Kfold = k;
            Data = data;
            chunckSize = new List<int>(Kfold);
            for (int i = 0; i < Kfold-1; ++i)
            {
                chunckSize[i] = Data.Count/Kfold;
            }
            chunckSize[Kfold - 1] = Data.Count - ((Kfold - 1)*(Data.Count/Kfold));
        }
        // this method shuffle the data of a list randomly at each call
        private List<T> ShuffleList<T>(List<T> inputList)
        {
            List<T> randomList = new List<T>();
            Random r = new Random((int)DateTime.Now.Ticks);
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }            
            return randomList; //return the new random list
        }

        public double Validation()
        {
            double error = 0;
            // shufflling all data randomly and sperate it to list of lists each list contains (datasize/#Ks) data 
            Data = ShuffleList<double>(Data);
            List<List<double>> AllShuffledData = new List<List<double>>();
            for (int i = 0; i < Kfold; i++)
            {
                List<double> lst = new List<double>();
                for (int j = 0; j < chunckSize[i]; j++)
                {
                    lst.Add(Data[i*chunckSize[0]+j]);
                }
                AllShuffledData.Add(lst);
            }
            // train and test k-folds
            for (int i = 0; i < Kfold; i++)
            {
                for (int j = 0; j < Kfold; j++)
                {
                    if(i==j)
                        continue;
                    //train all K-folds except i 
                }
                //test classifier with flod i
                //calculate Ni "the number of examples in Fold i that were wrongly classied"
            }
            //return the error percent
            return error;
        }
    }
}

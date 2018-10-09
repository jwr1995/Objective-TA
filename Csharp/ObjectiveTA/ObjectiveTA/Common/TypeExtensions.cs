using System;
using ObjectiveTA.Objects.Output;

namespace ObjectiveTA.Common
{
    public static class ArrayExtensions
    {
        public static double[] SubtractArray(this double[] first, double[] second)
        {
            try 
            {
                for (int i = 0; i < first.Length; i++)
                {
                    first[i] = first[i] - second[i];
                }
                return first;
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }
        }

        public static double Sum(this double[] vals)
        {
            double sum = 0;

            for (int i = 0; i < vals.Length; i++)
            {
                sum = sum + vals[i];
            }

            return sum;
        }

        public static double[] GetSegment(this double[] array, int start, int finish)
        {
            int count = finish - start;
            double[] output = new double[count];

            for (int i = 0; i < count; i++)
            {
                output[i] = array[i + start];
            }
            return array;
        }

        public static double Average(this double[] array)
        {
            return array.Sum() / array.Length;
        }

        public static double Variance(this double[] array)
        {
            return new Variance(array).Value;
        }

        public static double StandardDeviation(this double[] array)
        {
            return new StandardDeviation(array).Value;
        }
    }

    public static class DoubleExtensions
    {
        public static double Squared(this double db)
        {
            return db * db;
        }
    }

}

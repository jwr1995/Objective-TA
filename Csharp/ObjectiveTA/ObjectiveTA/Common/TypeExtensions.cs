using System;
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
    }

    public static class DoubleExtensions
    {
        public static double Squared(this double db)
        {
            return db * db;
        }
    }
}

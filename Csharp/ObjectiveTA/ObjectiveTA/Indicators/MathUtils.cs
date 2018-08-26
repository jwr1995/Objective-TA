using System;

namespace ObjectiveTA.Indicators
{
    public static partial class Indicators
    {
        private static int Abs(int input) => Math.Abs(input);

        private static double Abs(double input) => Math.Abs(input);

        private static double Max(double input1, double input2) => Math.Max(input1,input2);

        private static double Max(double input1, double input2, double input3) => Math.Max(Math.Max(input1, input2), input3);

        private static double[] SubtractArray(double[] first, double[] second)
        {
            double[] output = new double[first.Length];

            for (int i = 0; i < first.Length; i++)
            {
                output[i] = first[i] - second[i];
            }

            return output;
        }
    }
}

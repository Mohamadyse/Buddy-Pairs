namespace ConsoleApp3
{
    using System;
    public class Kata
    {
        //"1 2 0 4 7\r\n0 2 0 2 8\r\n0 0 -1 4 6\r\n1 2 3 2 3"
        public static string Solve(string input)
        {
            int[,] factors = new int[3, 4];
            MakeFactors(input, factors);
            var d = calculateDeterminant(factors);
            if (d == 0) return "SOLUTION=NONE";
            var d0 = DI(0, factors);
            var d1 = DI(1, factors);
            var d2 = DI(2, factors);
            var dd0 = (double)calculateDeterminant(d0);
            var dd1 = (double)calculateDeterminant(d1);
            var dd2 = (double)calculateDeterminant(d2);
            var x0 =  dd0/d;
             x0 = Math.Round(dd0/d, 14);
            var x1 = dd1 / d;
             x1 = Math.Round(dd1 / d, 14);
            var x2 = dd2;
             x2 = Math.Round(dd2 / d, 14);
            string result = $"SOLUTION=({x0}; {x1}; {x2})";
            return result;
        }

        private static int calculateDeterminant(int[,] f)
        {
            var s = f[0, 0] * (f[1, 1] * f[2, 2] - f[1, 2] * f[2, 1]) - f[0, 1] * (f[1, 0] * f[2, 2] - f[1, 2] * f[2, 0]) + f[0, 2] * (f[1, 0] * f[2, 1] - f[1, 1] * f[2, 0]);
            return s;
        }

        private static void MakeFactors(string input, int[,] factors)
        {
            var lines = input.Split("\r\n");
            string[] numbers = new string[3]; ;
            var i = 0;
            foreach (var line in lines)
            {
                var j = 0;
                numbers = line.Split(" ");
                foreach (var number in numbers)
                {
                    factors[i, j] = int.Parse(number);
                    j++;
                }
                i++;
            }
        }

        public static int[,] DI(int column, int[,] f)
        {
            var result = new int[3, 3];
            for (int i = 0; i < f.GetLength(0); i++)
            {
                for (int j = 0; j < f.GetLength(1)-1; j++)
                {
                    if (j != column)
                    {
                        result[i, j] = f[i, j];
                    }
                    else
                    {
                        result[i, j] = f[i, 3];
                    }
                }
            }
            return result;
        }
    }
}
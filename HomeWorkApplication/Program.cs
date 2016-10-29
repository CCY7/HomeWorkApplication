using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace HomeWorkApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //invoke PrimeFactorization
            Console.WriteLine(PrimeFactorization(int.Parse(Console.ReadLine())));

            //invoke TennisScoreBoard
            string[] strParam = Console.ReadLine().Split(' ');
            Console.WriteLine(TennisScoreBoard(int.Parse(strParam[0]), int.Parse(strParam[1])));
        }

        static string PrimeFactorization(int param)
        {
            string strResult = string.Empty;
               
            for (int i = 2; i <= param; i++)
            {
                if (param % i == 0)
                {
                    strResult = strResult + i.ToString() + " * ";
                    param = param / i;
                    i--;
                }
            }
            return strResult.Substring(0, strResult.Length-2);
        }

        static string TennisScoreBoard(int a, int b)
        {
            string[] DictScore = { "LOVE", "FIFTEEN", "THIRTY", "FORTY" };
            string[] DictEqual = { "ALL", "ALL", "ALL", "DEUCE", "DEUCE", "DEUCE" };
            string[] DictAdv = { "", "ADVANTAGE", "WIN", "WIN", "WIN" };


            if (a == b)
            {
                if (a < 3)
                    return DictScore[a] + " " + DictEqual[a];
                return DictEqual[a];
            }
            else
            {
                int gap = System.Math.Abs(a - b);
                string winnerName = a > b ? "A" : "B";

                if ((a > 3 || b > 3))
                    return winnerName + " " + DictAdv[gap];
                return DictScore[a] + " " + DictScore[b];
            }
        }
    }
}

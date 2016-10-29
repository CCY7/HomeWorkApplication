using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace TDDProject
{
    [TestClass]
    public class TDDUnitTest
    {
        [TestMethod]
        public void TestPrimeFactorization()
        {
            //Assert.AreEqual(2,Factorization.Output(2));
            //Assert.AreEqual(3,Factorization.Output(3));
            CollectionAssert.AreEqual(new int[] { 2 },Factorization.Output(2));
            CollectionAssert.AreEqual(new int[] { 3 }, Factorization.Output(3));
            CollectionAssert.AreEqual(new int[] { 2,2},Factorization.Output(4));//to this step, start first round of reconstruct 
            CollectionAssert.AreEqual(new int[] { 5 }, Factorization.Output(5));
            CollectionAssert.AreEqual(new int[] { 2, 3 }, Factorization.Output(6));
            CollectionAssert.AreEqual(new int[] { 7 }, Factorization.Output(7));
            CollectionAssert.AreEqual(new int[] { 2, 2, 2 }, Factorization.Output(8));//to this step, start second round of reconstruct 

            CollectionAssert.AreEqual(new int[] { 2, 3, 5 }, Factorization.Output(30));
            CollectionAssert.AreEqual(new int[] { 2, 3, 5 , 7 }, Factorization.Output(210));
            CollectionAssert.AreEqual(new int[] { 2, 3, 5 , 7, 11 }, Factorization.Output(2310));
            CollectionAssert.AreEqual(new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 }, Factorization.Output(223092870));
        }


        [TestMethod]
        public void TestTennisScoreBoard_When_EqualScore()
        {
            Assert.AreEqual("LOVE ALL", ScoreBoard.Show(0,0));
            Assert.AreEqual("FIFTEEN ALL", ScoreBoard.Show(1, 1));
            Assert.AreEqual("THIRTY ALL", ScoreBoard.Show(2, 2));
            Assert.AreEqual("DEUCE", ScoreBoard.Show(3, 3));
            Assert.AreEqual("DEUCE", ScoreBoard.Show(4, 4));
            Assert.AreEqual("DEUCE", ScoreBoard.Show(5, 5));
        }

        [TestMethod]
        public void TestTennisScoreBoard_When_A_is_higher()
        {
            Assert.AreEqual("FIFTEEN LOVE", ScoreBoard.Show(1, 0));
            Assert.AreEqual("THIRTY LOVE", ScoreBoard.Show(2, 0));
            Assert.AreEqual("THIRTY FIFTEEN", ScoreBoard.Show(2, 1));
            Assert.AreEqual("FORTY LOVE", ScoreBoard.Show(3, 0));
            Assert.AreEqual("FORTY FIFTEEN", ScoreBoard.Show(3, 1));
            Assert.AreEqual("FORTY THIRTY", ScoreBoard.Show(3, 2));
            Assert.AreEqual("A WIN", ScoreBoard.Show(4, 0));
            Assert.AreEqual("A WIN", ScoreBoard.Show(4, 1));
            Assert.AreEqual("A WIN", ScoreBoard.Show(4, 2));
            Assert.AreEqual("A ADVANTAGE", ScoreBoard.Show(4, 3));
            Assert.AreEqual("A WIN", ScoreBoard.Show(5, 3));
            Assert.AreEqual("A ADVANTAGE", ScoreBoard.Show(5, 4));
        }

        [TestMethod]
        public void TestTennisScoreBoard_When_B_is_higher()
        {
            Assert.AreEqual("LOVE FIFTEEN", ScoreBoard.ShowBoth(0,1));
            Assert.AreEqual("LOVE THIRTY", ScoreBoard.ShowBoth(0,2));
            Assert.AreEqual("FIFTEEN THIRTY", ScoreBoard.ShowBoth(1, 2));
            Assert.AreEqual("LOVE FORTY", ScoreBoard.ShowBoth(0, 3));//start to reconstruct old Show method
            Assert.AreEqual("FIFTEEN FORTY", ScoreBoard.ShowBoth(1, 3));
            Assert.AreEqual("THIRTY FORTY", ScoreBoard.ShowBoth(2, 3));
            Assert.AreEqual("B WIN", ScoreBoard.ShowBoth(0, 4));
            Assert.AreEqual("B WIN", ScoreBoard.ShowBoth(1, 4));
            Assert.AreEqual("B WIN", ScoreBoard.ShowBoth(2, 4));
            Assert.AreEqual("B ADVANTAGE", ScoreBoard.ShowBoth(3, 4));
            Assert.AreEqual("B WIN", ScoreBoard.ShowBoth(3, 5));
            Assert.AreEqual("B ADVANTAGE", ScoreBoard.ShowBoth(4, 5));
        }
    }

    public class Factorization
    {
        public static ArrayList Output(int param)
        {
            ArrayList list = new ArrayList();

            for (int i = 2; i <= param; i++)
            {
                if (param % i == 0 )
                {
                    list.Add(i);
                    param = param / i;
                    i--;
                }
            }

            //if (param % 2 == 0 && param > 2)
            //{
            //    list.Add(2);
            //    param = param / 2;
            //}
            //else if (param % 3 == 0 && param > 3)
            //{
            //    list.Add(3);
            //    param = param / 3;
            //}

            //list.Add(param);

            return list;
        }
    }

    public class ScoreBoard
    {
        public static string Show(int a, int b)
        {
            string[] DictScore = { "LOVE","FIFTEEN","THIRTY","FORTY"};
            string[] DictEqual = { "ALL", "ALL", "ALL", "DEUCE", "DEUCE", "DEUCE" };

            if (a == b)//section1
            {
                if (a < 3)
                    return DictScore[a] + " " + DictEqual[a];
                return DictEqual[a];    
            }
            else
            { //section2
                #region method2
                //int gap = a - b;
                //if (gap > 1 && a>3)
                //    return "A WIN";
                //if(a>3)
                //    return "A ADVANTAGE";
                //return DictScore[a] + " " + DictScore[b];
                #endregion
                if (a < 4 && b <= 2)
                    return DictScore[a] + " " + DictScore[b];
                if (a > 3 && a - b == 1)
                    return "A ADVANTAGE";
                return "A WIN";

            }
            #region abandon area
            ////abandon1 which is replaced by section1
            //if (a == 1)
            //    return "FIFTEEN ALL";
            //else if (a == 2)
            //    return "THIRTY ALL";
            //else if (a == 3)
            //    return "DEUCE";
            //else if (a == 4)
            //    return "DEUCE";
            //else if (a == 5)
            //    return "DEUCE";
            //return "LOVE ALL";

            ////abandon2 which is replaced by section2
            //if(a == 1 && b == 0)
            //    return "FIFTEEN LOVE";
            //if(a == 2 && b == 0)
            //    return "THIRTY LOVE";
            //if (a == 3 && b == 0)
            //    return "FORTY LOVE";
            //if(a == 2 && b == 1)
            //    return DictScore[a] + " " + DictScore[b];
            //if (a == 3 && b == 1)
            //    return DictScore[a] + " " + DictScore[b];
            //if(a == 3 && b ==2)
            //    return DictScore[a] + " " + DictScore[b];

            ////abandon3 which is replaced by section3
            //if (a == 4 && b == 3)
            //    return "A ADVANTAGE";
            //if (a == 5 && b == 4)
            //    return "A ADVANTAGE";

            ////abandon4 which is replaced by section4
            //if (a == 4 && b == 0)
            //    return "A WIN";
            //if (a == 4 && b == 1)
            //    return "A WIN";
            //if (a == 4 && b == 2)
            //    return "A WIN";

            //if(a==4 && b<3)
            //    return "A WIN";
            //if (a == 5 && b == 3)
            //    return "A WIN";

            ////abandon5 which is replaced by section2
            ////section3
            //if (a>3 && a-b==1)
            //    return "A ADVANTAGE";
            ////section4
            //if (a >3 && a - b > 1)

            //return null;
            #endregion
        }

        public static string ShowBoth(int a, int b)
        {
            string[] DictScore = { "LOVE", "FIFTEEN", "THIRTY", "FORTY" };
            string[] DictEqual = { "ALL", "ALL", "ALL", "DEUCE", "DEUCE", "DEUCE" };
            string[] DictAdv = { "", "ADVANTAGE", "WIN","WIN","WIN" };


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



                #region abandon area1
                //if( a== 0 && b==3)
                //    return DictScore[a] + " " + DictScore[b];
                //if( a==1 && b==3)
                //    return DictScore[a] + " " + DictScore[b];
                //if (a == 2 && b == 3)
                //    return DictScore[a] + " " + DictScore[b];

                //if (a == 0 && b == 4)
                //    return "B WIN";
                //if (a == 1 && b == 4)
                //    return "B WIN";
                //if(a == 2 && b == 4)
                //    return "B WIN";

                //if(a<=2 && b ==4)
                //    return "B WIN";
                //if(a==3 && b==5)
                //    return "B WIN";

                //if (a == 3 && b==4)
                //    return "B ADVANTAGE";
                //if(a == 4 && b==5)
                //    return "B ADVANTAGE";
                #endregion
                #region abandon area2
                //if (a <= 2 && b == 3)
                //    return DictScore[a] + " " + DictScore[b];

                //if (a < 4 && b <= 3)
                //    return DictScore[a] + " " + DictScore[b];

                //if (a <= 3 && b - a > 1)
                //    return "B WIN";

                //if (b > 3 && b - a == 1)
                //    return "B ADVANTAGE";

                //if (a > 3 && a - b == 1)
                //    return "A ADVANTAGE";
                //return "A WIN";
                #endregion

            }
        }
    }
}

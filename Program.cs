using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace ConsoleAppDistance
{
    public class PointClass
    {
        public float X;
        public float Y;
    }
    public struct PointStruct
    {
        public float X;
        public float Y;
    }
    public struct PointDouble
    {
        public double X;
        public double Y;
    }
    public struct PointStructDouble
    {
        public double X;
        public double Y;
    }
    class Program
    {

        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            var b = new BenchmarkClass(); //создаю экземпляр класса BenchmarkClass
            float[] a = new float[] { 2,9955, 3,5554 }; //создаю массив данных
            float c = a[1];
            b.DistanceRef(a,c); //выводит ошибку о невозможности преобразования float[] в ConsoleAppDistance.PointClass не пойму где ошибка
            b.DistanceVal(a,c);
            b.DistanceValDouble(a,c);
            b.DistanceValShort(a,c);
        }
        public class BenchmarkClass
        {
            PointClass a = new PointClass();
            PointClass b = new PointClass();

            PointStruct a1 = new PointStruct();
            PointStruct b1 = new PointStruct();

            PointStructDouble a2 = new PointStructDouble();
            PointStructDouble b2 = new PointStructDouble();

            public float DistanceRef(PointClass pointClass1, PointClass pointClass2)
            {
                float X = pointClass1.X - pointClass2.X;
                float Y = pointClass2.Y - pointClass2.Y;
                return (float)Math.Sqrt((X * X) + (Y * Y));
            }
            public float DistanceVal(PointStruct pointStruct1, PointStruct pointStruct2)
            {
                float X = pointStruct1.X - pointStruct2.X;
                float Y = pointStruct1.Y - pointStruct2.Y;
                return (float)Math.Sqrt((X * X) + (Y * Y));
            }
            public double DistanceValDouble(PointStructDouble pointStructDouble1, PointStructDouble pointStructDouble2)
            {
                double X = pointStructDouble1.X - pointStructDouble2.X;
                double Y = pointStructDouble1.Y - pointStructDouble2.Y;
                return Math.Sqrt((X * X) + (Y * Y));
            }
            public float DistanceValShort(PointStruct pointStruct1, PointStruct pointStruct2)
            {
                float X = pointStruct1.X - pointStruct2.X;
                float Y = pointStruct1.Y - pointStruct2.Y;
                return (X * X) + (Y * Y);
            }

            [Benchmark]
            public void Test1()
            {
                DistanceRef(a, b);
            }
            [Benchmark]
            public void Test2()
            {
                DistanceVal(a1, b1);
            }
            [Benchmark]
            public void Test3()
            {
                DistanceValDouble(a2, b2);
            }
            [Benchmark]
            public void Test4()
            {
                DistanceValShort(a1, b1);
            }
        }
    }
}

    


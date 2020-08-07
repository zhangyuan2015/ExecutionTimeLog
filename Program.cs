using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace ExecutionTimeLog
{
    class Program
    {
        static void Main(string[] args)
        {
            int res = 0;
            new Program().TimeLog("Test", () =>
            {
                res = new Program().Test4(1);
                res = 3;
            });
            Console.WriteLine(res);
        }

        public void Test1()
        {
            Thread.Sleep(1500);
        }

        public int Test2()
        {
            Thread.Sleep(2500);
            return 0;
        }

        public void Test3(int intp)
        {
            Thread.Sleep(3500);
        }

        public int Test4(int intp)
        {
            Thread.Sleep(4500);
            return intp;
        }

        public void TimeLog(string title, Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //动态调用
            action.Invoke();
            //结束测量
            stopwatch.Stop();
            File.AppendAllLines("D:\\Projects\\ExecutionTimeLog\\Log.txt", new[] { title + " 执行耗时:" + stopwatch.Elapsed.TotalSeconds });
        }
    }
}

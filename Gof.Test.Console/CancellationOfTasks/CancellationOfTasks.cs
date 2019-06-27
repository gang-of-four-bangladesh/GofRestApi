using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gof.Test.Console
{
    public class CancellationOfTasks
    {
        public static void Execute()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            Random random = new Random();
            object lockObj = new object();
            List<Task<int[]>> tasks = new List<Task<int[]>>();
            TaskFactory taskFactory = new TaskFactory(token);
            for (int counter = 0; counter <= 10; counter++)
            {
                int taskId = counter;
                tasks.Add(taskFactory.StartNew(() =>
                {
                    int[] values = new int[10];
                    int randomValue = 0;
                    for (int i = 0; i < values.Length; i++)
                    {
                        lock (lockObj)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(1));
                            randomValue = random.Next(0, 100);
                            System.Console.WriteLine($"Generated value {randomValue} at task {taskId}");
                        }
                        if (randomValue == 0)
                        {
                            source.Cancel();
                            System.Console.WriteLine($"Cancelling task {taskId}");
                        }
                        values[i] = randomValue;
                    }
                    return values;
                }, token));
            }
            try
            {
                Task<double> fTask = taskFactory.ContinueWhenAll(tasks.ToArray(), (results) =>
                {
                    long sum = 0;
                    int n = 0;
                    foreach (var t in results)
                    {
                        foreach (var r in t.Result)
                        {
                            sum += r;
                            n++;
                        }
                    }
                    return sum / (double)n;
                }, token);
                System.Console.WriteLine("The mean is {0}.", fTask.Result);
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                        System.Console.WriteLine("Unable to compute mean: {0}",
                                          ((TaskCanceledException)e).Message);
                    else
                        System.Console.WriteLine("Exception: " + e.GetType().Name);
                }
            }
            finally
            {
                source.Dispose();
            }
        }
    }
}
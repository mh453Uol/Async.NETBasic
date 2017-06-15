using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //GetNameAndContent();
        }

        public static string GetLongRunningName()
        {
            Thread.Sleep(1000); //1 second
            return "Reeeeallly Loooonnngggg Naaammme";
        }

        public static string GetContent()
        {
            Thread.Sleep(300); //0.3 seconds
            return new Random().Next().ToString();
        }

        public static void GetNameAndContent()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            var name = GetLongRunningName(); //1st this happens and takes 1 second
            var content = GetContent();//2nd this happens and takes 0.3 second

            watch.Stop();
            Console.WriteLine(String.Format("{0}:{1}", name, content));
            Console.WriteLine(watch.Elapsed.Seconds.ToString(),
                watch.Elapsed.Milliseconds.ToString());
        }

        public static async Task<string> GetLongRunningNameAsync()
        {
            await Task.Delay(1000); //1 second
            return "Reeeeallly Loooonnngggg Naaammme";
        }

        public static async Task<string> GetContentAsync()
        {
            await Task.Delay(300); //0.3 seconds
            return new Random().Next().ToString();
        }

        public static async Task<string> GetNameAndContentAsync()
        {
            var nameTask = GetLongRunningNameAsync(); //This runs 
            var content = GetContentAsync(); //This also runs at the same time
            var name = await nameTask;
            var task = await content;
            Console.WriteLine(string.Format("{0} {1}", name, task));
            return name;
            //****************** = GetNameAndContentAsync()
            //********* = GetContentAsync()
            //Total time is 1 second since both operation happen at the same time
        }

    }
}

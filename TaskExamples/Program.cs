using System;

namespace TaskExamples
{
    class Program
    {
        static async Task Main(string[] args)
        {

            // var myTask = new HttpClient().GetStringAsync("https://www.google.com").ContinueWith
            //  ((data) =>
            //{
            //    Console.WriteLine("data uzunluk:" + data.Result.Length);
            //});

            // Console.WriteLine("arada yapılacak işler");

            // await myTask;

            var myTask = new HttpClient().GetStringAsync("https://www.google.com");
            Console.WriteLine("arada yapılacak işler");
            var data = await myTask;
            Console.WriteLine("data uzunluk:" + data.Length);
        }


    } // end of class
} // end of namespace
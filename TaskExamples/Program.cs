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

            //var myTask = new HttpClient().GetStringAsync("https://www.google.com");
            //Console.WriteLine("arada yapılacak işler");
            //var data = await myTask;
            //Console.WriteLine("data uzunluk:" + data.Length);

            Console.WriteLine("Hello World!");

            var myTask = new HttpClient().GetStringAsync("https://www.google.com")
                .ContinueWith(calis);

            Console.WriteLine("Arada yapılacak işler");

            await myTask;
        }

        private static void calis(Task<string> data)
        {
            Console.WriteLine("data uzunluk:" + data.Result.Length);
            /// 100 satırlık kod burada
        }
    } // end of class
} // end of namespace
using System;

namespace TaskExamples
{
    public class Content
    {
        public string Site { get; set; }
        public int Length { get; set; } = 0;
    }

    internal class Program
    {
        private async static Task Main(string[] args)
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

            Console.WriteLine("Main thread1:" + Thread.CurrentThread.ManagedThreadId);

            List<string> urlList = new List<string>()
            {
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.n11.com",
                "https://www.haberturk.com"
            };

            List<Task<Content>> taskList = new List<Task<Content>>();
            urlList.ToList().ForEach(x =>
            {
                taskList.Add(GetContentAsync(x));
            });

            Console.WriteLine("Wait All methodundan önce");
            bool tamamlandimi = Task.WaitAll(taskList.ToArray(), 300);
            Console.WriteLine("Wait All methodundan sonra");

            Console.WriteLine("3 saniyede sonuc geldi mi?" +tamamlandimi);


            Console.WriteLine($"{taskList.First().Result.Site} -  {taskList.First().Result.Length}");

            Console.WriteLine("Main thread2:" + Thread.CurrentThread.ManagedThreadId);
        }

        public static async Task<Content> GetContentAsync(string url)
        {
            Content content = new Content();
            var data = await new HttpClient().GetStringAsync(url);

            content.Site = url;
            content.Length = data.Length;
            Console.WriteLine("url:" + url + " GetContentAsync thread:" + Thread.CurrentThread.ManagedThreadId);

            return content;
        }

    } // end of class
} // end of namespace
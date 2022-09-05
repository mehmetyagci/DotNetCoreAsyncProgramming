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

            Console.WriteLine("Main thread:" + Thread.CurrentThread.ManagedThreadId);

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

            //var contents = await Task.WhenAll(taskList.ToArray());
            //contents.ToList().ForEach(x =>
            //{
            //    Console.WriteLine($"{x.Site} boyut:{x.Length}");
            //});

            //contents.ToList().ForEach(x =>
            //{
            //    Console.WriteLine($"{x.Site} boyut:{x.Length}");
            //});

            var contents = Task.WhenAll(taskList.ToArray());

            Console.WriteLine("Aradaki işler yapılabilir.");
            Console.WriteLine("WhenAll methodtan sonra başka işler yaptım");

            var data = await contents;
           
            data.ToList().ForEach(x =>
            {
                Console.WriteLine($"{x.Site} boyut:{x.Length}");
            });
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace TestsWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //results 
        string res;
        //websites to be downloaded(their index page)
        public static List<string> websites = new List<string>()
        {
            "https://www.google.com",
            "https://www.microsoft.com",
            "https://www.cnn.com",
            "https://www.amazon.com",
            "https://www.facebook.com",
            "https://www.twitter.com",
            "https://www.codeproject.com",
            "https://www.stackoverflow.com",
            "https://en.wikipedia.org/wiki/.NET_Framework",
            "https://nakov.com",
            "https://elmah.io",
            "https://www.pluralsight.com",
            "https://www.udemy.com"
        };
        //method to download one site
        private static WebsiteDataModel DownloadWebsite(string websiteUrl)
        {
            WebsiteDataModel result = new WebsiteDataModel();

            result.WebsiteUrl = websiteUrl;
            WebClient webClient = new WebClient();
            //DownloadString has an async method
            result.WebsiteData = webClient.DownloadString(websiteUrl);
            //returning WebsiteDataModel obj(Url,result)
            return result;
        }

        //normal execute click event
        //normal aka sync
        private void btn_normal_Click(object sender, EventArgs e)
        {
            res = "";
            labelMethod.Text = "Normal";
            Stopwatch sw = new();
            sw.Start();
            DownloadNormal();
            sw.Stop();
            var time = sw.ElapsedMilliseconds;
            string conclusion = "Total time: " + time + "milliseconds.";
            //result display needs opt
            res += conclusion;
            textBox.Text = res;
        }
        //async execute click event
        private async void btn_async_Click(object sender, EventArgs e)
        {
            res = "";
            labelMethod.Text = "Async";
            Stopwatch sw = new();
            sw.Start();
            await DownloadAsync();
            sw.Stop();
            var time = sw.ElapsedMilliseconds;
            string conclusion = "Total time: " + time + "milliseconds.";
            //result display needs opt
            res += conclusion;
            textBox.Text = res;
        }
        //parallel async click event
        private async void btn_parallel_async_Click(object sender, EventArgs e)
        {
            res = "";
            labelMethod.Text = "Async Parallel";
            Stopwatch sw = new();
            sw.Start();
            await DownloadParallelAsync();
            sw.Stop();
            var time = sw.ElapsedMilliseconds;
            string conclusion = "Total time: " + time + "milliseconds.";
            //result display needs opt
            res += conclusion;
            textBox.Text = res;
        }
        //parallel normal click event
        private void btn_normal_parallel_Click(object sender, EventArgs e)
        {
            res = "";
            labelMethod.Text = "Normal Parallel";
            Stopwatch sw = new();
            sw.Start();
            DownloadParallelNormal();
            sw.Stop();
            var time = sw.ElapsedMilliseconds;
            string conclusion = "Total time: " + time + "milliseconds.";
            //result display needs opt
            res += conclusion;
            textBox.Text = res;
        }
        //METHODS
        //Normal download site
        private void DownloadNormal()
        {
            List<string> urls = websites;
            progressLabel.Text = "";

            foreach (string website in urls)
            {
                WebsiteDataModel result = DownloadWebsite(website);
                ReportResult(result);
            }
        }
        //Async download site
        private async Task DownloadAsync()
        {
            List<string> urls = websites;
            int count = 0;

            foreach (string website in urls)
            {
                //if we can't change the DownloadWebsite method to an async one
                //we're waiting for the website to download
                //waiting time-sum of all download times
                WebsiteDataModel result = await Task.Run(() => DownloadWebsite(website));
                ReportResult(result);

                count++;
                ReportProgress(count, urls.Count);
            }
        }
        //Parallel async download site
        private async Task DownloadParallelAsync()
        {
            List<string> urls = websites;
            List<Task<WebsiteDataModel>> taskItems = new List<Task<WebsiteDataModel>>();
            progressLabel.Text = "";

            foreach (string website in urls)
            {
                //returning Task<WebsiteDataModel> if not awaited as in this case
                //we're adding the downloading task to the list even if not done yet
                //---meaning all tasks are running at the same time
                //the downloading of these tasks is executed in parallel(at the same time)
                //---but also async because each task is not waiting for the one before to be completed
                //waiting time: the time of the task with the longest time
                //here we don't need the Parallel class simply because we do not block the thread(as in sync)
                taskItems.Add(Task.Run(() => DownloadWebsite(website)));
            }
            //passing a list of task and waiting until all of them are done
            var results = await Task.WhenAll(taskItems);
            foreach (WebsiteDataModel t in results)
            {
                ReportResult(t);
            }
        }
        //Parallel normal download site
        private void DownloadParallelNormal()
        {
            List<string> urls = websites;
            List<WebsiteDataModel> items = new List<WebsiteDataModel>();
            progressLabel.Text = "";
            //the Parallel class executes the selected operation(in this case ForEach) in parallel
            //---meaning that it doesn't wait for each loop to be done executing before firing the next one
            //although the Downloading of the website is still sync meaning that a Task is fired and the thread is blocked
            //--- if needed the Parallel class(the threadpool) can create new threads to deal with it
            //conceptually the threads are often said to run at the same time(in parallel),
            //---they are actually running consecutively in time slices 
            //closer look->Parallel schedules tasks to TaskScheduler, the scheduler then goes to the ThreadPool 
            Parallel.ForEach<string>(urls, (website) =>
            {
                items.Add(DownloadWebsite(website));
            });
            foreach (WebsiteDataModel t in items)
            {
                ReportResult(t);
            }
        }

        //reporting the results
        private void ReportResult(WebsiteDataModel result)
        {
            string resultString = $"Site " + result.WebsiteUrl + " - " + result.WebsiteData.Length + " characters long downloaded" + Environment.NewLine;
            res += resultString;

        }
        // reporting the progress
        private void ReportProgress(int downloadedCount, int allCount)
        {
            progressLabel.Text = downloadedCount + "/" + allCount;
        }

    }
}

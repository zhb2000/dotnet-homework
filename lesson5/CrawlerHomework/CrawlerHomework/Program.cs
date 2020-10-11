using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CrawlerHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            var crawler = new Crawler("https://www.cnblogs.com",
                                      "C:/Users/zhb/Desktop/temp/pages", 10);
            crawler.CrawlPageStarted +=
                url => Console.WriteLine($"Craw {url} started.");
            crawler.CrawlPageFailed +=
                (url, msg) => Console.WriteLine($"Craw {url} failed. Msg: {msg}.");
            crawler.CrawlPageSucceeded +=
                (url, html) => Console.WriteLine($"Craw {url} succeeded.");
            crawler.CrawlTaskEnded += () => Console.WriteLine("Craw task ended.");
            crawler.BfsCraw();
        }
    }

    public class Crawler
    {
        public Crawler(string firstUrl, string folderpath, int maxCount)
        {
            this.firstUrl = StandardizeUrl(firstUrl);
            this.folderpath = folderpath;
            this.maxCount = maxCount;
        }

        public delegate void CrawlTaskEndedHandler();
        public delegate void CrawlPageStartedHandler(string url);
        public delegate void CrawlPageSucceededHandler(string url, string html);
        public delegate void CrawlPageFailedHandler(string url, string failedMsg);

        /// <summary>
        /// 开始爬取某个网页
        /// </summary>
        public event CrawlPageStartedHandler CrawlPageStarted;
        /// <summary>
        /// 爬取某个网页成功
        /// </summary>
        public event CrawlPageSucceededHandler CrawlPageSucceeded;
        /// <summary>
        /// 爬取某个网页失败
        /// </summary>
        public event CrawlPageFailedHandler CrawlPageFailed;
        /// <summary>
        /// 爬取任务结束
        /// </summary>
        public event CrawlTaskEndedHandler CrawlTaskEnded;

        public void Stop() => stopFlag = true;

        public void DfsCraw()
        {
            Dfs(firstUrl);
            CrawlTaskEnded?.Invoke();
        }

        public void BfsCraw()
        {
            var urlQueue = new Queue<string>();
            urlQueue.Enqueue(firstUrl);
            while (!stopFlag && count < maxCount && urlQueue.Count > 0)
            {
                string url = urlQueue.Dequeue();
                CrawlPageStarted?.Invoke(url); //开始爬取
                string filepath = folderpath + "/" + (count + 1) + ".html";
                string html;
                try
                {
                    html = Download(url, filepath);
                }
                catch (Exception e)
                {
                    CrawlPageFailed?.Invoke(url, e.Message); //爬取失败
                    return;
                }
                CrawlPageSucceeded?.Invoke(url, html); //爬取成功
                hasCrawedUrl.Add(url);
                count++;

                foreach (var nxtUrl in UrlsInHtml(html, url))
                {
                    if (!hasCrawedUrl.Contains(nxtUrl))
                    {
                        urlQueue.Enqueue(nxtUrl);
                    }
                }
            }
            CrawlTaskEnded?.Invoke();
        }

        private void Dfs(string url)
        {
            if (stopFlag || count >= maxCount)
            {
                return;
            }

            CrawlPageStarted?.Invoke(url); //开始爬取
            string filepath = folderpath + "/" + (count + 1) + ".html";
            string html;
            try
            {
                html = Download(url, filepath);
            }
            catch (Exception e)
            {
                CrawlPageFailed?.Invoke(url, e.Message); //爬取失败
                return;
            }
            CrawlPageSucceeded?.Invoke(url, html); //爬取成功
            hasCrawedUrl.Add(url);
            count++;

            foreach (var nxtUrl in UrlsInHtml(html, url))
            {
                if (!hasCrawedUrl.Contains(nxtUrl))
                {
                    Dfs(nxtUrl);
                }
            }
        }

        /// <summary>
        /// 第一个 URL
        /// </summary>
        private readonly string firstUrl;
        /// <summary>
        /// 已爬取过的 URL
        /// </summary>
        private readonly HashSet<string> hasCrawedUrl = new HashSet<string>();
        /// <summary>
        /// 已爬取网页个数
        /// </summary>
        private int count = 0;
        /// <summary>
        /// 最大个数
        /// </summary>
        private readonly int maxCount;
        /// <summary>
        /// 存放网页的文件夹
        /// </summary>
        private readonly string folderpath;
        /// <summary>
        /// 停止爬取的标志变量
        /// </summary>
        private bool stopFlag = false;

        /// <summary>
        /// 将 URL 对应的网页下载到指定文件夹，并返回网页内容
        /// </summary>
        /// <returns>网页内容</returns>
        private static string Download(string url, string filepath)
        {
            var client = new WebClient { Encoding = Encoding.UTF8 };
            string html = client.DownloadString(url);
            File.WriteAllText(filepath, html, Encoding.UTF8);
            return html;
        }

        /// <summary>
        /// 让 URL 以 http:// 或 https: 开头，以 / 结尾
        /// </summary>
        private static string StandardizeUrl(string url)
        {
            url = url.Trim();
            if (!new Regex("^(http|https)://").IsMatch(url))
            {
                url = "http://" + url;
            }
            if (url[url.Length - 1] != '/')
            {
                url += "/";
            }
            return url;
        }

        /// <summary>
        /// 提取当前网页中的所有链接
        /// </summary>
        /// <param name="html">html 内容</param>
        /// <param name="currentUrl">当前 URL</param>
        private static ISet<string> UrlsInHtml(string html, string currentUrl)
        {
            var urls = new HashSet<string>();
            var regex = new Regex(@"<a\s*[^>]*\s*(href|HREF)\s*=\s*""([^""'#>]+)""");
            var matches = regex.Matches(html);
            foreach (Match match in matches)
            {
                Debug.Assert(match.Groups.Count == 2 + 1);
                string url = match.Groups[2].Value.Trim();
                if (IsHttpHttpsUrl(url)) //以 http 或 https 开头
                {
                    urls.Add(url);
                }
                else if (IsRelative(url)) //是相对路径
                {
                    urls.Add(Relative2Absolute(currentUrl, url));
                }
            }
            return urls;
        }

        /// <summary>
        /// 是否为 http 或 https 协议的绝对路径
        /// </summary>
        private static bool IsHttpHttpsUrl(string url)
        {
            var regex = new Regex(@"(http|https)://.+");
            return regex.IsMatch(url);
        }

        /// <summary>
        /// 是否为相对路径
        /// </summary>
        private static bool IsRelative(string url)
        {
            if (new Regex("^javascript:").IsMatch(url))
            {
                return false;
            }
            else if (url[0] == '/')
            {
                return false;
            }
            else
            {
                return true;
                //return new Regex(@"^\.{1,2}/").IsMatch(url);
            }
        }

        /// <summary>
        /// 相对路径转绝对路径
        /// </summary>
        /// <param name="currentUrl">当前路径</param>
        /// <param name="relativeUrl">相对路径</param>
        private static string Relative2Absolute(string currentUrl, string relativeUrl)
        {
            if (currentUrl[currentUrl.Length - 1] != '/')
            {
                currentUrl += "/";
            }
            if (new Regex(@"^\.\./").IsMatch(relativeUrl)) // ../xxx
            {
                var regex = new Regex("/[^/]*/$");
                var index = regex.Match(currentUrl).Index;
                return currentUrl.Substring(0, index + 1)
                    + relativeUrl.Substring(3, relativeUrl.Length - 3);
            }
            else if (new Regex(@"^\./").IsMatch(relativeUrl)) // ./xxx
            {
                return currentUrl + relativeUrl.Substring(2, relativeUrl.Length - 2);
            }
            else // xxx
            {
                return currentUrl + relativeUrl;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using CrawlerHomework;

namespace CrawlerGui
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private readonly MainWinVM viewModel = new MainWinVM();
        private Crawler crawler = null;

        /// <summary>
        /// 在 UI 线程执行添加表项的操作
        /// </summary>
        private void AddItemInUiThread(string url, string content, bool isSuccessful)
        {
            Dispatcher.BeginInvoke(
                DispatcherPriority.Normal,
                new Action(
                    () => viewModel.Results.Add(new ResultItem(url, content, isSuccessful))
                )
            );
        }

        /// <summary>
        /// 在 UI 线程执行添加 Log 的操作
        /// </summary>
        private void AddLogInUiThread(string log) => viewModel.AddLog(log);

        /// <summary>
        /// 在 UI 线程执行爬取结束时的一些操作
        /// </summary>
        private void CrawlEndedActionInUiThread()
        {
            Dispatcher.BeginInvoke(
                DispatcherPriority.Normal,
                new Action(() =>
                {
                    AddLogInUiThread("Craw task ended.");
                    MessageBox.Show("Craw task ended.");
                    startButton.IsEnabled = true;
                })
            );
        }

        private void SelectFolderButton_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    viewModel.Folderpath = dialog.SelectedPath;
                }
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.Folderpath == null || viewModel.Folderpath.Length == 0)
            {
                MessageBox.Show("Folderpath is empty.");
                return;
            }

            viewModel.Results.Clear();
            viewModel.ClearLog();
            crawler = new Crawler(viewModel.Url,
                                      viewModel.Folderpath,
                                      viewModel.MaxLimitInt);
            crawler.CrawlPageStarted += url => AddLogInUiThread($"Craw {url} started.");
            crawler.CrawlPageFailed += (url, msg) =>
            {
                AddItemInUiThread(url, msg, false);
                AddLogInUiThread($"Craw {url} failed. Msg: {msg}");
            };
            crawler.CrawlPageSucceeded += (url, html) =>
            {
                AddItemInUiThread(url, html, true);
                AddLogInUiThread($"Craw {url} succeeded.");
            };
            crawler.CrawlTaskEnded += () => CrawlEndedActionInUiThread();
            startButton.IsEnabled = false;
            Task.Run(() =>
            {
                if (viewModel.IsBfsChecked)
                {
                    crawler.BfsCraw();
                }
                else
                {
                    crawler.DfsCraw();
                }
            });
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            if (crawler != null)
            {
                crawler.Stop();
            }
        }
    }
}

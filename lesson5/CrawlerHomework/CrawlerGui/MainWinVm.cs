using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CrawlerGui
{
    /// <summary>
    /// 主窗口的 View Model
    /// </summary>
    class MainWinVM : INotifyPropertyChanged
    {
        /// <summary>
        /// 存放网页的文件夹路径
        /// </summary>
        private string folderpath = "";
        public string Folderpath
        {
            get => folderpath;
            set
            {
                folderpath = value;
                NotifyPropertyChanged("Folderpath");
            }
        }

        public string Url { get; set; } = "https://www.cnblogs.com";

        public int MaxLimitInt { get; private set; } = 10;
        public string MaxLimit
        {
            get => MaxLimitInt.ToString();
            set
            {
                try
                {
                    MaxLimitInt = int.Parse(value);
                    if (MaxLimitInt <= 0)
                    {
                        throw new ApplicationException("Max Limit must greater than zero.");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public bool IsBfsChecked { get; set; } = true;

        public ObservableCollection<ResultItem> Results { get; }
            = new ObservableCollection<ResultItem>();

        private string logMsg = "";
        public string LogMsg
        {
            get => logMsg;
            private set
            {
                logMsg = value;
                NotifyPropertyChanged("LogMsg");
            }
        }

        public void AddLog(string log) => LogMsg += log + "\n";

        public void ClearLog() => LogMsg = "";

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CrawlerGui
{
    /// <summary>
    /// 爬取结果列表的表项
    /// </summary>
    public class ResultItem
    {
        public ResultItem(string url, string content, bool isSuccessful)
        {
            Url = url;
            Content = content;
            this.isSuccessful = isSuccessful;
        }

        public string Url { get; }

        /// <summary>
        /// 若成功则显示 html 内容，若失败则显示错误信息
        /// </summary>
        public string Content { get; }

        public Brush BgColor
        {
            get => isSuccessful ? new SolidColorBrush(Colors.LightGreen)
                                : new SolidColorBrush(Colors.LightPink);
        }

        private readonly bool isSuccessful;
    }
}

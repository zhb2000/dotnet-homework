# 第五次作业
1. 改进书上例子 9-10 的爬虫程序。
    1. 只爬取起始网站（www.cnblog.com）上的网页。
    2. 只有当爬取的是 html、htm、jsp、aspx、php 页面时，才解析并爬取下一级 URL。
    3. 相对地址转成绝对地址进行爬取。
        例如：当前页面是 https://www.cnblogs.com/abc/ 时, 该页面中的链接 test/index.html 或者 ./test/index.html 都相当于 https://www.cnblogs.com/abc/test/index.html ， ../zzz/index.html 相当于 https://www.cnblogs.com/zzz/index.html 

2. 尝试使用 Winform 来设置初始 URL，启动爬虫，显示已经爬取的 URL 和错误的 URL 信息。

3. 将爬虫程序，使用并行处理进行优化，实现更快速的网页爬取。
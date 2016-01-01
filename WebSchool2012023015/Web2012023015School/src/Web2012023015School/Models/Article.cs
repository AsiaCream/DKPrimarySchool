using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2012023015School.Models
{
    public class Article
    {
        //文章信息(学生，老师写的好的文章
        public int Id { get; set; }
        public string Title { get; set;}
        public DateTime Datatime { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }//文章类别（科幻，悬疑...）
        public string Source { get; set; }
        public string Author { get; set; }
        public int Clickonthequantity{ get; set; }//点击量
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2012023015School.Models
{
    public class SchoolInfo
    {
        //学校信息
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Datetime { get; set; }
    }
}

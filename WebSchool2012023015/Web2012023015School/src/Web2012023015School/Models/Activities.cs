using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2012023015School.Models
{
    public class Activities
    {
        //校园活动
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public DateTime Datatime { get; set; }
        public string Content { get; set; }
        public int Priority { get; set; }
    }
}

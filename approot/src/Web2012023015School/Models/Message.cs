using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2012023015School.Models
{
    public enum State
    {
        未通过,
        通过,
    }
    public class Message
    {
        //留言板
        public int Id { get; set; }
        public State State { get; set; }
        public string NickName { get; set; }
        public DateTime Datatime { get; set; }
        public string Content { get; set; }
    }
}

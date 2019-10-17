using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWebApi.Loger
{
    public class LogEntity
    {
        public int Id { get; set; }
        public DateTime DateOfRequest { get; set; }
        public string Request { get; set; }
        public string RequestMethod { get; set; }
        public string Response { get; set; }
    }
}

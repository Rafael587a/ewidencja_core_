using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_ewidencja.Models
{
    public class Stat
    {
        public Int64 id { get; set; }
        public string visit_host_ip { get; set; }
        public DateTime date_visited { get; set; }
        public string page { get; set; }
    }
}

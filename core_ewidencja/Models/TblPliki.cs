using System;
using System.Collections.Generic;

namespace core_ewidencja.Models
{
    public partial class TblPliki
    {
        public long Id { get; set; }
        public DateTime? AddedDate { get; set; }
        public string Nazwapliku { get; set; }
        public string Url { get; set; }
        public string Comment { get; set; }
    }
}

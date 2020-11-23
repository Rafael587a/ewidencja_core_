using System;
using System.Collections.Generic;

namespace core_ewidencja.Models
{
    public partial class TblStats
    {
        public long Id { get; set; }
        public string VisitHostIp { get; set; }
        public DateTime? DateVisited { get; set; }
        public int? Counter { get; set; }
        public string Page { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace core_ewidencja.Models
{
    public partial class TblZuzycieGazu
    {
        public int Id { get; set; }
        public DateTime? Data { get; set; }
        public decimal? WskLicznika { get; set; }
        public decimal? Kwh { get; set; }
    }
}

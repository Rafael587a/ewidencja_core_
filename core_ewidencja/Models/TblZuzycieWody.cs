using System;
using System.Collections.Generic;

namespace core_ewidencja.Models
{
    public partial class TblZuzycieWody
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public decimal? WskLicznika { get; set; }
    }
}

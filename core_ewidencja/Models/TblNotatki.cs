using System;
using System.Collections.Generic;

namespace core_ewidencja.Models
{
    public partial class TblNotatki
    {
        public int Id { get; set; }
        public DateTime? Data { get; set; }
        public string Notatka { get; set; }
    }
}

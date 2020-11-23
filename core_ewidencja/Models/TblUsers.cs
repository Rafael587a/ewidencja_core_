using System;
using System.Collections.Generic;

namespace core_ewidencja.Models
{
    public partial class TblUsers
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Active { get; set; }
        public DateTime? AddedDate { get; set; }
        public int? TypeUser { get; set; }
    }
}

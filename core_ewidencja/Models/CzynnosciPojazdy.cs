using System;
using System.Collections.Generic;

namespace core_ewidencja.Models
{
    public partial class CzynnosciPojazdy
    {
        public int Id { get; set; }
        public int? IdPojazdu { get; set; }
        public string Przebieg { get; set; }
        public string OpisCzynnosci { get; set; }
        public DateTime? Data { get; set; }
        public int? IdVehicle { get; set; }
    }
}

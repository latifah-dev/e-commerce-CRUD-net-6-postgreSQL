using System;
using System.Collections.Generic;

namespace PALUGADA.Datas.Entities
{
    public partial class Pembeli
    {
        public int IdPembeli { get; set; }
        public string? NamaPembeli { get; set; }
        public string? AlamatPembeli { get; set; }
        public string? NotelpPembeli { get; set; }
        public string? NegaraPembeli { get; set; }
        public int? IdUser { get; set; }

        public virtual User? IdUserNavigation { get; set; }
    }
}

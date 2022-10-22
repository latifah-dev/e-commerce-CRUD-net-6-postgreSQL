using System;
using System.Collections.Generic;

namespace PALUGADA.Datas.Entities
{
    public partial class Barang
    {
        public int IdBarang { get; set; }
        public string? NamaBarang { get; set; }
        public string? KodeBarang { get; set; }
        public string? JenisBarang { get; set; }
        public int? HargaBarang { get; set; }
        public int? StokBarang { get; set; }
        public string? DeskripsiBarang { get; set; }
        public string? GambarBarang { get; set; }
        public int? IdPenjual { get; set; }
        public string? UrlGambar { get; set; }

        public virtual Penjual? IdPenjualNavigation { get; set; }
    }
}

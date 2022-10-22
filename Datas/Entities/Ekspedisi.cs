using System;
using System.Collections.Generic;

namespace PALUGADA.Datas.Entities
{
    public partial class Ekspedisi
    {
        public Ekspedisi()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdEkspedisi { get; set; }
        public string? NamaEkspedisi { get; set; }
        public string? AlamatEkspedisi { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}

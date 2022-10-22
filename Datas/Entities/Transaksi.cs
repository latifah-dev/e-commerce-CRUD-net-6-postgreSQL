using System;
using System.Collections.Generic;

namespace PALUGADA.Datas.Entities
{
    public partial class Transaksi
    {
        public int IdTransaksi { get; set; }
        public DateTime? TglBeli { get; set; }
        public DateTime? TglBayar { get; set; }
        public string? Status { get; set; }
        public string? JenisPembayaran { get; set; }
        public string? StatusPembayaran { get; set; }
        public int? IdBarang { get; set; }
        public int? Qty { get; set; }
        public int? Total { get; set; }
        public int? IdPembeli { get; set; }
        public int? IdPenjual { get; set; }
        public int? IdEkspedisi { get; set; }

        public virtual Barang? IdBarangNavigation { get; set; }
        public virtual Ekspedisi? IdEkspedisiNavigation { get; set; }
        public virtual Pembeli? IdPembeliNavigation { get; set; }
        public virtual Penjual? IdPenjualNavigation { get; set; }
    }
}

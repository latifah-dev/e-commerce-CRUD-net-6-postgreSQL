using System;
using System.Collections.Generic;

namespace PALUGADA.Datas.Entities
{
    public partial class User
    {
        public User()
        {
            Pembelis = new HashSet<Pembeli>();
            Penjuals = new HashSet<Penjual>();
        }

        public int IdUser { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? NohpUser { get; set; }
        public string? EmailUser { get; set; }
        public string? TipeUser { get; set; }

        public virtual ICollection<Pembeli> Pembelis { get; set; }
        public virtual ICollection<Penjual> Penjuals { get; set; }
    }
}

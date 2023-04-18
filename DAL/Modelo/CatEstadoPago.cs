using System;
using System.Collections.Generic;

namespace DAL.Modelo
{
    public partial class CatEstadoPago
    {
        public CatEstadoPago()
        {
            TdhEstadoPedidos = new HashSet<TdhEstadoPedido>();
        }

        public string MdUuid { get; set; } = null!;
        public DateTime MdDate { get; set; }
        public string? DescEstadoPago { get; set; }
        public string CodEstadoPago { get; set; } = null!;
        public long Id { get; set; }

        public virtual ICollection<TdhEstadoPedido> TdhEstadoPedidos { get; set; }
    }
}

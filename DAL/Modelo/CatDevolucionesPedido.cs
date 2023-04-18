using System;
using System.Collections.Generic;

namespace DAL.Modelo
{
    public partial class CatDevolucionesPedido
    {
        public CatDevolucionesPedido()
        {
            TdhEstadoPedidos = new HashSet<TdhEstadoPedido>();
        }

        public string CodDevolucion { get; set; } = null!;
        public long Id { get; set; }
        public string MdUuid { get; set; } = null!;
        public DateTime MdDate { get; set; }
        public string? DescDevolucion { get; set; }

        public virtual ICollection<TdhEstadoPedido> TdhEstadoPedidos { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DAL.Modelo
{
    public partial class CatEstadoEnvio
    {
        public CatEstadoEnvio()
        {
            TdhEstadoPedidos = new HashSet<TdhEstadoPedido>();
        }

        public string CodEstadoEnvio { get; set; } = null!;
        public string MdUuid { get; set; } = null!;
        public TimeOnly MdDate { get; set; }
        public string? DescEnvio { get; set; }
        public long Id { get; set; }

        public virtual ICollection<TdhEstadoPedido> TdhEstadoPedidos { get; set; }
    }
}

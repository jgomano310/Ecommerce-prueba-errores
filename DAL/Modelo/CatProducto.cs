using System;
using System.Collections.Generic;

namespace DAL.Modelo
{
    public partial class CatProducto
    {
        public CatProducto()
        {
            TdhEstadoPedidos = new HashSet<TdhEstadoPedido>();
        }

        public string CodProducto { get; set; } = null!;
        public long Id { get; set; }
        public string MdUuid { get; set; } = null!;
        public DateTime MdDate { get; set; }
        public string Tipo { get; set; } = null!;
        public string Precio { get; set; } = null!;
        public string? DescProducto { get; set; }

        public virtual ICollection<TdhEstadoPedido> TdhEstadoPedidos { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DAL.Modelo
{
    public partial class CatProveedore
    {
        public CatProveedore()
        {
            TdhEstadoPedidos = new HashSet<TdhEstadoPedido>();
        }

        public string CodProveedores { get; set; } = null!;
        public long Id { get; set; }
        public string MdUuid { get; set; } = null!;
        public TimeOnly MdDate { get; set; }
        public string Nombre { get; set; } = null!;
        public string Producto { get; set; } = null!;
        public long Precio { get; set; }

        public virtual ICollection<TdhEstadoPedido> TdhEstadoPedidos { get; set; }
    }
}

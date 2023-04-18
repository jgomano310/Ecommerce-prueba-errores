using System;
using System.Collections.Generic;

namespace DAL.Modelo
{
    public partial class TdhEstadoPedido
    {
        public long Id { get; set; }
        public string MdUuid { get; set; } = null!;
        public DateTime MdDate { get; set; }
        public string CodDevolucion { get; set; } = null!;
        public string CodigoLinea { get; set; } = null!;
        public string? CodEstadoEnvio { get; set; }
        public string? CodEstadoPago { get; set; }
        public string CodProducto { get; set; } = null!;
        public string CodProveedores { get; set; } = null!;

        public virtual CatDevolucionesPedido CodDevolucionNavigation { get; set; } = null!;
        public virtual CatEstadoEnvio? CodEstadoEnvioNavigation { get; set; }
        public virtual CatEstadoPago? CodEstadoPagoNavigation { get; set; }
        public virtual CatProducto CodProductoNavigation { get; set; } = null!;
        public virtual CatProveedore CodProveedoresNavigation { get; set; } = null!;
        public virtual CatDistribuidore CodigoLineaNavigation { get; set; } = null!;
    }
}

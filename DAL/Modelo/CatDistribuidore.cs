using System;
using System.Collections.Generic;

namespace DAL.Modelo
{
    public partial class CatDistribuidore
    {
        public CatDistribuidore()
        {
            TdhEstadoPedidos = new HashSet<TdhEstadoPedido>();
        }

        public string CodigoLinea { get; set; } = null!;
        public string MdUuid { get; set; } = null!;
        public DateTime MdDate { get; set; }
        public string CodProvincia { get; set; } = null!;
        public string CodMunicipio { get; set; } = null!;
        public string CodBarrio { get; set; } = null!;
        public long Id { get; set; }

        public virtual ICollection<TdhEstadoPedido> TdhEstadoPedidos { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace waSeguros.Models
{
    public partial class CatTipoIdentificacion
    {
        public CatTipoIdentificacion()
        {
            Clientes = new HashSet<Cliente>();
        }

        public string CodTipoIdentificacion { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}

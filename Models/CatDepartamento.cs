using System;
using System.Collections.Generic;

#nullable disable

namespace waSeguros.Models
{
    public partial class CatDepartamento
    {
        public CatDepartamento()
        {
            CatMunicipios = new HashSet<CatMunicipio>();
            Clientes = new HashSet<Cliente>();
        }

        public int CodPais { get; set; }
        public int CodDepartamento { get; set; }
        public string Xdepartamento { get; set; }
        public string Iestado { get; set; }
        public string Isum { get; set; }

        public virtual CatPai CodPaisNavigation { get; set; }
        public virtual ICollection<CatMunicipio> CatMunicipios { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}

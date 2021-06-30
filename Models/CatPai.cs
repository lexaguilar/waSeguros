using System;
using System.Collections.Generic;

#nullable disable

namespace waSeguros.Models
{
    public partial class CatPai
    {
        public CatPai()
        {
            CatDepartamentos = new HashSet<CatDepartamento>();
            Clientes = new HashSet<Cliente>();
        }

        public int CodPais { get; set; }
        public string Xpais { get; set; }
        public string Iestado { get; set; }

        public virtual ICollection<CatDepartamento> CatDepartamentos { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace waSeguros.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Polizas = new HashSet<Poliza>();
        }

        public int IdCliente { get; set; }
        public string CodTipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string NombreCliente { get; set; }
        public string Direccion { get; set; }
        public int? CodPais { get; set; }
        public int? CodDepartamento { get; set; }
        public int? CodMunicipio { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Estado { get; set; }
        public int? Edad { get; set; }

        public virtual CatDepartamento Cod { get; set; }
        public virtual CatMunicipio CodNavigation { get; set; }
        public virtual CatPai CodPaisNavigation { get; set; }
        public virtual CatTipoIdentificacion CodTipoIdentificacionNavigation { get; set; }
        public virtual ICollection<Poliza> Polizas { get; set; }
    }
}

using System;
using System.Linq;

namespace waSeguros.Models
{
    public partial class Poliza: LogicInit<Poliza>
    {
        internal override void init(SegurosContext _db)
        {
            this.CantidadCuotas = 1;
            this.Estado = "N";
            this.FechaVenta = DateTime.Now;
            this.MontoPagado = 0;
            this.MontoPendiente = this.TotalPrima;
            

            var idRecibo = _db.Polizas.Max(x => x.IdRecibo);
            this.IdRecibo = idRecibo + 1;

        }

    }
}
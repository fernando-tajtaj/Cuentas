using System.Collections.Generic;

namespace Modelos.Cuentas
{
    public class TiposCuentas
    {
        public List<TipoCuenta> ListaTipoCuentas { get; set; }
        public TiposCuentas()
        {
            this.ListaTipoCuentas = new List<TipoCuenta>();
        }
    }
}

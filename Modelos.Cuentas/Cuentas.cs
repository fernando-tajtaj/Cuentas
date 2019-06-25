using System.Collections.Generic;

namespace Modelos.Cuentas
{
    public class Cuentas
    {
        public List<Cuenta> ListaCuentas { get; set; }
        public Cuentas()
        {
            this.ListaCuentas = new List<Cuenta>();
        }
    }
}

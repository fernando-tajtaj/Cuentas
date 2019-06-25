using System.Collections.Generic;


namespace Modelos.Cuentas
{
    public class Clientes
    {
        public List<Cliente> ListaClientes { get; set; }
        public Clientes()
        {
            this.ListaClientes = new List<Cliente>();
        }
    }
}

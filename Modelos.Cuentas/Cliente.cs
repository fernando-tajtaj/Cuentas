namespace Modelos.Cuentas
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public string nombreCliente { get; set; }
        public string apellidoCliente { get; set; }

        public Cliente()
        {
            this.idCliente = 0;
            this.nombreCliente = string.Empty;
            this.apellidoCliente = string.Empty;
        }
    }
}

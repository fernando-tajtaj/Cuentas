namespace Modelos.Cuentas
{
    public class Cuenta
    {
        public int idCuenta { get; set; }
        public string numeroCuenta { get; set; }
        public string nombreCuenta { get; set; }
        public int idCliente { get; set; }
        public Cliente cliente { get; set; }
        public string tipoMoneda { get; set; }
        public int idTipoCuenta { get; set; } 
        public TipoCuenta tipoCuenta { get; set; }
        public string esCuentaTercero { get; set; }

        public Cuenta()
        {
            this.idCuenta = 0;
            this.numeroCuenta = string.Empty;
            this.nombreCuenta = string.Empty;
            this.idCliente = 0;
            this.cliente = new Cliente();
            this.tipoMoneda = string.Empty;
            this.idTipoCuenta = 0;
            this.tipoCuenta = new TipoCuenta();
            this.esCuentaTercero = string.Empty;
        }
    }
}

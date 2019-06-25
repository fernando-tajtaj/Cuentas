namespace Modelos.Cuentas
{
    public class TipoCuenta
    {
        public int idTipoCuenta { get; set; }
        public string tipoCuenta { get; set; }

        public TipoCuenta()
        {
            this.idTipoCuenta = 0;
            this.tipoCuenta = string.Empty;
        }
    }
}

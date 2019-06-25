using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;
using Modelos.Cuentas;
using Newtonsoft.Json;
using Servicios.Cuentas.Models;

namespace Servicios.Cuentas.Controllers
{
    public class CuentaController : ApiController
    {
        Modelos.Cuentas.Cuentas cuentas = new Modelos.Cuentas.Cuentas();
        private static Conexion objConexion = new Conexion();
        private static SqlCommand command = new SqlCommand();
        private DataSet objDatos = new DataSet();

        [HttpGet]
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", MessageId = "No se debe dar dispose a un objeto que se utiliza durante todo el tiempo de vida de la aplicación.")]
        [Route("api/Cuentas/ListadoCuentas")]
        public Modelos.Cuentas.Cuentas ListaCuentas()
        {
            objConexion.Conectar();
            string sql = "EXEC sp_cuentasSelect";
            command = new SqlCommand(sql, objConexion.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(objDatos);
        
            foreach (DataRow item in objDatos.Tables[0].Rows)
            {
                Cuenta cuenta = new Cuenta();
                cuenta.numeroCuenta = item["NumeroCuenta"].ToString();
                cuenta.nombreCuenta = item["NombreCuenta"].ToString();
                cuenta.cliente.nombreCliente = item["nombreCliente"].ToString();
                cuenta.tipoCuenta.tipoCuenta = item["tipoCuenta"].ToString();
                cuenta.tipoMoneda = item["tipoMoneda"].ToString();
                cuenta.esCuentaTercero = item["esCuentaTercero"].ToString();
                cuentas.ListaCuentas.Add(cuenta);
            }
            objConexion.Desconectar();
            return cuentas;
        }


        [HttpPost]
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", MessageId = "No se debe dar dispose a un objeto que se utiliza durante todo el tiempo de vida de la aplicación.")]
        [Route("api/Cuentas/CrearCuenta")]
        public Modelos.Cuentas.Cuentas CrearCuenta(string numeroCuenta, string nombreCuenta, int idCliente, int tipoMoneda, int idTipoCuenta, int esCuentaTercero)
        {
            objConexion.Conectar();
            command = new SqlCommand("sp_cuentas", objConexion.GetConnection());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@numeroCuenta", numeroCuenta.ToString());
            command.Parameters.AddWithValue("@nombreCuenta", nombreCuenta.ToString());
            command.Parameters.AddWithValue("@idCliente", idCliente.ToString());
            command.Parameters.AddWithValue("@tipoMoneda", tipoMoneda.ToString());
            command.Parameters.AddWithValue("@idTipoCuenta", idTipoCuenta.ToString());
            command.Parameters.AddWithValue("@esCuentaTercero", esCuentaTercero.ToString());
            command.ExecuteNonQuery();
            return cuentas;
        }

        [HttpPut]
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", MessageId = "No se debe dar dispose a un objeto que se utiliza durante todo el tiempo de vida de la aplicación.")]
        [Route("api/Cuentas/ActualizarCuenta")]
        public Modelos.Cuentas.Cuentas ActualizarCuenta(int idCuenta, string numeroCuenta, string nombreCuenta, int idCliente, int tipoMoneda, int idTipoCuenta, int esCuentaTercero)
        {
            objConexion.Conectar();
            command = new SqlCommand("sp_cuentasUpdate", objConexion.GetConnection());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@idCuenta", idCuenta.ToString());
            command.Parameters.AddWithValue("@numeroCuenta", numeroCuenta.ToString());
            command.Parameters.AddWithValue("@nombreCuenta", nombreCuenta.ToString());
            command.Parameters.AddWithValue("@idCliente", idCliente.ToString());
            command.Parameters.AddWithValue("@tipoMoneda", tipoMoneda.ToString());
            command.Parameters.AddWithValue("@idTipoCuenta", idTipoCuenta.ToString());
            command.Parameters.AddWithValue("@esCuentaTercero", esCuentaTercero.ToString());
            command.ExecuteNonQuery();
            return cuentas;
        }

        [HttpDelete]
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", MessageId = "No se debe dar dispose a un objeto que se utiliza durante todo el tiempo de vida de la aplicación.")]
        [Route("api/Cuentas/EliminarCuenta")]
        public Modelos.Cuentas.Cuentas EliminarCuenta(int idCuenta)
        {
            objConexion.Conectar();
            command = new SqlCommand("sp_cuentasDelete", objConexion.GetConnection());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@idCuenta", idCuenta.ToString());
            command.ExecuteNonQuery();

            return cuentas;
        }

        [HttpGet]
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", MessageId = "No se debe dar dispose a un objeto que se utiliza durante todo el tiempo de vida de la aplicación.")]
        [Route("api/Cuentas/BuscarCuenta")]
        public Modelos.Cuentas.Cuentas BuscarCuenta(string numeroCuenta)
        {
            objConexion.Conectar();
            command = new SqlCommand("sp_cuentasBuscar", objConexion.GetConnection());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@numeroCuenta", numeroCuenta.ToString());

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(objDatos);

            foreach (DataRow item in objDatos.Tables[0].Rows)
            {
                Cuenta cuenta = new Cuenta();
                cuenta.numeroCuenta = item["NumeroCuenta"].ToString();
                cuenta.nombreCuenta = item["NombreCuenta"].ToString();
                cuenta.cliente.nombreCliente = item["nombreCliente"].ToString();
                cuenta.tipoCuenta.tipoCuenta = item["tipoCuenta"].ToString();
                cuenta.tipoMoneda = item["tipoMoneda"].ToString();
                cuenta.esCuentaTercero = item["cuenta"].ToString();
                cuentas.ListaCuentas.Add(cuenta);
            }
            return cuentas;
        }

        [HttpGet]
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", MessageId = "No se debe dar dispose a un objeto que se utiliza durante todo el tiempo de vida de la aplicación.")]
        [Route("api/Clientes/ListadoClientes")]
        public Clientes ListaClientes()
        {
            objConexion.Conectar();
            Modelos.Cuentas.Clientes clientes = new Clientes();
            string sql = "EXEC sp_clientes";
            command = new SqlCommand(sql, objConexion.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(objDatos);

            foreach (DataRow item in objDatos.Tables[0].Rows)
            {
                Cliente cliente = new Cliente();
                cliente.idCliente = int.Parse(item["idCliente"].ToString());
                cliente.nombreCliente = item["nombreCliente"].ToString();
                clientes.ListaClientes.Add(cliente);
            }
            objConexion.Desconectar();
            return clientes;
        }
    }
}

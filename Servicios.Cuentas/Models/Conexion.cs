using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Servicios.Cuentas.Models
{
    public class Conexion
    {
        SqlConnection sqlConnection = new SqlConnection();
        SqlCommand sqlCommand = new SqlCommand();
        string cadenaConexion = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ControlCuentas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public Conexion()
        {
            this.sqlConnection = new SqlConnection(cadenaConexion);
        }

        public void Conectar()
        {
            if (sqlConnection != null)
            {
                if (sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    sqlConnection.Open();
                    Console.WriteLine("Se inicio la conexion");
                }
                else
                {
                    Console.WriteLine("No existe una conexion");
                }
            } 
        }

        public void Desconectar()
        {
            if (sqlConnection != null)
            {
                if (sqlConnection.State != System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Close();
                    Console.WriteLine("Se cerro la conexion");
                }
                else
                {
                    Console.WriteLine("No existe una conexion");
                }
            }
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
    }
}
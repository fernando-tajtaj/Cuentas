using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Modelos.Cuentas;
using Newtonsoft.Json;

namespace Cliente.KeylerTajtaj.Account.Controllers
{
    public class CuentaController : Controller
    {
        private HttpClient clienteRestFul;
        string Baseurl = "http://localhost:50665/";
        Cuentas cuentas = new Cuentas();
        HttpClient client = new HttpClient();

        public CuentaController()
        {

            this.clienteRestFul = new HttpClient();
        }

        // GET: Cuenta
        public async Task<ActionResult> Index()
        {
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            //Definir formato de datos de solicitud
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Enviando solicitud para encontrar el recurso de servicio REST de la API web Cuentas utilizando HttpClient
            HttpResponseMessage Res = await client.GetAsync("api/Cuentas/ListadoCuentas");

            //La verificación de la respuesta es exitosa o no, la cual se envía usando HttpClient
            if (Res.IsSuccessStatusCode)
            {
                //Almacenando los detalles de respuesta recibidos de la api web
                var CuentaResponse = Res.Content.ReadAsStringAsync().Result;

                //Deserializar la respuesta recibida de la API web y almacenarla en la lista de cuentas
                cuentas = JsonConvert.DeserializeObject<Cuentas>(CuentaResponse);
            }
            return View(cuentas);
        }

        // GET: Clientes
        public async Task<ActionResult> Cuenta()
        {
            Clientes clientes = new Clientes();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            //Definir formato de datos de solicitud
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Enviando solicitud para encontrar el recurso de servicio REST de la API web Cuentas utilizando HttpClient
            HttpResponseMessage Res = await client.GetAsync("api/Clientes/ListadoClientes");

            //La verificación de la respuesta es exitosa o no, la cual se envía usando HttpClient
            if (Res.IsSuccessStatusCode)
            {
                //Almacenando los detalles de respuesta recibidos de la api web
                var ClienteResponse = Res.Content.ReadAsStringAsync().Result;

                //Deserializar la respuesta recibida de la API web y almacenarla en la lista de cuentas
                clientes = JsonConvert.DeserializeObject<Clientes>(ClienteResponse);
            }
            return View(clientes);
        }

        [HttpPost]
        public async Task<ActionResult> CrearCuenta(string numeroCuenta, string nombreCuenta, int idCliente, int tipoMoneda, int idTipoCuenta, int esCuentaTercero)
        {
            Cuentas item = new Cuentas();
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            //Definir formato de datos de solicitud
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Enviando solicitud para encontrar el recurso de servicio REST de la API web Cuentas utilizando HttpClient
            ////string Format = "api/Cuentas/CrearCuenta?numeroCuenta={0}&nombreCuenta={1}&idCliente{2}&tipoMoneda={3}&idTipoCuenta={4}&esCuentaTercero={5}";
            ////"api/Cuentas/CrearCuenta?numeroCuenta={0}&nombreCuenta={1}&idCliente{2}&tipoMoneda={3}&idTipoCuenta={4}&esCuentaTercero={5}", numeroCuenta, nombreCuenta, idCliente, tipoMoneda, idTipoCuenta, esCuentaTercero

            var cuenta = new Cuenta()
            {
                numeroCuenta = numeroCuenta,
                nombreCuenta = nombreCuenta,
                idCliente = idCliente,
                tipoMoneda = tipoMoneda.ToString(),
                idTipoCuenta = idTipoCuenta,
                esCuentaTercero = esCuentaTercero.ToString()
            };

            HttpResponseMessage Res = await client.PostAsJsonAsync("api/Cuentas/CrearCuenta?numeroCuenta={0}&nombreCuenta={1}&idCliente{2}&tipoMoneda={3}&idTipoCuenta={4}&esCuentaTercero={5}", cuenta);

            //La verificación de la respuesta es exitosa o no, la cual se envía usando HttpClient
             if (Res.IsSuccessStatusCode)
            {
                //Almacenando los detalles de respuesta recibidos de la api web
                var CuentaResponse = Res.Content.ReadAsStringAsync().Result;

                //Deserializar la respuesta recibida de la API web y almacenarla en la lista de cuentas
                item = JsonConvert.DeserializeObject<Cuentas>(CuentaResponse);
            }
            return RedirectToAction("../Cuenta/Index");
        }
    }
}
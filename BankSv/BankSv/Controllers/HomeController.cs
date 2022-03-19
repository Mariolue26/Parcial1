using BankSv.Models;
using BankSv.Bussines;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BankSv.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //AREA DE BANCA
        Operaciones op = new Operaciones();

        public IActionResult Index(Acciones acciones)
        {
            int resultado = op.retiro(acciones);
            int saldoTotal = acciones.Saldo;
            ViewBag.VariableAEnviar4 = saldoTotal;

            int Cantidad = acciones.cant;
            ViewBag.VariableAEnviar5 = Cantidad;

            if (acciones.cant == 0)
            {

            }
            else
            {
                if (resultado == 0)
                {
                    string msg1 = "!Tú Transacción fue exitosa!";
                    int Final = acciones.Saldo - acciones.cant;
                    String msg2 = "Su saldo actual es:";
                    ViewBag.VariableAEnviar = msg1;
                    ViewBag.VariableAEnviar2 = msg2;
                    ViewBag.VariableAEnviar3 = Final;
                }
                else
                {
                    string msg = "Ops... Intenta nuevamente.";
                    ViewBag.VariableAEnviar = msg;
                }
            }


            
            return View();
        }
    }
}
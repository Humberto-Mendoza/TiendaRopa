using System;
using System.Web.Mvc;
using TiendaRopaMVC.Web.Filters;

[ValidarSesion]
public class ReportesController : Controller
{
    ReportesBL bl = new ReportesBL();

    public ActionResult VentasPorFecha()
    {
        return View();
    }

    [HttpPost]
    public ActionResult VentasPorFecha(DateTime FechaInicio, DateTime FechaFin)
    {
        var datos = bl.VentasPorFecha(FechaInicio, FechaFin);
        return View(datos);
    }

    public ActionResult ProductosMasVendidos()
    {
        var datos = bl.ProductosMasVendidos();
        return View(datos);
    }
}


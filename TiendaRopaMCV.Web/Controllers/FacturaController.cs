using System.Collections.Generic;
using System.Web.Mvc;
using TiendaRopaMVC.Web.Filters;

[ValidarSesion]
public class FacturasController : Controller
{
    FacturaBL bl = new FacturaBL();

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(int IdCliente, List<int> IdProducto,
        List<int> Cantidad, List<decimal> Precio)
    {
        decimal total = 0;

        for (int i = 0; i < Cantidad.Count; i++)
        {
            total += Cantidad[i] * Precio[i];
        }

        int idUsuario = Convert.ToInt32(Session["IdUsuario"]);
        int idFactura = bl.InsertarFactura(IdCliente, idUsuario, total);

        for (int i = 0; i < Cantidad.Count; i++)
        {
            bl.InsertarDetalle(idFactura, IdProducto[i], Cantidad[i], Precio[i], 0);
        }

        return RedirectToAction("Detalle", new { id = idFactura });
    }

    public ActionResult Detalle(int id)
    {
        ViewBag.IdFactura = id;
        return View();
    }
}


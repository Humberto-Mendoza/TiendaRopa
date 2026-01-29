using System.Web;
using System.Web.Mvc;
using TiendaRopaMVC.Web.Filters;


public class ProductosController : Controller
{
    ProductoBL bl = new ProductoBL();

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(HttpPostedFileBase Imagen,
        string Nombre, decimal Precio, int Stock, decimal Descuento, int IdCategoria)
    {
        string ruta = "";
        if (Imagen != null)
        {
            ruta = "/Uploads/Productos/" + Imagen.FileName;
            Imagen.SaveAs(Server.MapPath(ruta));
        }

        bl.Insertar(Nombre, Precio, Stock, Descuento, ruta, IdCategoria);
        return RedirectToAction("Index");
    }
}



/*PARA PROTEGER LA APLICACION*/
[ValidarSesion]
public class ProductosController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
}


public class FacturasController : Controller
{
    [ValidarSesion]
    public ActionResult Create()
    {
        return View();
    }
}


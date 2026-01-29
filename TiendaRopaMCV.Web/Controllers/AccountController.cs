using System.Data;
using System.Web.Mvc;

public class AccountController : Controller
{
    LoginBL bl = new LoginBL();

    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Login(string usuario, string clave)
    {
        DataTable dt = bl.Validar(usuario, clave);

        if (dt.Rows.Count > 0)
        {
            Session["Usuario"] = dt.Rows[0]["Usuario"].ToString();
            Session["Rol"] = dt.Rows[0]["Rol"].ToString();
            Session["IdUsuario"] = dt.Rows[0]["IdUsuario"].ToString();

            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Usuario o contraseña incorrectos";
        return View();
    }

    public ActionResult Logout()
    {
        Session.Clear();
        return RedirectToAction("Login");
    }
}



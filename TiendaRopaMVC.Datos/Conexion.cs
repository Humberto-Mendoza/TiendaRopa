using System.Data.SqlClient;

public class Conexion
{
    public static SqlConnection Obtener()
    {
        return new SqlConnection(
          "Data Source=.;Initial Catalog=TiendaRopa;Integrated Security=True");
    }
}


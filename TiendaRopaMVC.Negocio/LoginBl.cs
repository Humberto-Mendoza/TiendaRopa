using System.Data;
using System.Data.SqlClient;

public class LoginBL
{
    public DataTable Validar(string usuario, string clave)
    {
        SqlCommand cmd = new SqlCommand("sp_Login", Conexion.Obtener());
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Usuario", usuario);
        cmd.Parameters.AddWithValue("@Clave", clave);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;
    }
}



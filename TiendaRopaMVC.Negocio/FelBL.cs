using System.Data.SqlClient;

public class FelBL
{
    public void Registrar(int idFactura, string uuid,
        string serie, string numero, string estado, string xml)
    {
        SqlCommand cmd = new SqlCommand("sp_RegistrarFEL", Conexion.Obtener());
        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@IdFactura", idFactura);
        cmd.Parameters.AddWithValue("@UUID", uuid);
        cmd.Parameters.AddWithValue("@Serie", serie);
        cmd.Parameters.AddWithValue("@Numero", numero);
        cmd.Parameters.AddWithValue("@Estado", estado);
        cmd.Parameters.AddWithValue("@XML", xml);

        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }
}



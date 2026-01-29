using System.Data;
using System.Data.SqlClient;

public class ProductoBL
{
    public void Insertar(string nombre, decimal precio, int stock,
        decimal descuento, string imagen, int categoria)
    {
        SqlCommand cmd = new SqlCommand("sp_InsertarProducto", Conexion.Obtener());
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Nombre", nombre);
        cmd.Parameters.AddWithValue("@Precio", precio);
        cmd.Parameters.AddWithValue("@Stock", stock);
        cmd.Parameters.AddWithValue("@Descuento", descuento);
        cmd.Parameters.AddWithValue("@Imagen", imagen);
        cmd.Parameters.AddWithValue("@IdCategoria", categoria);

        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }
}




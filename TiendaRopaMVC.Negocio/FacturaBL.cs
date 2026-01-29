using System.Data;
using System.Data.SqlClient;

public class FacturaBL
{
    public int InsertarFactura(int idCliente, int idUsuario, decimal total)
    {
        SqlCommand cmd = new SqlCommand("sp_InsertarFactura", Conexion.Obtener());
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@IdCliente", idCliente);
        cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
        cmd.Parameters.AddWithValue("@Total", total);

        cmd.Connection.Open();
        int idFactura = Convert.ToInt32(cmd.ExecuteScalar());
        cmd.Connection.Close();

        return idFactura;
    }

    public void InsertarDetalle(int idFactura, int idProducto, int cantidad,
        decimal precio, decimal descuento)
    {
        SqlCommand cmd = new SqlCommand("sp_InsertarDetalleFactura", Conexion.Obtener());
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@IdFactura", idFactura);
        cmd.Parameters.AddWithValue("@IdProducto", idProducto);
        cmd.Parameters.AddWithValue("@Cantidad", cantidad);
        cmd.Parameters.AddWithValue("@Precio", precio);
        cmd.Parameters.AddWithValue("@Descuento", descuento);

        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }
}


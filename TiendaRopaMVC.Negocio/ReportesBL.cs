using System.Data;
using System.Data.SqlClient;

public class ReportesBL
{
    public DataTable VentasPorFecha(DateTime inicio, DateTime fin)
    {
        SqlCommand cmd = new SqlCommand("sp_VentasPorFecha", Conexion.Obtener());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FechaInicio", inicio);
        cmd.Parameters.AddWithValue("@FechaFin", fin);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;
    }

    public DataTable VentasPorCliente(int idCliente)
    {
        SqlCommand cmd = new SqlCommand("sp_VentasPorCliente", Conexion.Obtener());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IdCliente", idCliente);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;
    }

    public DataTable ProductosMasVendidos()
    {
        SqlCommand cmd = new SqlCommand("sp_ProductosMasVendidos", Conexion.Obtener());
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        return dt;
    }
}



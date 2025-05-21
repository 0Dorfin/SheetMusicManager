using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SheetMusicManager
{
    public static class Session
    {
        public static int UsuarioId { get; set; }
        public static string NombreUsuario { get; set; }
        public static bool Admin { get; set; }

        public static void CargarUsuario(int id)
        {
            string connStr = "Server=DORFIN\\SQLEXPRESS;Database=PartiturasDB;Trusted_Connection=True;";
            using var conn = new SqlConnection(connStr);
            conn.Open();

            var cmd = new SqlCommand("SELECT NombreUsuario, Admin FROM Usuarios WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                NombreUsuario = reader.GetString(0);
                Admin = reader.GetBoolean(1);
            }

            UsuarioId = id;
        }
    }
}
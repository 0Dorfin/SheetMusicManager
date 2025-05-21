using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheetMusicManager
{
    public static class DatabaseConnection
    {
        private static readonly string server = "XXXXXX";
        private static readonly string database = "PartiturasDB";

        public static string ConnectionString =>
            $"Server={server};Database={database};Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
    }
}

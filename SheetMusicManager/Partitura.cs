using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheetMusicManager
{
    public class Partitura
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Compositor { get; set; }
        public string Epoca { get; set; }
        public string Agrupacion { get; set; }
        public string Instrumentos { get; set; }
        public decimal Precio { get; set; }
        public bool Licencia { get; set; }
        public byte[] ArchivoPDF { get; set; }
    }

}

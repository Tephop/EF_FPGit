using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Forms
{
    public class InventarioVista
    {
        public string ID_Producto { get; set; }
        public string NombreProducto { get; set; }
        public string Proveedor { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Stock { get; set; }
        public string Estado { get; set; }
    }
}

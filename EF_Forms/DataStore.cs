using System.Collections.Generic;

namespace EF_Forms
{
    public static class DataStore
    {
        public static List<Producto> Productos = new List<Producto>();
        public static List<Venta> Ventas = new List<Venta>();
        public static List<DetalleVenta> DetalleVentas = new List<DetalleVenta>();
        public static List<Proveedor> Proveedores = new List<Proveedor>();
    }
}

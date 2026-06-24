using System;
using System.Globalization;
using System.IO;

namespace EF_Forms
{
    public static class ArchivoHelper
    {
        private static string carpeta = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            "MiSistemaTienda"
        );

        private static string ruta = Path.Combine(carpeta, "productos.txt");
        private static string rutaVentas = Path.Combine(carpeta, "ventas.txt");
        private static string rutaDetalleVentas = Path.Combine(carpeta, "detalle_ventas.txt");
        private static string rutaProveedores = Path.Combine(carpeta, "proveedores.txt");

        public static void GuardarProductos()
        {
            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);

            using (StreamWriter sw = new StreamWriter(ruta))
            {
                foreach (Producto p in DataStore.Productos)
                {
                    sw.WriteLine(
                        p.ID_Producto + "|" +
                        p.ID_Proveedor + "|" +
                        p.NombreProducto + "|" +
                        p.PrecioUnitario + "|" +
                        p.Stock
                    );
                }
            }
        }
        public static void CargarProductos()
        {
            if (!File.Exists(ruta))
                return;

            DataStore.Productos.Clear();

            foreach (string linea in File.ReadAllLines(ruta))
            {
                if (string.IsNullOrWhiteSpace(linea))
                    continue;

                string[] datos = linea.Split('|');

                DataStore.Productos.Add(new Producto
                {
                    ID_Producto = datos[0],
                    ID_Proveedor = datos[1],
                    NombreProducto = datos[2],
                    PrecioUnitario = decimal.Parse(datos[3]),
                    Stock = int.Parse(datos[4])
                });
            }
        }
        public static void GuardarVentas()
        {
            using (StreamWriter sw = new StreamWriter(rutaVentas))
            {
                foreach (Venta v in DataStore.Ventas)
                {
                    sw.WriteLine($"{v.ID_Venta}|{v.Fecha}|{v.MetodoPago}|{v.Total}");
                }
            }
        }
        public static void GuardarDetalleVentas()
        {
            using (StreamWriter sw = new StreamWriter(rutaDetalleVentas))
            {
                foreach (DetalleVenta d in DataStore.DetalleVentas)
                {
                    sw.WriteLine($"{d.ID_Venta}|{d.ID_Producto}|{d.NombreProducto}|{d.PrecioUnitario}|{d.Cantidad}|{d.Subtotal}");
                }
            }
        }
        public static void CargarVentas()
        {
            if (!File.Exists(rutaVentas))
                return;

            DataStore.Ventas.Clear();

            foreach (string linea in File.ReadAllLines(rutaVentas))
            {
                string[] datos = linea.Split('|');

                DataStore.Ventas.Add(new Venta
                {
                    ID_Venta = datos[0],
                    Fecha = DateTime.Parse(datos[1]),
                    MetodoPago = datos[2],
                    Total = decimal.Parse(datos[3])
                });
            }
        }
        public static void CargarDetalleVentas()
        {
            if (!File.Exists(rutaDetalleVentas))
                return;

            DataStore.DetalleVentas.Clear();

            foreach (string linea in File.ReadAllLines(rutaDetalleVentas))
            {
                string[] datos = linea.Split('|');

                DataStore.DetalleVentas.Add(new DetalleVenta
                {
                    ID_Venta = datos[0],
                    ID_Producto = datos[1],
                    NombreProducto = datos[2],
                    PrecioUnitario = decimal.Parse(datos[3]),
                    Cantidad = int.Parse(datos[4]),
                    Subtotal = decimal.Parse(datos[5])
                });
            }
        }
        public static void GuardarProveedores()
        {
            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);

            using (StreamWriter sw = new StreamWriter(rutaProveedores))
            {
                foreach (Proveedor p in DataStore.Proveedores)
                {
                    sw.WriteLine(
                        p.ID_Proveedor + "|" +
                        p.NombreProveedor + "|" +
                        p.Telefono + "|" +
                        p.Email + "|" +
                        p.Direccion
                    );
                }
            }
        }
        public static void CargarProveedores()
        {
           if (!File.Exists(rutaProveedores))
           return;

           DataStore.Proveedores.Clear();

           using (StreamReader sr = new StreamReader(rutaProveedores))
           {   
              while (!sr.EndOfStream)
              {
                 string linea = sr.ReadLine();

                 if (string.IsNullOrWhiteSpace(linea))
                   continue;

                 string[] datos = linea.Split('|');

                if (datos.Length < 5)
                   continue;

                Proveedor p = new Proveedor
                {
                    ID_Proveedor = datos[0],
                    NombreProveedor = datos[1],
                    Telefono = datos[2],
                    Email = datos[3],
                    Direccion = datos[4]
                };

               DataStore.Proveedores.Add(p);
              }
           }
        }
    }
}
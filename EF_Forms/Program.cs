using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_Forms
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ArchivoHelper.CargarProductos();
            ArchivoHelper.CargarVentas();
            ArchivoHelper.CargarDetalleVentas();
            ArchivoHelper.CargarProveedores();

            Application.Run(new FormPrincipal());
        }
    }
}

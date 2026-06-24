using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EF_Forms
{
    public partial class FormVentas : Form
    {
        private decimal totalVenta = 0;
        public FormVentas()
        {
            InitializeComponent();

            CargarProductos();

            cmbMetodoPago.Items.Add("Efectivo");
            cmbMetodoPago.Items.Add("Yape");
            cmbMetodoPago.Items.Add("Plin");

            cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoPago.SelectedIndex = -1;


            lblTotal.Text = "TOTAL: S/ 0.00";
        }
        private string GenerarIdVenta()
        {
            int max = 0;

            string ruta = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "MiSistemaTienda",
                "ventas.txt"
            );

            if (File.Exists(ruta))
            {
                foreach (string linea in File.ReadAllLines(ruta))
                {
                    string[] datos = linea.Split('|');
                    string id = datos[0];

                    if (id.StartsWith("V"))
                    {
                        int num = int.Parse(id.Substring(1));
                        if (num > max)
                            max = num;
                    }
                }
            }

            return "V" + (max + 1).ToString("D3");
        }
        private void CargarProductos()
        {
            cmbProductos.Items.Clear();

            foreach (Producto p in DataStore.Productos)
            {
                cmbProductos.Items.Add(p);
            }

            cmbProductos.DisplayMember = "NombreProducto";
            cmbProductos.ValueMember = "ID_Producto";
        }
        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            Producto producto = cmbProductos.SelectedItem as Producto;

            if (producto == null)
            {
                MessageBox.Show("Seleccione un producto válido.");
                return;
            }

            int cantidadNueva = (int)nudCantidad.Value;

            if (cantidadNueva <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.");
                return;
            }

            DataGridViewRow filaExistente = null;

            foreach (DataGridViewRow fila in dgvCarrito.Rows)
            {
                if (fila.IsNewRow) continue;

                if (fila.Cells[0].Value.ToString() == producto.ID_Producto)
                {
                    filaExistente = fila;
                    break;
                }
            }

            int cantidadTotalEnCarrito = 0;

            if (filaExistente != null)
            {
                cantidadTotalEnCarrito = Convert.ToInt32(filaExistente.Cells[3].Value);
            }

            int cantidadFinal = cantidadTotalEnCarrito + cantidadNueva;

            if (cantidadFinal > producto.Stock)
            {
                MessageBox.Show("Stock insuficiente. Disponible: " + producto.Stock);
                return;
            }

            decimal subtotal = producto.PrecioUnitario * cantidadNueva;

            if (filaExistente != null)
            {

                filaExistente.Cells[3].Value = cantidadFinal;
                filaExistente.Cells[4].Value = producto.PrecioUnitario * cantidadFinal;
            }
            else
            {
                dgvCarrito.Rows.Add(
                    producto.ID_Producto,
                    producto.NombreProducto,
                    producto.PrecioUnitario,
                    cantidadNueva,
                    subtotal,
                    producto.Estado
                );
            }

            totalVenta = 0;

            foreach (DataGridViewRow fila in dgvCarrito.Rows)
            {
                if (fila.IsNewRow) continue;

                totalVenta += Convert.ToDecimal(fila.Cells[4].Value);
            }

            lblTotal.Text = "TOTAL: S/ " + totalVenta.ToString("0.00");
        }

        private void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            bool hayProductos = dgvCarrito.Rows.Cast<DataGridViewRow>().Any(r => !r.IsNewRow);

            if (!hayProductos)
            {
                MessageBox.Show("No hay productos en el carrito.");
                return;
            }

            string idVenta = GenerarIdVenta();
            decimal total = 0;

            foreach (DataGridViewRow fila in dgvCarrito.Rows)
            {
                if (fila.IsNewRow) continue;

                string idProducto = fila.Cells[0].Value.ToString();
                string nombre = fila.Cells[1].Value.ToString();
                decimal precio = Convert.ToDecimal(fila.Cells[2].Value);
                int cantidad = Convert.ToInt32(fila.Cells[3].Value);
                decimal subtotal = Convert.ToDecimal(fila.Cells[4].Value);

                total += subtotal;

                DataStore.DetalleVentas.Add(new DetalleVenta
                {
                    ID_Venta = idVenta,
                    ID_Producto = idProducto,
                    NombreProducto = nombre,
                    PrecioUnitario = precio,
                    Cantidad = cantidad,
                    Subtotal = subtotal
                });

                Producto p = DataStore.Productos.First(x => x.ID_Producto == idProducto);
                p.Stock -= cantidad;
            }

            DataStore.Ventas.Add(new Venta
            {
                ID_Venta = idVenta,
                Fecha = DateTime.Now,
                MetodoPago = cmbMetodoPago.Text,
                Total = total
            });

            ArchivoHelper.GuardarProductos();
            ArchivoHelper.GuardarVentas();
            ArchivoHelper.GuardarDetalleVentas();

            dgvCarrito.Rows.Clear();
            totalVenta = 0;
            lblTotal.Text = "TOTAL: S/ 0.00";
            cmbMetodoPago.SelectedIndex = -1;

            MessageBox.Show("VENTA REGISTRADA: " + idVenta);
        }

        private void btnEliminarCarrito_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.CurrentRow == null || dgvCarrito.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Seleccione un producto del carrito.");
                return;
            }

            DialogResult r = MessageBox.Show("¿Eliminar producto del carrito?","Confirmar",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (r != DialogResult.Yes)
                return;

            decimal subtotal = Convert.ToDecimal(dgvCarrito.CurrentRow.Cells[4].Value);

            totalVenta -= subtotal;

            if (totalVenta < 0) totalVenta = 0;

            dgvCarrito.Rows.RemoveAt(dgvCarrito.CurrentRow.Index);

            lblTotal.Text = "TOTAL: S/ " + totalVenta.ToString("0.00");
        }
    }
}

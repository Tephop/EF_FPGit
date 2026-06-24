using System;
using System.Linq;
using System.Windows.Forms;

namespace EF_Forms
{
    public partial class FormProducto : Form
    {
        private string idProductoSeleccionado = "";
        public FormProducto()
        {
            InitializeComponent();

            nudPrecio.DecimalPlaces = 2;
            nudPrecio.Increment = 0.10M;
            nudPrecio.Maximum = 1000000;

            CargarProveedores();

            ActualizarGrid();
        }

        private string GenerarId()
        {
            int max = 0;

            foreach (var p in DataStore.Productos)
            {
                int num = int.Parse(p.ID_Producto.Substring(1));
                if (num > max)
                    max = num;
            }

            return "P" + (max + 1).ToString("D3");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Complete el nombre.");
                return;
            }

            if (cmbProveedor.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un proveedor.");
                return;
            }

            Producto nuevo = new Producto();

            Proveedor proveedor = DataStore.Proveedores[cmbProveedor.SelectedIndex];

            nuevo.ID_Producto = GenerarId();
            nuevo.ID_Proveedor = proveedor.ID_Proveedor;
            nuevo.NombreProducto = txtNombre.Text.Trim();
            nuevo.PrecioUnitario = nudPrecio.Value;
            nuevo.Stock = (int)nudStock.Value;

            DataStore.Productos.Add(nuevo);

            ActualizarGrid();

            ArchivoHelper.GuardarProductos();

            txtNombre.Clear();

            nudPrecio.Value = 0;
            nudStock.Value = 0;

            cmbProveedor.SelectedIndex = -1;

            MessageBox.Show("Producto registrado correctamente.");
        }
        private void ActualizarGrid()
        {
            dgvProductos.Rows.Clear();

            foreach (Producto p in DataStore.Productos)
            {
                Proveedor proveedor = DataStore.Proveedores.FirstOrDefault(x => x.ID_Proveedor == p.ID_Proveedor);

                string nombreProveedor = "";

                if (proveedor != null)
                    nombreProveedor = proveedor.NombreProveedor;

                dgvProductos.Rows.Add(
                    p.ID_Producto,
                    p.NombreProducto,
                    nombreProveedor,
                    p.PrecioUnitario,
                    p.Stock
                );
            }
        }
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || dgvProductos.Rows[e.RowIndex].IsNewRow)
                return;

            DataGridViewRow row = dgvProductos.Rows[e.RowIndex];

            if (row.Cells[0].Value == null)
                return;

            idProductoSeleccionado = row.Cells[0].Value.ToString();

            txtNombre.Text = row.Cells[1].Value?.ToString() ?? "";

            string nombreProveedor = row.Cells[2].Value?.ToString();

            cmbProveedor.SelectedIndex = DataStore.Proveedores
                .FindIndex(p => p.NombreProveedor == nombreProveedor);

            if (!decimal.TryParse(row.Cells[3].Value?.ToString(), out decimal precio))
                precio = 0;

            if (!int.TryParse(row.Cells[4].Value?.ToString(), out int stock))
                stock = 0;

            nudPrecio.Value = precio;
            nudStock.Value = stock;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(idProductoSeleccionado))
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            Producto producto = DataStore.Productos
                .FirstOrDefault(p => p.ID_Producto == idProductoSeleccionado);

            if (producto == null)
            {
                MessageBox.Show("Producto no encontrado.");
                return;
            }

            if (cmbProveedor.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un proveedor.");
                return;
            }

            Proveedor proveedor = DataStore.Proveedores[cmbProveedor.SelectedIndex];

            producto.ID_Proveedor = proveedor.ID_Proveedor;
            producto.NombreProducto = txtNombre.Text;
            producto.PrecioUnitario = nudPrecio.Value;
            producto.Stock = (int)nudStock.Value;

            ActualizarGrid();
            ArchivoHelper.GuardarProductos();

            MessageBox.Show("Producto modificado correctamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idProductoSeleccionado))
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            Producto producto = DataStore.Productos
                .FirstOrDefault(p => p.ID_Producto == idProductoSeleccionado);

            if (producto == null)
            {
                MessageBox.Show("Producto no encontrado.");
                return;
            }

            DialogResult r = MessageBox.Show(
                "¿Desea eliminar este producto?",
                "Confirmación",
                MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                DataStore.Productos.Remove(producto);

                ActualizarGrid();
                ArchivoHelper.GuardarProductos();

                txtNombre.Clear();
                nudPrecio.Value = 0;
                nudStock.Value = 0;

                idProductoSeleccionado = "";

                MessageBox.Show("Producto eliminado correctamente.");
            }
        }

        private void lblProveedor_Click(object sender, EventArgs e)
        {

        }
        private void CargarProveedores()
        {
            cmbProveedor.Items.Clear();

            foreach (Proveedor p in DataStore.Proveedores)
            {
                cmbProveedor.Items.Add(p.NombreProveedor);
            }
        }
    }
}

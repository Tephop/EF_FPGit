using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EF_Forms
{
    public partial class FormInventario : Form
    {
        public FormInventario()
        {
            InitializeComponent();
            ActualizarGrid();
        }
        private void FormInventario_Load(object sender, EventArgs e)
        {
            Mostrar(DataStore.Productos);
        }
        private void ActualizarGrid()
        {
            Mostrar(DataStore.Productos);
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarGrid();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvInventario.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            InventarioVista item = (InventarioVista)dgvInventario.CurrentRow.DataBoundItem;

            Producto producto = DataStore.Productos.FirstOrDefault(p => p.ID_Producto == item.ID_Producto);

            if (producto == null)
            {
                MessageBox.Show("No se encontró el producto.");
                return;
            }

            DialogResult r = MessageBox.Show("¿Seguro que desea eliminar este producto?", "Confirmar",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                DataStore.Productos.Remove(producto);

                ArchivoHelper.GuardarProductos();

                ActualizarGrid();
            }
        }
        private void Mostrar(List<Producto> lista)
        {
            List<InventarioVista> inventario = new List<InventarioVista>();

            foreach (Producto p in lista)
            {
                Proveedor proveedor = DataStore.Proveedores
                    .FirstOrDefault(x => x.ID_Proveedor == p.ID_Proveedor);

                InventarioVista item = new InventarioVista();

                item.ID_Producto = p.ID_Producto;
                item.NombreProducto = p.NombreProducto;
                item.Proveedor = proveedor != null ? proveedor.NombreProveedor : "";
                item.PrecioUnitario = p.PrecioUnitario;
                item.Stock = p.Stock;
                item.Estado = p.Estado;

                inventario.Add(item);
            }

            dgvInventario.DataSource = null;
            dgvInventario.DataSource = inventario;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim().ToLower();

            List<Producto> resultado = DataStore.Productos
                .Where(p =>
                    !string.IsNullOrEmpty(p.NombreProducto) &&
                    p.NombreProducto.ToLower().Contains(texto)
                )
                .ToList();

            Mostrar(resultado);
        }

        private void btnMostyrarTodo_Click(object sender, EventArgs e)
        {
            Mostrar(DataStore.Productos);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvInventario.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            InventarioVista item =(InventarioVista)dgvInventario.CurrentRow.DataBoundItem;

            Producto producto = DataStore.Productos
                .FirstOrDefault(p => p.ID_Producto == item.ID_Producto);

            if (producto == null)
            {
                MessageBox.Show("No se encontró el producto.");
                return;
            }

            string nuevoNombre = Interaction.InputBox(
                "Nuevo nombre:",
                "Modificar",
                producto.NombreProducto);

            string precioStr = Interaction.InputBox(
                "Nuevo precio:",
                "Modificar",
                producto.PrecioUnitario.ToString());

            string stockStr = Interaction.InputBox(
                "Nuevo stock:",
                "Modificar",
                producto.Stock.ToString());

            if (!string.IsNullOrWhiteSpace(nuevoNombre))
                producto.NombreProducto = nuevoNombre;

            if (decimal.TryParse(precioStr, out decimal nuevoPrecio))
                producto.PrecioUnitario = nuevoPrecio;

            if (int.TryParse(stockStr, out int nuevoStock))
                producto.Stock = nuevoStock;

            ArchivoHelper.GuardarProductos();
            ActualizarGrid();
        }
    }
}

using System;
using System.Linq;
using System.Windows.Forms;

namespace EF_Forms
{
    public partial class FormProveedor : Form
    {
        private Proveedor proveedorSeleccionado = null;
        public FormProveedor()
        {
            InitializeComponent();

            dgvProveedores.AutoGenerateColumns = true;

            ActualizarGrid();
        }
        private void FormProveedor_Load(object sender, EventArgs e)
        {
            ActualizarGrid();
        }
        private string GenerarIdProveedor()
        {
            int max = 0;

            foreach (Proveedor p in DataStore.Proveedores)
            {
                int numero = int.Parse(p.ID_Proveedor.Substring(2));

                if (numero > max)
                    max = numero;
            }

            return "PR" + (max + 1).ToString("D3");
        }
        private void ActualizarGrid()
        {
            dgvProveedores.DataSource = null;
            dgvProveedores.DataSource = DataStore.Proveedores;
        }
        private void LimpiarCampos()
        {
            foreach (TextBox txt in Controls.OfType<TextBox>())
                txt.Clear();

            lblIdProveedor.Text = GenerarIdProveedor();
            proveedorSeleccionado = null;
        }
        private bool EmailValido(string email)
        {
            try
            {
                var direccion = new System.Net.Mail.MailAddress(email);

                return direccion.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreProveedor.Text))
            {
                MessageBox.Show("Ingrese el nombre del proveedor.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefonoProveedor.Text))
            {
                MessageBox.Show("Ingrese el teléfono.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmailProveedor.Text))
            {
                MessageBox.Show("Ingrese el email.");
                return;
            }

            if (!EmailValido(txtEmailProveedor.Text))
            {
                MessageBox.Show("Ingrese un email válido.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDireccionProveedor.Text))
            {
                MessageBox.Show("Ingrese la dirección.");
                return;
            }

            bool existe = DataStore.Proveedores.Any(p =>
                p.NombreProveedor.Equals(
                    txtNombreProveedor.Text.Trim(),
                    StringComparison.OrdinalIgnoreCase));

            if (existe)
            {
                MessageBox.Show("Ya existe un proveedor con ese nombre.");
                return;
            }

            Proveedor nuevo = new Proveedor();

            nuevo.ID_Proveedor = GenerarIdProveedor();
            nuevo.NombreProveedor = txtNombreProveedor.Text.Trim();
            nuevo.Telefono = txtTelefonoProveedor.Text.Trim();
            nuevo.Email = txtEmailProveedor.Text.Trim();
            nuevo.Direccion = txtDireccionProveedor.Text.Trim();

            DataStore.Proveedores.Add(nuevo);

            ArchivoHelper.GuardarProveedores();

            ActualizarGrid();

            LimpiarCampos();

            MessageBox.Show("Proveedor registrado correctamente.");
        }
        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvProveedores.Rows[e.RowIndex].IsNewRow)
                return;

            DataGridViewRow row = dgvProveedores.Rows[e .RowIndex];

            if (row.Cells[0].Value == null)
                return;

            string idProveedor = row.Cells[0].Value.ToString();

            proveedorSeleccionado = DataStore.Proveedores
                .FirstOrDefault(p => p.ID_Proveedor == idProveedor);

            if (proveedorSeleccionado == null)
                return;

            lblIdProveedor.Text = proveedorSeleccionado.ID_Proveedor;
            txtNombreProveedor.Text = proveedorSeleccionado.NombreProveedor;
            txtTelefonoProveedor.Text = proveedorSeleccionado.Telefono;
            txtEmailProveedor.Text = proveedorSeleccionado.Email;
            txtDireccionProveedor.Text = proveedorSeleccionado.Direccion;
        }
        private void btnModificarProveedor_Click(object sender, EventArgs e)
        {
            if (proveedorSeleccionado == null)
            {
                MessageBox.Show("Seleccione un proveedor.");
                return;
            }

            bool repetido = DataStore.Proveedores.Any(p =>
                p.NombreProveedor.Equals(
                    txtNombreProveedor.Text.Trim(),
                    StringComparison.OrdinalIgnoreCase)
                &&
                p.ID_Proveedor != lblIdProveedor.Text);

            if (repetido)
            {
                MessageBox.Show("Ya existe otro proveedor con ese nombre.");
                return;
            }

            if (!EmailValido(txtEmailProveedor.Text))
            {
                MessageBox.Show("Ingrese un email válido.");
                return;
            }

            Proveedor proveedor = proveedorSeleccionado;

            proveedor.NombreProveedor = txtNombreProveedor.Text.Trim();
            proveedor.Telefono = txtTelefonoProveedor.Text.Trim();
            proveedor.Email = txtEmailProveedor.Text.Trim();
            proveedor.Direccion = txtDireccionProveedor.Text.Trim();

            ArchivoHelper.GuardarProveedores();

            ActualizarGrid();

            LimpiarCampos();

            MessageBox.Show("Proveedor modificado correctamente.");
        }
        private void btnEliminarProveedor_Click(object sender, EventArgs e)
        {
            if (proveedorSeleccionado == null)
            {
                MessageBox.Show("Seleccione un proveedor.");
                return;
            }

            bool enUso = DataStore.Productos.Any(p => p.ID_Proveedor == proveedorSeleccionado.ID_Proveedor);

            if (enUso)
            {
                MessageBox.Show("No se puede eliminar este proveedor porque tiene productos asociados.");
                return;
            }

            DialogResult r = MessageBox.Show(
                "¿Desea eliminar este proveedor?",
                "Confirmación",
                MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                DataStore.Proveedores.Remove(proveedorSeleccionado);
                proveedorSeleccionado = null;

                ArchivoHelper.GuardarProveedores();
                ActualizarGrid();

                MessageBox.Show("Proveedor eliminado correctamente.");
            }
        }
        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            string texto = txtBuscarProveedor.Text.Trim().ToUpper();

            dgvProveedores.DataSource = DataStore.Proveedores
                .Where(p => p.NombreProveedor.ToUpper().Contains(texto))
                .ToList();
        }

        private void btnMostrarTodosProveedores_Click(object sender, EventArgs e)
        {
            txtBuscarProveedor.Clear();

            ActualizarGrid();
        }

        private void txtTelefonoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

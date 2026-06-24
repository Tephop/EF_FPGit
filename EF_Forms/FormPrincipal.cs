using System;
using System.Windows.Forms;

namespace EF_Forms
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }
        private void AbrirFormulario(Form formulario)
        {
            panelContenido.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelContenido.Controls.Add(formulario);

            formulario.Show();
        }
        private void panelContenido_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormProducto());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormVentas());
        }
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea salir del sistema?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormInventario());
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormProveedor());
        }
    }
}

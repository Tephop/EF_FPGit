namespace EF_Forms
{
    partial class FormProveedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTituloProveedor = new System.Windows.Forms.Label();
            this.lblNombreProveedor = new System.Windows.Forms.Label();
            this.lblTelefonoProveedor = new System.Windows.Forms.Label();
            this.lblEmailProveedor = new System.Windows.Forms.Label();
            this.lblDireccionProveedor = new System.Windows.Forms.Label();
            this.lblTextoIdProveedor = new System.Windows.Forms.Label();
            this.lblIdProveedor = new System.Windows.Forms.Label();
            this.txtNombreProveedor = new System.Windows.Forms.TextBox();
            this.txtTelefonoProveedor = new System.Windows.Forms.TextBox();
            this.txtEmailProveedor = new System.Windows.Forms.TextBox();
            this.txtDireccionProveedor = new System.Windows.Forms.TextBox();
            this.txtBuscarProveedor = new System.Windows.Forms.TextBox();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.btnAgregarProveedor = new System.Windows.Forms.Button();
            this.btnModificarProveedor = new System.Windows.Forms.Button();
            this.btnEliminarProveedor = new System.Windows.Forms.Button();
            this.btnBuscarProveedor = new System.Windows.Forms.Button();
            this.btnMostrarTodosProveedores = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloProveedor
            // 
            this.lblTituloProveedor.AutoSize = true;
            this.lblTituloProveedor.Font = new System.Drawing.Font("Sylfaen", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloProveedor.Location = new System.Drawing.Point(308, 9);
            this.lblTituloProveedor.Name = "lblTituloProveedor";
            this.lblTituloProveedor.Size = new System.Drawing.Size(171, 27);
            this.lblTituloProveedor.TabIndex = 0;
            this.lblTituloProveedor.Text = "PROVEEDORES";
            // 
            // lblNombreProveedor
            // 
            this.lblNombreProveedor.AutoSize = true;
            this.lblNombreProveedor.Font = new System.Drawing.Font("Sylfaen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreProveedor.Location = new System.Drawing.Point(120, 115);
            this.lblNombreProveedor.Name = "lblNombreProveedor";
            this.lblNombreProveedor.Size = new System.Drawing.Size(63, 19);
            this.lblNombreProveedor.TabIndex = 1;
            this.lblNombreProveedor.Text = "Nombre:";
            // 
            // lblTelefonoProveedor
            // 
            this.lblTelefonoProveedor.AutoSize = true;
            this.lblTelefonoProveedor.Font = new System.Drawing.Font("Sylfaen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefonoProveedor.Location = new System.Drawing.Point(120, 166);
            this.lblTelefonoProveedor.Name = "lblTelefonoProveedor";
            this.lblTelefonoProveedor.Size = new System.Drawing.Size(71, 19);
            this.lblTelefonoProveedor.TabIndex = 2;
            this.lblTelefonoProveedor.Text = "Teléfono: ";
            // 
            // lblEmailProveedor
            // 
            this.lblEmailProveedor.AutoSize = true;
            this.lblEmailProveedor.Font = new System.Drawing.Font("Sylfaen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailProveedor.Location = new System.Drawing.Point(120, 219);
            this.lblEmailProveedor.Name = "lblEmailProveedor";
            this.lblEmailProveedor.Size = new System.Drawing.Size(46, 19);
            this.lblEmailProveedor.TabIndex = 3;
            this.lblEmailProveedor.Text = "Email:";
            // 
            // lblDireccionProveedor
            // 
            this.lblDireccionProveedor.AutoSize = true;
            this.lblDireccionProveedor.Font = new System.Drawing.Font("Sylfaen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccionProveedor.Location = new System.Drawing.Point(120, 276);
            this.lblDireccionProveedor.Name = "lblDireccionProveedor";
            this.lblDireccionProveedor.Size = new System.Drawing.Size(71, 19);
            this.lblDireccionProveedor.TabIndex = 4;
            this.lblDireccionProveedor.Text = "Dirección:";
            // 
            // lblTextoIdProveedor
            // 
            this.lblTextoIdProveedor.AutoSize = true;
            this.lblTextoIdProveedor.Font = new System.Drawing.Font("Sylfaen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoIdProveedor.Location = new System.Drawing.Point(120, 67);
            this.lblTextoIdProveedor.Name = "lblTextoIdProveedor";
            this.lblTextoIdProveedor.Size = new System.Drawing.Size(98, 19);
            this.lblTextoIdProveedor.TabIndex = 5;
            this.lblTextoIdProveedor.Text = "ID Proveedor:";
            // 
            // lblIdProveedor
            // 
            this.lblIdProveedor.AutoSize = true;
            this.lblIdProveedor.Font = new System.Drawing.Font("Sylfaen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdProveedor.Location = new System.Drawing.Point(274, 67);
            this.lblIdProveedor.Name = "lblIdProveedor";
            this.lblIdProveedor.Size = new System.Drawing.Size(52, 19);
            this.lblIdProveedor.TabIndex = 6;
            this.lblIdProveedor.Text = "PR001";
            // 
            // txtNombreProveedor
            // 
            this.txtNombreProveedor.Font = new System.Drawing.Font("Sylfaen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreProveedor.Location = new System.Drawing.Point(278, 107);
            this.txtNombreProveedor.Name = "txtNombreProveedor";
            this.txtNombreProveedor.Size = new System.Drawing.Size(397, 27);
            this.txtNombreProveedor.TabIndex = 7;
            // 
            // txtTelefonoProveedor
            // 
            this.txtTelefonoProveedor.Font = new System.Drawing.Font("Sylfaen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefonoProveedor.Location = new System.Drawing.Point(278, 158);
            this.txtTelefonoProveedor.Name = "txtTelefonoProveedor";
            this.txtTelefonoProveedor.Size = new System.Drawing.Size(397, 27);
            this.txtTelefonoProveedor.TabIndex = 8;
            this.txtTelefonoProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefonoProveedor_KeyPress);
            // 
            // txtEmailProveedor
            // 
            this.txtEmailProveedor.Font = new System.Drawing.Font("Sylfaen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailProveedor.Location = new System.Drawing.Point(278, 219);
            this.txtEmailProveedor.Name = "txtEmailProveedor";
            this.txtEmailProveedor.Size = new System.Drawing.Size(397, 27);
            this.txtEmailProveedor.TabIndex = 9;
            // 
            // txtDireccionProveedor
            // 
            this.txtDireccionProveedor.Font = new System.Drawing.Font("Sylfaen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccionProveedor.Location = new System.Drawing.Point(278, 273);
            this.txtDireccionProveedor.Name = "txtDireccionProveedor";
            this.txtDireccionProveedor.Size = new System.Drawing.Size(397, 27);
            this.txtDireccionProveedor.TabIndex = 10;
            // 
            // txtBuscarProveedor
            // 
            this.txtBuscarProveedor.Font = new System.Drawing.Font("Sylfaen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarProveedor.Location = new System.Drawing.Point(147, 345);
            this.txtBuscarProveedor.Name = "txtBuscarProveedor";
            this.txtBuscarProveedor.Size = new System.Drawing.Size(260, 27);
            this.txtBuscarProveedor.TabIndex = 11;
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.AllowUserToAddRows = false;
            this.dgvProveedores.AllowUserToDeleteRows = false;
            this.dgvProveedores.AllowUserToResizeColumns = false;
            this.dgvProveedores.AllowUserToResizeRows = false;
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Location = new System.Drawing.Point(161, 396);
            this.dgvProveedores.MultiSelect = false;
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.ReadOnly = true;
            this.dgvProveedores.RowHeadersVisible = false;
            this.dgvProveedores.Size = new System.Drawing.Size(500, 150);
            this.dgvProveedores.TabIndex = 12;
            this.dgvProveedores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProveedores_CellContentClick);
            // 
            // btnAgregarProveedor
            // 
            this.btnAgregarProveedor.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProveedor.Location = new System.Drawing.Point(351, 574);
            this.btnAgregarProveedor.Name = "btnAgregarProveedor";
            this.btnAgregarProveedor.Size = new System.Drawing.Size(104, 38);
            this.btnAgregarProveedor.TabIndex = 13;
            this.btnAgregarProveedor.Text = "Agregar";
            this.btnAgregarProveedor.UseVisualStyleBackColor = true;
            this.btnAgregarProveedor.Click += new System.EventHandler(this.btnAgregarProveedor_Click);
            // 
            // btnModificarProveedor
            // 
            this.btnModificarProveedor.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarProveedor.Location = new System.Drawing.Point(179, 574);
            this.btnModificarProveedor.Name = "btnModificarProveedor";
            this.btnModificarProveedor.Size = new System.Drawing.Size(104, 38);
            this.btnModificarProveedor.TabIndex = 14;
            this.btnModificarProveedor.Text = "Modificar";
            this.btnModificarProveedor.UseVisualStyleBackColor = true;
            this.btnModificarProveedor.Click += new System.EventHandler(this.btnModificarProveedor_Click);
            // 
            // btnEliminarProveedor
            // 
            this.btnEliminarProveedor.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarProveedor.Location = new System.Drawing.Point(522, 574);
            this.btnEliminarProveedor.Name = "btnEliminarProveedor";
            this.btnEliminarProveedor.Size = new System.Drawing.Size(104, 38);
            this.btnEliminarProveedor.TabIndex = 15;
            this.btnEliminarProveedor.Text = "Eliminar";
            this.btnEliminarProveedor.UseVisualStyleBackColor = true;
            this.btnEliminarProveedor.Click += new System.EventHandler(this.btnEliminarProveedor_Click);
            // 
            // btnBuscarProveedor
            // 
            this.btnBuscarProveedor.Font = new System.Drawing.Font("Sylfaen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarProveedor.Location = new System.Drawing.Point(439, 345);
            this.btnBuscarProveedor.Name = "btnBuscarProveedor";
            this.btnBuscarProveedor.Size = new System.Drawing.Size(104, 27);
            this.btnBuscarProveedor.TabIndex = 16;
            this.btnBuscarProveedor.Text = "Buscar";
            this.btnBuscarProveedor.UseVisualStyleBackColor = true;
            this.btnBuscarProveedor.Click += new System.EventHandler(this.btnBuscarProveedor_Click);
            // 
            // btnMostrarTodosProveedores
            // 
            this.btnMostrarTodosProveedores.Font = new System.Drawing.Font("Sylfaen", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarTodosProveedores.Location = new System.Drawing.Point(610, 345);
            this.btnMostrarTodosProveedores.Name = "btnMostrarTodosProveedores";
            this.btnMostrarTodosProveedores.Size = new System.Drawing.Size(104, 27);
            this.btnMostrarTodosProveedores.TabIndex = 17;
            this.btnMostrarTodosProveedores.Text = "Mostrar todo";
            this.btnMostrarTodosProveedores.UseVisualStyleBackColor = true;
            this.btnMostrarTodosProveedores.Click += new System.EventHandler(this.btnMostrarTodosProveedores_Click);
            // 
            // FormProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 687);
            this.Controls.Add(this.btnMostrarTodosProveedores);
            this.Controls.Add(this.btnBuscarProveedor);
            this.Controls.Add(this.btnEliminarProveedor);
            this.Controls.Add(this.btnModificarProveedor);
            this.Controls.Add(this.btnAgregarProveedor);
            this.Controls.Add(this.dgvProveedores);
            this.Controls.Add(this.txtBuscarProveedor);
            this.Controls.Add(this.txtDireccionProveedor);
            this.Controls.Add(this.txtEmailProveedor);
            this.Controls.Add(this.txtTelefonoProveedor);
            this.Controls.Add(this.txtNombreProveedor);
            this.Controls.Add(this.lblIdProveedor);
            this.Controls.Add(this.lblTextoIdProveedor);
            this.Controls.Add(this.lblDireccionProveedor);
            this.Controls.Add(this.lblEmailProveedor);
            this.Controls.Add(this.lblTelefonoProveedor);
            this.Controls.Add(this.lblNombreProveedor);
            this.Controls.Add(this.lblTituloProveedor);
            this.Name = "FormProveedor";
            this.Text = "FormProveedor";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloProveedor;
        private System.Windows.Forms.Label lblNombreProveedor;
        private System.Windows.Forms.Label lblTelefonoProveedor;
        private System.Windows.Forms.Label lblEmailProveedor;
        private System.Windows.Forms.Label lblDireccionProveedor;
        private System.Windows.Forms.Label lblTextoIdProveedor;
        private System.Windows.Forms.Label lblIdProveedor;
        private System.Windows.Forms.TextBox txtNombreProveedor;
        private System.Windows.Forms.TextBox txtTelefonoProveedor;
        private System.Windows.Forms.TextBox txtEmailProveedor;
        private System.Windows.Forms.TextBox txtDireccionProveedor;
        private System.Windows.Forms.TextBox txtBuscarProveedor;
        private System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.Button btnAgregarProveedor;
        private System.Windows.Forms.Button btnModificarProveedor;
        private System.Windows.Forms.Button btnEliminarProveedor;
        private System.Windows.Forms.Button btnBuscarProveedor;
        private System.Windows.Forms.Button btnMostrarTodosProveedores;
    }
}
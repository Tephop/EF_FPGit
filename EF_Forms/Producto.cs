namespace EF_Forms
{
    public class Producto
    {
        public string ID_Producto { get; set; }
        public string ID_Proveedor { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Stock { get; set; }
        public string Estado
        {
            get
            {
                if (Stock == 0)
                    return "Agotado";
                else if (Stock <= 5)
                    return "Stock Bajo";
                else
                    return "Disponible";
            }
        }
    }
}

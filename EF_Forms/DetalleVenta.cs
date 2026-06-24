namespace EF_Forms
{
    public class DetalleVenta
    {
        public string ID_Venta { get; set; }
        public string ID_Producto { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}

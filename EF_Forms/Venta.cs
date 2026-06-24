using System;

namespace EF_Forms
{
    public class Venta
    {
        public string ID_Venta { get; set; }
        public DateTime Fecha { get; set; }
        public string MetodoPago { get; set; }
        public decimal Total { get; set; }
    }
}

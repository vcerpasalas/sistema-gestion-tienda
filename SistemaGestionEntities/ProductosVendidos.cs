﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
    public class ProductosVendidos
    {
        public int id { get; set; }
        public int idProducto { get; set; }
        public string descripcion { get; set; }
        public double costo { get; set; }
        public double precioVenta { get; set; }
        public int stock { get; set; }
        public int idUsuario { get; set; }
        public int idVenta { get; set; }
    }
}

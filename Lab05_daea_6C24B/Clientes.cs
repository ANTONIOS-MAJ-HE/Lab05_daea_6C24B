﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05_daea_6C24B
{
    public class Clientes
    {
        public int idCliente { get; set; }
        public String NombreCompañia { get; set; }
        public String NombreContacto { get; set; }
        public String CargoContacto { get; set; }
        public DateTime Direccion { get; set; }
        public DateTime Ciudad { get; set; }


        public Clientes(int idCliente, string nombreCompañia, string nombreContacto, string cargoContacto, DateTime direccion, DateTime ciudad)
        {
            this.idCliente = idCliente;
            NombreCompañia = nombreCompañia;
            NombreContacto = nombreContacto;
            CargoContacto = cargoContacto;
            Direccion = direccion;
            Ciudad = ciudad;
          
        }

    }
}

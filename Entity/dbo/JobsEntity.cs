﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class JobsEntity: EN
    {
        public int? Id_Puesto { get; set; }
        public string Nombre { get; set; }
        public int Salario { get; set; }
    }
}

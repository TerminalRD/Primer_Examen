﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class JobsEntity: EN
    {
        public int? Id_puesto { get; set; }
        public string Name { get; set; }
        public int Salario { get; set; }
    }
}
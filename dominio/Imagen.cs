﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Imagen
    {
        public int IdImagen { get; set; }
        public int IdArticulo { get; set; }
        public string ImagenURL { get; set; }
        public override string ToString()
        {
            return ImagenURL;
        }
    }
}

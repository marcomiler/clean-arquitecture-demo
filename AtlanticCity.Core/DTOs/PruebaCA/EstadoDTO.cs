using System;
using System.Collections.Generic;
using System.Text;

namespace AtlanticCity.Core.DTOs.PruebaCA
{
    public abstract class EstadoDTO
    {
        public string Descripcion { get; set; }
        public string Empresa { get; set; }
    }

    public class EstadoInserDTO: EstadoDTO
    {
    }

    public class EstadoUpdateDTO: EstadoDTO
    {
        public string Id { get; set; }
    }
}

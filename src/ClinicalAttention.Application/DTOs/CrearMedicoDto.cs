using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalAttention.Application.DTOs
{
    public class CrearMedicoDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalAttention.Application.DTOs
{
    public class ActualizarPacienteDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public int Edad { get; set; }
    }
}
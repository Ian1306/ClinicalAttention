using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalAttention.Application.DTOs
{
    public class CrearSolicitudDto
    {
        public Guid PacienteId { get; set; }
        public string Especialidad { get; set; } = string.Empty;
        public string Motivo { get; set; } = string.Empty;
        public string Prioridad { get; set; } = string.Empty;
    }
}
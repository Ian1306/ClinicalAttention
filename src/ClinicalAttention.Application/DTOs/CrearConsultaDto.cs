using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalAttention.Application.DTOs
{
    public class CrearConsultaDto
    {
        public Guid SolicitudId { get; set; }
        public Guid MedicoId { get; set; }
        public string Diagnostico { get; set; } = string.Empty;
        public string Tratamiento { get; set; } = string.Empty;
    }
}
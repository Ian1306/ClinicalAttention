using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalAttention.Application.DTOs
{
    public class CambiarEstadoDto
    {
        public required string Estado { get; set; }
        public string? Observacion { get; set; }
    }
}
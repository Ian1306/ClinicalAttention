using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalAttention.Application.DTOs
{
    public class SolicitudResponseDto
    {
        public Guid Id { get; set; }
        public required  string Especialidad { get; set; }
        public required string Estado { get; set; }
    }
}
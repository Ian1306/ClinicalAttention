using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Domain.Common;

namespace ClinicalAttention.Domain.Entities
{
    public class Consulta : BaseEntity
    {
        public Guid SolicitudId { get; private set; }
        public Guid MedicoId { get; private set; }
        public string Diagnostico { get; private set; }
        public string Tratamiento { get; private set; }
        public DateTime Fecha { get; private set; }

        public Consulta(Guid solicitudId, Guid medicoId, string diagnostico, string tratamiento)
        {
            if (solicitudId == Guid.Empty)
                throw new Exception("Solicitud requerida");

            if (medicoId == Guid.Empty)
                throw new Exception("Médico requerido");

            if (string.IsNullOrWhiteSpace(diagnostico))
                throw new Exception("Diagnóstico requerido");

            SolicitudId = solicitudId;
            MedicoId = medicoId;
            Diagnostico = diagnostico;
            Tratamiento = tratamiento;
            Fecha = DateTime.UtcNow;
        }
    }
}
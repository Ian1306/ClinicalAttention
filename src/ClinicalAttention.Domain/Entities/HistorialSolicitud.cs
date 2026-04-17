using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Domain.Common;

namespace ClinicalAttention.Domain.Entities
{
    public class HistorialSolicitud : BaseEntity
    {
        public Guid SolicitudId { get; private set; }
        public string EstadoAnterior { get; private set; }
        public string EstadoNuevo { get; private set; }
        public DateTime Fecha { get; private set; }
        public string? Observacion { get; private set; }

        public HistorialSolicitud(Guid solicitudId, string estadoAnterior, string estadoNuevo, string? observacion)
        {
            SolicitudId = solicitudId;
            EstadoAnterior = estadoAnterior;
            EstadoNuevo = estadoNuevo;
            Observacion = observacion;
            Fecha = DateTime.UtcNow;
        }
    }
}
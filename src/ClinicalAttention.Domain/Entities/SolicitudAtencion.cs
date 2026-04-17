using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Domain.Common;

namespace ClinicalAttention.Domain.Entities
{
    public class SolicitudAtencion : BaseEntity
    {
        public Guid PacienteId { get; private set; }
        public string Especialidad { get; private set; }
        public string Motivo { get; private set; }
        public string Prioridad { get; private set; }
        public EstadoSolicitud Estado { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public Guid? MedicoAsignadoId { get; private set; }

        public SolicitudAtencion(Guid pacienteId, string especialidad, string motivo, string prioridad)
        {
            if (string.IsNullOrWhiteSpace(especialidad)) throw new Exception("Especialidad requerida");
            if (motivo.Length < 10) throw new Exception("Motivo muy corto");

            PacienteId = pacienteId;
            Especialidad = especialidad;
            Motivo = motivo;
            Prioridad = prioridad;
            Estado = EstadoSolicitud.CREADA;
            FechaCreacion = DateTime.UtcNow;
        }

        public void AsignarMedico(Guid medicoId)
        {
            if (Estado == EstadoSolicitud.RECHAZADA || Estado == EstadoSolicitud.CERRADA)
                throw new Exception("No se puede asignar");

            MedicoAsignadoId = medicoId;
            Estado = EstadoSolicitud.ASIGNADA;
        }

        public void CambiarEstado(string nuevoEstado)
        {
            Estado = Enum.Parse<EstadoSolicitud>(nuevoEstado);
        }
    }
}
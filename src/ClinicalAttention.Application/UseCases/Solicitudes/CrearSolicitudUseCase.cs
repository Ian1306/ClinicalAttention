using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Application.Abstractions;
using ClinicalAttention.Domain.Entities;

namespace ClinicalAttention.Application.UseCases.Solicitudes
{
    public class CrearSolicitudUseCase
    {
        private readonly ISolicitudRepository _repo;

        public CrearSolicitudUseCase(ISolicitudRepository repo)
        {
            _repo = repo;
        }

        public async Task<SolicitudAtencion> Ejecutar(Guid pacienteId, string especialidad, string motivo, string prioridad)
        {
            var solicitud = new SolicitudAtencion(pacienteId, especialidad, motivo, prioridad);

            await _repo.AddAsync(solicitud);

            return solicitud;
        }
    }
}
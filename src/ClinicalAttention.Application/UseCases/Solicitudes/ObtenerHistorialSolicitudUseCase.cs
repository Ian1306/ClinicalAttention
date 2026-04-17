using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Application.Abstractions;
using ClinicalAttention.Domain.Entities;

namespace ClinicalAttention.Application.UseCases.Solicitudes
{
    public class ObtenerHistorialSolicitudUseCase
    {
        private readonly IHistorialRepository _repo;

        public ObtenerHistorialSolicitudUseCase(IHistorialRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<HistorialSolicitud>> Ejecutar(Guid solicitudId)
        {
            return await _repo.GetBySolicitudIdAsync(solicitudId);
        }
    }
}
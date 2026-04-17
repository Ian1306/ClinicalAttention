using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Application.Abstractions;
using ClinicalAttention.Domain.Entities;

namespace ClinicalAttention.Application.UseCases.Solicitudes
{
    public class ObtenerSolicitudesUseCase
    {
        private readonly ISolicitudRepository _repo;

        public ObtenerSolicitudesUseCase(ISolicitudRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<SolicitudAtencion>> Ejecutar()
        {
            return await _repo.GetAllAsync();
        }
    }
}
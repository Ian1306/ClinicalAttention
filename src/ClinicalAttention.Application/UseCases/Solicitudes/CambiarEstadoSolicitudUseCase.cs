using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Application.Abstractions;
using ClinicalAttention.Domain.Entities;

namespace ClinicalAttention.Application.UseCases.Solicitudes
{
    public class CambiarEstadoSolicitudUseCase
    {
        private readonly ISolicitudRepository _solicitudRepo;
        private readonly IHistorialRepository _historialRepo;

        public CambiarEstadoSolicitudUseCase(ISolicitudRepository solicitudRepo, IHistorialRepository historialRepo)
        {
            _solicitudRepo = solicitudRepo;
            _historialRepo = historialRepo;
        }

        public async Task Ejecutar(Guid id, string nuevoEstado, string? observacion)
        {
            var solicitud = await _solicitudRepo.GetByIdAsync(id);

            if (solicitud == null)
                throw new Exception("Solicitud no encontrada");

            var estadoAnterior = solicitud.Estado.ToString();

            solicitud.CambiarEstado(nuevoEstado);

            await _solicitudRepo.UpdateAsync(solicitud);

            var historial = new HistorialSolicitud(id, estadoAnterior, nuevoEstado, observacion);
            await _historialRepo.AddAsync(historial);
        }
    }
}
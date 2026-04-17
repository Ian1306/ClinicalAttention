using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Application.Abstractions;

namespace ClinicalAttention.Application.UseCases.Solicitudes
{
    public class AsignarMedicoUseCase
    {
        private readonly ISolicitudRepository _solicitudRepo;
        private readonly IMedicoRepository _medicoRepo;

        public AsignarMedicoUseCase(ISolicitudRepository solicitudRepo, IMedicoRepository medicoRepo)
        {
            _solicitudRepo = solicitudRepo;
            _medicoRepo = medicoRepo;
        }

        public async Task Ejecutar(Guid solicitudId)
        {
            var solicitud = await _solicitudRepo.GetByIdAsync(solicitudId);
            if (solicitud == null)
                throw new Exception("Solicitud no encontrada");

            var medico = await _medicoRepo.GetDisponiblePorEspecialidadAsync(solicitud.Especialidad);
            if (medico == null)
                throw new Exception("No hay médicos disponibles");

            solicitud.AsignarMedico(medico.Id);

            await _solicitudRepo.UpdateAsync(solicitud);

            medico.MarcarComoNoDisponible();
            await _medicoRepo.UpdateAsync(medico);
        }
    }
}
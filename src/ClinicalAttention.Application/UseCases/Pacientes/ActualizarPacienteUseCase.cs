using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Application.Abstractions;
using ClinicalAttention.Domain.Entities;

namespace ClinicalAttention.Application.UseCases.Pacientes
{
    public class ActualizarPacienteUseCase
    {
        private readonly IPacienteRepository _repo;

        public ActualizarPacienteUseCase(IPacienteRepository repo)
        {
            _repo = repo;
        }

        public async Task<Paciente?> Ejecutar(Guid id, string nombre, string documento, int edad)
        {
            var paciente = await _repo.GetByIdAsync(id);

            if (paciente == null)
                return null;

            paciente.Actualizar(nombre, documento, edad);

            await _repo.UpdateAsync(paciente);

            return paciente;
        }
    }
}
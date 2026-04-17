using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Application.Abstractions;
using ClinicalAttention.Domain.Entities;

namespace ClinicalAttention.Application.UseCases.Pacientes
{
    public class ObtenerPacientesUseCase
    {
        private readonly IPacienteRepository _repo;

        public ObtenerPacientesUseCase(IPacienteRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Paciente>> Ejecutar()
        {
            return await _repo.GetAllAsync();
        }
    }
}
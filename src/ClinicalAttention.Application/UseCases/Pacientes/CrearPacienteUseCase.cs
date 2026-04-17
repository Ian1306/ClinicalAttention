using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Application.Abstractions;
using ClinicalAttention.Domain.Entities;

namespace ClinicalAttention.Application.UseCases.Pacientes
{
    public class CrearPacienteUseCase
    {
        private readonly IPacienteRepository _repo;

        public CrearPacienteUseCase(IPacienteRepository repo)
        {
            _repo = repo;
        }

        public async Task<Paciente> Ejecutar(string nombre, string documento, int edad)
        {
            var paciente = new Paciente(nombre, documento, edad);

            await _repo.AddAsync(paciente);

            return paciente;
        }
    }
}
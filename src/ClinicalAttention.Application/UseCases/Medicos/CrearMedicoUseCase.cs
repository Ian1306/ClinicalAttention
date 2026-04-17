using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Application.Abstractions;
using ClinicalAttention.Domain.Entities;

namespace ClinicalAttention.Application.UseCases.Medicos
{
    public class CrearMedicoUseCase
    {
        private readonly IMedicoRepository _repo;

        public CrearMedicoUseCase(IMedicoRepository repo)
        {
            _repo = repo;
        }

        public async Task<Medico> Ejecutar(string nombre, string especialidad)
        {
            var medico = new Medico(nombre, especialidad);

            await _repo.AddAsync(medico);

            return medico;
        }
    }
}
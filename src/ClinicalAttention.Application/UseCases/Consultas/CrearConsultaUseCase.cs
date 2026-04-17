using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Application.Abstractions;
using ClinicalAttention.Domain.Entities;

namespace ClinicalAttention.Application.UseCases.Consultas
{
    public class CrearConsultaUseCase
    {
        private readonly IConsultaRepository _repo;

        public CrearConsultaUseCase(IConsultaRepository repo)
        {
            _repo = repo;
        }

        public async Task<Consulta> Ejecutar(Guid solicitudId, Guid medicoId, string diagnostico, string tratamiento)
        {
            var consulta = new Consulta(
                solicitudId,
                medicoId,
                diagnostico,
                tratamiento
            );

            await _repo.AddAsync(consulta);

            return consulta;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Application.Abstractions;
using ClinicalAttention.Domain.Entities;

namespace ClinicalAttention.Application.UseCases.Consultas
{
    public class ObtenerConsultasUseCase
    {
        private readonly IConsultaRepository _repo;

        public ObtenerConsultasUseCase(IConsultaRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Consulta>> Ejecutar()
        {
            return await _repo.GetAllAsync();
        }
    }
}
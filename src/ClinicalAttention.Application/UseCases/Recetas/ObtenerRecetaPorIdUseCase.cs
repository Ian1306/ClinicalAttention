using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Application.Abstractions;
using ClinicalAttention.Domain.Entities;

namespace ClinicalAttention.Application.UseCases.Recetas
{
    public class ObtenerRecetaPorIdUseCase
    {
        private readonly IRecetaRepository _repo;

        public ObtenerRecetaPorIdUseCase(IRecetaRepository repo)
        {
            _repo = repo;
        }

        public async Task<Receta?> Ejecutar(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }
    }
}
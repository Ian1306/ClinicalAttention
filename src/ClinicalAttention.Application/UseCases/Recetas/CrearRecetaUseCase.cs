using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Application.Abstractions;
using ClinicalAttention.Domain.Entities;

namespace ClinicalAttention.Application.UseCases.Recetas
{
    public class CrearRecetaUseCase
    {
        private readonly IRecetaRepository _repo;

        public CrearRecetaUseCase(IRecetaRepository repo)
        {
            _repo = repo;
        }

        public async Task<Receta> Ejecutar(Guid consultaId)
        {
            var receta = new Receta(consultaId);

            await _repo.AddAsync(receta);

            return receta;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Application.Abstractions;

namespace ClinicalAttention.Application.UseCases.Common
{
    public class TestDbUseCase
    {
            private readonly ISolicitudRepository _repo;

        public TestDbUseCase(ISolicitudRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Ejecutar()
        {
            // Solo valida conexión a DB
            await _repo.GetByIdAsync(Guid.NewGuid());
            return true;
        }
    }
}
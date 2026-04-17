using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Application.Abstractions;
using ClinicalAttention.Domain.Entities;


namespace ClinicalAttention.Application.UseCases.Medicos
{
    public class ObtenerMedicosDisponiblesUseCase
    {
        private readonly IMedicoRepository _repo;

        public ObtenerMedicosDisponiblesUseCase(IMedicoRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Medico>> Ejecutar()
        {
            return await _repo.GetDisponiblesAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Domain.Entities;

namespace ClinicalAttention.Application.Abstractions
{
    public interface IMedicoRepository
    {
            Task<Medico?> GetDisponiblePorEspecialidadAsync(string especialidad);
            Task UpdateAsync(Medico medico);
            Task<List<Medico>> GetAllAsync();
            Task AddAsync(Medico medico);
            Task<List<Medico>> GetDisponiblesAsync();
    }
}
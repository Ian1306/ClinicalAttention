using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Domain.Entities;

namespace ClinicalAttention.Application.Abstractions
{
    public interface IPacienteRepository
    {
        Task<List<Paciente>> GetAllAsync();
        Task<Paciente?> GetByIdAsync(Guid id);
        Task AddAsync(Paciente paciente);
        Task UpdateAsync(Paciente paciente);
    }
}
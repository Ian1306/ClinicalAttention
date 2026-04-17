using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Domain.Entities;

namespace ClinicalAttention.Application.Abstractions
{
    public interface IRecetaRepository
    {
        Task AddAsync(Receta receta);
        Task<Receta?> GetByIdAsync(Guid id);
    }
}
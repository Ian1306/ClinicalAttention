using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Domain.Entities;

namespace ClinicalAttention.Application.Abstractions
{
    public interface IConsultaRepository
    {
        Task AddAsync(Consulta consulta);
        Task<List<Consulta>> GetAllAsync();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Domain.Entities;

namespace ClinicalAttention.Application.Abstractions
{
    public interface ISolicitudRepository
    {
        Task AddAsync(SolicitudAtencion solicitud);
        Task<SolicitudAtencion?> GetByIdAsync(Guid id);

        Task UpdateAsync(SolicitudAtencion solicitud);

        Task<List<SolicitudAtencion>> GetAllAsync();
    }
}
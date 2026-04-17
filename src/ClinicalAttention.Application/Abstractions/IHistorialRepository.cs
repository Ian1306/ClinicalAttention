using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Domain.Entities;

namespace ClinicalAttention.Application.Abstractions
{
    public interface IHistorialRepository
    {
        Task AddAsync(HistorialSolicitud historial);
        Task<List<HistorialSolicitud>> GetBySolicitudIdAsync(Guid solicitudId);
    }
}
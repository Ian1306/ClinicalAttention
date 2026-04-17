using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Application.Abstractions;
using ClinicalAttention.Domain.Entities;
using ClinicalAttention.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ClinicalAttention.Infrastructure.Persistence.Repositories
{
    public class HistorialRepository : IHistorialRepository
    {
        private readonly AppDbContext _context;

        public HistorialRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(HistorialSolicitud historial)
        {
            await _context.Set<HistorialSolicitud>().AddAsync(historial);
            await _context.SaveChangesAsync();
        }

        public async Task<List<HistorialSolicitud>> GetBySolicitudIdAsync(Guid solicitudId)
        {
            return await _context.Set<HistorialSolicitud>()
                .Where(x => x.SolicitudId == solicitudId)
                .ToListAsync();
        }
    }
}
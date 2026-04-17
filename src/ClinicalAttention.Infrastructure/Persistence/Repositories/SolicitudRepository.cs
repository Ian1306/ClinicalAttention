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
    public class SolicitudRepository : ISolicitudRepository
    {
        private readonly AppDbContext _context;

        public SolicitudRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(SolicitudAtencion solicitud)
        {
            await _context.Solicitudes.AddAsync(solicitud);
            await _context.SaveChangesAsync();
        }

        public async Task<SolicitudAtencion?> GetByIdAsync(Guid id)
        {
            return await _context.Solicitudes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(SolicitudAtencion solicitud)
        {
            _context.Solicitudes.Update(solicitud);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SolicitudAtencion>> GetAllAsync()
        {
            return await _context.Solicitudes.ToListAsync();
        }

    }
}
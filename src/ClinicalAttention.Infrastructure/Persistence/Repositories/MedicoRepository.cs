using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Domain.Entities;
using ClinicalAttention.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using ClinicalAttention.Application.Abstractions;

namespace ClinicalAttention.Infrastructure.Persistence.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly AppDbContext _context;

        public MedicoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Medico?> GetDisponiblePorEspecialidadAsync(string especialidad)
        {
            return await _context.Medicos
                .FirstOrDefaultAsync(x => x.Especialidad == especialidad && x.Disponible);
        }

        public async Task UpdateAsync(Medico medico)
        {
            _context.Medicos.Update(medico);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Medico>> GetAllAsync()
        {
            return await _context.Medicos.ToListAsync();
        }

        public async Task AddAsync(Medico medico)
        {
            await _context.Medicos.AddAsync(medico);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Medico>> GetDisponiblesAsync()
        {
            return await _context.Medicos
                .Where(x => x.Disponible)
                .ToListAsync();
        }
    }
}
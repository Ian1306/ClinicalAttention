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
    public class PacienteRepository : IPacienteRepository
    {
        private readonly AppDbContext _context;

        public PacienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Paciente>> GetAllAsync()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task<Paciente?> GetByIdAsync(Guid id)
        {
            return await _context.Pacientes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Paciente paciente)
        {
            await _context.Pacientes.AddAsync(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            await _context.SaveChangesAsync();
        }
    }
}
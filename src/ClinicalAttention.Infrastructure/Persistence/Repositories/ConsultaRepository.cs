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
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly AppDbContext _context;

        public ConsultaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Consulta consulta)
        {
            await _context.Consultas.AddAsync(consulta);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Consulta>> GetAllAsync()
        {
            return await _context.Consultas.ToListAsync();
        }
    }
}
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
    public class RecetaRepository : IRecetaRepository
    {
        private readonly AppDbContext _context;

        public RecetaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Receta receta)
        {
            await _context.Recetas.AddAsync(receta);
            await _context.SaveChangesAsync();
        }

        public async Task<Receta?> GetByIdAsync(Guid id)
        {
            return await _context.Recetas
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
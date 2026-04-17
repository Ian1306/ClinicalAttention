using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalAttention.Application.Abstractions;
using ClinicalAttention.Infrastructure.Persistence.Context;
using ClinicalAttention.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicalAttention.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var provider = configuration["Database:Provider"];

        services.AddDbContext<AppDbContext>(options =>
        {
            if (provider == "SqlServer")
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            else
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<ISolicitudRepository, SolicitudRepository>();

        services.AddScoped<IMedicoRepository, MedicoRepository>();

        services.AddScoped<IPacienteRepository, PacienteRepository>();

        services.AddScoped<IRecetaRepository, RecetaRepository>();
        
        services.AddScoped<IConsultaRepository, ConsultaRepository>();

        services.AddScoped<IHistorialRepository, HistorialRepository>();


        return services;
    }
}